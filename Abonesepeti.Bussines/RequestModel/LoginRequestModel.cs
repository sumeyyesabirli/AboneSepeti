using System.ComponentModel.DataAnnotations;

namespace Abonesepeti.Bussines.RequestModel
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Geçerli bir telefon numarası giriniz (10 haneli).")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Parola zorunludur.")]
        public string Password { get; set; }
    }
}
