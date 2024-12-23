using Contact_App_MVC_.Models;
using Contact_App_MVC_.Repository;
using Contact_App_MVC_.Service;
using Microsoft.AspNetCore.Mvc;

namespace Contact_App_MVC_.Controllers
{
    public class ContactController : Controller
    {
        ContactRepository contacts = new ContactRepository();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Enter()
        {
            return View("Enter");
        }

        public IActionResult ContactList()
        {
            var contact = contacts.ShowContactList();

            return View("ContactList", contact);
        }

        public IActionResult ContactCard(int ID)
        {
            var contact = contacts.ContactCard(ID);

            return View(contact);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            if (contact != null)
            {
                contacts.AddContact(contact);
            }

            return RedirectToAction("ContactList"); 
        }

        public IActionResult RemoveContact(int ID)
        {
            var contact = contacts.ShowContactList();

            if (contact != null)
            {
                contacts.RemoveContact(ID);

                
            }

            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public IActionResult UpdateContact(int ID)
        {
            var contact = contacts.ContactCard(ID);

            if (contact == null)
            {
                return RedirectToAction("ContactList"); 
            }

            return View(contact);
        }


        [HttpPost]
        public IActionResult UpdateContact(int ID, string name, string surname, string phonenumber)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(phonenumber))
            {
                Console.WriteLine($"Contact Name: {name}, Surname: {surname}, Phone: {phonenumber}");


                contacts.UpdateContact(ID, name, surname, phonenumber);
            }
            else
            {
                Console.WriteLine("Contact parameters are missing or invalid!");
            }

            return RedirectToAction("ContactList");
        }


    }
}
