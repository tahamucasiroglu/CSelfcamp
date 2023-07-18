using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.Survey;
using NeDersinV2.Abstracts.Service.Base;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Constants.Const;

namespace NeDersinV2.Abstracts.Service
{
    public interface ISurveyService : IService<GetSurveyDTO, VM_Create_Survey, VM_Update_Survey>
    {
        public IReturnModel<GetSurveyDTO> GetById(int id);
        public Task<IReturnModel<GetSurveyDTO>> GetByIdAsync(int id);
        public IReturnModel<GetSurveyDTO> GetByAddress(Guid address);
        public Task<IReturnModel<GetSurveyDTO>> GetByAddressAsync(Guid address);
        public IReturnModel<IEnumerable<GetSurveyDTO>> GetByTitle(string name);
        public Task<IReturnModel<IEnumerable<GetSurveyDTO>>> GetByTitleAsync(string name);
        public IReturnModel<IEnumerable<GetSurveyDTO>> GetByStartDate(DateTime dateTime, bool isEnd);
        public Task<IReturnModel<IEnumerable<GetSurveyDTO>>> GetByStartDateAsync(DateTime dateTime, bool isEnd);
        public IReturnModel<GetSurveyWithQuestions> GetByIdWithQuestions(int id);
        public Task<IReturnModel<GetSurveyWithQuestions>> GetByIdWithQuestionsAsync(int id);
        public IReturnModel<GetSurveyWithQuestions> GetByAddressWithQuestions(Guid address);
        public Task<IReturnModel<GetSurveyWithQuestions>> GetByAddressWithQuestionsAsync(Guid address);
        public IReturnModel<GetSurveyWithQuestionAndAnswers> GetByIdWithQuestionsAndAnswers(int id);
        public Task<IReturnModel<GetSurveyWithQuestionAndAnswers>> GetByIdWithQuestionsAndAnswersAsync(int id);
        public IReturnModel<GetSurveyWithQuestionAndAnswers> GetByAddressWithQuestionsAndAnswers(Guid address);
        public Task<IReturnModel<GetSurveyWithQuestionAndAnswers>> GetByAddressWithQuestionAndAnswersAsync(Guid address);
        public IReturnModel<GetSurveyPaginationDTO> GetByPagination(int pageNum, int pageSize, string order, string shortType);
        public Task<IReturnModel<GetSurveyPaginationDTO>> GetByPaginationAsync(int pageNum, int pageSize, string order, string shortType);


    }
}
