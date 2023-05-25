using AlfaSoft.Models;
using AlfaSoft.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlfaSoft.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IContactRepository _contactRepository;

        public HomeController(ILogger<HomeController> logger, IContactRepository contactRepository)
        {
            _logger = logger;
            _contactRepository = contactRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contactRepository.GetAllAsync());
        }
    }
}