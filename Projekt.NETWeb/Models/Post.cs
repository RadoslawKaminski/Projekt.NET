using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Projekt.NETWeb.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public List<Like> Likes { get; set; }
    }

    public class Like
    {
        public virtual Post Post { get; set; }
        public virtual ApplicationUser LikedByMembershipUser { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string PostContent { get; set; }
        public DateTime DateCreated { get; set; }
        public int LikeCount { get; set; }
        public virtual MembershipUser User { get; set; }
        public virtual IList<Like> Likes { get; set; }
    }
}