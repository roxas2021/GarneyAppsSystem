using ApplicationService.EntityModel;
using ApplicationService.Utility;
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

        public async Task<user> getUserById(int Id)
        {
            return _dbConn.user.FirstOrDefault(u => u.Id == Id);
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

        public async Task<user> editUserDetails(user data)
        {
            var exisUser = await _dbConn.user.FindAsync(data.Id);

            if(exisUser != null)
            {
                exisUser.FullName = data.FullName;
                exisUser.Age = data.Age;
                exisUser.DOB = data.DOB;
                exisUser.Email = data.Email;
                exisUser.ContactNo = data.ContactNo;
                exisUser.Address = data.Address;
                exisUser.Role = data.UserType == "Guest"? 0 : 1;
                exisUser.PasswordHash = EncryptionHelper.Encrypt(data.PasswordHash);
                exisUser.UpdatedDate = DateTime.Now;

                await _dbConn.SaveChangesAsync();
                return exisUser;
            }

            return null;
        }
    }
}
