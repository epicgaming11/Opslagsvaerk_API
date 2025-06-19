using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Opslagsværk_API.Services
{
    //generates JWT tokens for user authentication.
    public class JwtGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // creates a JWT token for a given user ID and role.
        //The token will contain the users identity and permissions, and will be digitally signed for security.
        public string GenerateToken(string userId, string role)
        {
            //Secret key used to sign the JWT token.
            var jwtKey = "StarWarsFeaturingWalterWhiteAndSkylerYo69";

            //identifies who issued the token (Application).
            var jwtIssuer = "itsBritneyBitch";

            //Identifies who should accept this token (API).
            var jwtAudience = "youGuysss";

            //Check if jwtKey is null or empty, throws exepction.
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("JWT_KEY is not set. Check your environment variables.");
            }

            //converts the secret key string into cryptographic key object, used to sign the token.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

            // create security credentials using secret key and HMAC-SHA256 algorithm.
            // This is how the token gets its digital signature for security.
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Claims are pieces of information about the user that are included in the token, like user identity, roles etc.
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, userId),//User Id
        new Claim(ClaimTypes.Role, role)//Role
    };
            //Build JWT token with all information and signing credentials.
            var token = new JwtSecurityToken(
                issuer: jwtIssuer, //(application)
                audience: jwtAudience, //(API)
                claims: claims, // list of claims liek user id and role etc.
                expires: DateTime.UtcNow.AddMinutes(2), //expiration time of the token.
                signingCredentials: credentials // using the credientials to sign token.
            );

            //convert JWT token object  into string, and send string to the client for authentication.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
