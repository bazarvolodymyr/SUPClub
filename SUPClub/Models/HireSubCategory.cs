namespace SUPClub.Models
{
    public class HireSubCategory
    {
        public const int MAX_LENGHT_NAME = 100;
        public const int MAX_LENGHT_CREATE_BY_ID = 36;

        private List<Equipment> _equipments;
        public int Id { get; }
        public string? Name { get; }
        public int HireCategoryId { get; }
        public bool? IsActive { get; }
        public string? CreateById { get; }
        public bool? IsDeleted { get; }
        public DateTime CreatedDate { get; }
        public DateTime UpdateDate { get; }
        public List<Equipment> Equipments
        {
            get { return _equipments; }
        }
        private HireSubCategory(
            string? name,
            int hireCategoryId,
            bool isActive,
            string? createById)
        {
            Name = name;
            HireCategoryId = hireCategoryId;
            IsActive = isActive;
            CreateById = createById;
            IsDeleted = false;
            _equipments = new();
            CreatedDate = UpdateDate = DateTime.Now;
        }
        public static HireSubCategory Create(string? name, int hireCategoryId, 
            bool isActive, string? createById)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_LENGHT_NAME)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (string.IsNullOrWhiteSpace(createById) || createById.Length > MAX_LENGHT_CREATE_BY_ID)
            {
                throw new ArgumentNullException(nameof(createById));
            }

            return new HireSubCategory(name.Trim(), hireCategoryId, isActive, createById);
        }
    }
}
