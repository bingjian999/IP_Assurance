using System.Threading.Tasks;
using CPAHelper.Agent.Contracts;

namespace CPAHelper.Agent.DesktopShell;

internal interface ISkillMarketClient
{
	Task<SkillMarketResponse> ListAsync(SkillMarketQuery query);
}
