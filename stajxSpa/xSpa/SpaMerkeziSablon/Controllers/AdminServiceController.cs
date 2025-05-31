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
    public class AdminServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public AdminServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.TGetList().OrderByDescending(x=>x.ServiceDate).ToList();
            ViewBag.serviceCount = _serviceService.TGetList().Count();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(AddService p)
        {
            Service s = new Service();
            if (p.ImgUrl != null)
            {
                var extension = Path.GetExtension(p.ImgUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImgUrl.CopyTo(stream);
                s.ImgUrl = newimagename;
            }
            s.ServiceName = p.ServiceName;
            s.ServiceDetails = p.ServiceDetails;
            s.ServiceDescription = p.ServiceDescription;
            s.ServiceDate = DateTime.Now;
            _serviceService.TAdd(s);
            return RedirectToAction("Index", "AdminService");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var service = _serviceService.TGetByID(id);
            if (service == null)
            {
                return NotFound();
            }

            var model = new UpdateSerice
            {
                Id = service.ServiceID,
                ServiceName = service.ServiceName,
                ServiceDetails = service.ServiceDetails,
                ServiceDescription = service.ServiceDescription,
                ExistingImagePath = service.ImgUrl // Mevcut resim dosyası yolunu sakla
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateService(UpdateSerice model)
        {
            if (ModelState.IsValid)
            {
                var service = _serviceService.TGetByID(model.Id);
                if (service == null)
                {
                    return NotFound();
                }

                service.ServiceName = model.ServiceName;
                service.ServiceDetails = model.ServiceDetails;
                service.ServiceDescription = model.ServiceDescription;

                if (model.NewImageFile != null)
                {
                    // Eski resim dosyasını sil
                    if (!string.IsNullOrEmpty(service.ImgUrl))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/", service.ImgUrl);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Yeni resim dosyasını yükle
                    var extension = Path.GetExtension(model.NewImageFile.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/", newImageName);
                    using (var stream = new FileStream(newImagePath, FileMode.Create))
                    {
                        model.NewImageFile.CopyTo(stream);
                    }

                    // Yeni resim dosyası bilgisi güncellenir
                    service.ImgUrl = newImageName;
                }

                _serviceService.TUpdate(service);

                return RedirectToAction("Index", "AdminService");
            }

            return View(model);
        }


        public IActionResult DeleteService(int id)
        {
            var service = _serviceService.TGetByID(id);
            if (service == null)
            {
                return NotFound();
            }

            // Resim dosyası silinir
            if (!string.IsNullOrEmpty(service.ImgUrl))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/", service.ImgUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            // Servis silinir
            _serviceService.TDelete(service);

            return RedirectToAction("Index", "AdminService");
        }

    }
}
