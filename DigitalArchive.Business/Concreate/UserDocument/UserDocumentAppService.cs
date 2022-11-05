using DigitalArchive.Business.Abstract;
using DigitalArchive.Business.ValidationRules.FluentValidation.UserDocument;
using DigitalArchive.Core.Aspects.AutoFac.Authorize;
using DigitalArchive.Core.Aspects.AutoFac.Validation;
using DigitalArchive.Core.Authorization;
using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Core.Extensions.Linq;
using DigitalArchive.Core.Repositories;
using DigitalArchive.Entities.ViewModels.UserDocumentVM;
using Microsoft.EntityFrameworkCore;

namespace DigitalArchive.Business.Concreate
{
    public class UserDocumentAppService : BaseAppService, IUserDocumentAppService
    {
        private readonly IRepository<UserDocument, int> _userDocumentRepository;
        private readonly IRepository<User, int> _userRepository;
        private readonly IRepository<Document, int> _documentRepository;
        private readonly IRepository<Category, int> _categoryRepository;
        private readonly IRepository<CategoryType, int> _categoryTypeRepository;

        public UserDocumentAppService
            (
            IRepository<UserDocument, int> userDocumentRepository,
            IRepository<User, int> userRepository,
            IRepository<Document, int> documentRepository,
            IRepository<Category, int> categoryRepository,
            IRepository<CategoryType, int> categoryTypeRepository
            )
        {
            _userDocumentRepository = userDocumentRepository;
            _userRepository = userRepository;
            _documentRepository = documentRepository;
            _categoryRepository = categoryRepository;
            _categoryTypeRepository = categoryTypeRepository;
        }
        [AuthorizeAspect(new string[] { AllPermissions.UserDocument_List })]
        public async Task<PagedResult<GetAllUserDocumentInfo>> GetAllUserDocumentByPage(GetAllUserDocumentInput input)
        {
            var categoryIds = await GetParentCategoryIds(input.CategoryId);

            var query = from userDocument in _userDocumentRepository.GetAll()
                        join user in _userRepository.GetAll() on userDocument.UserId equals user.Id
                        join category in _categoryRepository.GetAll() on userDocument.CategoryId equals category.Id
                        join categoryType in _categoryTypeRepository.GetAll() on category.CategoryTypeId equals categoryType.Id
                        join document in _documentRepository.GetAll() on userDocument.DocumentId equals document.Id
                        where !userDocument.IsDeleted && !user.IsDeleted && !category.IsDeleted && !categoryType.IsDeleted
                        && !document.IsDeleted
                        select new { userDocument, user, category, categoryType, document };

            query = query.WhereIf(!string.IsNullOrEmpty(input.SearchText), x => x.document.Name.Contains(input.SearchText))
                         .WhereIf(input.UserId.HasValue, x => x.userDocument.UserId == input.UserId)
                         .WhereIf(categoryIds.Any(), x => categoryIds.Contains(x.category.Id));


            var totalCategoryCount = await query.CountAsync();

            var categories = await query.PageBy(input.SkipCount, input.MaxResultCount)
                .Select(x => new GetAllUserDocumentInfo
                {
                    DocumentUser = Mapper.Map<DocumentUserInfo>(x.user),
                    DocumentCategory = Mapper.Map<DocumentCategoryInfo>(x.category),
                    DocumentInfo = Mapper.Map<DocumentInfo>(x.document),
                    DocumentCategoryType = Mapper.Map<DocumentCategoryTypeInfo>(x.categoryType),
                    DocumentTitle = x.userDocument.DocumentTitle,
                    CreationTime = x.userDocument.CreationTime,
                    UserDocumentId = x.userDocument.DocumentId,

                }).ToListAsync();

            return new PagedResult<GetAllUserDocumentInfo>(totalCategoryCount, categories);
        }


        public async Task<GetAllUserDocumentInfo> GetUserDocumentById(int userDocumentId)
        {
            var query = from userDocument in _userDocumentRepository.GetAll()
                        join user in _userRepository.GetAll() on userDocument.UserId equals user.Id
                        join category in _categoryRepository.GetAll() on userDocument.CategoryId equals category.Id
                        join categoryType in _categoryTypeRepository.GetAll() on category.CategoryTypeId equals categoryType.Id
                        join document in _documentRepository.GetAll() on userDocument.DocumentId equals document.Id
                        where !userDocument.IsDeleted && !user.IsDeleted && !category.IsDeleted && !categoryType.IsDeleted
                        && !document.IsDeleted
                        select new { userDocument, user, category, categoryType, document };

            var userDocumentInfo = await query.FirstOrDefaultAsync(x => x.userDocument.Id == userDocumentId);
            if (userDocumentInfo == null)
            {
                throw new Exception("kayıt bulunamadı");
            }

            var mappedUserDocument = new GetAllUserDocumentInfo()
            {
                DocumentUser = Mapper.Map<DocumentUserInfo>(userDocumentInfo.user),
                DocumentCategory = Mapper.Map<DocumentCategoryInfo>(userDocumentInfo.category),
                DocumentInfo = Mapper.Map<DocumentInfo>(userDocumentInfo.document),
                DocumentTitle = userDocumentInfo.userDocument.DocumentTitle,
                CreationTime = userDocumentInfo.userDocument.CreationTime,
                UserDocumentId = userDocumentInfo.userDocument.Id,

            };
            return mappedUserDocument;
        }

        [AuthorizeAspect(new string[] { AllPermissions.UserDocument_Create })]
        [ValidationAspect(typeof(CreateUserDocumentInputValidator))]
        public async Task CreateUserDocument(CreateUserDocumentInput input)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == input.UserId);
            if (user == null) throw new Exception($"{user.Id} nolu Id degeri bulunamadı");

            var category = await _categoryRepository.FirstOrDefaultAsync(y => y.Id == input.CategoryId);
            if (category == null) throw new Exception($"{category.Id} nolu Id degeri bulunamadı");

            var document = await _documentRepository.FirstOrDefaultAsync(x => x.Id == input.DocumentId);
            if (document == null) throw new Exception($"{document.Id} nolu Id degeri bulunamadı");


            var newUserDocument = Mapper.Map<UserDocument>(input);
            await _userDocumentRepository.InsertAsync(newUserDocument);

        }

        [AuthorizeAspect(new string[] { AllPermissions.UserDocument_Update })]
        [ValidationAspect(typeof(UpdateUserDocumentInputValidator))]
        public async Task UpdateUserDocument(UpdateUserDocumentInput input)
        {
            var userDocument = await _userDocumentRepository.GetAsync(input.UserDocumentId);
            if (userDocument == null) throw new Exception($"{userDocument.Id} nolu Id degeri bulunamadı");


            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == input.UserId);
            if (user == null) throw new Exception($"{user.Id} nolu Id degeri bulunamadı");

            var category = await _categoryRepository.FirstOrDefaultAsync(y => y.Id == input.CategoryId);
            if (category == null) throw new Exception($"{category.Id} nolu Id degeri bulunamadı");

            var document = await _documentRepository.FirstOrDefaultAsync(x => x.Id == input.DocumentId);
            if (document == null) throw new Exception($"{document.Id} nolu Id degeri bulunamadı");



            Mapper.Map(input,userDocument);
            await _userDocumentRepository.UpdateAsync(userDocument);
        }

        [AuthorizeAspect(new string[] { AllPermissions.UserDocument_Delete })]
        public async Task DeleteUserDocument(int userDocumentId)
        {
            var checkUserDocument = await _userRepository.GetAsync(userDocumentId);
            if (checkUserDocument == null)
            {
                throw new Exception($"{userDocumentId} nolu Id degeri bulunamadı");
            }
            checkUserDocument.IsDeleted = true;

            await _userRepository.DeleteAsync(checkUserDocument.Id);
        }



        private async Task<List<int>> GetParentCategoryIds(int? categoryId)
        {
            List<int> categoryIds = new List<int>();
            if (!categoryId.HasValue)
                return categoryIds;

            var categoryInfo = await _categoryRepository.FirstOrDefaultAsync(x => x.Id == categoryId);
            if (categoryInfo != null)
            {
                categoryIds.Add(categoryInfo.Id);
                var child1 = await GetChildCategories(categoryInfo.Id);
                foreach (var item1 in child1)
                {
                    categoryIds.Add(item1.Id);
                    var child2 = await GetChildCategories(item1.Id);
                    foreach (var item2 in child2)
                    {
                        categoryIds.Add(item2.Id);
                        var child3 = await GetChildCategories(item2.Id);
                        foreach (var item3 in child3)
                        {
                            categoryIds.Add(item3.Id);
                        }
                    }
                }
            }

            return categoryIds;
        }

        private async Task<List<Category>> GetChildCategories(int categoryId)
        {
            return await _categoryRepository.GetAll().Where(x => !x.IsDeleted && x.ParentCategoryId == categoryId).ToListAsync();
        }
    }
}
