using Abonesepeti.Bussines.Abstract;
using Abonesepeti.Bussines.RequestModel;
using Abonesepeti.Core.Helpers;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Abonesepeti.Bussines.Concrete
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<UserRequestModel> _users;

        public UserService(IMongoClient mongoClient, IConfiguration configuration)
        {
            var database = mongoClient.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
            _users = database.GetCollection<UserRequestModel>(configuration["MongoDbSettings:UsersCollectionName"]);
        }

        public async Task<UserRequestModel> CreateUserAsync(RegisterRequestModel model)
        {
            var user = new UserRequestModel
            {
                Id = ObjectId.GenerateNewId(),
                PhoneNumber = model.PhoneNumber,
                PasswordHash = PasswordHasher.HashPassword(model.Password),
                UserType = model.UserType,
                CreatedAt = DateTime.UtcNow
            };

            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task<UserRequestModel> ValidateUserAsync(string phoneNumber, string password)
        {
            var user = await GetUserByPhoneNumberAsync(phoneNumber);
            return user != null && PasswordHasher.VerifyPassword(password, user.PasswordHash) ? user : null;
        }

        public Task<bool> PhoneNumberExistsAsync(string phoneNumber) =>
            _users.Find(u => u.PhoneNumber == phoneNumber).AnyAsync();

        public async Task<UserRequestModel> GetUserByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId)) return null;
            return await _users.Find(u => u.Id == objectId).FirstOrDefaultAsync();
        }

        public Task<UserRequestModel> GetUserByPhoneNumberAsync(string phoneNumber) =>
            _users.Find(u => u.PhoneNumber == phoneNumber).FirstOrDefaultAsync();

        public async Task UpdateRefreshTokenAsync(string userId, string refreshToken, DateTime expiryTime)
        {
            if (!ObjectId.TryParse(userId, out ObjectId objectId)) return;

            var update = Builders<UserRequestModel>.Update
                .Set(u => u.RefreshToken, refreshToken)
                .Set(u => u.RefreshTokenExpiryTime, expiryTime)
                .Set(u => u.UpdatedAt, DateTime.UtcNow);

            await _users.UpdateOneAsync(u => u.Id == objectId, update);
        }
    }
}