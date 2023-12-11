using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Http;
using DeLaSalle.Ecommerce.WebApplication.Pages.Services.Interfaces;
using Newtonsoft.Json;
using System;

namespace DeLaSalle.Ecommerce.WebApplication.Pages.Services
{
    public class BrandService : IBrandService
    {
        #region Propiedades
        public string UrlAPI { get; set; }
        public string Token { get; set; }
        #endregion

        #region Métodos

        private string _baseUrl = "https://localhost:7025/";
        private string _endpoint = "api/Brand";

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var url = $"{_baseUrl}{_endpoint}/{id}";
            var client = new HttpClient();
            var res = await client.DeleteAsync(url);
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<bool>>(json);
        }

        public async Task<Response<List<BrandDto>>> GetAllAsync()
        {
            var url = $"{_baseUrl}{_endpoint}";
            var client = new HttpClient();
            var res = await client.GetAsync("https://localhost:7025/api/Brand");
            var json = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response<List<BrandDto>>>(json);
        }

        public async Task<Response<BrandDto>> GetByIdAsync(int id)
        {
            var url = $"{_baseUrl}{_endpoint}/{id}";
            var client = new HttpClient();
            var res = await client.GetAsync(url);
            var json = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Response<BrandDto>>(json);
        }

        public async Task<Response<BrandDto>> SaveAsync(BrandDto dto)
        {
            var url = $"{_baseUrl}{_endpoint}";
            var jsonRequest = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var res = await client.PostAsync(url, content);
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<BrandDto>>(json);
        }

        public async Task<Response<BrandDto>> UpdateAsync(BrandDto dto)
        {
            var url = $"{_baseUrl}{_endpoint}";
            var jsonRequest = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var res = await client.PutAsync(url, content);
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<BrandDto>>(json);
        }
        #endregion
    }
}