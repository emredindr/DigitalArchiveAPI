using DigitalArchive.Core.Entities;

namespace DigitalArchive.Business.Abstract.User.Dtos
{
    public class GetUserResponse :Entity<int>
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
    }
}
