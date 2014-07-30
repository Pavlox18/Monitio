using Monitio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Monitio.Repository.Implementations
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private DbContext context;

		public Repository(DbContext dbcontext)
		{
			context = dbcontext;
		}

		public T GetById(int Id)
		{
			return context.Set<T>().Find(Id);
		}

		public IEnumerable<T> GetAll()
		{
			try
			{
				return context.Set<T>();
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public void Add(T entity)
		{
			context.Set<T>().Add(entity);
		}

		public void Delete(T entity)
		{
			context.Set<T>().Remove(entity);
		}
	}
}
