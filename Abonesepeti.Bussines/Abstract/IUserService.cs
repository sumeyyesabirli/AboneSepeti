using Abonesepeti.Bussines.RequestModel;

namespace Abonesepeti.Bussines.Abstract
{
    public interface IUserService
    {
        Task<UserRequestModel> CreateUserAsync(RegisterRequestModel model);
        Task<UserRequestModel> ValidateUserAsync(string phoneNumber, string password);
        Task<bool> PhoneNumberExistsAsync(string phoneNumber);
        Task<UserRequestModel> GetUserByIdAsync(string id);
        Task<UserRequestModel> GetUserByPhoneNumberAsync(string phoneNumber);
        Task UpdateRefreshTokenAsync(string userId, string refreshToken, DateTime expiryTime);
    }
}
