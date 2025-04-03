namespace SUPClub.Models
{
    public class HireCategory
    {
        public const int MAX_LENGHT_NAME = 100;
        public const int MAX_LENGHT_IMAGE_URL = 300;
        public const int MAX_LENGHT_CREATE_BY_ID = 36;

        private List<HireSubCategory> _hireSubCategories;
        private List<Equipment> _equipments;

        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? ImageUrl { get; private set; }
        public bool IsActive { get; private set; }
        public string? CreateById { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
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
            string? createById,
            bool isDeleted,
            List<HireSubCategory> hireSubCategories,
            List<Equipment> equipments,
            DateTime createDate,
            DateTime updateDate)
        {
            Name = name;
            ImageUrl = imageUrl;
            IsActive = isActive;
            CreateById = createById;
            IsDeleted = isDeleted;
            _hireSubCategories = hireSubCategories;
            _equipments = equipments;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }
        public HireCategory Update(string? name, string? imageUrl, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_LENGHT_NAME)
            {
                throw new ArgumentException(nameof(name));
            }
            if (imageUrl != null && imageUrl.Length > MAX_LENGHT_IMAGE_URL)
            {
                throw new ArgumentException(nameof(imageUrl));
            }
            Name = name;
            ImageUrl = imageUrl;
            IsActive = isActive;
            UpdateDate = DateTime.UtcNow;  
            return this;

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
            return new HireCategory(name.Trim(), imageUrl, isActive, createById, 
                    false, new(), new(), DateTime.UtcNow, DateTime.UtcNow);

        }
    }
}
