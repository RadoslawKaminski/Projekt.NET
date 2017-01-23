using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.NETWeb.Models
{
    public class WallViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
        public int? TotalCount { get; set; }
    }
}