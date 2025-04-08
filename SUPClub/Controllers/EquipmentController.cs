using Microsoft.AspNetCore.Mvc;
using SUPClub.Services.Abstract;

namespace SUPClub.Controllers
{
    public class EquipmentController : Controller
    {  
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }
        public async Task<IActionResult> ShowEquipment(int id)
        {
            var equipment = await _equipmentService.GetViewByIdAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return View(equipment);
        }
    }
}
