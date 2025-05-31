using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.ViewComponents.Default
{
    public class _HomeBlog : ViewComponent
    {
        private readonly IBlogService _blogService;

        public _HomeBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var data = _blogService.TGetList().OrderByDescending(b => b.Created).Take(4).ToList();
            return View(data);
        }
    }
}
