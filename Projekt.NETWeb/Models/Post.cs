using System;
using System.Collections.Generic;

namespace Projekt.NET.Models
{
    public class Post
    {
		public string PostId { get; set; }
		public string PostContent{ get; set; }
		public DateTime AdditionDate { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Friend> Friend{ get; set; }
    }
}