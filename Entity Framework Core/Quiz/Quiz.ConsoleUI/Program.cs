using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using Quiz.Data;
using Microsoft.AspNetCore.Identity;
using Quiz.Services;

namespace Quiz.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dbContext = serviceProvider.GetService<ApplicationDbContext>();

            //foreach (var item in dbContext.Users)
            //{
            //    Console.WriteLine(item.UserName);
            //}

            var quizService = serviceProvider.GetService<IQuizService>();
            var points = quizService.GetUserResult("1ef20420-090a-4b78-9163-8f4099359e98", 1);
            Console.WriteLine(points);
            //quizService.Add("C# DB");
            //var quiz = quizService.GetQuizById(1);

            //Console.WriteLine(quiz.Title);

            //foreach (var question in quiz.Questions)
            //{
            //    Console.WriteLine(question.Title);

            //    foreach (var answer in question.Answers)
            //    {
            //        Console.WriteLine(answer.Title);
            //    }
            //}

            //var questionService = serviceProvider.GetService<IQuestionService>();
            //questionService.Add("What is Entity Framework Core", 1);

            //var answerService =  serviceProvider.GetService<IAnswerService>();
            //answerService.Add("Its is an ORM.", 5, true, 1);
            //answerService.Add("Its is an MicroORM.", 0, false, 1);

            //var userAnswerService =  serviceProvider.GetService<IUserAnswerService>();
            //userAnswerService.AddUserAnswer("1ef20420-090a-4b78-9163-8f4099359e98", 1, 1, 2);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IUserAnswerService, UserAnswerService>();

        }
    }
}