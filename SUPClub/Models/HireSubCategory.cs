namespace SUPClub.Models
{
    public class HireSubCategory
    {
        public const int MAX_LENGHT_NAME = 100;
        public const int MAX_LENGHT_CREATE_BY_ID = 36;

        private List<Equipment> _equipments;
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public int HireCategoryId { get; private set; }
        public bool IsActive { get; private set; }
        public string? CreateById { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public List<Equipment> Equipments
        {
            get { return _equipments; }
        }
        private HireSubCategory(
            string? name,
            int hireCategoryId,
            bool isActive,
            string? createById,
            bool isDeleted,
            List<Equipment> equipments,
            DateTime createDate,
            DateTime updateDate)
        {
            Name = name;
            HireCategoryId = hireCategoryId;
            IsActive = isActive;
            CreateById = createById;
            IsDeleted = isDeleted;
            _equipments = equipments;
            CreatedDate = createDate;
            UpdateDate = updateDate;
        }
        public HireSubCategory Update(string? name, int hireCategoryId, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_LENGHT_NAME)
            {
                throw new ArgumentException(nameof(name));
            }
            
            Name = name.Trim();
            HireCategoryId = hireCategoryId;
            IsActive = isActive;
            UpdateDate = DateTime.Now;
            return this;

        }
        public static HireSubCategory Create(string? name, int hireCategoryId, 
            bool isActive, string? createById)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_LENGHT_NAME)
            {
                throw new ArgumentException(nameof(name));
            }
            if (string.IsNullOrWhiteSpace(createById) || createById.Length > MAX_LENGHT_CREATE_BY_ID)
            {
                throw new ArgumentException(nameof(createById));
            }

            return new HireSubCategory(name.Trim(), hireCategoryId, isActive, createById,
                                            false, new(), DateTime.Now, DateTime.Now);
        }
    }
}
