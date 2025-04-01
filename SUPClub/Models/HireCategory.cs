namespace SUPClub.Models
{
    public class HireCategory
    {
        public const int MAX_LENGHT_NAME = 100;
        public const int MAX_LENGHT_IMAGE_URL = 300;
        public const int MAX_LENGHT_CREATE_BY_ID = 36;

        private List<HireSubCategory> _hireSubCategories;
        private List<Equipment> _equipments;

        public int Id { get; }
        public string? Name { get; }
        public string? ImageUrl { get; }
        public bool? IsActive { get; }
        public string? CreateById { get; }
        public bool? IsDeleted { get; }
        public DateTime CreatedDate { get; }
        public DateTime UpdateDate { get; }
        public List<HireSubCategory> HireSubCategories 
        { 
            get { return _hireSubCategories; } 
        }
        public List<Equipment> Equipments 
        {
            get { return _equipments; } 
        }
        private HireCategory(
            string? name,
            string? imageUrl,
            bool isActive,
            string? createById)
        {
            Name = name;
            ImageUrl = imageUrl;
            IsActive = isActive;
            CreateById = createById;
            IsDeleted = false;
            _hireSubCategories = new();
            _equipments = new();
            CreatedDate = UpdateDate = DateTime.Now;
        }
        public static HireCategory Create(string? name, string? imageUrl, string? createById, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_LENGHT_NAME)
            {
                throw new ArgumentException(nameof(name));
            }
            if (imageUrl !=null && imageUrl.Length > MAX_LENGHT_IMAGE_URL)
            {
                throw new ArgumentException(nameof(imageUrl));
            }
            if (string.IsNullOrWhiteSpace(createById) || createById.Length > MAX_LENGHT_CREATE_BY_ID)
            {
                throw new ArgumentException(nameof(createById));
            }
            return new HireCategory(name.Trim(), imageUrl, isActive, createById);

        }
    }
}
