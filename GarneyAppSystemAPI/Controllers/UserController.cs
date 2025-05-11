using ApplicationService.EntityModel;
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
    }
}
