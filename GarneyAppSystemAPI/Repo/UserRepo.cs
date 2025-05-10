using ApplicationService.EntityModel;
using GarneyAppSystemAPI.Services;
using System.Linq;

namespace GarneyAppSystemAPI.Repo
{
    public class UserRepo
    {
        private readonly AppDbContext _dbConn;

        public UserRepo(AppDbContext dbConn)
        {
            _dbConn = dbConn;
        }

        public async Task<user> getUser(string email)
        {
            return _dbConn.user.FirstOrDefault(u => u.Email == email);
        }

        public async Task<bool> VerifyUser(string email, string password)
        {
            return _dbConn.user.Any(u => u.Email == email && u.PasswordHash == password);
        }

        public async Task InsertUserLogin(userlogin data)
        {
            _dbConn.userlogin.Add(data);
            _dbConn.SaveChanges();
        }
    }
}
