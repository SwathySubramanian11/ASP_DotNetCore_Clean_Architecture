﻿using HR.LeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity //public interface that accepts type parameter T were T is a type of BaseEntity 
    {
        Task<IReadOnlyList<T>> GetAsync();
        Task<T>GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
