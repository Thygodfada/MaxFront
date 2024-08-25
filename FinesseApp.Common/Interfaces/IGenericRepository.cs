using FinesseApp.Common.Models;
using System.Linq.Expressions;

namespace FinesseApp.Common.Interfaces;

public interface IGenericRepository<T> where T : class
{
	Task<IEnumerable<T>> GetAllAsync();
	Task<T> GetByIdAsync(int id);
	IQueryable<T> Find(Expression<Func<T, bool>> predicate);	
	Task AddAsync(T entity);
	void Update(T entity);
	void Delete(T entity);
}
