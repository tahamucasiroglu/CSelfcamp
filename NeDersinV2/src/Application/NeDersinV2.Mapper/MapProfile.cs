using AutoMapper;
using AutoMapper.Execution;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.Answer;
using NeDersinV2.DTOs.ViewModels.Question;
using NeDersinV2.DTOs.ViewModels.Response;
using NeDersinV2.DTOs.ViewModels.Survey;
using NeDersinV2.DTOs.ViewModels.SurveyRating;
using NeDersinV2.DTOs.ViewModels.User;
using NeDersinV2.Entities.Concrete;


namespace NeDersinV2.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<VM_Create_Answer, Answer>();
            CreateMap<VM_Create_Question, Question>();
            CreateMap<VM_Create_Response, Response>();
            CreateMap<VM_Create_Survey, Survey>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.IsEnd, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.ResponseCount, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.ViewCount, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => 0));
            CreateMap<VM_Create_SurveyRating, SurveyRating>();
            CreateMap<VM_Create_User, User>();

            CreateMap<VM_Update_Answer, Answer>();
            CreateMap<VM_Update_Question, Question>();
            CreateMap<VM_Update_Survey, Survey>();
            CreateMap<VM_Update_User, User>();

            CreateMap<int, Answer>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src));
            CreateMap<int, Question>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src));
            CreateMap<int, Response>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src));
            CreateMap<int, Survey>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src));
            CreateMap<int, SurveyRating>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src));
            CreateMap<int, User>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src));

            CreateMap<Answer, GetAnswerDTO>();
            CreateMap<Question, GetQuestionDTO>();
            CreateMap<Response, GetResponseDTO>();
            CreateMap<Survey, GetSurveyDTO>();
            CreateMap<SurveyRating, GetSurveyRatingDTO>();
            CreateMap<User, GetUserDTO>();
        }
    }
}
