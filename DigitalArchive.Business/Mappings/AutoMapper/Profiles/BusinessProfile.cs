using AutoMapper;
using DigitalArchive.Core.DbModels;
using DigitalArchive.Entities.UserVM;
using DigitalArchive.Entities.ViewModels.CategoryTypeVM;
using DigitalArchive.Entities.ViewModels.CategoryVM;
using DigitalArchive.Entities.ViewModels.PermissionVM;
using DigitalArchive.Entities.ViewModels.PermissionGroupVM;
using DigitalArchive.Entities.ViewModels.UserDocumentVM;
using DigitalArchive.Entities.ViewModels.UserVM;

namespace DigitalArchive.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            //ReverseMap çift yonlüdönüşümü sağlar.
            //Veritabanına ismen karsılık gelmeyen member için custom ayar yapıldı.
            //CreateMap<User, GetAllUserInfo>().ForMember(k => k.SurnSdame, opt => opt.MapFrom(a => a.Surname)).ReverseMap();
            //User
            CreateMap<GetAllUserInfo, User>().ReverseMap();
            CreateMap<User, CreateUserInput>().ReverseMap();
            CreateMap<User, UpdateUserInput>().ReverseMap();
            CreateMap<User, UserLoginOutput>().ReverseMap();

            //Category            
            CreateMap<Category, GetAllCategoryInfo>().ReverseMap();
            CreateMap<Category, CreateCategoryInput>().ReverseMap();
            CreateMap<Category, UpdateCategoryInput>().ReverseMap();
            CreateMap<Category, GetAllCategoryByGroup>().ReverseMap();

            //CategoryType
            CreateMap<CategoryType, GetAllCategoryTypeInfo>().ReverseMap();
            CreateMap<CategoryType, CreateCategoryTypeInput>().ReverseMap();
            CreateMap<CategoryType, UpdateCategoryTypeInput>().ReverseMap();
            //Permission
            CreateMap<Permission, GetAllPermissionInfo>().ReverseMap();
            CreateMap<Permission, CreatePermissionInput>().ReverseMap();
            CreateMap<Permission, UpdatePermissionInput>().ReverseMap();
            

            //UserDocument
            CreateMap<User, DocumentUserInfo>().ForMember(k=>k.UserId,opt=>opt.MapFrom(a=>a.Id)).ReverseMap();
            CreateMap<Category, DocumentCategoryInfo>().ForMember(k => k.CategoryId, opt => opt.MapFrom(a => a.Id)).ReverseMap();
            CreateMap<Document, DocumentInfo>().ReverseMap();
            CreateMap<CategoryType, DocumentCategoryTypeInfo>().ForMember(k => k.CategoryTpyeId, opt => opt.MapFrom(a => a.Id)).ReverseMap();
            CreateMap<UserDocument, CreateUserDocumentInput>().ReverseMap();
            CreateMap<UserDocument, UpdateUserDocumentInput>().ForMember(k=>k.UserDocumentId,opt=>opt.MapFrom(a=>a.Id)).ReverseMap();

            //PermissionGroup

            CreateMap<PermissionGroup, GetAllPermissionGroupInfo>().ReverseMap();
            CreateMap<PermissionGroup, CreatePermissionGroupInput>().ReverseMap();
            CreateMap<PermissionGroup, UpdatePermissionGroupInput>().ReverseMap();

            //UserCategory

           
        }
    }
}
