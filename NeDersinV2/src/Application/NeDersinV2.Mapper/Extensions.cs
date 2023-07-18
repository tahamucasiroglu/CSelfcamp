using AutoMapper;
using NeDersinV2.DTOs.Abstract;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.Answer;
using NeDersinV2.DTOs.ViewModels.Question;
using NeDersinV2.DTOs.ViewModels.Response;
using NeDersinV2.DTOs.ViewModels.Survey;
using NeDersinV2.DTOs.ViewModels.SurveyRating;
using NeDersinV2.DTOs.ViewModels.User;
using NeDersinV2.Entities.Abstract;
using NeDersinV2.Entities.Concrete;

namespace NeDersinV2.Mapper
{
    static public class Extensions
    {
        private static IEnumerable<T> ConvertToEntity<T>(IEnumerable<I_VM> entity, IMapper mapper)
            where T : class, IEntity
            => mapper.Map<IEnumerable<T>>(entity);
        private static T ConvertToEntity<T>(I_VM entity, IMapper mapper)
            where T : class, IEntity
            => mapper.Map<T>(entity);

        private static IEnumerable<T> ConvertToDto<T>(IEnumerable<IEntity> entity, IMapper mapper)
            where T : class, IGetDTO
            => mapper.Map<IEnumerable<T>>(entity);
        private static T ConvertToDto<T>(IEntity entity, IMapper mapper)
            where T : class, IGetDTO
            => mapper.Map<T>(entity);

        public static IEnumerable<T> ConvertToEntityCustom<T>(this IEnumerable<I_VM> entity, IMapper mapper)
            where T : class, IEntity =>
            ConvertToEntity<T>(entity, mapper);
        public static T ConvertToEntityCustom<T>(this I_VM entity, IMapper mapper)
            where T : class, IEntity =>
            ConvertToEntity<T>(entity, mapper);

        public static IEnumerable<T> ConvertToDtoCustom<T>(this IEnumerable<IEntity> entity, IMapper mapper)
            where T : class, IGetDTO
            => ConvertToDto<T>(entity, mapper);
        public static T ConvertToDtoCustom<T>(this IEntity entity, IMapper mapper)
            where T : class, IGetDTO
            => ConvertToDto<T>(entity, mapper);


        public static IEnumerable<T> ConvertToEntityCustom<T>(this IEnumerable<int> entity, IMapper mapper)
            where T : class, IEntity
            => mapper.Map<IEnumerable<T>>(entity);

        public static T ConvertToEntityCustom<T>(this int entity, IMapper mapper)
            where T : class, IEntity
            => mapper.Map<T>(entity);


        public static IEnumerable<Answer> ConvertToEntity(this IEnumerable<VM_Create_Answer> entity, IMapper mapper)
            => ConvertToEntity<Answer>(entity, mapper);
        public static IEnumerable<Question> ConvertToEntity(this IEnumerable<VM_Create_Question> entity, IMapper mapper)
            => ConvertToEntity<Question>(entity, mapper);
        public static IEnumerable<Response> ConvertToEntity(this IEnumerable<VM_Create_Response> entity, IMapper mapper)
            => ConvertToEntity<Response>(entity, mapper);
        public static IEnumerable<Survey> ConvertToEntity(this IEnumerable<VM_Create_Survey> entity, IMapper mapper)
           => ConvertToEntity<Survey>(entity, mapper);
        public static IEnumerable<SurveyRating> ConvertToEntity(this IEnumerable<VM_Create_SurveyRating> entity, IMapper mapper)
           => ConvertToEntity<SurveyRating>(entity, mapper);
        public static IEnumerable<User> ConvertToEntity(this IEnumerable<VM_Create_User> entity, IMapper mapper)
           => ConvertToEntity<User>(entity, mapper);


        public static IEnumerable<Answer> ConvertToEntity(this IEnumerable<VM_Update_Answer> entity, IMapper mapper)
            => ConvertToEntity<Answer>(entity, mapper);
        public static IEnumerable<Question> ConvertToEntity(this IEnumerable<VM_Update_Question> entity, IMapper mapper)
            => ConvertToEntity<Question>(entity, mapper);
        public static IEnumerable<Survey> ConvertToEntity(this IEnumerable<VM_Update_Survey> entity, IMapper mapper)
           => ConvertToEntity<Survey>(entity, mapper);
        public static IEnumerable<User> ConvertToEntity(this IEnumerable<VM_Update_User> entity, IMapper mapper)
           => ConvertToEntity<User>(entity, mapper);




        public static Answer ConvertToEntity(this VM_Create_Answer entity, IMapper mapper)
            => ConvertToEntity<Answer>(entity, mapper);
        public static Question ConvertToEntity(this VM_Create_Question entity, IMapper mapper)
            => ConvertToEntity<Question>(entity, mapper);
        public static Response ConvertToEntity(this VM_Create_Response entity, IMapper mapper)
            => ConvertToEntity<Response>(entity, mapper);
        public static Survey ConvertToEntity(this VM_Create_Survey entity, IMapper mapper)
           => ConvertToEntity<Survey>(entity, mapper);
        public static SurveyRating ConvertToEntity(this VM_Create_SurveyRating entity, IMapper mapper)
           => ConvertToEntity<SurveyRating>(entity, mapper);
        public static User ConvertToEntity(this VM_Create_User entity, IMapper mapper)
           => ConvertToEntity<User>(entity, mapper);


        public static Answer ConvertToEntity(this VM_Update_Answer entity, IMapper mapper)
            => ConvertToEntity<Answer>(entity, mapper);
        public static Question ConvertToEntity(this VM_Update_Question entity, IMapper mapper)
            => ConvertToEntity<Question>(entity, mapper);
        public static Survey ConvertToEntity(this VM_Update_Survey entity, IMapper mapper)
           => ConvertToEntity<Survey>(entity, mapper);
        public static User ConvertToEntity(this VM_Update_User entity, IMapper mapper)
           => ConvertToEntity<User>(entity, mapper);



        public static IEnumerable<GetAnswerDTO> ConvertToDto(this IEnumerable<Answer> entity, IMapper mapper)
           => ConvertToDto<GetAnswerDTO>(entity, mapper);
        public static IEnumerable<GetQuestionDTO> ConvertToDto(this IEnumerable<Question> entity, IMapper mapper)
           => ConvertToDto<GetQuestionDTO>(entity, mapper);
        public static IEnumerable<GetResponseDTO> ConvertToDto(this IEnumerable<Response> entity, IMapper mapper)
           => ConvertToDto<GetResponseDTO>(entity, mapper);
        public static IEnumerable<GetSurveyDTO> ConvertToDto(this IEnumerable<Survey> entity, IMapper mapper)
           => ConvertToDto<GetSurveyDTO>(entity, mapper);
        public static IEnumerable<GetSurveyRatingDTO> ConvertToDto(this IEnumerable<SurveyRating> entity, IMapper mapper)
           => ConvertToDto<GetSurveyRatingDTO>(entity, mapper);
        public static IEnumerable<GetUserDTO> ConvertToDto(this IEnumerable<User> entity, IMapper mapper)
           => ConvertToDto<GetUserDTO>(entity, mapper);

        public static GetAnswerDTO ConvertToDto(this Answer entity, IMapper mapper)
           => ConvertToDto<GetAnswerDTO>(entity, mapper);
        public static GetQuestionDTO ConvertToDto(this Question entity, IMapper mapper)
           => ConvertToDto<GetQuestionDTO>(entity, mapper);
        public static GetResponseDTO ConvertToDto(this Response entity, IMapper mapper)
           => ConvertToDto<GetResponseDTO>(entity, mapper);
        public static GetSurveyDTO ConvertToDto(this Survey entity, IMapper mapper)
           => ConvertToDto<GetSurveyDTO>(entity, mapper);
        public static GetSurveyRatingDTO ConvertToDto(this SurveyRating entity, IMapper mapper)
           => ConvertToDto<GetSurveyRatingDTO>(entity, mapper);
        public static GetUserDTO ConvertToDto(this User entity, IMapper mapper)
           => ConvertToDto<GetUserDTO>(entity, mapper);
    }
}
