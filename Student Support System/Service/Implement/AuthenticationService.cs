using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

namespace StudentSupportSystem.Service.Implement
{

    public class AuthenticationService : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    return await Task.FromResult(new AuthenticationState(AnonymousUser));
        //}

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await _localStorage.GetItemAsStringAsync("token");
            var identity = new ClaimsIdentity();
            //_http.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(token))
            {
                identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
                //_http.DefaultRequestHeaders.Authorization =
                //    new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
            }

            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        //private ClaimsPrincipal AnonymousUser = new(new ClaimsIdentity(Array.Empty<Claim>()));

        public async Task SignIn(string Token)
        {
            await _localStorage.SetItemAsync("token", Token);
            await GetAuthenticationStateAsync();
            //var claims = new[] {
            //    new Claim(ClaimTypes.PrimarySid, Id.ToString()),
            //    new Claim(ClaimTypes.Name, Name),
            //    new Claim(ClaimTypes.Role, "admin"),
            //};
            //var identity = new ClaimsIdentity(claims, "faked");
            //AnonymousUser = new ClaimsPrincipal(identity);
            //var result = Task.FromResult(new AuthenticationState(AnonymousUser));
            //NotifyAuthenticationStateChanged(result);
        }

        public async Task<bool> IsSignIn()
        {
            var _token = await _localStorage.GetItemAsStringAsync("token");
            return !string.IsNullOrEmpty(_token);
        }

        public async Task SignOut()
        {
            await _localStorage.RemoveItemAsync("token");
            await GetAuthenticationStateAsync();
            //var result = Task.FromResult(new AuthenticationState(AnonymousUser));
            //NotifyAuthenticationStateChanged(result);
        }

    }
}
