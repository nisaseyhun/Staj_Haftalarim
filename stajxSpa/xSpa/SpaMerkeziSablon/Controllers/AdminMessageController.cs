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
    [Authorize]
    public class AdminMessageController : Controller
    {
        private readonly IMessageService _messageService;

        public AdminMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            var values = _messageService.TGetList().OrderByDescending(m=> m.MessageDate).ToList();
            ViewBag.messageCount = _messageService.TGetList().Count();
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            var values = _messageService.TGetByID(id);
            _messageService.TDelete(values);
            return RedirectToAction("Index", "AdminMessage");
        }
    }
}
