
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {

        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // İlk 8 blogu çekiyoruz
            var values = _context.Blogs.Include(x => x.AppUser).OrderByDescending(x=>x.Created).Take(8).ToList();
            ViewBag.TotalBlogs = _context.Blogs.Count(); // Toplam blog sayısını ViewBag'e koyuyoruz
            return View(values);
        }

        public IActionResult Post(int id)
        {
            var blog = _context.Blogs.Include(x => x.AppUser).FirstOrDefault(x => x.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [HttpGet]
        public IActionResult GetMoreBlogs(int page)
        {
            int pageSize = 8;
            var blogs = _context.Blogs.Include(x => x.AppUser)
                                      .Skip(page * pageSize)
                                      .Take(pageSize)
                                      .ToList();

            return PartialView("_BlogPartial", blogs);
        }
    }
}
