using System.Data;

namespace Kemet.ERP.Domain.IRepositories
{
    public interface IDapperRepository
    {
        Task<T?> FirstOrDefaultAsync<T>(string sql, object? param = null, CommandType? commandType = null, int? commandTimeout = null) where T : class;
        Task<List<T>?> ListAsync<T>(string sql, object? param = null, CommandType? commandType = null, int? commandTimeout = null) where T : class;
        Task<DataTable> TableAsync(string sql, object? param = null, CommandType? commandType = null, int? commandTimeout = null);
        Task<int> ExecuteAsync(string sql, object? param = null, CommandType? commandType = null, int? commandTimeout = null);

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
