using ContactsApp.Data;
using ContactsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var contactsList = await _context.Contacts.ToListAsync();

            return View(contactsList);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var contactExist =  await _context.Contacts.FindAsync(id);
            if (contactExist == null)
            {
                return NotFound();
            }

            return View(contactExist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid) {

                contact.CreationDate = DateTime.Now;

                await _context.Contacts.FindAsync(contact);
                await _context.SaveChangesAsync();

                return RedirectToAction("Read");
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var contactExist = await _context.Contacts.FindAsync(id);
            if (contactExist == null)
            {
                return NotFound();
            }

            return View(contactExist);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Contact contact)
        {
            var contactExist = await _context.Contacts.FindAsync(contact.Id);
            if (contactExist == null)
            {
                return NotFound();
            }

            _context.Update(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction("Read");
        }


        [HttpDelete]
        public async Task<JsonResult> Delete(int id)
        {
            var contactExist = await  _context.Contacts.FindAsync(id);
            if (contactExist == null)
            {
                return Json(new { response = false });
            }

            _context.Contacts.Remove(contactExist);
            await _context.SaveChangesAsync();

            return Json(new { response = true });
        }
    }
}
