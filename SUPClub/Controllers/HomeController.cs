using Microsoft.AspNetCore.Mvc;
using SUPClub.Services.Abstract;

namespace SUPClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactService _contactService;
        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Contacts()
        {
            return View(await _contactService.GetAllAsync());
        }
    }
}
