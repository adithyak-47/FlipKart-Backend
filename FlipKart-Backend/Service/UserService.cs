using FlipKart_Backend.DTO;
using FlipKart_Backend.Interface;
using FlipKart_Backend.User_Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlipKart_Backend.Service
{
    public class UserService: IUserService
    {
        private string _secretKey;
        public UserService()
        {
            _secretKey = "kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk";
        }
        public string LoginUser(UserDTO user)
        {
            if(user.Email == User.Email && user.Password == User.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin")
                };

                var expiry = DateTime.UtcNow.AddMinutes(1);

                string token = CreateJWTToken(claims, expiry);
                return token;
            }
            return "";
        }

        private string CreateJWTToken(IEnumerable<Claim> claimsList, DateTime expiry)
        {
            var secretKey = Encoding.ASCII.GetBytes(_secretKey);

            var jwt = new JwtSecurityToken(

                claims: claimsList,
                notBefore: DateTime.UtcNow,
                expires: expiry,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
