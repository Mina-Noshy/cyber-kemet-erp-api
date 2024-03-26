using Dapper;
using Kemet.ERP.Domain.IRepositories.IShared;
using Kemet.ERP.Persistence.Contexts;
using System.Data;

namespace Kemet.ERP.Persistence.Repositories.Shared
{
    public class DapperRepository : IDapperRepository, IDisposable
    {
        private readonly RepositoryDbContext _db;
        private IDbTransaction? _transaction;

        public DapperRepository(RepositoryDbContext db)
        {
            _db = db;
        }

        public async Task<T?> FirstOrDefaultAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null) where T : class
        {
            sql = SecureAgainstHarmfulCommands(sql, param);

            return await _db.Connection.QueryFirstOrDefaultAsync<T>(sql, param, _transaction, commandTimeout, commandType);
        }

        public async Task<List<T>?> ListAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null) where T : class
        {
            sql = SecureAgainstHarmfulCommands(sql, param);

            return (await _db.Connection.QueryAsync<T>(sql, param, _transaction, commandTimeout, commandType)).ToList();
        }

        public async Task<DataTable> TableAsync(string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            sql = SecureAgainstHarmfulCommands(sql, param);

            DataTable tbl = new DataTable();
            var reader = await _db.Connection.ExecuteReaderAsync(sql, param, _transaction, commandTimeout, commandType);
            tbl.Load(reader);
            return tbl;
        }

        public async Task<int> ExecuteAsync(string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            sql = SecureAgainstHarmfulCommands(sql, param);

            return await _db.Connection.ExecuteAsync(sql, param, _transaction, commandTimeout, commandType);
        }

        public void BeginTransaction()
        {
            if (_transaction is null)
            {
                _transaction = _db.Connection.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }

        void IDisposable.Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();

            GC.SuppressFinalize(_db);
            GC.SuppressFinalize(this);
        }


        private static readonly string[] HARMFUL_COMMANDS =
        {
            "DROP DATABASE",
            "DROP TABLE",
            "ALTER TABLE",
            "TRUNCATE TABLE"
        };

        private static string SecureAgainstHarmfulCommands(string sql, object? param)
        {
            if (param != null) return sql;

            sql = sql.Trim().Replace("'", "''");

            foreach (string command in HARMFUL_COMMANDS)
            {
                if (sql.Contains(command, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException($"Detected potentially harmful SQL command: '{command}'");
                }
            }

            return "EXEC SP_SQLEXEC ' " + sql + " '; ";
        }
    }
}
