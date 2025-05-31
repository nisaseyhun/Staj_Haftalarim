using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser: IdentityUser<int>
    {
        public string name { get; set; }
        public string surname { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
