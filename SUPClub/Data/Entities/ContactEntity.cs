using SUPClub.Models.Enum;

namespace SUPClub.Data.Entities
{
    public class ContactEntity
    {
        public int Id { get; set; }
        public string? IconUrl { get; set; }
        public string? Text { get; set; }
        public string? Source { get; set; }
        public ContactType? Type { get; set; }
        public int Rank { get; set; }
    }
}
