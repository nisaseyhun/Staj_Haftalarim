using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Models
{
    public class UpdateBlog
    {
        
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string DetailDescription { get; set; }

        public string ImageUrl { get; set; }

        public IFormFile NewImageFile { get; set; }
    }
}
