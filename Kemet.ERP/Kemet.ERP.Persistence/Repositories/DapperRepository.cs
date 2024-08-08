using Dapper;
using Kemet.ERP.Domain.IRepositories;
using Kemet.ERP.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Kemet.ERP.Persistence.Repositories
{
    public class DapperRepository : IDapperRepository, IDisposable
    {
        private readonly IMainDbContext _db;
        private IDbTransaction? _transaction;

        public DapperRepository(IMainDbContext db)
        {
            _db = db;
        }

        public async Task<T?> FirstOrDefaultAsync<T>(string sql, object? param = null, CommandType? commandType = null, int? commandTimeout = null) where T : class
        {
            sql = SecureAgainstHarmfulCommands(sql, param);

            return await _db.Database.GetDbConnection().QueryFirstOrDefaultAsync<T>(sql, param, _transaction, commandTimeout, commandType);
        }

        public async Task<List<T>?> ListAsync<T>(string sql, object? param = null, CommandType? commandType = null, int? commandTimeout = null) where T : class
        {
            sql = SecureAgainstHarmfulCommands(sql, param);

            return (await _db.Database.GetDbConnection().QueryAsync<T>(sql, param, _transaction, commandTimeout, commandType)).ToList();
        }

        public async Task<DataTable> TableAsync(string sql, object? param = null, CommandType? commandType = null, int? commandTimeout = null)
        {
            sql = SecureAgainstHarmfulCommands(sql, param);

            DataTable tbl = new DataTable();
            var reader = await _db.Database.GetDbConnection().ExecuteReaderAsync(sql, param, _transaction, commandTimeout, commandType);
            tbl.Load(reader);
            return tbl;
        }

        public async Task<int> ExecuteAsync(string sql, object? param = null, CommandType? commandType = null, int? commandTimeout = null)
        {
            sql = SecureAgainstHarmfulCommands(sql, param);

            return await _db.Database.GetDbConnection().ExecuteAsync(sql, param, _transaction, commandTimeout, commandType);
        }

        public void BeginTransaction()
        {
            _transaction = _db.Database.GetDbConnection().BeginTransaction();
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
