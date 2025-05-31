using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
