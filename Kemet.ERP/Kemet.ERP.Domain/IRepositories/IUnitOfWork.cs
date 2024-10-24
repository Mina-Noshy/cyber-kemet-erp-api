﻿namespace Kemet.ERP.Domain.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository();
        IDapperRepository Dapper();

        Task<int> CommitAsync(CancellationToken cancellationToken);

        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}

