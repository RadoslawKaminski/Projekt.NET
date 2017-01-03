using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekt.NET.Models
{
    public class Acc
    {
		public int AccId { get; set; }
        [Required()]
        [MinLength(5)]
        public string Login { get; set; }
        [Required()]
        [MinLength(5)]
        public string Password { get; set; }
		public virtual List<User> Users { get; set; }
        public virtual List<Emails> Email { get; set; }
        public virtual List<PhoneNumbers> PhoneNumber { get; set; }
    }
}