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
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AdminAboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var values = _aboutService.TGetList();
            return View(values);
        }

        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return RedirectToAction("Index", "AdminAbout");
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _aboutService.TAdd(about);
            return RedirectToAction("Index", "AdminAbout");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            _aboutService.TUpdate(about);
            return RedirectToAction("Index", "AdminAbout");
        }
    }
}
