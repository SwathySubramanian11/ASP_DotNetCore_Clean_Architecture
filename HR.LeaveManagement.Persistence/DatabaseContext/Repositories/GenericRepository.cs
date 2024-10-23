using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    { 
        protected readonly HrDatabaseContext _context;
        public GenericRepository(HrDatabaseContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();   //As we dont know what datatype or tabletype we want as its generic we use set of type <T>
            //AsNoTracking() -- in context of API no tracking req as we dont know how long b/w each select and what will be submitted, so by disabling tracking get more performance of select query in API
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id==id);
        }

        public async Task UpdateAsync(T entity)
        {
            //_context.Update(entity);
            _context.Entry(entity).State=EntityState.Modified;  //mark it as modified so when changes gets saved it sees that state is modified
            await _context.SaveChangesAsync();
        }
    }
}
