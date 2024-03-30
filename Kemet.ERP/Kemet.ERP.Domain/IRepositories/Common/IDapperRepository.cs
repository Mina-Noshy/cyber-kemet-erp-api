using System.Data;

namespace Kemet.ERP.Domain.IRepositories.Common
{
    public interface IDapperRepository
    {
        Task<T?> FirstOrDefaultAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null) where T : class;
        Task<List<T>?> ListAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null) where T : class;
        Task<DataTable> TableAsync(string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<int> ExecuteAsync(string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null);

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
