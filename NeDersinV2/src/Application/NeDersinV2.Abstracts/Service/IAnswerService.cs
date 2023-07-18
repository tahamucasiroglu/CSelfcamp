using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.Answer;
using NeDersinV2.Abstracts.Service.Base;
using NeDersinV2.Returns.Abstract;

namespace NeDersinV2.Abstracts.Service
{
    public interface IAnswerService : IService<GetAnswerDTO, VM_Create_Answer, VM_Update_Answer>
    {

        public IReturnModel<IEnumerable<GetAnswerDTO>> GetByQuestionId(int id);
        public Task<IReturnModel<IEnumerable<GetAnswerDTO>>> GetByQuestionIdAsync(int id);
    }
}
