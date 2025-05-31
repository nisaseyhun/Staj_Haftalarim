using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Models
{
    public class AddHome
    {
        public string HomeTitle { get; set; }
        public string HomeDescriptions { get; set; }
        public IFormFile HomeImage { get; set; }
        public string HomePhone { get; set; }
        public string HomeWelCome { get; set; }
        public string instagramURl { get; set; }
        public string BannerUrl { get; set; }

    }
}
