using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExercicesMVC.Controllers
{
    public class ContactsController : Controller
    {
        private static List<Contact> contacts = new List<Contact>
        {
            new Contact { Id = 1, Name = "Alice", Email = "alice@example.com" },
            new Contact { Id = 2, Name = "Bob", Email = "bob@example.com" },
            new Contact { Id = 3, Name = "Charlie", Email = "charlie@example.com" }
        };

        public IActionResult Index()
        {
            ViewBag.Title = "Liste des contacts";
            ViewData["Description"] = "Voici la liste des contacts disponibles.";
            return View(contacts); 
        }

        public IActionResult Details(int id)
        {
            var contact = contacts.Find(c => c.Id == id); 
            if (contact == null)
            {
                return NotFound(); 
            }

            ViewBag.Title = "Détails du contact";
            ViewData["Description"] = $"Détails pour le contact {contact.Name}.";
            return View(contact); 
        }

        public IActionResult Add()
        {
            ViewBag.Title = "Ajouter un contact";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Id = contacts.Count + 1; 
                contacts.Add(contact);
                return RedirectToAction("Index"); 
            }

            ViewBag.Title = "Ajouter un contact";
            return View(contact); 
        }
    }

    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
