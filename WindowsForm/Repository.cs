using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SharedModels;
using SharedModels.Dto.Ingresos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WindowsForm
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        public Repository(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task<T> CreateAsync(object dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseData);
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception(errorResponse);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception(errorResponse);
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception(errorResponse);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(_endpoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception(errorResponse);
            }
        }

        public async Task<List<T>> GetByEmployeeNumberAsync(int employeeNumber, DateTime? startPeriod, DateTime? endPeriod)
        {
            var endpointUrl = $"{_endpoint}/ByEmployee/{employeeNumber}";

            var queryParameters = new List<string>();

            if (startPeriod.HasValue)
            {
                queryParameters.Add($"startPeriodDate={Uri.EscapeDataString(startPeriod.Value.ToString("yyyy-MM-ddTHH:mm:ss.fff"))}");
            }

            if (endPeriod.HasValue)
            {
                queryParameters.Add($"endPeriodDate={Uri.EscapeDataString(endPeriod.Value.ToString("yyyy-MM-ddTHH:mm:ss.fff"))}");
            }

            if (queryParameters.Any())
            {
                endpointUrl += "?" + string.Join("&", queryParameters);
            }

            var response = await _httpClient.GetAsync(endpointUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var deductionDtos = JsonConvert.DeserializeObject<IEnumerable<T>>(content);
                return deductionDtos.ToList();
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception(errorResponse);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception(errorResponse);
            }
        }

        public async Task<bool> UpdateAsync(int id, object dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_endpoint}/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception(errorResponse);
            }
        }

        internal async Task<bool> IngresosUpdateAsync(IngresosUpdateDto ingresoUpdateDto)
        {
            var json = JsonConvert.SerializeObject(ingresoUpdateDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var id = ingresoUpdateDto.Ingresos_Id; // Obtén el Id del DTO para construir la URL
            var response = await _httpClient.PutAsync($"{_endpoint}/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar el ingreso. {errorResponse}");
            }
        }
    }
}
