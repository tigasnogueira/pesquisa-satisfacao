using Microsoft.Extensions.Options;
using Pesquisa.WebApp.Mvc.Extensions;
using Pesquisa.WebApp.Mvc.Interfaces;
using Pesquisa.WebApp.Mvc.Models;

namespace Pesquisa.WebApp.Mvc.Services
{
    public class AuthenticationService : Services, IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly HttpClient _httpClient;

        public AuthenticationService(ILogger<AuthenticationService> logger, HttpClient httpClient,
                                    IOptions<AppSettings> settings) : base(logger)
        {
            _logger = logger;

            httpClient.BaseAddress = new Uri(settings.Value.AutenticationUrl);
            
            _httpClient = httpClient;
        }

        public async Task<UserResponseLogin> Login(UserLogin userLogin)
        {
            var loginContent = GetContent(userLogin);

            var response = await _httpClient.PostAsync("/api/identity/login", loginContent);

            if (!HandleErrorsResponse(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            _logger.LogInformation("Login service loaded");

            return await DeserializeObjectResponse<UserResponseLogin>(response);
        }

        public async Task<UserResponseLogin> Register(UserRegister userRegister)
        {
            var registerContent = GetContent(userRegister);

            var response = await _httpClient.PostAsync("/api/identity/register", registerContent);

            if (!HandleErrorsResponse(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            _logger.LogInformation("Register service loaded");

            return await DeserializeObjectResponse<UserResponseLogin>(response);
        }
    }
}
