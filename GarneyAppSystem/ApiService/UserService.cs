using ApplicationService.EntityModel;
using GarneyAppSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GarneyAppSystem.ApiService
{
    public class UserService
    {
        private readonly httpClientService _httpClient;

        public UserService()
        {
            _httpClient = new httpClientService();
        }

        public async Task<EntityMaster> getUserDetail()
        {
            int userId = Preferences.Get("uid", defaultValue: 0);

            string endpoint = $"user/user?id={userId}";

            var dataModel = await _httpClient.DoGetAsync(endpoint);

            return dataModel?.dataModel;
        }

        public async Task<user> updateUserDetails(user user)
        {
            //user.UserType
            string endpoint = "user/update";
            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.doPostAssync(content, endpoint);
            if (response != null)
            {
                return response.dataModel.user;
            }
            return null;
        }

        public async Task<ApiResponseWrapper> UploadProfileImage(byte[] image, string fileName)
        {
            int userId = Preferences.Get("uid", defaultValue: 0);
            string endpoint = $"user/uploadProfileImage?id={userId}";

            var content = new MultipartFormDataContent();

            var fileContent = new ByteArrayContent(image);
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            // Use the actual file name
            content.Add(fileContent, "file", fileName);

            var response = await _httpClient.doPostAssync(content, endpoint);

            return response;
        }

        public async Task<ApiResponseWrapper> CreateUser(user _user)
        {
            string endpoint = "user/InsertUser";
            var content = new StringContent(JsonSerializer.Serialize(_user), Encoding.UTF8, "application/json");
            var response = await _httpClient.doPostAssync(content, endpoint);
            if (response != null)
            {
                return response;
            }
            return null;
        }

        public async Task<ApiResponseWrapper> checkEmail(string email)
        {
            string endpoint = $"user/checkEmail?email={email}";

            var dataModel = await _httpClient.DoGetAsync(endpoint);

            return dataModel;
        }
    }
}
