using AutoMapper;
using Pesquisa.ClientApi.Models;
using Pesquisa.ClientApi.ViewModels;

namespace Pesquisa.ClientApi.Configuration;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<ClientModel, ClientViewModel>().ReverseMap();
    }
}
