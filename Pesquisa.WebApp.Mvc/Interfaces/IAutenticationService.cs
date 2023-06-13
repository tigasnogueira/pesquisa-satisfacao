using Pesquisa.WebApp.Mvc.Models;

namespace Pesquisa.WebApp.Mvc.Interfaces;

public interface IAutenticationService
{
    Task<UserResponseLogin> Login(UserLogin userLogin);

    Task<UserResponseLogin> Register(UserRegister userRegister);
}
