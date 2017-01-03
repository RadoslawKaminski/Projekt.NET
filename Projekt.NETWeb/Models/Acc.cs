using System.Collections.Generic;

namespace Projekt.NET.Models
{
    public class Acc
    {
			public int AccId { get; set; }
			public string Login { get; set; }
			public string Password { get; set; }
			List<User> Users { get; set; }
			List<Emails> Email { get; set; }
			List<PhoneNumbers> PhoneNumber { get; set; }
    }
}