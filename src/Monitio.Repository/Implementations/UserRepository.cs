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
	public class UserRepository : Repository<User>
	{
		public UserRepository(DbContext context) : base(context) { }
	}
}
