using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Models
{
    public class AddBlogModel
    {
        // test
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string DetailDescription { get; set; }

        public IFormFile Image { get; set; }
    }
}
