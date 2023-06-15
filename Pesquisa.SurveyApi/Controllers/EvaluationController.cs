using Microsoft.AspNetCore.Mvc;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Controllers;

[ApiController]
[Route("api/evaluations")]
public class EvaluationController : ControllerBase
{
    private readonly ILogger<EvaluationController> _logger;
    private readonly IEvaluationService _evaluationService;

    public EvaluationController(ILogger<EvaluationController> logger, IEvaluationService evaluationService)
    {
        _logger = logger;
        _evaluationService = evaluationService;
    }

    [HttpPost]
    public IActionResult CreateEvaluation(EvaluationModel evaluation)
    {
        _logger.LogInformation("Creating evaluation for customer {0}", evaluation.CustomerId);

        var createdEvaluation = _evaluationService.CreateEvaluation(evaluation);
        return CreatedAtAction(nameof(GetEvaluationById), new { id = createdEvaluation.Id }, createdEvaluation);
    }

    [HttpGet]
    public IActionResult GetEvaluations()
    {
        _logger.LogInformation("Getting all evaluations");

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

        _logger.LogInformation("Getting evaluation {0}", evaluation.Id);

        return Ok(evaluation);
    }

    [HttpGet("search")]
    public IActionResult GetEvaluationsByMonthAndYear(int month, int year)
    {
        _logger.LogInformation("Getting evaluations by month {0} and year {1}", month, year);

        var evaluations = _evaluationService.GetEvaluationsByMonthAndYear(month, year);
        return Ok(evaluations);
    }

    [HttpGet("customer/{customerId}")]
    public IActionResult GetEvaluationsByCustomerId(Guid customerId)
    {
        _logger.LogInformation("Getting evaluations by customer {0}", customerId);

        var evaluations = _evaluationService.GetEvaluationsByCustomerId(customerId);
        return Ok(evaluations);
    }

    [HttpGet("result")]
    public IActionResult GetEvaluationResult(int month, int year)
    {
        _logger.LogInformation("Getting evaluation result for month {0} and year {1}", month, year);

        var nps = _evaluationService.CalculateNPS(month, year);
        return Ok(nps);
    }
}
