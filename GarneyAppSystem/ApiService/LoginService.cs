using ApplicationService.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GarneyAppSystem.ViewModel;

namespace GarneyAppSystem.ApiService
{
    public class LoginService
    {
        private readonly httpClientService _httpClient;

        public LoginService()
        {
            _httpClient = new httpClientService();
        }

        public async Task<EntityMaster> LoginAccountAsync(string email, string password)
        {
            var loginRequest = new LoginRequest
            {
                email = email,
                password = password,
                devicename = "Android Emulator", // temporary set
                ipaddress = "127.0.0.1" // temporary set
            };

            var json = JsonSerializer.Serialize(loginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            string endpoint = "login/login";

            var dataModel = await _httpClient.doPostAssync(content, endpoint);

            return dataModel?.dataModel;
        }
    }
}
