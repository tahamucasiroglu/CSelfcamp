using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.API.HateoasModels;
using NeDersinV2.Infrasructure.Repository.EfCore;
using NeDersinV2.Services;

namespace NeDersinV2.API.Extensions
{
    static public class AddScopedExtension
    {
        public static void AddScoped(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAnswerRepository, EfAnswerRepository>();
            builder.Services.AddScoped<IQuestionRepository, EfQuestionRepository>();
            builder.Services.AddScoped<IResponseRepository, EfResponseRepository>();
            builder.Services.AddScoped<ISurveyRatingRepository, EfSurveyRatingRepository>();
            builder.Services.AddScoped<ISurveyRepository, EfSurveyRepository>();
            builder.Services.AddScoped<IUserRepository, EfUserRepository>();

            builder.Services.AddScoped<IAnswerService, AnswerService>();
            builder.Services.AddScoped<IQuestionService, QuestionService>();
            builder.Services.AddScoped<IResponseService, ResponseService>();
            builder.Services.AddScoped<ISurveyRatingService, SurveyRatingService>();
            builder.Services.AddScoped<ISurveyService, SurveyService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<HateoasModel>();
        }
    }
}
