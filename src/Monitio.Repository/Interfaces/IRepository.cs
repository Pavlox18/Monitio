using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitio.Repository.Interfaces
{
	public interface IRepository<T> where T : class
	{
		T GetById(int Id);
		IEnumerable<T> GetAll();
		void Add(T entity);
		void Delete(T entity);
	}
}
