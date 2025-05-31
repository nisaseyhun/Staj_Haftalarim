using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Models
{
    public class AddService
    {
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceDetails { get; set; }
        public IFormFile ImgUrl { get; set; }
    }
}
