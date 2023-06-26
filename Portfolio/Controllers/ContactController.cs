using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        ContactDataAccessLayer contactDataAccessLayer = new ContactDataAccessLayer();
        public IActionResult Index()
        {
            List<Contact> contact = new List<Contact>();
            contact = contactDataAccessLayer.GetAllContacts().ToList();

            return View(contact);
        }

        // to create a contact

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactDataAccessLayer.AddContact(contact);
                return RedirectToAction("create");
            }
            return View(contact);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Contact contact = contactDataAccessLayer.GetContactData(id);

            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }


        // delete contact
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Contact contact = contactDataAccessLayer.GetContactData(id);

            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            contactDataAccessLayer.DeleteContact(id);
            return RedirectToAction("Index");
        }

    }
}
