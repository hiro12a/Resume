using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Resume.Models;
using Resume.Repository.IRepository;

namespace Resume.Repository
{
    public class TokenServices : ITokenService
    {
        // Dependency injection
        private readonly IConfiguration _config; // Used to call appsettings.json stuff
        private readonly SymmetricSecurityKey _key;
        public TokenServices(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"])); // We need to get the key
        }

        public string CreateToken(AppUsers user)
        {
            // Define a list of claims (key-value pairs) to include in the JWT
            var claims = new List<Claim>
            {
                // Add the user's email as a claim using a standard JWT claim name
                new Claim(JwtRegisteredClaimNames.Email, user.Email),

                // Add the user's username as the given name claim
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
            };

            // Define the credentials used to sign the JWT using the HMAC SHA512 algorithm
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            // Create a token descriptor that outlines the contents and properties of the JWT
            var tokenDesc = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),  // Set the subject of the token to a ClaimsIdentity, which includes the claims list
                Expires = DateTime.Now.AddDays(7),  // Set the expiration date for the token to 7 days from the current time
                SigningCredentials = creds, // Specify the signing credentials (the algorithm and key used to sign the token)
                Issuer = _config["JWT:Issuer"], // Set the issuer of the token (who is generating it), fetched from the configuration
                Audience = _config["JWT:Audience"] // Set the audience (who is allowed to use the token), fetched from the configuration
            };

            // Create a token handler that is responsible for generating and processing JWTs
            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate the JWT token based on the token descriptor
            var token = tokenHandler.CreateToken(tokenDesc);

            // Write the token as a string and return it
            return tokenHandler.WriteToken(token);
        }
    }
}