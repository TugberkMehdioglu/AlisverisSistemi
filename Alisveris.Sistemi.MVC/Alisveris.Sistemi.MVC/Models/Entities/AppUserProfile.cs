using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alisveris.Sistemi.MVC.Models.Entities
{
    //Bu class'a validation uyguladık çünkü bu property'lere veri girilmesini zorunlu kılıp koşullara tabi tuttuk

    public class AppUserProfile : BaseEntity
    {
        [Required(ErrorMessage = "{0} girilmesi zorunludur")] //Veri girilmesini zorunlu kıldık
        [MinLength(2, ErrorMessage ="{0} minimum {1} karakter uzunluğunda olmalıdır")] //Minimum 2 karakter koşulu
        [MaxLength(10, ErrorMessage ="{0} maksimum {1} karakter uzunluğunda olmalıdır")] //Maksimum 10 karakter koşulu
        [Display(Name = "İsim")] //Validation error'da property'nin ismi Kullanıcı Adı olarak gözüksün 
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} girilmesi zorunludur")]
        [MinLength(2, ErrorMessage = "{0} minimum {1} karakter uzunluğunda olmalıdır")]
        [MaxLength(10, ErrorMessage = "{0} maksimum {1} karakter uzunluğunda olmalıdır")]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }


        public string Country { get; set; }

        [Required(ErrorMessage = "{0} girilmesi zorunludur")]
        [MinLength(2, ErrorMessage = "{0} minimum {1} karakter uzunluğunda olmalıdır")]
        [MaxLength(15, ErrorMessage = "{0} maksimum {1} karakter uzunluğunda olmalıdır")]
        [Display(Name = "Şehir")]
        public string City { get; set; }

        [Required(ErrorMessage = "{0} girilmesi zorunludur")]
        [MinLength(5, ErrorMessage = "{0} minimum {1} karakter uzunluğunda olmalıdır")]
        [MaxLength(25, ErrorMessage = "{0} maksimum {1} karakter uzunluğunda olmalıdır")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} girilmesi zorunludur")]
        [MinLength(10, ErrorMessage = "{0} minimum {1} karakter uzunluğunda olmalıdır")]
        [MaxLength(16, ErrorMessage = "{0} maksimum {1} karakter uzunluğunda olmalıdır")]
        [Display(Name = "Telefon numarası")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "{0} girilmesi zorunludur")]
        [MinLength(8, ErrorMessage = "{0} minimum {1} karakter uzunluğunda olmalıdır")]
        [MaxLength(35, ErrorMessage = "{0} maksimum {1} karakter uzunluğunda olmalıdır")]
        [Display(Name = "Mail")]
        public string Email { get; set; }


        //Relational Properties

        public virtual AppUser AppUser { get; set; }

    }
}