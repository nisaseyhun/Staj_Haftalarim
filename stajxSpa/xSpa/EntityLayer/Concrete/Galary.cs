using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Galary
    {
        [Key]
        public int GalaryID { get; set; }
        public string GalaryImg { get; set; }
        public DateTime GalaryDate { get; set; }
    }
}
