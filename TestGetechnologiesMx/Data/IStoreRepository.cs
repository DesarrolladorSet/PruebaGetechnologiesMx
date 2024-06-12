using Microsoft.AspNetCore.Mvc;

namespace Backend.Data
{
	public interface IBaseRepository<T> where T : class,IEntity
	{
		public Task<ActionResult<IEnumerable<T>>> GetAll();
		public Task<ActionResult<T>> Create(T entity);
		public Task<ActionResult<T>> Update(int id, T entity);
		public Task<ActionResult<T>> Delete(int id);
	}
}
