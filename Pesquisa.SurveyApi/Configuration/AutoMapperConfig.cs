using AutoMapper;
using Pesquisa.SurveyApi.Models;
using Pesquisa.SurveyApi.ViewModels;

namespace Pesquisa.SurveyApi.Configuration;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<EvaluationModel, EvaluationViewModel>().ReverseMap();
        CreateMap<CustomerModel, CustomerViewModel>().ReverseMap();
    }
}
