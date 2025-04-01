using SUPClub.Data.Entities;

namespace SUPClub.Models
{
    public class Equipment
    {
        public const int MAX_LENGHT_NAME = 100;
        public const int MAX_LENGHT_DESCRIPTION_SHORT = 3000;
        public const int MAX_LENGHT_DESCRIPTION = 100000;
        public const int MAX_LENGHT_PHOTO_URL = 300;
        public const int MAX_LENGHT_CREATE_BY_ID = 36;

        public int Id { get; }
        public string? Name { get; }
        public string? DescriptionShort { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; }
        public int? Quantity { get; }
        public decimal? Price { get; }
        public int? HireSubCategoryId { get; }
        public int? HireCategoryId { get; }
        public bool? IsActive { get; }
        public string? CreateById { get; }
        public bool? IsDeleted { get; }
        public DateTime CreatedDate { get; }
        public DateTime UpdateDate { get; }
        
        private Equipment(
            string? name,
            string? descriptionShort,
            string? description,
            string? photo,
            int? quantity,
            decimal? price,
            int? hireSubCategoryId,
            int? hireCategoryId,
            bool isActive,
            string? createById)
        {
            Name = name;
            DescriptionShort = descriptionShort;
            Description = description;
            Photo = photo;
            Quantity = quantity;
            Price = price;
            HireSubCategoryId = hireSubCategoryId;
            HireCategoryId = hireCategoryId;
            CreateById = createById;
            IsActive = isActive;
            IsDeleted = false;
            CreatedDate = UpdateDate = DateTime.Now;
        }
        public static Equipment Create(string? name, string? descriptionShort,
                string? description, string? photo, int? quantity, decimal? price,
                int? hireCategoryId, int? hireSubCategoryId, string? createById, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_LENGHT_NAME)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (descriptionShort != null && descriptionShort.Length > MAX_LENGHT_DESCRIPTION_SHORT)
            {
                throw new ArgumentNullException(nameof(descriptionShort));
            }
            if (description != null && description.Length > MAX_LENGHT_DESCRIPTION)
            {
                throw new ArgumentNullException(nameof(description));
            }
            if (photo != null && photo.Length > MAX_LENGHT_PHOTO_URL)
            {
                throw new ArgumentNullException(nameof(photo));
            }
            if (string.IsNullOrWhiteSpace(createById) || createById.Length > MAX_LENGHT_CREATE_BY_ID)
            {
                throw new ArgumentNullException(nameof(createById));
            }
            return new Equipment(name.Trim(), descriptionShort,description,photo,quantity,
                price,hireSubCategoryId, hireCategoryId, isActive, createById);

        }
    }
}
