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

        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? DescriptionShort { get; private set; }
        public string? Description { get; private set; }
        public string? Photo { get; private set; }
        public int? Quantity { get; private set; }
        public decimal? Price { get; private set; }
        public int? HireSubCategoryId { get; private set; }
        public int? HireCategoryId { get; private set; }
        public bool IsActive { get; private set; }
        public string? CreateById { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        
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
            string? createById,
            bool isDeleted,
            DateTime createDate,
            DateTime updateDate)
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
            IsDeleted = isDeleted;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }
        public Equipment Update(string? name, string? descriptionShort,
                string? description, string? photo, int? quantity, decimal? price,
                int? hireCategoryId, int? hireSubCategoryId, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_LENGHT_NAME)
            {
                throw new ArgumentException(nameof(name));
            }
            if (descriptionShort != null && descriptionShort.Length > MAX_LENGHT_DESCRIPTION_SHORT)
            {
                throw new ArgumentException(nameof(descriptionShort));
            }
            if (description != null && description.Length > MAX_LENGHT_DESCRIPTION)
            {
                throw new ArgumentException(nameof(description));
            }
            if (photo != null && photo.Length > MAX_LENGHT_PHOTO_URL)
            {
                throw new ArgumentException(nameof(photo));
            }
            if (quantity < 0)
            {
                throw new ArgumentException(nameof(quantity));
            }
            if (price < 0)
            {
                throw new ArgumentException(nameof(photo));
            }
            Name = name.Trim();
            DescriptionShort = descriptionShort;
            Description = description;
            Photo = photo;
            Quantity = quantity;
            Price = price;
            HireCategoryId = hireCategoryId;
            HireSubCategoryId = hireSubCategoryId;
            IsActive = isActive;
            return this;
        }
        public static Equipment Create(string? name, string? descriptionShort,
                string? description, string? photo, int? quantity, decimal? price,
                int? hireCategoryId, int? hireSubCategoryId, string? createById, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_LENGHT_NAME)
            {
                throw new ArgumentException (nameof(name));
            }
            if (descriptionShort != null && descriptionShort.Length > MAX_LENGHT_DESCRIPTION_SHORT)
            {
                throw new ArgumentException(nameof(descriptionShort));
            }
            if (description != null && description.Length > MAX_LENGHT_DESCRIPTION)
            {
                throw new ArgumentException(nameof(description));
            }
            if (photo != null && photo.Length > MAX_LENGHT_PHOTO_URL)
            {
                throw new ArgumentException(nameof(photo));
            }
            if (quantity < 0)
            {
                throw new ArgumentException(nameof(quantity));
            }
            if (price < 0)
            {
                throw new ArgumentException(nameof(photo));
            }
            if (string.IsNullOrWhiteSpace(createById) || createById.Length > MAX_LENGHT_CREATE_BY_ID)
            {
                throw new ArgumentException(nameof(createById));
            }
            return new Equipment(name.Trim(), descriptionShort,description,photo,quantity,
                                 price, hireSubCategoryId, hireCategoryId, isActive, 
                                 createById, false, DateTime.Now, DateTime.Now);
        }
    }
}
