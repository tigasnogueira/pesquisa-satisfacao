﻿using System.Text.Json;
using System.Text;
using Pesquisa.WebApp.Mvc.Extensions;

namespace Pesquisa.WebApp.Mvc.Services;

public abstract class Services
{
    private readonly ILogger<Services> _logger;

    public Services(ILogger<Services> logger)
    {
        _logger = logger;
    }

    protected StringContent GetContent(object data)
    {
        _logger.LogInformation("GetContent loaded");

        return new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json");
    }

    protected async Task<T> DeserializeObjectResponse<T>(HttpResponseMessage responseMessage)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        _logger.LogInformation("DeserializeObjectResponse loaded");

        return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
    }

    protected bool HandleErrorsResponse(HttpResponseMessage response)
    {
        switch ((int)response.StatusCode)
        {
            case 401:
            case 403:
            case 404:
            case 500:
                throw new CustomHttpRequestException(response.StatusCode);

            case 400:
                return false;
        }

        response.EnsureSuccessStatusCode();

        _logger.LogInformation("HandleErrorsResponse loaded");

        return true;
    }
}
