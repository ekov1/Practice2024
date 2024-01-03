using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Models;

namespace Quiz.Services
{

    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext _context;

        public QuizService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Add(string title)
        {
            var quiz = new Quiz.Models.Quiz
            {
                Title = title
            };

            _context.Quizzes.Add(quiz);
            _context.SaveChanges();
        }

        public QuizViewModel GetQuizById(int quizId)
        {
            var quiz = _context.Quizzes
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault(x => x.Id == quizId);

            var quizViewModel = new QuizViewModel()
            {
                Title = quiz.Title,
                Questions = quiz.Questions.Select(q => new QuestionViewModel
                {
                    Title = q.Title,
                    Answers = q.Answers.Select(a => new AnswerViewModel
                    {
                        Title = a.Title
                    }).ToHashSet()

                }).ToHashSet()
            };

            return quizViewModel;
        }

        public void BulkAddUserAnswer(QuizInputModel quizInputModel)
        {
            var userAnswers = new List<UserAnswer>();

            foreach (var item in quizInputModel.Questions)
            {
                var userAnswer = new UserAnswer()
                {
                    IdentityUserId = quizInputModel.UserId,
                    Quizid = quizInputModel.QuizId,
                    AnswerId = item.AnswerId,
                    QuestionId = item.QuestionId
                };

                userAnswers.Add(userAnswer);
            }

            _context.UserAnswers.AddRange(userAnswers);
            _context.SaveChanges();
        }

        public int? GetUserResult(string userId, int quizId)
        {
            var originalQuiz = _context.Quizzes
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .ThenInclude(x => x.UserAnswers)
                .FirstOrDefault(x => x.Id == quizId);

            var userAnswers = _context.UserAnswers
                .Where(x => x.IdentityUserId == userId && x.Quizid == quizId)
                .ToHashSet();

            int? totalPoints = 0;

            foreach (var userAnswer in userAnswers)
            {
                totalPoints += originalQuiz.Questions
                    .FirstOrDefault(x => x.Id == userAnswer.QuestionId)
                    .Answers
                    .Where(x => x.IsCorrect == true)
                    .FirstOrDefault(x => x.Id == userAnswer.AnswerId)
                    .Points;

            }

            return totalPoints.GetValueOrDefault();
        }
    }
}