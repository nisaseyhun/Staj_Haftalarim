using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
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

    [AllowAnonymous]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IServiceService _serviceService;

        public ServiceController(AppDbContext context, IServiceService serviceService)
        {
            _context = context;
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var data = _serviceService.TGetList().OrderByDescending(x=>x.ServiceDate).Take(8).ToList();
            ViewBag.TotalBlogs = _context.Services.Count();
            return View(data);
        }

        [HttpGet]
        public IActionResult ServiceDetails(int id)
        {
            var values = _serviceService.TGetByID(id);
            if (values == null)
            {
                return NotFound();
            }
            return View(values);
        }


        [HttpGet]
        public IActionResult GetMoreBlogs(int page)
        {
            int pageSize = 8;
            var blogs = _context.Services.Skip(page * pageSize)
                                      .Take(pageSize)
                                      .ToList();

            return PartialView("_BlogPartial", blogs);
        }
    }
}
