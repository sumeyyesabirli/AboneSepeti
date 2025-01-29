using System.ComponentModel.DataAnnotations;

namespace Abonesepeti.Bussines.RequestModel
{
    public class RefreshTokenRequestModel
    {
        [Required(ErrorMessage = "Access token zorunludur.")]
        public string AccessToken { get; set; }

        [Required(ErrorMessage = "Refresh token zorunludur.")]
        public string RefreshToken { get; set; }
    }
}
