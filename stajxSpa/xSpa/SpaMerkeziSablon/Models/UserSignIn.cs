using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Models
{
    public class UserSignIn
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını doldurun")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Lütfen sifrenizi giriniz")]
        public string userPassword { get; set; }
    }
}
