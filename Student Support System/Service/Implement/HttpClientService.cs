using Newtonsoft.Json;
using StudentSupportSystem.Model;
using StudentSupportSystem.Service.Interface;
using System.Text;

namespace StudentSupportSystem.Service.Implement
{
    public class HttpClientService : IHttpClientService
    {
        HttpClient _httpClient;
        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T> Delete<T>(string Url, T obj)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, Url);
                var response = await _httpClient.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ResponseData<T>>(json);
                return data.Result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Get<T>(string Url)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, Url);
                var response = await _httpClient.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ResponseData<T>>(json);
                return data.Result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<TR> Post<T, TR>(string Url, T obj)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, Url);
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await _httpClient.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ResponseData<TR>>(json);
                return data.Result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<TR> Put<T, TR>(string Url, T obj)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Put, Url);
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await _httpClient.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ResponseData<TR>>(json);
                return data.Result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
