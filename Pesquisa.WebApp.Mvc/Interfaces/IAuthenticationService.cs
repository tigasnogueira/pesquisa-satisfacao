using Pesquisa.WebApp.Mvc.Models;

namespace Pesquisa.WebApp.Mvc.Interfaces;

public interface IAuthenticationService
{
    Task<UserResponseLogin> Login(UserLogin userLogin);

    Task<UserResponseLogin> Register(UserRegister userRegister);
}
