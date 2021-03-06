﻿using Innovt.Domain.Core.Repository;


namespace Innovt.Data.EFCore.Repositories
{
    public class GenericRepository<T> : RepositoryBase<T> where T : class 
    {
        public GenericRepository(IExtendedUnitOfWork context) : base(context)
        {
        }
    }
}