using Monitio.Model;
using Monitio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitio.Repository.Implementations
{
	public class UnitOfWork : IUnitOfWork
	{
		DbContext context;

		#region Repositories
		private IRepository<User> _userRepository;

		public IRepository<User> UserRepository
		{
			get
			{
				if (_userRepository == null)
					_userRepository = new UserRepository(context);
				return _userRepository;
			}
		}

		#endregion

		public UnitOfWork()
		{
			context = new MonitioModelContainer();
		}

		public UnitOfWork(DbContext dbcontext)
		{
			context = dbcontext;
		}

		public void Commit()
		{
			try
			{
				context.SaveChanges();
			}
			catch(Exception ex)
			{

			}
		}
	}
}
