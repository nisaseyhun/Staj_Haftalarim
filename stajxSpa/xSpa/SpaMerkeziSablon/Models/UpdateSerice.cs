using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Models
{
    public class UpdateSerice
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDetails { get; set; }
        public string ServiceDescription { get; set; }
        public IFormFile NewImageFile { get; set; }
        public string ExistingImagePath { get; set; }
    }
}
