using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
	{
		private readonly ETicaretAPIDbContext _context;

		public WriteRepository(ETicaretAPIDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public async Task<T> AddAsync(T entity)
		{
			EntityEntry<T> entityEntry = await Table.AddAsync(entity);
			return entityEntry.Entity;
		}

		public async Task<bool> RemoveAsync(int id)
		{
			T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
			return Remove(model);
		}

		public bool Remove(T entity)
		{
			EntityEntry<T> entityEntry = Table.Remove(entity);
			return entityEntry.State == EntityState.Deleted;
		}

		public bool RemoveRange(List<T> datas)
		{
			Table.RemoveRange(datas);
			return true;
		}

		public async Task<int> SaveAsync()
		=> await _context.SaveChangesAsync();

		public bool Update(T entity)
		{
			EntityEntry entityEntry = Table.Update(entity);
			return entityEntry.State == EntityState.Modified;
		}
	}
}
