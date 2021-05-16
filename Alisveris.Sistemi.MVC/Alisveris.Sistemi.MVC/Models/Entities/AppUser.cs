using Alisveris.Sistemi.MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.Models.Entities
{
    //Bu class'a validation uyguladık çünkü bu property'lere veri girilmesini zorunlu kılıp koşullara tabi tuttuk
    public class AppUser : BaseEntity
    {
        [Required(ErrorMessage ="{0} girilmesi zorunludur")] //Veri girilmesini zorunlu kıldık
        [MinLength(2, ErrorMessage = "{0} minimum {1} karakter uzunluğunda olmalıdır")] //Minimum 2 karakter koşulu
        [MaxLength(10, ErrorMessage = "{0} maksimum {1} karakter uzunluğunda olmalıdır")] //Maksimum 10 karakter koşulu
        [Display(Name ="Kullanıcı Adı")] //Validation error'da property'nin ismi Kullanıcı Adı olarak gözüksün 
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} girilmesi zorunludur")]
        [MinLength(5, ErrorMessage = "{0} minimum {1} karakter uzunluğunda olmalıdır")]
        [MaxLength(15, ErrorMessage = "{0} maksimum {1} karakter uzunluğunda olmalıdır")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Girdiğiniz şifre uyuşmuyor")] //Bu property'nin verisi Password'daki veri ile aynı olmak zorunda koşulu
        public string ConfirmPassword { get; set; }
        public UserRole Role { get; set; }


        public AppUser()
        {
            Role = UserRole.Member;
        }

        //Relational Properties

        public virtual AppUserProfile Profile { get; set; }
        public virtual List<Order> Orders { get; set; }

    }
}