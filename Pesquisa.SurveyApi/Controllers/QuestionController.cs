using Microsoft.AspNetCore.Mvc;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;
using Pesquisa.SurveyApi.ViewModels;

namespace Pesquisa.SurveyApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuestionViewModel>>> GetQuestions()
    {
        var questions = await _questionService.GetQuestionsAsync();
        var questionViewModels = MapToViewModels(questions);
        return Ok(questionViewModels);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionViewModel>> GetQuestion(Guid id)
    {
        var question = await _questionService.GetQuestionAsync(id);
        if (question == null)
        {
            return NotFound();
        }

        var questionViewModel = MapToViewModel(question);
        return Ok(questionViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<QuestionViewModel>> CreateQuestion(QuestionViewModel questionViewModel)
    {
        var question = MapToModel(questionViewModel);
        var createdQuestion = await _questionService.CreateQuestionAsync(question);
        var createdQuestionViewModel = MapToViewModel(createdQuestion);
        return CreatedAtAction(nameof(GetQuestion), new { id = createdQuestionViewModel.Id }, createdQuestionViewModel);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<QuestionViewModel>> UpdateQuestion(Guid id, QuestionViewModel questionViewModel)
    {
        if (id != questionViewModel.Id)
        {
            return BadRequest();
        }

        var existingQuestion = await _questionService.GetQuestionAsync(id);
        if (existingQuestion == null)
        {
            return NotFound();
        }

        var updatedQuestion = MapToModel(questionViewModel);
        updatedQuestion.CreatedAt = existingQuestion.CreatedAt;
        var result = await _questionService.UpdateQuestionAsync(updatedQuestion);
        var updatedQuestionViewModel = MapToViewModel(result);
        return Ok(updatedQuestionViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<QuestionViewModel>> DeleteQuestion(Guid id)
    {
        var existingQuestion = await _questionService.GetQuestionAsync(id);
        if (existingQuestion == null)
        {
            return NotFound();
        }

        var deletedQuestion = await _questionService.DeleteQuestionAsync(id);
        var deletedQuestionViewModel = MapToViewModel(deletedQuestion);
        return Ok(deletedQuestionViewModel);
    }

    private IEnumerable<QuestionViewModel> MapToViewModels(IEnumerable<QuestionModel> questions)
    {
        var questionViewModels = new List<QuestionViewModel>();
        foreach (var question in questions)
        {
            var questionViewModel = MapToViewModel(question);
            questionViewModels.Add(questionViewModel);
        }
        return questionViewModels;
    }

    private QuestionViewModel MapToViewModel(QuestionModel question)
    {
        var questionViewModel = new QuestionViewModel
        {
            Id = question.Id,
            Description = question.Description,
            Type = question.Type,
            Options = question.Options,
            SurveyId = question.SurveyId
        };
        return questionViewModel;
    }

    private QuestionModel MapToModel(QuestionViewModel questionViewModel)
    {
        var question = new QuestionModel
        {
            Id = questionViewModel.Id,
            Description = questionViewModel.Description,
            Type = questionViewModel.Type,
            Options = questionViewModel.Options,
            SurveyId = questionViewModel.SurveyId
        };
        return question;
    }
}
