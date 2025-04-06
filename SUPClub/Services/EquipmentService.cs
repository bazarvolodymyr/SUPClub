using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using SUPClub.Data.Entities;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Infrastructure;
using SUPClub.Models;
using SUPClub.Models.DTO.EquipmentDTO;
using SUPClub.Services.Abstract;

namespace SUPClub.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IHireSubCategoryRepository _hireSubCategoryRepository;
        private readonly IHireCategoryRepository _hireCategoryRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ImageHandler _imageHandler;
        public EquipmentService(IHireSubCategoryRepository hireSubCategoryRepository,
                                IHireCategoryRepository hireCategoryRepository,
                                IEquipmentRepository equipmentRepository,
                                UserManager<AppUser> userManager,
                                ImageHandler imageHandler)
        {
            _hireSubCategoryRepository = hireSubCategoryRepository;
            _hireCategoryRepository = hireCategoryRepository;
            _equipmentRepository = equipmentRepository;
            _userManager = userManager;
            _imageHandler = imageHandler;
        }
        public async Task<List<HireCategory>> CategoriesListAsync()
        {
            var categories = await _hireCategoryRepository.GetAllAsync();
            return categories.ToList();
        }

        public async Task<IEnumerable<EquipmentInfoVM>> GetAllInfoAsync()
        {
            var equipmentsInfo = new List<EquipmentInfoVM>();
            var equipments = await _equipmentRepository.GetAllAsync();
            if (equipments == null)
            {
                return equipmentsInfo;
            }

            foreach (var equipment in equipments)
            {
                string categoryName = "";
                string subCategoryName = "";
                string userName = "";
                var category = await _hireCategoryRepository.GetByIdAsync(equipment.HireCategoryId);
                if (category != null)
                {
                    categoryName = category.Name!;
                }
                var subCategory = await _hireSubCategoryRepository.GetByIdAsync(equipment.HireSubCategoryId);
                if (subCategory != null)
                {
                    subCategoryName = subCategory.Name!;
                }
                if (equipment.CreateById != null)
                {
                    var user = await _userManager.FindByIdAsync(equipment.CreateById);
                    userName = user!.UserName ?? "";
                }
                equipmentsInfo.Add(new EquipmentInfoVM()
                {
                    Id = equipment.Id,
                    Name = equipment.Name,
                    Quantity = equipment.Quantity,
                    Price = equipment.Price,
                    SubCategoryName = subCategoryName,
                    CategoryName = categoryName,
                    CreateAt = userName,
                    IsActive = equipment.IsActive,
                    CreateDate = equipment.CreateDate,
                    UpdateDate = equipment.UpdateDate
                });
            }
            return equipmentsInfo;
        }
        public async Task<EditEquipmentVM?> GetEditModelAsync(int id)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(id);
            if (equipment == null)
            {
                return null;
            }
            return new EditEquipmentVM()
            {
                Id = equipment.Id,
                Name = equipment.Name,
                DescriptionShort = equipment.DescriptionShort,
                Description = equipment.Description,
                Photo = equipment.Photo,
                Quantity = equipment.Quantity,
                Price = equipment.Price,
                HireCategoryId = equipment.HireCategoryId,
                HireSubCategoryId = equipment.HireSubCategoryId,
                IsActive = equipment.IsActive
            };
        }

        public async Task<string?> SaveAsync(EditEquipmentVM editEquipment, 
                                        string? userId, IFormFile? titleImageFile)
        {
            if (editEquipment.Price < 0)
            {
                return "Ціна не може бути менше 0";
            }
            if (editEquipment.Quantity < 0)
            {
                return "Кількість не може бути менше 0";
            }
            Equipment? equipment;
            if (titleImageFile != null)
            {
                editEquipment.Photo = titleImageFile.FileName;
                await _imageHandler.SaveImg(titleImageFile);
            }
            if (editEquipment.Id == default)
            {
                equipment = Equipment.Create(editEquipment.Name, editEquipment.DescriptionShort,
                    editEquipment.Description, editEquipment.Photo, editEquipment.Quantity, 
                    editEquipment.Price, editEquipment.HireCategoryId, editEquipment.HireSubCategoryId,
                    userId, editEquipment.IsActive);
            }
            else
            {
                equipment = await _equipmentRepository.GetByIdAsync(editEquipment.Id);
                if (equipment == null)
                {
                    return "Спорядження не знайддено";
                }
                equipment.Update(editEquipment.Name, editEquipment.DescriptionShort,
                    editEquipment.Description, editEquipment.Photo, editEquipment.Quantity,
                    editEquipment.Price, editEquipment.HireCategoryId, editEquipment.HireSubCategoryId,
                    editEquipment.IsActive);
            }
            await _equipmentRepository.SaveAsync(equipment);
            return null;
        }

        public Task<string?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
