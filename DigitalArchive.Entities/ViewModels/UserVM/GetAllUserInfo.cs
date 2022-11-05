namespace DigitalArchive.Entities.ViewModels.UserVM
{
    //public class GetAllUsersOutput
    //{
    //    //class içindeki listler  otomatik newlenmez newlemek gerekir 
    //    public List<GetAllUserInfo> Users { get; set; }
    //    public int TotalCount { get; set; }
    //}
    public class GetAllUserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }




    }
}
