using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.Response;
using NeDersinV2.Abstracts.Service.Base;
using NeDersinV2.Returns.Abstract;

namespace NeDersinV2.Abstracts.Service
{
    public interface IResponseService : IService<GetResponseDTO, VM_Create_Response>
    {
        public IReturnModel<GetResponseDTO> GetById(int id);
        public Task<IReturnModel<GetResponseDTO>> GetByIdAsync(int id);
        public IReturnModel<IEnumerable<GetResponseDTO>> GetByUserId(int userId);
        public Task<IReturnModel<IEnumerable<GetResponseDTO>>> GetByUserIdAsync(int userId);
        public IReturnModel<IEnumerable<GetResponseDTO>> GetByQuestionId(int questionId);
        public Task<IReturnModel<IEnumerable<GetResponseDTO>>> GetByQuestionIdAsync(int questionId);
    }
}
