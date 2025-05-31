using DataAccesLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.ViewComponents.Default
{
    public class _HomeService : ViewComponent
    {
        private readonly AppDbContext _context;

        public _HomeService(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context.Services.ToList().OrderByDescending(x => x.ServiceDate).Take(4).ToList();
            return View(data);
        }
    }
}
