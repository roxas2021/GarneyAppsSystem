using GarneyAppSystem.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ApplicationService.Utility;

namespace GarneyAppSystem.ApiService
{
    public class httpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly SystemConfig _config = new SystemConfig();

        public httpClientService()
        {
            _httpClient = new HttpClient();
        }

        public string getUrl()
        {
            string baseUrl;

            #if DEBUG
                baseUrl = _config.apiUrl_test;
#else
                baseUrl = _config.apiUrl;
#endif

            return baseUrl;
        }

        public async Task<ApiResponseWrapper> doPostAssync(HttpContent content, string endpoint)
        {
            try
            {
                var response = await _httpClient.PostAsync( getUrl() + endpoint, content);

                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Status: {response.StatusCode}");
                Console.WriteLine($"Body: {body}");

                if (response.IsSuccessStatusCode)
                {
                    var wrapper = JsonSerializer.Deserialize<ApiResponseWrapper>(body, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return wrapper;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EXCEPTION: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

            return null;
        }

        public async Task<ApiResponseWrapper> DoGetAsync(string endpoint)
        {
            try
            {
                string authToken = Preferences.Get("authToken", string.Empty);

                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                var response = await _httpClient.GetAsync(getUrl() + endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string body = await response.Content.ReadAsStringAsync();

                    var wrapper = JsonSerializer.Deserialize<ApiResponseWrapper>(body, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return wrapper;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DoGetAsync Error] {ex.Message}");
            }

            return null;
        }
    }
}
