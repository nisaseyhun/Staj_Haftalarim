using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.ViewsComponents.Default
{
    public class _Footer : ViewComponent
    {
        private readonly IContactService _contactService;

        public _Footer(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var data = _contactService.TGetList();
            return View(data);
        }
    }
}
