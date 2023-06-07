using DigitalArchive.Business.Abstract.User.Dtos;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.UserVM;
using DigitalArchive.Entities.ViewModels.UserVM;

namespace DigitalArchive.Business.Abstract
{
    public interface IUserAppService
    {
        Task<GetAllUserInfo> GetUserById(int userId);
        Task<GetAllUserInfo> GetCurrentUserInfo();
        Task<PagedResult<GetAllUserInfo>> GetAllUsersByPage(GetAllUserInput input);
        Task<ListResult<GetAllUserInfo>> GetUserList(GetAllUserInput input);
        Task<UserLoginOutput> Login(UserLoginInput input);
        Task CreateUser(CreateUserInput input);
        Task UpdateUser(UpdateUserInput input);
        Task UpdateCurrentUserInfo(UpdateUserInput updateUserInput);
        Task DeleteUser(int userId);
    }
}
