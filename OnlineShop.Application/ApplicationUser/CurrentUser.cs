using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ApplicationUser
{
	public class CurrentUser
	{
		public CurrentUser(string id, string email)
		{
			Id = id;
			Email = email;	
		}

		public string Id { get; set; }
		public string Email { get; set; }
	}
}
