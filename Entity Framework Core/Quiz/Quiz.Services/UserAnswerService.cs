using Quiz.Data;
using Quiz.Models;

namespace Quiz.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly ApplicationDbContext _context;

        public UserAnswerService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void AddUserAnswer(string useerId, int quizId, int questionId, int answerId)
        {
            var userAnswer = new UserAnswer()
            {
                IdentityUserId = useerId,
                Quizid = quizId,
                QuestionId = questionId,
                AnswerId = answerId
            };

            _context.UserAnswers.Add(userAnswer);
            _context.SaveChanges();
        }
    }
}
