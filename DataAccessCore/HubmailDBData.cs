using DataAccessCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessCore
{
	public class HubmailDBData : IHubmailDBData
	{
		private readonly ISqlDataAccess _db;

		public HubmailDBData(ISqlDataAccess db)
		{
			_db = db;
		}
		public Task<List<PageSumQueryModel>> PageSumQuery()
		{
			string sql = "SELECT GRP_ID,SUM(CASE WHEN DATA_12 = @COLOUR THEN CAST(DOC_NB_PAGES AS INT)ELSE 0 END)as Colour_Totals,SUM(CASE WHEN DATA_12 = @MONO THEN CAST(DOC_NB_PAGES AS INT)ELSE 0 END)as Mono_Totals from dbo.ChartTestData GROUP BY GRP_ID;";
			return _db.LoadData<PageSumQueryModel, dynamic>(sql, new { COLOUR = "COLOUR", MONO = "MONO"});

		}
		//START Chart Test
		public Task<IEnumerable<PageSumChartQueryModel>> PageSumChartQuery()
		{
			string sql = "SELECT GRP_ID,SUM(CASE WHEN DATA_12 = @COLOUR THEN CAST(DOC_NB_PAGES AS INT)ELSE 0 END)as Colour_Totals,SUM(CASE WHEN DATA_12 = @MONO THEN CAST(DOC_NB_PAGES AS INT)ELSE 0 END)as Mono_Totals from dbo.ChartTestData GROUP BY GRP_ID;";
			return _db.LoadChart<PageSumChartQueryModel, dynamic>(sql, new { COLOUR = "COLOUR", MONO = "MONO"});
		}
		// END Chart Test
	}
}