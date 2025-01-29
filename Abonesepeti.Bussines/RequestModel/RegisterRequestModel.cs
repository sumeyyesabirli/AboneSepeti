using Abonesepeti.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Abonesepeti.Bussines.RequestModel
{
    public class RegisterRequestModel
    {
        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Geçerli bir telefon numarası giriniz (10 haneli).")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Parola zorunludur.")]
        [MinLength(8, ErrorMessage = "Parola en az 8 karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Parola en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Parola doğrulama zorunludur.")]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Kullanıcı tipi zorunludur.")]
        public UserType UserType { get; set; }
    }  

}
