using Microsoft.AspNetCore.Mvc;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;
using Pesquisa.SurveyApi.ViewModels;

namespace Pesquisa.SurveyApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SurveyController : ControllerBase
{
    private readonly ISurveyService _surveyService;

    public SurveyController(ISurveyService surveyService)
    {
        _surveyService = surveyService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SurveyViewModel>>> GetSurveys()
    {
        var surveys = await _surveyService.GetSurveysAsync();
        var surveyViewModels = MapToViewModels(surveys);
        return Ok(surveyViewModels);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SurveyViewModel>> GetSurvey(Guid id)
    {
        var survey = await _surveyService.GetSurveyAsync(id);
        if (survey == null)
        {
            return NotFound();
        }

        var surveyViewModel = MapToViewModel(survey);
        return Ok(surveyViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<SurveyViewModel>> CreateSurvey(SurveyViewModel surveyViewModel)
    {
        var survey = MapToModel(surveyViewModel);
        var createdSurvey = await _surveyService.CreateSurveyAsync(survey);
        var createdSurveyViewModel = MapToViewModel(createdSurvey);
        return CreatedAtAction(nameof(GetSurvey), new { id = createdSurveyViewModel.Id }, createdSurveyViewModel);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<SurveyViewModel>> UpdateSurvey(Guid id, SurveyViewModel surveyViewModel)
    {
        if (id != surveyViewModel.Id)
        {
            return BadRequest();
        }

        var existingSurvey = await _surveyService.GetSurveyAsync(id);
        if (existingSurvey == null)
        {
            return NotFound();
        }

        var updatedSurvey = MapToModel(surveyViewModel);
        updatedSurvey.CreatedAt = existingSurvey.CreatedAt;
        var result = await _surveyService.UpdateSurveyAsync(updatedSurvey);
        var updatedSurveyViewModel = MapToViewModel(result);
        return Ok(updatedSurveyViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<SurveyViewModel>> DeleteSurvey(Guid id)
    {
        var existingSurvey = await _surveyService.GetSurveyAsync(id);
        if (existingSurvey == null)
        {
            return NotFound();
        }

        var deletedSurvey = await _surveyService.DeleteSurveyAsync(id);
        var deletedSurveyViewModel = MapToViewModel(deletedSurvey);
        return Ok(deletedSurveyViewModel);
    }

    private IEnumerable<SurveyViewModel> MapToViewModels(IEnumerable<SurveyModel> surveys)
    {
        var surveyViewModels = new List<SurveyViewModel>();
        foreach (var survey in surveys)
        {
            var surveyViewModel = MapToViewModel(survey);
            surveyViewModels.Add(surveyViewModel);
        }
        return surveyViewModels;
    }

    private SurveyViewModel MapToViewModel(SurveyModel survey)
    {
        var surveyViewModel = new SurveyViewModel
        {
            Id = survey.Id,
            Title = survey.Title,
            Description = survey.Description,
            CreatedAt = survey.CreatedAt,
            UpdatedAt = survey.UpdatedAt,
            Questions = MapToQuestionViewModels(survey.Questions)
        };
        return surveyViewModel;
    }

    private IEnumerable<QuestionViewModel> MapToQuestionViewModels(IEnumerable<QuestionModel> questions)
    {
        var questionViewModels = new List<QuestionViewModel>();
        foreach (var question in questions)
        {
            var questionViewModel = MapToQuestionViewModel(question);
            questionViewModels.Add(questionViewModel);
        }
        return questionViewModels;
    }

    private QuestionViewModel MapToQuestionViewModel(QuestionModel question)
    {
        var questionViewModel = new QuestionViewModel
        {
            Id = question.Id,
            Description = question.Description,
            SurveyId = question.SurveyId
        };
        return questionViewModel;
    }

    private SurveyModel MapToModel(SurveyViewModel surveyViewModel)
    {
        var survey = new SurveyModel
        {
            Id = surveyViewModel.Id,
            Title = surveyViewModel.Title,
            Description = surveyViewModel.Description,
            CreatedAt = surveyViewModel.CreatedAt,
            UpdatedAt = surveyViewModel.UpdatedAt,
            Questions = MapToQuestionModels(surveyViewModel.Questions)
        };
        return survey;
    }

    private ICollection<QuestionModel> MapToQuestionModels(IEnumerable<QuestionViewModel> questionViewModels)
    {
        var questions = new List<QuestionModel>();
        foreach (var questionViewModel in questionViewModels)
        {
            var question = MapToQuestionModel(questionViewModel);
            questions.Add(question);
        }
        return questions;
    }

    private QuestionModel MapToQuestionModel(QuestionViewModel questionViewModel)
    {
        var question = new QuestionModel
        {
            Id = questionViewModel.Id,
            Description = questionViewModel.Description,
            SurveyId = questionViewModel.SurveyId
        };
        return question;
    }
}
