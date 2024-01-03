using Quiz.Data;
using Quiz.Models;

namespace Quiz.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _context;

        public QuestionService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Add(string title, int quizId)
        {
            var question = new Question
            {
                Title = title,
                QuizId = quizId
            };

            this._context.Questions.Add(question);
            this._context.SaveChanges();
        }
    }
}
