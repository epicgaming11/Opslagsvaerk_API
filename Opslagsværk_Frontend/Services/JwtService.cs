using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;

namespace Opslagsværk_Frontend.Services
{
    //Manages JWT tokens in browers local storage.
    //Retrieve, store and validate JWT tokens for user authentication.
    public class JwtService
    {
        //takes ILocalStorageService from BlazoredLocalStorage, to sotre and retrieve the JsonWebToken (JWT) from the browsers local storage.
        private readonly ILocalStorageService _localStorage;
        public JwtService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }


        public async Task<bool> IsTokenValid() //checks if token is valid with async.
        {
            var token = await _localStorage.GetItemAsync<string>("authToken"); //gets token using key "authToken".

            //if token is empty/null its invalid and returns false.
            if (string.IsNullOrEmpty(token))
                return false;

            //create handler to parse and read JWT tokens, read and decode the JWT token into an object.
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            //find expiration claim in tokens claim list.
            var expClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "exp");

            //if no expiration claim, token is invalid and false.
            if (expClaim == null)
                return false;

            // turns the Unix timestamp into a real date and time for expiration for token.
            var expUnix = long.Parse(expClaim.Value);
            var expiryTime = DateTimeOffset.FromUnixTimeSeconds(expUnix);

            //Return true if valid, false if expired.
            return expiryTime > DateTimeOffset.UtcNow;
        }


        // retrieve the JWT token from local storage using "authToken", returns token as a string or null if not found.
        public async Task<string?> GetTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>("authToken");
        }
    }
}
