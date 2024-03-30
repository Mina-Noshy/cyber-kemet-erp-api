﻿using Kemet.ERP.Shared.Constants;

namespace Kemet.ERP.Abstraction.Common
{
    public interface IMemoryCacheService
    {
        T? Get<T>(CacheServiceKeys key);
        void Set<T>(CacheServiceKeys key, T value, TimeSpan expiration);
        void Remove(CacheServiceKeys key);
    }
}