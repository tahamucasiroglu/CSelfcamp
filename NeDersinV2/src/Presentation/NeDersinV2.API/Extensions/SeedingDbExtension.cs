using NeDersinV2.Constants.Const;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Extensions;
using NeDersinV2.Infrasructure.Contexts;

namespace NeDersinV2.API.Extensions
{
    static public class SeedingDbExtension
    {
        public static async Task Seeding(this WebApplication app)
        {
            using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<NeDersinV2Context>())
            {
                Random random = new Random();
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();

                List<User> users = new List<User>();
                users.Add(new User() { Name = $"User{1}", Surname = $"Surname{1}", Email = $"User{1}@gmail.com", Password = 1.ToSha256(), UserStatus = UserStatusConst.Anonim });
                for (int i = 2; i < 10001; i++)
                {
                    users.Add(new User() { Name = $"User{i}", Surname = $"Surname{i}", Email = $"User{i}@gmail.com", Password = i.ToSha256(), UserStatus = (i < 20) ? UserStatusConst.Admin : (i < 100) ? UserStatusConst.Pollster : UserStatusConst.Member, Country = random.Next(1, 81) });
                }
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();

                List<Survey> surveys = new List<Survey>();
                surveys.Add(new Survey() { Address = Guid.NewGuid(), UserId = random.Next(100, 10000), Title = $"Title{1}", Describtion = $"Describtion{1}", Date = DateTime.Now, IsEnd = false, ResponseCount = 0, ViewCount = 0, Rating = 0.0 });
                for (int i = 2; i < 10001; i++)
                {
                    surveys.Add(new Survey() { Address = Guid.NewGuid(), UserId = random.Next(100, 10000), Title = $"Title{i}", Describtion = $"Describtion{i}", Date = DateTime.Now, IsEnd = false, ResponseCount = 0, ViewCount = 0, Rating = 0.0 });
                }
                await context.Surveys.AddRangeAsync(surveys);
                await context.SaveChangesAsync();

                List<SurveyRating> surveyRatings = new List<SurveyRating>();
                for (int i = 1; i < 10001; i++)
                {
                    surveyRatings.Add(new SurveyRating() { SurveyId = random.Next(1, 10000), UserId = random.Next(1, 10000), RatingCount = random.Next(1, 5) });
                }
                await context.SurveyRatings.AddRangeAsync(surveyRatings);
                await context.SaveChangesAsync();

                List<Question> questions = new List<Question>();
                for (int i = 1; i < 10001; i++)
                {
                    questions.Add(new Question() { QuestionText = $"Question{i}", FileAddress = (i % 5 == 0) ? "https://picsum.photos/200/300" : null, SurveyId = random.Next(1, 10000), });
                }
                await context.Questions.AddRangeAsync(questions);
                await context.SaveChangesAsync();

                List<Answer> answers = new List<Answer>();
                for (int i = 1; i < 10001; i++)
                {
                    answers.Add(new Answer() { QuestionId = random.Next(1, 10000), Type = (i < 1000) ? AnswerTypeConst.Rating5 : i < 2000 ? AnswerTypeConst.Rating10 : i < 3000 ? AnswerTypeConst.LongText : i < 4000 ? AnswerTypeConst.ShortText : i < 5000 ? AnswerTypeConst.MultiSelect : AnswerTypeConst.SingleSelect, AnswerValue = i > 4000 ? new List<string>() { "Answer1", "Answer2", "Answer3", "Answer4", "Answer5", "Answer6", "Answer7", "Answer8", "Answer9", "Answer10" }.ToJson() : null });
                }
                await context.Answers.AddRangeAsync(answers);
                await context.SaveChangesAsync();

                List<Response> responses = new List<Response>();
                for (int i = 1; i < 10001; i++)
                {
                    int qi = random.Next(1, 10000);
                    responses.Add(new Response() { QuestionId = qi, UserId = random.Next(1, 10000), ResponseText = qi < 4000 ? $"Response{i}" : $"answer{random.Next(1, 10)}" });
                }
                await context.Responses.AddRangeAsync(responses);
                await context.SaveChangesAsync();
            }
        }
    }
}
