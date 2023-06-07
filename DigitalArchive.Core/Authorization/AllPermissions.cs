namespace DigitalArchive.Core.Authorization
{
    public static class AllPermissions
    {
        //User
        public const string Administration_User_List = "Administration.User.List";
        public const string Administration_User_Create = "Administration.User.Create";
        public const string Administration_User_Edit = "Administration.User.Edit";
        public const string Administration_User_Delete = "Administration.User.Delete";
        //Category
        public const string Category_List = "Category.List";
        public const string Category_Create = "Category.Create";
        public const string Category_Update = "Category.Update";
        public const string Category_Delete = "Category.Delete";
        //CategoryType
        public const string CategoryType_List = "CategoryType.List";
        public const string CategoryType_Create = "CategoryType.Create";
        public const string CategoryType_Update = "CategoryType.Update";
        public const string CategoryType_Delete = "CategoryType.Delete";
        //UserDocument
        public const string UserDocument_List = "UserDocument.List";
        public const string UserDocument_Create = "UserDocument.Create";
        public const string UserDocument_Update = "UserDocument.Update";
        public const string UserDocument_Delete = "UserDocument.Delete";
        //UserPermission
        public const string UserPermission_List = "UserPermission.List";
        public const string UserPermission_CreateOrUpdate = "UserPermission.CreateOrUpdate";
        public const string UserPermission_Delete = "UserPermission.Delete";
        //Permission 
        public const string Permission_List = "Permission.List";
        public const string Permission_Create = "Permission.Create";
        public const string Permission_Update = "Permission.Update";
        public const string Permission_Delete = "Permission.Delete";
        //PermissionGroup
        public const string PermissionGroup_List = "PermissionGroup.List";
        public const string PermissionGroup_Create = "PermissionGroup.Create";
        public const string PermissionGroup_Update = "PermissionGroup.Update";
        public const string PermissionGroup_Delete = "PermissionGroup.Delete";
        //Document
        public const string Document_List = "Document.List";
        public const string Document_Create = "Document.Create";
        public const string Document_Update = "Document.Update";
        public const string Document_Delete = "Document.Delete";
        //UserCategory
        public const string UserCategory_CreateOrUpdate = "UserCategory.CreateOrUpdate";
    }
}
