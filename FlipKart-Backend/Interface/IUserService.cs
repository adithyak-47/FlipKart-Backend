using FlipKart_Backend.DTO;
using FlipKart_Backend.User_Data;
using System.Security.Claims;

namespace FlipKart_Backend.Interface
{
    public interface IUserService
    {
        string LoginUser(UserDTO user);

        //string CreateJWTToken(IEnumerable<Claim> claimsList, DateTime expiry);
    }
}
