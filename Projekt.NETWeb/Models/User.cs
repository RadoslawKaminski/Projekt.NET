using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Projekt.NET.Models
{
    public class User
    {
        public string UserId { get; set; }

        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public string BackgroundPhotoUrl { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Friend> Friend { get; set; }
        public virtual ICollection<FamilyPerson> FamilyPerson { get; set; }
    }
}