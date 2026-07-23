using System;
using System.Threading;
using System.Threading.Tasks;

namespace CPAHelper.Agent.DesktopShell;

internal sealed class DesktopTurnCancellationManager : IDisposable
{
	internal sealed class DesktopTurnCancellationLease : IDisposable
	{
		private readonly DesktopTurnCancellationManager _owner;

		private readonly CancellationTokenSource _cts;

		private int _disposed;

		public CancellationToken Token => _cts.Token;

		public DesktopTurnCancellationLease(DesktopTurnCancellationManager owner, CancellationTokenSource cts)
		{
			_owner = owner ?? throw new ArgumentNullException("owner");
			_cts = cts ?? throw new ArgumentNullException("cts");
		}

		public void Dispose()
		{
			if (Interlocked.Exchange(ref _disposed, 1) == 0)
			{
				_owner.CompleteTurn(_cts);
			}
		}
	}

	private readonly SemaphoreSlim _turnGate = new SemaphoreSlim(1, 1);

	private readonly object _syncRoot = new object();

	private CancellationTokenSource _currentCts;

	private bool _disposed;

	public async Task<DesktopTurnCancellationLease> BeginTurnAsync()
	{
		CancelCurrentTurn();
		await _turnGate.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
		CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
		bool flag = false;
		try
		{
			lock (_syncRoot)
			{
				ThrowIfDisposed();
				CancellationTokenSource currentCts = _currentCts;
				_currentCts = cancellationTokenSource;
				if (currentCts != null && currentCts != cancellationTokenSource)
				{
					currentCts.Dispose();
				}
			}
			flag = true;
			return new DesktopTurnCancellationLease(this, cancellationTokenSource);
		}
		finally
		{
			if (!flag)
			{
				cancellationTokenSource.Dispose();
				_turnGate.Release();
			}
		}
	}

	public void CancelCurrentTurn()
	{
		lock (_syncRoot)
		{
			try
			{
				_currentCts?.Cancel();
			}
			catch (ObjectDisposedException)
			{
			}
		}
	}

	public void Dispose()
	{
		CancellationTokenSource currentCts;
		lock (_syncRoot)
		{
			if (_disposed)
			{
				return;
			}
			_disposed = true;
			currentCts = _currentCts;
			_currentCts = null;
		}
		try
		{
			currentCts?.Cancel();
		}
		catch (ObjectDisposedException)
		{
		}
	}

	private void CompleteTurn(CancellationTokenSource cts)
	{
		lock (_syncRoot)
		{
			if (_currentCts == cts)
			{
				_currentCts = null;
			}
		}
		cts.Dispose();
		_turnGate.Release();
	}

	private void ThrowIfDisposed()
	{
		if (_disposed)
		{
			throw new ObjectDisposedException("DesktopTurnCancellationManager");
		}
	}
}
