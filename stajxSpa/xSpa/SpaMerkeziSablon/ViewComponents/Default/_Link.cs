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
    public class _Link : ViewComponent
    {
        private readonly ILinkService _linkService;

        public _Link(ILinkService linkService)
        {
            _linkService = linkService;
        }

        public IViewComponentResult Invoke()
        {
            var data = _linkService.TGetList().OrderBy(x => x.LinlName).ToList();
            return View(data);
        }
    }
}
