using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Controllers
{
    [Authorize]
    public class AdminContactController : Controller
    {
        private readonly IContactService _contactService;

        public AdminContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _contactService.TAdd(contact);
            return RedirectToAction("Index", "AdminContact");
        }

        [HttpPost]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetByID(id);
            _contactService.TDelete(values);
            return RedirectToAction("Index", "AdminContact");
        }

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var values = _contactService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return RedirectToAction("Index", "AdminContact");
        }

    }
}
