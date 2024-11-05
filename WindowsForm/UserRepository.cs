using Newtonsoft.Json;
using SharedModels.Dto.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public UserRepository(HttpClient httpClient,
            string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            var loginDto = new LoginUserDto
            {
                UserName = username,
                Password = password
            };
            var json = JsonConvert.SerializeObject(loginDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<dynamic>(responseData).token;
            }
            else
            {
                // Manejar diferentes tipos de errores de autenticación
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Unauthorized: Invalid username or password.");
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new Exception("Bad request: Invalid request format.");
                }
                else
                {
                    throw new Exception("Failed to authenticate user.");
                }
            }
        }

    }
}
