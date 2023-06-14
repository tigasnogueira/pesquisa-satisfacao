using Pesquisa.SurveyApi.Context;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Repository;
using Pesquisa.SurveyApi.Services;

namespace Pesquisa.SurveyApi.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<SurveyDbContext>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<ISurveyService, SurveyService>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEvaluationRepository, EvaluationRepository>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IEvaluationService, EvaluationService>();

        return services;
    }
}
