using System.ComponentModel.DataAnnotations;

namespace Projekt.NET.Models
{
    public class PhoneNumbers
    {
		public int PhoneNumbersId { get; set; }
        [MinLength(4)]
		public string PhoneNumber { get; set; }
    }
}