using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Link
    {
        [Key]
        public int LinlID { get; set; }
        public string LinlName { get; set; }
        public string LinlUrl { get; set; }
    }
}
