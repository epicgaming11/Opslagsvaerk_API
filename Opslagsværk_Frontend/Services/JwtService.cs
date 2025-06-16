using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;

namespace Opslagsværk_Frontend.Services
{
    public class JwtService
    {
        private readonly ILocalStorageService _localStorage;

        public JwtService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<bool> IsTokenValid()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrEmpty(token))
                return false;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var expClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "exp");

            if (expClaim == null)
                return false;

            var expUnix = long.Parse(expClaim.Value);
            var expiryTime = DateTimeOffset.FromUnixTimeSeconds(expUnix);

            return expiryTime > DateTimeOffset.UtcNow;
        }

        public async Task<string?> GetTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>("authToken");
        }
    }
}
