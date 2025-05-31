using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.ViewComponents.Default
{
    public class _Navbar: ViewComponent
    {
        private readonly IHomeService _homeService;

        public _Navbar(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IViewComponentResult Invoke()
        {
            var data = _homeService.TGetList();
            return View(data);
        }
    }
}
