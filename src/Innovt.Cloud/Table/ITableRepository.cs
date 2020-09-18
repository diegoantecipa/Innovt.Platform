﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Innovt.Cloud.Table
{
    public interface ITableRepository
    {
        Task<T> GetByIdAsync<T>(object id, string rangeKey=null, CancellationToken cancellationToken = default) where T : ITableMessage;

        Task DeleteAsync<T>(T value, CancellationToken cancellationToken = default) where T : ITableMessage;

        Task DeleteAsync<T>(object id, string rangeKey=null, CancellationToken cancellationToken = default) where T : ITableMessage;

        Task AddAsync<T>(T message, CancellationToken cancellationToken = default) where T : ITableMessage;

        Task AddAsync<T>(IList<T> message, CancellationToken cancellationToken = default) where T : ITableMessage;

        Task<T> QueryFirstAsync<T>(object id, CancellationToken cancellationToken = default) where T : ITableMessage;
        
        Task<IList<T>> QueryAsync<T>(object id, CancellationToken cancellationToken = default) where T : ITableMessage;
 
        Task<PagedResult<T>> ScanPaginatedByAsync<T>(Innovt.Cloud.Table.ScanRequest request, CancellationToken cancellationToken = default) where T : ITableMessage;
        Task<PagedResult<T>> QueryPaginatedByAsync<T>(Innovt.Cloud.Table.QueryRequest request, CancellationToken cancellationToken = default) where T : ITableMessage;
   
    }
}