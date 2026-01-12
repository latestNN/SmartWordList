using System.ComponentModel.DataAnnotations;

namespace SmartWordList.Models.ViewModels
{
    public class AppUserSignInViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı boş bırakılamaz!")]
        [StringLength(15, ErrorMessage = "Kullanıcı Adı 4 ile 15 karakter olmalı")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen emaili boş geçmeyiniz...")]
        [EmailAddress(ErrorMessage = "Lütfen email formatında bir değer belirtiniz...")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz...")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen şifreyi tüm kuralları göz önüne alarak giriniz...")]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
    }
}
