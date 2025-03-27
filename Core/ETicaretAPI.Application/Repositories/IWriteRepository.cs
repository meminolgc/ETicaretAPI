using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
	{
		Task<T> AddAsync(T entity);
		Task<bool> RemoveAsync(int id);
		bool Remove(T entity);
		bool RemoveRange(List<T> datas);
		bool Update(T entity);
		Task<int> SaveAsync();
	}
}
