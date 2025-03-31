namespace SUPClub.Data.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string? CreateById { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
