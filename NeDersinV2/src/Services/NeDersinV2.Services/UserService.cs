using AutoMapper;
using NeDersinV2.Abstracts.Repository;
using NeDersinV2.Abstracts.Service;
using NeDersinV2.DTOs.DTOs.GetModels;
using NeDersinV2.DTOs.ViewModels.User;
using NeDersinV2.Entities.Concrete;
using NeDersinV2.Extensions;
using NeDersinV2.Returns.Abstract;
using NeDersinV2.Returns.Concrete;
using NeDersinV2.Services.Base;

namespace NeDersinV2.Services
{
    public sealed class UserService : ServiceBase<User, GetUserDTO, VM_Create_User, VM_Update_User>, IUserService
    {
        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }



        public IReturnModel<bool> CheckPassword(int id, string password)
        {
            IReturnModel<User> result = repository.Get(r => r.Id == id);
            Console.WriteLine($"status = {result.Status} data = {result.Data?.ToJson()} mesage = {result.Message}");
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(result.Message,result.Exception); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public IReturnModel<bool> CheckPassword(string email, string password)
        {
            IReturnModel<User> result = repository.Get(r => r.Email == email);
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(result.Message, result.Exception); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public IReturnModel<bool> CheckPassword(GetUserDTO user, string password)
        {
            IReturnModel<User> result = repository.Get(r => r.Id == user.Id);
            if (!result.Status || result.Data == null) { result = repository.Get(r => r.Email == user.Email); }
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(result.Message, result.Exception); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public async Task<IReturnModel<bool>> CheckPasswordAsync(int id, string password)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Id == id);
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(result.Message, result.Exception); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public async Task<IReturnModel<bool>> CheckPasswordAsync(string email, string password)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Email == email);
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(result.Message, result.Exception); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public async Task<IReturnModel<bool>> CheckPasswordAsync(GetUserDTO user, string password)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Id == user.Id);
            if (!result.Status || result.Data == null) { result = await repository.GetAsync(r => r.Email == user.Email); }
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public IReturnModel<GetUserDTO> GetByEmail(string email)
        {
            IReturnModel<User> result = repository.Get(r => r.Email == email);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public async Task<IReturnModel<GetUserDTO>> GetByEmailAsync(string email)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Email == email);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public IReturnModel<GetUserDTO> GetById(int id)
        {
            IReturnModel<User> result = repository.Get(r => r.Id == id);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public async Task<IReturnModel<GetUserDTO>> GetByIdAsync(int id)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Id == id);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetUserDTO>> GetByName(string name)
        {
            IReturnModel<IEnumerable<User>> result = repository.GetAll(r => r.Name.Contains(name));
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetUserDTO>>> GetByNameAsync(string name)
        {
            IReturnModel<IEnumerable<User>> result = await repository.GetAllAsync(r => r.Name.Contains(name));
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public IReturnModel<GetUserDTO> GetByPhone(string phone)
        {
            IReturnModel<User> result = repository.Get(r => r.Phone == phone);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public async Task<IReturnModel<GetUserDTO>> GetByPhoneAsync(string phone)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Phone == phone);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetUserDTO>> GetByStatus(string status)
        {
            IReturnModel<IEnumerable<User>> result = repository.GetAll(r => r.UserStatus == status);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetUserDTO>>> GetByStatusAsync(string status)
        {
            IReturnModel<IEnumerable<User>> result = await repository.GetAllAsync(r => r.UserStatus == status);
            return ConvertToReturn<GetUserDTO, User>(result, mapper);
        }
    }
}
