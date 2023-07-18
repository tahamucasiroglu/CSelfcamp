using AutoMapper;
using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.Question;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Services.Base;

namespace NeDersinV2.Services
{
    public sealed class QuestionService : ServiceBase<Question, GetQuestionDTO, VM_Create_Question, VM_Update_Question>, IQuestionService
    {

        public QuestionService(IQuestionRepository repository, IMapper mapper) : base(repository, mapper) { }


        public IReturnModel<GetQuestionDTO> GetById(int id)
        {
            IReturnModel<Question> result = repository.Get(r => r.Id == id);
            return ConvertToReturn<GetQuestionDTO, Question>(result, mapper);
        }

        public async Task<IReturnModel<GetQuestionDTO>> GetByIdAsync(int id)
        {
            IReturnModel<Question> result = await repository.GetAsync(r => r.Id == id);
            return ConvertToReturn<GetQuestionDTO, Question>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetQuestionDTO>> GetQuestionsBySurveyId(int surveyId)
        {
            IReturnModel<IEnumerable<Question>> result = repository.GetAll(r => r.SurveyId == surveyId);
            return ConvertToReturn<GetQuestionDTO, Question>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetQuestionDTO>>> GetQuestionsBySurveyIdAsync(int surveyId)
        {
            IReturnModel<IEnumerable<Question>> result = await repository.GetAllAsync(r => r.SurveyId == surveyId);
            return ConvertToReturn<GetQuestionDTO, Question>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetQuestionDTO>> GetsBySurveyId(int surveyId)
        {
            throw new NotImplementedException();
        }

        public Task<IReturnModel<IEnumerable<GetQuestionDTO>>> GetsBySurveyIdAsync(int surveyId)
        {
            throw new NotImplementedException();
        }
    }
}
