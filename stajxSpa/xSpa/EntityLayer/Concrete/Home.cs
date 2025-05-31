using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Home
    {
        [Key]
        public int HomeID { get; set; }
        public string HomeWelCome { get; set; }
        public string HomeTitle { get; set; }
        public string HomeDescriptions { get; set; }
        public string HomeImage { get; set; }
        public string HomePhone { get; set; }
        public string instagramURl { get; set; }
        public string BannerUrl { get; set; }
    }
}
