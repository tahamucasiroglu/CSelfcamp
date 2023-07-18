using AutoMapper;
using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.Answer;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Services.Base;

namespace NeDersinV2.Services
{
    public sealed class AnswerService : ServiceBase<Answer, GetAnswerDTO, VM_Create_Answer, VM_Update_Answer>, IAnswerService
    {
        public AnswerService(IAnswerRepository repository, IMapper mapper) : base(repository, mapper) { }

        public IReturnModel<IEnumerable<GetAnswerDTO>> GetByQuestionId(int id)
        {
            IReturnModel<IEnumerable<Answer>> result = repository.GetAll(r => r.QuestionId == id);
            return ConvertToReturn<GetAnswerDTO, Answer>(result, mapper);
        }
        public async Task<IReturnModel<IEnumerable<GetAnswerDTO>>> GetByQuestionIdAsync(int id)
        {
            IReturnModel<IEnumerable<Answer>> result = await repository.GetAllAsync(r => r.QuestionId == id);
            return ConvertToReturn<GetAnswerDTO, Answer>(result, mapper);
        }

    }
}
