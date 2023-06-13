﻿using Microsoft.Extensions.Options;
using Pesquisa.WebApp.Mvc.Extensions;
using Pesquisa.WebApp.Mvc.Interfaces;
using Pesquisa.WebApp.Mvc.Models;

namespace Pesquisa.WebApp.Mvc.Services
{
    public class AutenticationService : Services, IAutenticationService
    {
        private readonly HttpClient _httpClient;

        public AutenticationService(HttpClient httpClient,
                                    IOptions<AppSettings> settings)
        {
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

            return await DeserializeObjectResponse<UserResponseLogin>(response);
        }
    }
}
