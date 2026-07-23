using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using SseStreamInitializer;

namespace Helper_2;

internal abstract class Helper_2 : INotifyPropertyChanged
{
	[CompilerGenerated]
	private PropertyChangedEventHandler m_PropertyChanged;

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.m_PropertyChanged;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.m_PropertyChanged;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref this.m_PropertyChanged, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	protected bool MrCsWWMvwp<peP3OHs0MxE09EASVHh>(ref peP3OHs0MxE09EASVHh P_0, peP3OHs0MxE09EASVHh HJKZHkskGawWJ3YGAge, [CallerMemberName] string propertyName = null)
	{
		if (EqualityComparer<peP3OHs0MxE09EASVHh>.Default.Equals(P_0, HJKZHkskGawWJ3YGAge))
		{
			return false;
		}
		P_0 = HJKZHkskGawWJ3YGAge;
		fpVsxno8nm(propertyName);
		return true;
	}

	protected void fpVsxno8nm([CallerMemberName] string propertyName = null)
	{
		this.m_PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected Helper_2()
	{
		SseStreamInitializer.InitializeRuntime();
	}
}
