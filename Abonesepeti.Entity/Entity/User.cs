using Abonesepeti.Core.Entity;
using Abonesepeti.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Abonesepeti.Entity.Entity
{
    public class User:BaseEntity
    {

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public UserType UserType { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    } 
}
