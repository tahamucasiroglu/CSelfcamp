using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.Question;
using NeDersinV2.Abstracts.Service.Base;
using NeDersinV2.Returns.Abstract;

namespace NeDersinV2.Abstracts.Service
{
    public interface IQuestionService : IService<GetQuestionDTO, VM_Create_Question, VM_Update_Question>
    {
        public IReturnModel<GetQuestionDTO> GetById(int id);
        public Task<IReturnModel<GetQuestionDTO>> GetByIdAsync(int id);
        public IReturnModel<IEnumerable<GetQuestionDTO>> GetsBySurveyId(int surveyId);
        public Task<IReturnModel<IEnumerable<GetQuestionDTO>>> GetsBySurveyIdAsync(int surveyId);
    }
}
