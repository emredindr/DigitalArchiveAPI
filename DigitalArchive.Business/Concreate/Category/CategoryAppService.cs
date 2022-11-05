using DigitalArchive.Business.Abstract;
using DigitalArchive.Business.ValidationRules.FluentValidation.Category;
using DigitalArchive.Core.Aspects.AutoFac.Authorize;
using DigitalArchive.Core.Aspects.AutoFac.Validation;
using DigitalArchive.Core.Authorization;
using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Core.Extensions.Linq;
using DigitalArchive.Core.Repositories;
using DigitalArchive.Entities.ViewModels.CategoryVM;
using Microsoft.EntityFrameworkCore;

namespace DigitalArchive.Business.Concreate
{
    public class CategoryAppService : BaseAppService, ICategoryAppService
    {
        private readonly IRepository<Category, int> _categoryRepository;
        private readonly IRepository<CategoryType, int> _categoryTypeRepository;

        public CategoryAppService
            (
                IRepository<Category, int> categoryRepository,
                IRepository<CategoryType, int> categoryTypeRepository
            )
        {
            _categoryRepository = categoryRepository;
            _categoryTypeRepository = categoryTypeRepository;
        }

        public async Task<ListResult<GetAllCategoryInfo>> GetCategoryList(GetCategoryListInput input)
        {
            var query = _categoryRepository.GetAll().Where(x => !x.IsDeleted);
            query = query.WhereIf(!string.IsNullOrEmpty(input.SearchText), x => x.Name.Contains(input.SearchText))
                         .WhereIf(input.CategoryTypeId.HasValue, y => y.CategoryTypeId == input.CategoryTypeId)
                         .WhereIf(input.ParentCategoryId.HasValue, y => y.ParentCategoryId == input.ParentCategoryId);

            var mappedCategoryList = Mapper.Map<List<GetAllCategoryInfo>>(await query.ToListAsync());
            return new ListResult<GetAllCategoryInfo>(mappedCategoryList);
        }
        public async Task<GetAllCategoryInfo> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(x => x.Id == categoryId && !x.IsDeleted);
            if (category == null)
            {
                throw new Exception($"{categoryId} nolu Id degeri bulunamadı");
            }
            var mappedCategory = Mapper.Map<GetAllCategoryInfo>(category);
            return mappedCategory;
        }

        [AuthorizeAspect(new string[] { AllPermissions.Category_List })]
        public async Task<PagedResult<GetAllCategoryInfo>> GetAllCategoryByPage(GetAllCategoryInput input)
        {
            var query = from category in _categoryRepository.GetAll()
                        join categoryType in _categoryTypeRepository.GetAll()
                        on category.CategoryTypeId equals categoryType.Id
                        where !category.IsDeleted && !categoryType.IsDeleted
                        select new GetAllCategoryInfo
                        {
                            Name = category.Name,
                            Id = category.Id,
                            CategoryTypeId = categoryType.Id,
                            CategoryTypeName = categoryType.Name,
                            ParentCategoryId = category.ParentCategoryId
                        };


            query = query.WhereIf(!string.IsNullOrEmpty(input.SearchText), x => x.Name.Contains(input.SearchText));

            var totalCategoryCount = await query.CountAsync();

            var categories = await query.PageBy(input.SkipCount, input.MaxResultCount).ToListAsync();

            return new PagedResult<GetAllCategoryInfo>(totalCategoryCount, categories);
        }

        [AuthorizeAspect(new string[] { AllPermissions.Category_Create })]
        [ValidationAspect(typeof(CreateCategoryInputValidator))]
        public async Task CreateCategory(CreateCategoryInput input)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(x => x.Name == input.Name && x.CategoryTypeId == input.CategoryTypeId && x.IsDeleted == false);
            if (category != null)
            {
                throw new Exception("Hata! Aynı kategory ismine aynı kategori tipi zaten var");
            }
            var newCategories = Mapper.Map<Category>(input);
            await _categoryRepository.InsertAsync(newCategories);

        }

        [AuthorizeAspect(new string[] { AllPermissions.Category_Update })]
        [ValidationAspect(typeof(UpdateCategoryInputValidator))]
        public async Task UpdateCategory(UpdateCategoryInput input)
        {
            var checkCategory = await _categoryRepository.GetAsync(input.Id);
            if (checkCategory == null)
            {
                throw new Exception($"{input.Id} nolu Id degeri bulunamadı");
            }

            var category = await _categoryRepository.FirstOrDefaultAsync(x => x.Name == input.Name && x.CategoryTypeId == input.CategoryTypeId && x.IsDeleted == false);
            if (category != null)
            {
                if (category.Id != checkCategory.Id)
                {
                    throw new Exception("Aynı isimle aktif permission oldugu icin guncellenemedi. ");
                }
            }
            //checkUser.Name = updateUserInput.Name;
            //var user = Mapper.Map<User>(updateUserInput);

            Mapper.Map(input, checkCategory);
            await _categoryRepository.UpdateAsync(checkCategory);

        }

        [AuthorizeAspect(new string[] { AllPermissions.Category_Delete })]
        public async Task DeleteCategory(int id)
        {
            var checkCategory = await _categoryRepository.GetAsync(id);
            if (checkCategory == null)
            {
                throw new Exception($"{id} nolu Id degeri bulunamadı");
            }
            checkCategory.IsDeleted = true;
            await _categoryRepository.UpdateAsync(checkCategory);
        }


    }
}
