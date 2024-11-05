using SharedModels;
using SharedModels.Dto.EmpleadosDatos;
using SharedModels.Dto.Ingresos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        public IRepository<EmpleadosDto> Empleados { get; set; }
        public IRepository<IngresosDto> EmpleadosIngresos { get; set; }
        public IUserRepository LoginUsers { get; }
        public ApiClient()
        {
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _httpClient = new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
            Empleados = new Repository<EmpleadosDto>(_httpClient, "Empleados");
            EmpleadosIngresos = new Repository<IngresosDto>(_httpClient, "EmpleadosIngresos");
            LoginUsers = new UserRepository(_httpClient, "Auth/Login");
        }
        internal void SetAuthToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }


    }
}
