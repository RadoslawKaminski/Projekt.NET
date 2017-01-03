using System;
using System.Collections.Generic;

namespace Projekt.NET.Models
{
    public class Post
    {
		public int PostId { get; set; }
		public string PostContent{ get; set; }
		public DateTime AdditionDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Friend> Friend{ get; set; }
    }
}