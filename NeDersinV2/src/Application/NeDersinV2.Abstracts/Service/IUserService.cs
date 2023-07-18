using NeDersinV2.DTOs.Abstract;
using NeDersinV2.Abstracts.Service.Base;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.User;

namespace NeDersinV2.Abstracts.Service
{
    public interface IUserService : IService<GetUserDTO, VM_Create_User, VM_Update_User>
    {
        public IReturnModel<GetUserDTO> GetById(int id);
        public Task<IReturnModel<GetUserDTO>> GetByIdAsync(int id);
        public IReturnModel<IEnumerable<GetUserDTO>> GetByName(string name);
        public Task<IReturnModel<IEnumerable<GetUserDTO>>> GetByNameAsync(string name);
        public IReturnModel<GetUserDTO> GetByEmail(string email);
        public Task<IReturnModel<GetUserDTO>> GetByEmailAsync(string email);
        public IReturnModel<GetUserDTO> GetByPhone(string phone);
        public Task<IReturnModel<GetUserDTO>> GetByPhoneAsync(string phone);
        public IReturnModel<IEnumerable<GetUserDTO>> GetByStatus(string status);
        public Task<IReturnModel<IEnumerable<GetUserDTO>>> GetByStatusAsync(string status);
        public IReturnModel<bool> CheckPassword(int id, string password);
        public IReturnModel<bool> CheckPassword(string email, string password);
        public IReturnModel<bool> CheckPassword(GetUserDTO user, string password);
        public Task<IReturnModel<bool>> CheckPasswordAsync(int id, string password);
        public Task<IReturnModel<bool>> CheckPasswordAsync(string email, string password);
        public Task<IReturnModel<bool>> CheckPasswordAsync(GetUserDTO user, string password);

    }
}
