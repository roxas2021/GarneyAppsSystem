using ApplicationService.EntityModel;
using ApplicationService.Utility;
using GarneyAppSystemAPI.Repo;
using Microsoft.AspNetCore.Mvc;

namespace GarneyAppSystemAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserRepo _userRepo;

        public UserController(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserDetail(int id)
        {
            var userdetail = await _userRepo.getUserById(id);

            ApiResult apidata = new ApiResult();
            apidata.msg = "User successfully retrieve.";

            var dataModel = new EntityMaster
            {
                apiResult = apidata,
                user = userdetail
            };

            return Ok(new { dataModel = dataModel });
        }

        [HttpPost("update")]
        public async Task<IActionResult> updateUserDetails([FromBody] user data)
        {
            var result = await _userRepo.editUserDetails(data);

            return Ok(new { dataModel = new EntityMaster { user = data } });
        }

        [HttpPost("uploadProfileImage")]
        public async Task<IActionResult> UploadProfileImage([FromQuery] int id, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            await _userRepo.saveImageFileName(id, file.FileName);

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "profileuploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            ApiResult apidata = new ApiResult();
            apidata.msg = "Image uploaded successfully.";

            var dataModel = new EntityMaster
            {
                apiResult = apidata
            };

            return Ok(new { dataModel = dataModel });
        }

        [HttpPost("InsertUser")]
        public async Task<IActionResult> InsertUser([FromBody] user user)
        {
            user.PasswordHash = EncryptionHelper.Encrypt(user.PasswordHash);
            user.CreatedDate = DateTime.Now;
            user.Role = 1;
            user.imageDIR = "profile4.png";
            user.Status = "Active";

            var result = await _userRepo.InsertUser(user);

            ApiResult apidata = new ApiResult();
            apidata.msg = result != null ? "Account successfully created." : "";
            apidata.statuscode = result != null ? 200 : 400;

            var dataModel = new EntityMaster
            {
                apiResult = apidata,
                user = result
            };

            return Ok(new { dataModel = dataModel });
        }

        [HttpGet("checkEmail")]
        public async Task<IActionResult> checkEmail(string email)
        {
            var result = await _userRepo.checkEmail(email);

            ApiResult apidata = new ApiResult();
            apidata.msg = result == true ? "Email already exists." : "Email is available.";
            apidata.statuscode = 200;
            apidata.isExist = result;

            var dataModel = new EntityMaster
            {
                apiResult = apidata,
            };

            return Ok(new { dataModel = dataModel });
        }
    }
}
