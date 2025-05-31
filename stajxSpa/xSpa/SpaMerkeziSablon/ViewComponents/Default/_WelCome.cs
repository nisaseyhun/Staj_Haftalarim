using DataAccesLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.ViewComponents
{
    public class _WelCome:ViewComponent
    {
        private readonly AppDbContext _context;

        public _WelCome(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _context.Homes.ToListAsync();
            return View(data);
        }
    }
}
