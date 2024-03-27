﻿using Kemet.ERP.Contracts.HR;
using Kemet.ERP.Contracts.HttpResponse;

namespace Kemet.ERP.Abstraction.IEntity.HR
{
    public interface IAccountService
    {
        Task<ApiResponse> GetUsersAsync(int skip, int take, CancellationToken cancellationToken = default);
        Task<ApiResponse> GetUserByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<ApiResponse> CreateUserAsync(CreateUserDto request, CancellationToken cancellationToken = default);
    }
}
