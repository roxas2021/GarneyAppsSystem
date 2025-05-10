using ApplicationService.EntityModel;
using ApplicationService.Utility;
using GarneyAppSystemAPI.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace GarneyAppSystemAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly UserRepo _userRepo;

        public LoginController(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var encryptedPass = EncryptionHelper.Encrypt(request.password);
            bool isExist = await _userRepo.VerifyUser(request.email, encryptedPass);

            if (!isExist)
            {
                return Unauthorized(new { message = "User not found" });
            }

            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            var user = await _userRepo.getUser(request.email);

            var login = new userlogin
            {
                userid = user.Id,
                password = encryptedPass,
                authtoken = token,
                devicename = "",
                ipaddress = "",
                createdat = DateTime.UtcNow,
                lastusedat = DateTime.UtcNow
            };

            await _userRepo.InsertUserLogin(login);

            return Ok(new { message = "User successfully login." , token, user = user });
        }
    }
}
