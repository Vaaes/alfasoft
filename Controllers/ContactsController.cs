using AlfaSoft.Models;
using AlfaSoft.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlfaSoft.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            return View(contact);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);

            if (contact is null)
            {
                return null;
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactRepository.UpdateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var contact = await _contactRepository.GetByIdAsync(id.Value);
            return View(contact);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _contactRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            try
            {
                await _contactRepository.CreateAsync(contact);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
