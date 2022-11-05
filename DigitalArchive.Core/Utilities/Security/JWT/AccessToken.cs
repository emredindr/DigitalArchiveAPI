namespace DigitalArchive.Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExprationTime { get; set; }
    }
}
