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

        public async Task<T> UploadFile<T>(string Url, MultipartFormDataContent Content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Url);
            request.Headers.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ0eXBlIjoyLCJzdWIiOiJyYW5nNzc1NEBnbWFpbC5jb20iLCJuYW1lIjoiXHUwZTI4XHUwZTIzXHUwZTMyXHUwZTI3XHUwZTM4XHUwZTE4IFx1MGUxYVx1MGUzMVx1MGUyN1x1MGU0MFx1MGUwMlx1MGUzNVx1MGUyMlx1MGUyNyIsImRhdGVfdGltZSI6IjIwMjQtMTAtMzEgMjI6NDc6MzQiLCJleHAiOjE3MzA0NzYwNTR9.rKs2TTDfHmL1uB4JO7ZQxP0NlkQll5mMo-OjR4RhsmM");
            request.Content = Content;
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseData<T>>(json);
            return data.Result;
        }
    }
}
