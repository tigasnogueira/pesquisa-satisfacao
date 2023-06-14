using AutoMapper;
using Pesquisa.SurveyApi.Models;
using Pesquisa.SurveyApi.ViewModels;

namespace Pesquisa.SurveyApi.Configuration;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<SurveyModel, SurveyViewModel>().ReverseMap();
        CreateMap<QuestionModel, QuestionViewModel>().ReverseMap();
        CreateMap<EvaluationModel, EvaluationViewModel>().ReverseMap();
        CreateMap<CustomerModel, CustomerViewModel>().ReverseMap();
    }
}
