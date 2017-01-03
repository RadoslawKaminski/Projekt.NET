using Projekt.NET.Models;
using System;
using System.Collections.Generic;

namespace Projekt.NET.Models
{
    public class FakeUser
    {
			public int UserId { get; set; }
			public string Username { get; set; }
			public string Login { get; set; }
			public string Password { get; set; }
			public DateTime Birthday { get; set; }
			//public xxx ProfilePhoto { get; set; }
			//public xxx BackgroundPhoto { get; set; }
			List<Emails> Email { get; set; }
			List<PhoneNumbers> PhonNumber { get; set; }
			List<Friend> Friend { get; set; }
			List<Following> Following { get; set; }
			List<FamilyPerson> FamilyPerson {get; set; }
			
    }
}