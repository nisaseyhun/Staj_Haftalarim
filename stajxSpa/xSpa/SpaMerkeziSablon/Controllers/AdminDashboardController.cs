using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaMerkeziSablon.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Controllers
{
    [Authorize]
    public class AdminDashboardController : Controller
    {
        private readonly IHomeService _homeService;

        public AdminDashboardController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            var values = _homeService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDashboard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDashboard(AddHome p)
        {
            Home s = new Home();
            if (p.HomeImage != null)
            {
                var extension = Path.GetExtension(p.HomeImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/home/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.HomeImage.CopyTo(stream);
                s.HomeImage = newimagename;
            }
            s.HomeTitle = p.HomeTitle;
            s.HomeDescriptions = p.HomeDescriptions;
            s.HomeWelCome = p.HomeWelCome;
            s.HomePhone = p.HomePhone;
            s.instagramURl = p.instagramURl;
            s.BannerUrl = p.BannerUrl;
            _homeService.TAdd(s);
            return RedirectToAction("Index", "AdminDashboard");
        }


        [HttpGet]
        public IActionResult UpdateHome(int id)
        {
            var service = _homeService.TGetByID(id);
            if (service == null)
            {
                return NotFound();
            }

            var model = new UpdateHome
            {
                Id = service.HomeID,
                HomeTitle = service.HomeTitle,
                HomePhone = service.HomePhone,
                HomeDescriptions = service.HomeDescriptions,
                HomeWelCome = service.HomeWelCome,
                instagramURl = service.instagramURl,
                BannerUrl = service.BannerUrl,
                ExistingImagePath = service.HomeImage // Mevcut resim dosyası yolunu sakla
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateHome(UpdateHome model)
        {
            if (ModelState.IsValid)
            {
                var service = _homeService.TGetByID(model.Id);
                if (service == null)
                {
                    return NotFound();
                }

                service.HomeTitle = model.HomeTitle;
                service.HomeDescriptions = model.HomeDescriptions;
                service.HomePhone = model.HomePhone;
                service.HomeWelCome = model.HomeWelCome;
                service.instagramURl = model.instagramURl;
                service.BannerUrl = model.BannerUrl;

                if (model.NewImageFile != null)
                {
                    // Eski resim dosyasını sil
                    if (!string.IsNullOrEmpty(service.HomeImage))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/home/", service.HomeImage);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Yeni resim dosyasını yükle
                    var extension = Path.GetExtension(model.NewImageFile.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/home/", newImageName);
                    using (var stream = new FileStream(newImagePath, FileMode.Create))
                    {
                        model.NewImageFile.CopyTo(stream);
                    }

                    // Yeni resim dosyası bilgisi güncellenir
                    service.HomeImage = newImageName;
                }

                _homeService.TUpdate(service);

                return RedirectToAction("Index", "AdminDashboard");
            }

            return View(model);
        }


        public IActionResult DeleteHome(int id)
        {
            var service = _homeService.TGetByID(id);
            if (service == null)
            {
                return NotFound();
            }

            // Resim dosyası silinir
            if (!string.IsNullOrEmpty(service.HomeImage))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/home/", service.HomeImage);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            // Servis silinir
            _homeService.TDelete(service);

            return RedirectToAction("Index", "AdminDashboard");
        }
    }
}
