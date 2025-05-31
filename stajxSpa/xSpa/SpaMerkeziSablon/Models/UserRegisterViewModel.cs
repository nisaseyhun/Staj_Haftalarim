using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Adınız soy adınızı giriniz.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Adınız soy adınızı giriniz.")]
        public string mail { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınzız giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen sifrenizi giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen tekrar sifrenizi giriniz.")]
        [Compare("Password", ErrorMessage ="Girilen sifreler aynı değil!")]
        public string ConfirmPassword { get; set; }
    }
}
