using Microsoft.AspNetCore.Mvc;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Controllers;

[ApiController]
[Route("api/evaluations")]
public class EvaluationController : ControllerBase
{
    private readonly IEvaluationService _evaluationService;

    public EvaluationController(IEvaluationService evaluationService)
    {
        _evaluationService = evaluationService;
    }

    [HttpPost]
    public IActionResult CreateEvaluation(EvaluationModel evaluation)
    {
        var createdEvaluation = _evaluationService.CreateEvaluation(evaluation);
        return CreatedAtAction(nameof(GetEvaluationById), new { id = createdEvaluation.Id }, createdEvaluation);
    }

    [HttpGet]
    public IActionResult GetEvaluations()
    {
        var evaluations = _evaluationService.GetEvaluations();
        return Ok(evaluations);
    }

    [HttpGet("{id}")]
    public IActionResult GetEvaluationById(Guid id)
    {
        var evaluation = _evaluationService.GetEvaluationById(id);

        if (evaluation == null)
        {
            return NotFound();
        }

        return Ok(evaluation);
    }

    [HttpGet("search")]
    public IActionResult GetEvaluationsByMonthAndYear(int month, int year)
    {
        var evaluations = _evaluationService.GetEvaluationsByMonthAndYear(month, year);
        return Ok(evaluations);
    }

    [HttpGet("customer/{customerId}")]
    public IActionResult GetEvaluationsByCustomerId(int customerId)
    {
        var evaluations = _evaluationService.GetEvaluationsByCustomerId(customerId);
        return Ok(evaluations);
    }

    [HttpGet("result")]
    public IActionResult GetEvaluationResult(int month, int year)
    {
        var nps = _evaluationService.CalculateNPS(month, year);
        return Ok(nps);
    }
}
