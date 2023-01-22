using DigitalArchive.Business.Abstract;
using DigitalArchive.Business.ValidationRules.FluentValidation.User;
using DigitalArchive.Core.Aspects.AutoFac.Authorize;
using DigitalArchive.Core.Aspects.AutoFac.Validation;
using DigitalArchive.Core.Authorization;
using DigitalArchive.Core.DbModels;
using DigitalArchive.Core.Dto.Response;
using DigitalArchive.Core.Extensions.Linq;
using DigitalArchive.Core.Repositories;
using DigitalArchive.Core.Utilities.Security.JWT;
using DigitalArchive.Entities.Enums;
using DigitalArchive.Entities.UserVM;
using DigitalArchive.Entities.ViewModels.UserVM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DigitalArchive.Business.Concreate
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly IRepository<User, int> _userRepository;
        private readonly IUserPermissionAppService _userPermissionAppService;
        private readonly ILogger<UserAppService> _logger;


        public UserAppService(
            IJwtAuthenticationManager jwtAuthenticationManager,
            IRepository<User, int> userRepository,
            IUserPermissionAppService userPermissionAppService,
            ILogger<UserAppService> logger
            )
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _userRepository = userRepository;
            _userPermissionAppService = userPermissionAppService;
            _logger = logger;
        }

        [ValidationAspect(typeof(UserLoginInputValidator))]
        public async Task<UserLoginOutput> Login(UserLoginInput input)
        {
            var userCheck = await _userRepository.GetAsync(x => x.Email == input.Email);
            if (userCheck == null)
                throw new Exception($"{input.Email} mail adresine eş kayıt bulunamadı");

            if (userCheck.Password != input.Password)
                throw new Exception("Hatalı parola");

            var userPermissionList = await _userPermissionAppService.GetUserPermissions(userCheck.Id);

            var accessToken = _jwtAuthenticationManager.CreateToken(userCheck, userPermissionList);

            var mappedItem = Mapper.Map<UserLoginOutput>(userCheck);
            mappedItem.Token = accessToken.Token;
            return mappedItem;
        }


        public async Task<GetAllUserInfo> GetUserById(int userId)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == userId);
            if (user == null)
            {
                throw new Exception($"{userId} nolu Id degeri bulunamadı");
            }
            var mappedUser = Mapper.Map<GetAllUserInfo>(user);
            return mappedUser;
        }

        public async Task<ListResult<GetAllUserInfo>> GetUserList()
        {
            var query = await _userRepository.GetAll().Where(x => !x.IsDeleted).ToListAsync();
            var newUsers = Mapper.Map<List<GetAllUserInfo>>(query);

            return new ListResult<GetAllUserInfo>(newUsers);
        }

        [AuthorizeAspect(new string[] { AllPermissions.Administration_User_List })]
        public async Task<PagedResult<GetAllUserInfo>> GetAllUsersByPage(GetAllUserInput input)
        {
            //var result = new GetAllUsersOutput();
            _logger.Log(LogLevel.Information, "Success :))");
            var query = _userRepository.GetAll().Where(x => !x.IsDeleted);

            query = query.WhereIf(input.IsActive == UserStatusEnum.Active, x => x.IsActive)
                         .WhereIf(input.IsActive == UserStatusEnum.Passive, x => !x.IsActive)
                         .WhereIf(!string.IsNullOrEmpty(input.SearchText), x => x.UserName.Contains(input.SearchText) || x.Email.Contains(input.SearchText));


            #region AmeleIfBlogu
            //if (!string.IsNullOrEmpty(input.SearchText))
            //{
            //    query = query.Where(x => x.UserName.Contains(input.SearchText) || x.Email.Contains(input.SearchText));
            //}

            //if (input.IsActive == UserStatus.Active)
            //{
            //    query = query.Where(x => x.IsActive);
            //}

            //if (input.IsActive == UserStatus.Passive)
            //{
            //    query = query.Where(x => !x.IsActive);
            //}
            #endregion

            var totalUserCount = await query.CountAsync();
            //linq ile kod fazlalığı ortadan kaldırıldı.
            //var users = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            var users = query.PageBy(input.SkipCount, input.MaxResultCount).ToList();
            var newUsers = Mapper.Map<List<GetAllUserInfo>>(users);
            #region MapperOld
            //var newUsers = new List<GetAllUserInfo>();
            //foreach (var user in users)
            //{
            //    newUsers.Add(new GetAllUserInfo
            //    {
            //        Id = user.Id,
            //        UserName = user.UserName,
            //        Email = user.Email,
            //    });
            //}
            ////result.TotalCount = totalUserCount;
            #endregion
            return new PagedResult<GetAllUserInfo>(totalUserCount, newUsers);
        }


        [AuthorizeAspect(new string[] { AllPermissions.Administration_User_Create })]
        [ValidationAspect(typeof(CreateUserInputValidator))]
        public async Task CreateUser(CreateUserInput createUserInput)
        {
            var newUser = Mapper.Map<User>(createUserInput);
            newUser.IsActive = false;

            await _userRepository.InsertAsync(newUser);
        }

        [AuthorizeAspect(new string[] { AllPermissions.Administration_User_Edit })]
        [ValidationAspect(typeof(UpdateUserInputValidator))]
        public async Task UpdateUser(UpdateUserInput updateUserInput)
        {

            var checkUser = await _userRepository.GetAsync(updateUserInput.Id);
            if (checkUser == null)
            {
                throw new Exception($"{updateUserInput.Id} nolu Id degeri bulunamadı");
            }
            //checkUser.Name = updateUserInput.Name;
            //var user = Mapper.Map<User>(updateUserInput);
            Mapper.Map(updateUserInput, checkUser);
            await _userRepository.UpdateAsync(checkUser);
        }

        [AuthorizeAspect(new string[] { AllPermissions.Administration_User_Delete })]
        public async Task DeleteUser(int userId)
        {
            var checkUser = await _userRepository.GetAsync(userId);
            if (checkUser == null)
            {
                throw new Exception($"{userId} nolu Id degeri bulunamadı");
            }
            checkUser.IsDeleted = true;

            await _userRepository.DeleteAsync(checkUser.Id);
        }
    }
}
