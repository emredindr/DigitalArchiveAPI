using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Entities.ViewModels.CategoryTypeVM;

namespace DigitalArchive.Business.Abstract
{
    public interface ICategoryTypeAppService
    {
        Task<PagedResult<GetAllCategoryTypeInfo>> GetAllCategoryTypeByPage(GetAllCategoryTypeInput input);
        Task<ListResult<GetAllCategoryTypeInfo>> GetCategoryTypeList();
        Task CreateCategoryType(CreateCategoryTypeInput input);
        Task UpdateCategoryType(UpdateCategoryTypeInput input);
        Task DeleteCategoryType(int categoryTypeId);
    }
}
