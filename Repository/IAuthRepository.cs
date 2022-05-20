using System.Threading.Tasks;
using JWTBooks.Models;

namespace JWTBooks.Repository
{
    public interface IAuthRepository
    {
        Task<TblUser> Register(TblUser user, string password);
        Task<TblUser> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}

