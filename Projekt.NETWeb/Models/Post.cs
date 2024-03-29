﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projekt.NETWeb.Models
{
    public class Like
    {
        [Key]
        public int LikeIds { get; set; }
        public virtual Post Post { get; set; }
        public virtual ApplicationUser LikedBy { get; set; }
    }

    public class Post
    {
        [Key]
        public int PostId  { get; set; }
        public string PostContent { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool Edited { get; set; }
        public DateTime? DateEdited { get; set; }
        public int LikesCount { get; set; }
        public string UserName { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual List<Like> Likes { get; set; }
    }
}