using AutoMapper;
using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.Response;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Services.Base;

namespace NeDersinV2.Services
{
    public sealed class ResponseService : ServiceBase<Response, GetResponseDTO, VM_Create_Response>, IResponseService
    {
        public ResponseService(IResponseRepository repository, IMapper mapper) : base (repository, mapper) { }

        public IReturnModel<GetResponseDTO> GetById(int id)
        {
            IReturnModel<Response> result = repository.Get(r => r.Id == id);
            return ConvertToReturn<GetResponseDTO, Response>(result, mapper);
        }

        public async Task<IReturnModel<GetResponseDTO>> GetByIdAsync(int id)
        {
            IReturnModel<Response> result = await repository.GetAsync(r => r.Id == id);
            return ConvertToReturn<GetResponseDTO, Response>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetResponseDTO>> GetByQuestionId(int questionId)
        {
            IReturnModel<IEnumerable<Response>> result = repository.GetAll(r => r.QuestionId == questionId);
            return ConvertToReturn<GetResponseDTO, Response>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetResponseDTO>>> GetByQuestionIdAsync(int questionId)
        {
            IReturnModel<IEnumerable<Response>> result = await repository.GetAllAsync(r => r.QuestionId == questionId);
            return ConvertToReturn<GetResponseDTO, Response>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetResponseDTO>> GetByUserId(int userId)
        {
            IReturnModel<IEnumerable<Response>> result = repository.GetAll(r => r.UserId == userId);
            return ConvertToReturn<GetResponseDTO, Response>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetResponseDTO>>> GetByUserIdAsync(int userId)
        {
            IReturnModel<IEnumerable<Response>> result = await repository.GetAllAsync(r => r.UserId == userId);
            return ConvertToReturn<GetResponseDTO, Response>(result, mapper);
        }
    }
}
