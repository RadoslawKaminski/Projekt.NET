using System.ComponentModel.DataAnnotations;

namespace Projekt.NET.Models
{
    public class Emails
    {
		public int EmailsId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}