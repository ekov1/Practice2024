namespace Quiz.Services
{
    public interface IUserAnswerService
    {
        void AddUserAnswer(string useerId, int quizId, int questionId, int answerId);
    }
}
