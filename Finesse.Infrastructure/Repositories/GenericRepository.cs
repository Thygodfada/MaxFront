using FinesseApp.Common.Interfaces;
using FinesseApp.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finesse.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext.ApplicationDbContext applicationDbContext;
        private DbSet<T> DbSet;

        public GenericRepository(ApplicationDbContext.ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            DbSet = applicationDbContext.Set<T>();
        }
        public async Task AddAsync(T entity) => await DbSet.AddAsync(entity);

        public void Delete(T entity) => DbSet.Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync() => await DbSet.ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await DbSet.FindAsync(id);

        public void Update(T entity) => DbSet.Update(entity);
		public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
		{
			return DbSet.Where(predicate);
		}
	}
}
