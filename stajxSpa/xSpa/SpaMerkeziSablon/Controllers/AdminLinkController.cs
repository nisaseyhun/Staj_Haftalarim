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
    public class AdminLinkController : Controller
    {
        private readonly ILinkService _linkService;

        public AdminLinkController(ILinkService linkService)
        {
            _linkService = linkService;
        }

        public IActionResult Index()
        {
            var values = _linkService.TGetList().OrderBy(x=>x.LinlName).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateLink()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateLink(Link link)
        {
            _linkService.TAdd(link);
            return RedirectToAction("Index", "AdminLink");
        }

        [HttpGet]
        public IActionResult UpdateLink(int id)
        {
            var values = _linkService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateLink(Link link)
        {
            _linkService.TUpdate(link);
            return RedirectToAction("Index", "AdminLink");
        }
        [HttpPost]
        public IActionResult DeleteLink(int id)
        {
            var result = _linkService.TGetByID(id);
            _linkService.TDelete(result);
            return RedirectToAction("Index", "AdminLink");
        }
    }
}
