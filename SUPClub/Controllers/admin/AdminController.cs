using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SUPClub.Models;
using SUPClub.Services.Abstract;

namespace SUPClub.Controllers.admin
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IContactService _contactService;
        public AdminController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ShowContacts()
        {
            return View(await _contactService.GetAllAsync());
        }
        [HttpGet]
        public async Task<IActionResult> EditContact(int id)
        {
            if (id == default)
            {
                return View(new Contact());
            }
            var contact = await _contactService.GetByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> EditContact(Contact contact, IFormFile titleImageFile)
        {
            await _contactService.SaveAsync(contact, titleImageFile);
            return RedirectToAction("ShowContacts");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _contactService.DeleteAsync(id);
            return RedirectToAction("ShowContacts");
        }
    }
}
