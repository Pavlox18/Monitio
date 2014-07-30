using Monitio.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel = Monitio.Model;

namespace Monitio.Domain
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		public User() { }

		public User(DBModel.User user)
		{
			this.Id = user.Id;
			this.Login = user.Login;
			this.Password = user.Password;
			this.Email = user.Email;
			this.Name = user.Name;
			this.Surname = user.Surname;
		}

		public static User GetById(int id)
		{
			UnitOfWork uow = new UnitOfWork();
			DBModel.User usr = uow.UserRepository.GetById(id);
			if (usr != null) return new User(usr);
			return null;
		}
	}
}
