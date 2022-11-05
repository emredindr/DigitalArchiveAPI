namespace DigitalArchive.Entities.ViewModels.UserVM
{
    public class CreateUserInput
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
