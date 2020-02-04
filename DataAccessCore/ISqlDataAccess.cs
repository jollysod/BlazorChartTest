using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessCore
{
	public interface ISqlDataAccess
	{
		string ConnectionStringName { get; set; }

		//Task<IEnumerable<T>> LoadChart<T, U>(string sql, U parameters);
		Task<List<T>> LoadData<T, U>(string sql, U parameters);
		Task SaveData<T>(string sql, T parameters);
		Task<IEnumerable<T>> LoadChart<T, U>(string sql, U parameters);
	}
}