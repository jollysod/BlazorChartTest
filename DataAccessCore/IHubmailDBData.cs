using DataAccessCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessCore
{
	public interface IHubmailDBData
	{
		Task<List<PageSumQueryModel>> PageSumQuery();
		Task<IEnumerable<PageSumChartQueryModel>> PageSumChartQuery();
	}
}