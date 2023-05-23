using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.UserDocumentVM;

namespace DigitalArchive.Business.Abstract
{
    public interface IUserDocumentAppService
    {
        Task<PagedResult<GetAllUserDocumentInfo>> GetAllUserDocumentByPage(GetAllUserDocumentInput input);
        Task<ListResult<GetAllUserDocumentInfo>> GetAllUserDocumentList(GetAllUserDocumentInput input);
        Task<GetAllUserDocumentInfo> GetUserDocumentById(int userDocumentId);
        Task CreateUserDocument(CreateUserDocumentInput input);
        Task UpdateUserDocument(UpdateUserDocumentInput input);
        Task DeleteUserDocument(int userDocumentId);
    }
}
