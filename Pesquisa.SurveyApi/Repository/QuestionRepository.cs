using Microsoft.EntityFrameworkCore;
using Pesquisa.SurveyApi.Context;
using Pesquisa.SurveyApi.Interfaces;
using Pesquisa.SurveyApi.Models;

namespace Pesquisa.SurveyApi.Repository;

public class QuestionRepository : IQuestionRepository
{
    private readonly SurveyDbContext _context;

    public QuestionRepository(SurveyDbContext context)
    {
        _context = context;
    }

    public async Task<QuestionModel> CreateQuestionAsync(QuestionModel question)
    {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        return question;
    }

    public async Task<QuestionModel> DeleteQuestionAsync(Guid id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null)
        {
            return null;
        }

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();

        return question;
    }

    public async Task<QuestionModel> GetQuestionAsync(Guid id)
    {
        return await _context.Questions.FindAsync(id);
    }

    public async Task<IEnumerable<QuestionModel>> GetQuestionsAsync()
    {
        return await _context.Questions.ToListAsync();
    }

    public async Task<QuestionModel> UpdateQuestionAsync(QuestionModel question)
    {
        _context.Entry(question).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return question;
    }
}
