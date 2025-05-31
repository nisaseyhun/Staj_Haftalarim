using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaMerkeziSablon.Models;
using System;
using System.IO;
using System.Linq;

namespace SpaMerkeziSablon.Controllers
{
    [Authorize]
    public class AdminGalaryController : Controller
    {
        private readonly IGalaryService _galaryService;

        public AdminGalaryController(IGalaryService galaryService)
        {
            _galaryService = galaryService;
        }

        public IActionResult Index()
        {
            var values = _galaryService.TGetList().OrderByDescending(x=>x.GalaryDate).ToList();
            ViewBag.galaryCount = _galaryService.TGetList().Count();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGalary()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGalary(AddGalary p)
        {
            Galary s = new Galary();
            if (p.GalaryImg != null)
            {
                var extension = Path.GetExtension(p.GalaryImg.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/galary/", newimagename);

                // Using block to ensure the stream is closed after writing
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    p.GalaryImg.CopyTo(stream);
                }

                s.GalaryImg = newimagename;
            }
            s.GalaryDate = DateTime.Now;
            _galaryService.TAdd(s);
            return RedirectToAction("Index", "AdminGalary");
        }

        public IActionResult DeleteGalary(int id)
        {
            var service = _galaryService.TGetByID(id);
            if (service == null)
            {
                return NotFound();
            }

            // Resim dosyası silinir
            if (!string.IsNullOrEmpty(service.GalaryImg))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/galary/", service.GalaryImg);
                if (System.IO.File.Exists(imagePath))
                {
                    try
                    {
                        // Attempt to delete the file
                        System.IO.File.Delete(imagePath);
                    }
                    catch (IOException ex)
                    {
                        // Log the exception or handle it accordingly
                        Console.WriteLine("IOException: " + ex.Message);
                        // Optionally, provide feedback to the user/admin
                        return StatusCode(500, "Error deleting file. Please try again later.");
                    }
                }
            }

            // Servis silinir
            _galaryService.TDelete(service);

            return RedirectToAction("Index", "AdminGalary");
        }
    }
}
