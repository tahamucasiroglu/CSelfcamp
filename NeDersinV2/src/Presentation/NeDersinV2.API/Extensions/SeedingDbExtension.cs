using Microsoft.EntityFrameworkCore;
using NeDersinV2.Constants.Const;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Extensions;
using NeDersinV2.Infrasructure.Contexts;
using NeDersinV2.Mapper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace NeDersinV2.API.Extensions
{
    static public class SeedingDbExtension
    {
        /*
        public static async Task Seeding(this WebApplication app)
        {
            using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<NeDersinV2Context>())
            {
                int DbSize = 1_000;  // 100 < DbSize < oo

                Random random = new Random();
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();

                List<User> users = new List<User>
                {
                    new User() { Name = $"User{1}", Surname = $"Surname{1}", Email = $"User{1}@gmail.com", Password = 1.ToSha256(), UserStatus = UserStatusConst.Anonim }
                };
                for (int i = 2; i < DbSize + 1; i++)
                {
                    users.Add(new User() { Name = $"User{i}", Surname = $"Surname{i}", Email = $"User{i}@gmail.com", Password = i.ToSha256(), UserStatus = (i < 20) ? UserStatusConst.Admin : (i < 100) ? UserStatusConst.Pollster : UserStatusConst.Member, Country = random.Next(1, 81) });
                }
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();

                List<Survey> surveys = new List<Survey>
                {
                    new Survey() { Address = Guid.NewGuid(), UserId = random.Next(100, DbSize), Title = $"Title{1}", Describtion = $"Describtion{1}", Date = DateTime.Now, IsEnd = false, ResponseCount = 0, ViewCount = 0, Rating = random.Next(4) + random.NextDouble() }
                };
                for (int i = 2; i < DbSize + 1; i++)
                {
                    surveys.Add(new Survey() { Address = Guid.NewGuid(), UserId = random.Next(100, DbSize), Title = $"Title{i}", Describtion = $"Describtion{i}", Date = DateTime.Now, IsEnd = false, ResponseCount = 0, ViewCount = 0, Rating = random.Next(4) + random.NextDouble() });
                }
                await context.Surveys.AddRangeAsync(surveys);
                await context.SaveChangesAsync();

                List<SurveyRating> surveyRatings = new List<SurveyRating>();
                for (int i = 1; i < DbSize + 1; i++)
                {
                    surveyRatings.Add(new SurveyRating() { SurveyId = random.Next(1, DbSize), UserId = random.Next(2, DbSize), RatingCount = random.Next(1, 5) });
                    surveyRatings.Add(new SurveyRating() { SurveyId = random.Next(1, DbSize), UserId = 1, RatingCount = random.Next(1, 5) });
                    surveyRatings.Add(new SurveyRating() { SurveyId = random.Next(1, DbSize), UserId = 1, RatingCount = random.Next(1, 5) });
                }
                await context.SurveyRatings.AddRangeAsync(surveyRatings);
                await context.SaveChangesAsync();

                List<Question> questions = new List<Question>();
                for (int i = 1; i < DbSize * 10 + 1; i++)
                {
                    questions.Add(new Question() { QuestionText = $"Question{i}", FileAddress = (i % 5 == 0) ? "https://picsum.photos/200/300" : null, SurveyId = random.Next(1, DbSize), });

                }
                await context.Questions.AddRangeAsync(questions);
                await context.SaveChangesAsync();

                List<Answer> answers = new List<Answer>();
                for (int i = 1; i < DbSize * 100 + 1; i++)
                {
                    answers.Add(new Answer() { QuestionId = random.Next(1, DbSize * 10), Type = (i < DbSize / 10) ? AnswerTypeConst.LongText : i < DbSize / 8 ? AnswerTypeConst.ShortText : i < DbSize / 6 ? AnswerTypeConst.Rating5 : i < DbSize / 4 ? AnswerTypeConst.Rating10 : i < DbSize / 2 ? AnswerTypeConst.MultiSelect : AnswerTypeConst.SingleSelect, AnswerValue = i > DbSize / 4 ? new List<string>() { "Answer1", "Answer2", "Answer3", "Answer4", "Answer5", "Answer6", "Answer7", "Answer8", "Answer9", "Answer10" }.ToJson() : null });
                }
                await context.Answers.AddRangeAsync(answers);
                await context.SaveChangesAsync();


                List<Response> responses = new List<Response>();
                for (int i = 1; i < DbSize * 1000 + 1; i++)
                {
                    int qi = random.Next(1, 10000);
                    responses.Add(new Response() { QuestionId = qi, UserId = i % 100 == 0 ? random.Next(2, DbSize) : 1, ResponseText = qi > DbSize / 4 ? $"Response{i}" : $"answer{random.Next(1, 10)}" });
                }
                await context.Responses.AddRangeAsync(responses);
                await context.SaveChangesAsync();


            }
        }
        */
        /*
        public static async Task Seeding(this WebApplication app)
        {
            using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<NeDersinV2Context>())
            {
                int DbSize = 1_000;  // 100 < DbSize < oo

                Random random = new Random();
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();


                context.Users.Add(new User() { Name = $"User{1}", Surname = $"Surname{1}", Email = $"User{1}@gmail.com", Password = 1.ToSha256(), UserStatus = UserStatusConst.Anonim });
                await context.SaveChangesAsync();
                for (int i = 2; i < DbSize + 1; i++)
                {
                    context.Users.Add(new User() { Name = $"User{i}", Surname = $"Surname{i}", Email = $"User{i}@gmail.com", Password = i.ToSha256(), UserStatus = (i < 20) ? UserStatusConst.Admin : (i < 100) ? UserStatusConst.Pollster : UserStatusConst.Member, Country = random.Next(1, 81) });
                    await context.SaveChangesAsync();
                }
                context.Surveys.Add(new Survey() { Address = Guid.NewGuid(), UserId = random.Next(100, DbSize), Title = $"Title{1}", Describtion = $"Describtion{1}", Date = DateTime.Now, IsEnd = false, ResponseCount = 0, ViewCount = 0, Rating = random.Next(4) + random.NextDouble() });
                await context.SaveChangesAsync();
                for (int i = 2; i < DbSize + 1; i++)
                {
                    context.Surveys.Add(new Survey() { Address = Guid.NewGuid(), UserId = random.Next(100, DbSize), Title = $"Title{i}", Describtion = $"Describtion{i}", Date = DateTime.Now, IsEnd = false, ResponseCount = 0, ViewCount = 0, Rating = random.Next(4) + random.NextDouble() });
                    await context.SaveChangesAsync();
                }
                for (int i = 1; i < DbSize + 1; i++)
                {
                    context.SurveyRatings.Add(new SurveyRating() { SurveyId = random.Next(1, DbSize), UserId = random.Next(2, DbSize), RatingCount = random.Next(1, 5) });
                    context.SurveyRatings.Add(new SurveyRating() { SurveyId = random.Next(1, DbSize), UserId = 1, RatingCount = random.Next(1, 5) });
                    context.SurveyRatings.Add(new SurveyRating() { SurveyId = random.Next(1, DbSize), UserId = 1, RatingCount = random.Next(1, 5) });
                    await context.SaveChangesAsync();
                }
                for (int i = 1; i < DbSize * 10 + 1; i++)
                {
                    context.Questions.Add(new Question() { QuestionText = $"Question{i}", FileAddress = (i % 5 == 0) ? "https://picsum.photos/200/300" : null, SurveyId = random.Next(1, DbSize), });
                    await context.SaveChangesAsync();
                }
                for (int i = 1; i < DbSize * 100 + 1; i++)
                {

                    context.Answers.Add(new Answer() { QuestionId = random.Next(1, DbSize * 10), Type = (i < DbSize / 10) ? AnswerTypeConst.LongText : i < DbSize / 8 ? AnswerTypeConst.ShortText : i < DbSize / 6 ? AnswerTypeConst.Rating5 : i < DbSize / 4 ? AnswerTypeConst.Rating10 : i < DbSize / 2 ? AnswerTypeConst.MultiSelect : AnswerTypeConst.SingleSelect, AnswerValue = i > DbSize / 4 ? new List<string>() { "Answer1", "Answer2", "Answer3", "Answer4", "Answer5", "Answer6", "Answer7", "Answer8", "Answer9", "Answer10" }.ToJson() : null });
                    await context.SaveChangesAsync();
                }
                for (int i = 1; i < DbSize * 1000 + 1; i++)
                {
                    int qi = random.Next(1, 10000);
                    context.Responses.Add(new Response() { QuestionId = qi, UserId = i % 100 == 0 ? random.Next(2, DbSize) : 1, ResponseText = qi > DbSize / 4 ? $"Response{i}" : $"answer{random.Next(1, 10)}" });
                    await context.SaveChangesAsync();
                }
            }
        }
        */
        public static async Task Seeding(this WebApplication app)
        {
            using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<NeDersinV2Context>())
            {
                int DbSize = 1_000;  // 100 < DbSize < oo

                Random random = new Random();
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();

                List<User> users = new List<User>
                {
                    new User() { Name = $"User{1}", Surname = $"Surname{1}", Email = $"User{1}@gmail.com", Password = 1.ToSha256(), UserStatus = UserStatusConst.Anonim }
                };
                for (int i = 2; i < DbSize + 1; i++)
                {
                    users.Add(new User() { Name = $"User{i}", Surname = $"Surname{i}", Email = $"User{i}@gmail.com", Password = i.ToSha256(), UserStatus = (i < 20) ? UserStatusConst.Admin : (i < 100) ? UserStatusConst.Pollster : UserStatusConst.Member, Country = random.Next(1, 81) });
                }

                List<Survey> surveys = new List<Survey>
                {
                    new Survey() { Address = Guid.NewGuid(), UserId = random.Next(100, DbSize), Title = $"Title{1}", Describtion = $"Describtion{1}", Date = DateTime.Now, IsEnd = false, ResponseCount = 0, ViewCount = 0, Rating = random.Next(4) + random.NextDouble() }
                };
                for (int i = 2; i < DbSize + 1; i++)
                {
                    surveys.Add(new Survey() { Address = Guid.NewGuid(), UserId = random.Next(100, DbSize), Title = $"Title{i}", Describtion = $"Describtion{i}", Date = DateTime.Now, IsEnd = false, ResponseCount = 0, ViewCount = 0, Rating = random.Next(4) + random.NextDouble() });
                }

                List<SurveyRating> surveyRatings = new List<SurveyRating>();
                for (int i = 1; i < DbSize + 1; i++)
                {
                    surveyRatings.Add(new SurveyRating() { SurveyId = random.Next(1, DbSize), UserId = random.Next(2, DbSize), RatingCount = random.Next(1, 5) });
                    surveyRatings.Add(new SurveyRating() { SurveyId = random.Next(1, DbSize), UserId = 1, RatingCount = random.Next(1, 5) });
                    surveyRatings.Add(new SurveyRating() { SurveyId = random.Next(1, DbSize), UserId = 1, RatingCount = random.Next(1, 5) });
                }


                List<Question> questions = new List<Question>();
                for (int i = 1; i < DbSize * 10 + 1; i++)
                {
                    questions.Add(new Question() { QuestionText = $"Question{i}", FileAddress = (i % 5 == 0) ? "https://picsum.photos/200/300" : null, SurveyId = random.Next(1, DbSize), });

                }


                List<Answer> answers = new List<Answer>();
                for (int i = 1; i < DbSize * 100 + 1; i++)
                {
                    answers.Add(new Answer() { QuestionId = random.Next(1, DbSize * 10), Type = (i < DbSize / 10) ? AnswerTypeConst.LongText : i < DbSize / 8 ? AnswerTypeConst.ShortText : i < DbSize / 6 ? AnswerTypeConst.Rating5 : i < DbSize / 4 ? AnswerTypeConst.Rating10 : i < DbSize / 2 ? AnswerTypeConst.MultiSelect : AnswerTypeConst.SingleSelect, AnswerValue = i > DbSize / 4 ? new List<string>() { "Answer1", "Answer2", "Answer3", "Answer4", "Answer5", "Answer6", "Answer7", "Answer8", "Answer9", "Answer10" }.ToJson() : null });
                }


                List<Response> responses = new List<Response>();
                for (int i = 1; i < DbSize * 1000 + 1; i++)
                {
                    int qi = random.Next(1, 10000);
                    responses.Add(new Response() { QuestionId = qi, UserId = i % 100 == 0 ? random.Next(2, DbSize) : 1, ResponseText = qi > DbSize / 4 ? $"Response{i}" : $"answer{random.Next(1, 10)}" });
                }

                Stopwatch stopwatch = Stopwatch.StartNew();

                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
                Console.WriteLine("Users time = " + stopwatch.ElapsedMilliseconds.ToString());
                stopwatch.Restart();
                users.Clear();
                await context.Surveys.AddRangeAsync(surveys);
                await context.SaveChangesAsync();
                Console.WriteLine("Surveys time = " + stopwatch.ElapsedMilliseconds.ToString());
                stopwatch.Restart();
                surveys.Clear();
                await context.SurveyRatings.AddRangeAsync(surveyRatings);
                await context.SaveChangesAsync();
                Console.WriteLine("SurveyRatings time = " + stopwatch.ElapsedMilliseconds.ToString());
                stopwatch.Restart();
                surveyRatings.Clear();
                await context.Questions.AddRangeAsync(questions);
                await context.SaveChangesAsync();
                Console.WriteLine("Questions time = " + stopwatch.ElapsedMilliseconds.ToString());
                stopwatch.Restart();
                questions.Clear();
                await context.Answers.AddRangeAsync(answers);
                await context.SaveChangesAsync();
                Console.WriteLine("Answers time = " + stopwatch.ElapsedMilliseconds.ToString());
                stopwatch.Restart();
                answers.Clear();
                Stopwatch stopwatch1 = Stopwatch.StartNew();
                Stopwatch stopwatch2 = Stopwatch.StartNew();
                long sw1 = 0, sw2 = 0;
                for (int i = 0; i < responses.Count; i+=100)
                {
                    stopwatch.Restart();
                    stopwatch1.Restart();
                    
                    await context.Responses.AddRangeAsync(responses.Take(i..(i+100)));
                    sw1 = stopwatch1.ElapsedMilliseconds;stopwatch2.Restart();
                    await context.SaveChangesAsync();
                    sw2 = stopwatch2.ElapsedMilliseconds;
                    Console.WriteLine($" {i}/{responses.Count} Responses time = {stopwatch.ElapsedMilliseconds} sw1 = {sw1}  sw2 = {sw2}");
                    
                }
                stopwatch.Stop();
                responses.Clear();





            }
        }


    }
}
