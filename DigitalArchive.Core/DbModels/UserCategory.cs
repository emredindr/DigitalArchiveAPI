using DigitalArchive.Core.Entities;

namespace DigitalArchive.Core.DbModels;

public class UserCategory : Entity<int>
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
}