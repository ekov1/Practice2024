using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quiz.Models;

namespace Quiz.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserAnswer>()
                .HasKey(k => new { k.IdentityUserId, k.Quizid });

            builder.Entity<UserAnswer>()
                .HasOne(x => x.Quiz)
                .WithMany(x => x.UserAnswers)
                .HasForeignKey(x => x.Quizid)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<UserAnswer>()
                .HasOne(x => x.Question)
                .WithMany(x => x.UserAnswers)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            base.OnModelCreating(builder);
        }
    }
}