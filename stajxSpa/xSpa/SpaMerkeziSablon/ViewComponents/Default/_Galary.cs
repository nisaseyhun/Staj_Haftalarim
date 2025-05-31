using DataAccesLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.ViewComponents.Default
{
    public class _Galary: ViewComponent
    {
        private readonly AppDbContext _context;

        public _Galary(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var images =  _context.Galaries.OrderByDescending(x=> x.GalaryDate).Take(16).ToList();
            return View(images);
        }
    }
}
