using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Controllers
{

    [AllowAnonymous]
    public class GalaryController : Controller
    {
        private readonly IGalaryService _galaryService;

        public GalaryController(IGalaryService galaryService)
        {
            _galaryService = galaryService;
        }

        public IActionResult Index()
        {
            var data = _galaryService.TGetList().OrderByDescending(x=> x.GalaryDate).ToList();
            return View(data);
        }
    }
}
