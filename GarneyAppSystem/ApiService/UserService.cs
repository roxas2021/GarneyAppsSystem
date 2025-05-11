using ApplicationService.EntityModel;
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
    }
}
