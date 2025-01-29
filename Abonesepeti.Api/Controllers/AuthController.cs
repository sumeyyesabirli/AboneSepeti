using Abonesepeti.Bussines.Abstract;
using Abonesepeti.Bussines.RequestModel;
using Abonesepeti.Core.ResponseManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Abonesepeti.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public IActionResult UserOnlyEndpoint() =>
            Ok(ApiResponse<string>.SuccessResult("Bu endpoint'e sadece User rolüne sahip kullanıcılar erişebilir."));

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnlyEndpoint() =>
            Ok(ApiResponse<string>.SuccessResult("Bu endpoint'e sadece Admin rolüne sahip kullanıcılar erişebilir."));

        [HttpGet("all-authorized")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult AllAuthorizedEndpoint() =>
            Ok(ApiResponse<string>.SuccessResult("Bu endpoint'e hem Admin hem de User rolüne sahip kullanıcılar erişebilir."));

        [HttpGet("public")]
        [AllowAnonymous]
        public IActionResult PublicEndpoint() =>
            Ok(ApiResponse<string>.SuccessResult("Bu endpoint'e herkes erişebilir, token gerekli değil."));

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<TokenResponseModel>>> Register([FromBody] RegisterRequestModel model)
        {
            try
            {
                if (await _userService.PhoneNumberExistsAsync(model.PhoneNumber))
                    return BadRequest(ApiResponse<TokenResponseModel>.ErrorResult("Bu telefon numarası zaten kayıtlı."));

                var user = await _userService.CreateUserAsync(model);
                var tokenResponse = await _jwtService.GenerateTokensAsync(user);
                return Ok(ApiResponse<TokenResponseModel>.SuccessResult(tokenResponse, "Kullanıcı başarıyla kaydedildi."));
            }
            catch
            {
                return StatusCode(500, ApiResponse<TokenResponseModel>.ErrorResult("Bir hata oluştu. Lütfen daha sonra tekrar deneyiniz."));
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<TokenResponseModel>>> Login([FromBody] LoginRequestModel model)
        {
            try
            {
                var user = await _userService.ValidateUserAsync(model.PhoneNumber, model.Password);
                if (user == null)
                    return BadRequest(ApiResponse<TokenResponseModel>.ErrorResult("Telefon numarası veya parola hatalı."));

                var tokenResponse = await _jwtService.GenerateTokensAsync(user);
                return Ok(ApiResponse<TokenResponseModel>.SuccessResult(tokenResponse, "Giriş başarılı."));
            }
            catch
            {
                return StatusCode(500, ApiResponse<TokenResponseModel>.ErrorResult("Bir hata oluştu. Lütfen daha sonra tekrar deneyiniz."));
            }
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<ApiResponse<TokenResponseModel>>> RefreshToken([FromBody] RefreshTokenRequestModel model)
        {
            try
            {
                var tokenResponse = await _jwtService.RefreshTokenAsync(model.AccessToken, model.RefreshToken);
                if (tokenResponse == null)
                    return BadRequest(ApiResponse<TokenResponseModel>.ErrorResult("Geçersiz veya süresi dolmuş token."));

                return Ok(ApiResponse<TokenResponseModel>.SuccessResult(tokenResponse, "Token başarıyla yenilendi."));
            }
            catch
            {
                return StatusCode(500, ApiResponse<TokenResponseModel>.ErrorResult("Bir hata oluştu. Lütfen daha sonra tekrar deneyiniz."));
            }
        }
    }
}
