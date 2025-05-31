using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaMerkeziSablon.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpaMerkeziSablon.Controllers
{
    [Authorize]
    public class AdminBlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBlogService _blogService;

        public AdminBlogController(AppDbContext context, IBlogService blogService)
        {
            _context = context;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var values = _context.Blogs.Include(x => x.AppUser).ToList().OrderByDescending(x=>x.Created).ToList();
            ViewBag.blogCount = _context.Blogs.Count();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddBlog(AddBlogModel p)
        {
            // Kullanıcı kimliğini al
            var adminUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Kullanıcı kimliğini int'e çevir
            if (int.TryParse(adminUserId, out int userId))
            {
                Blog s = new Blog();

                // Eğer resim varsa işle
                if (p.Image != null)
                {
                    var extension = Path.GetExtension(p.Image.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogImage/", newImageName);

                    // Resmi kaydet
                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        p.Image.CopyTo(stream);
                    }

                    // Resim yolu Blog nesnesine ekle
                    s.ImagePath = newImageName;
                }

                // Diğer Blog özelliklerini ayarla
                s.Title = p.Title;
                s.SubTitle = p.Description;
                s.Content = p.DetailDescription;
                s.Created = DateTime.Now;
                s.AppUserID = userId;

                try
                {
                    _blogService.TAdd(s);
                    return RedirectToAction("Index", "AdminBlog");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Blog eklenirken bir hata oluştu.");

                }
            }
            ModelState.AddModelError("", "Kullanıcı kimliği alınamadı.");
            return View(p); 
        }

        [HttpPost]
        public IActionResult DeleteBlog(int id)
        {
            var blog = _blogService.TGetByID(id);
            if (blog == null)
            {
                return NotFound();
            }

            // Resim dosyasını sil
            if (!string.IsNullOrEmpty(blog.ImagePath))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogImage/", blog.ImagePath);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _blogService.TDelete(blog);
            return RedirectToAction("Index", "AdminBlog");
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogService.TGetByID(id);
            if (blog == null)
            {
                return NotFound();
            }

            var model = new UpdateBlog
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.SubTitle,
                DetailDescription = blog.Content,

                ImageUrl = blog.ImagePath // Mevcut resim dosyası yolunu sakla
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateBlog(UpdateBlog model)
        {
            if (ModelState.IsValid)
            {
                var adminUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (int.TryParse(adminUserId, out int userId))
                {
                    var _bM = _blogService.TGetByID(model.Id);
                    if (_bM == null)
                    {
                        return NotFound();
                    }

                    _bM.Title = model.Title;
                    _bM.SubTitle = model.Description;
                    _bM.Content = model.DetailDescription;

                    if (model.NewImageFile != null)
                    {
                        // Eski resim dosyasını sil
                        if (!string.IsNullOrEmpty(_bM.ImagePath))
                        {
                            var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogImage/", _bM.ImagePath);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        // Yeni resim dosyasını yükle
                        var extension = Path.GetExtension(model.NewImageFile.FileName);
                        var newImageName = Guid.NewGuid() + extension;
                        var newImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/blogImage/", newImageName);
                        using (var stream = new FileStream(newImagePath, FileMode.Create))
                        {
                            model.NewImageFile.CopyTo(stream);
                        }

                        // Yeni resim dosyası bilgisi güncellenir
                        _bM.ImagePath = newImageName;
                    }

                    _blogService.TUpdate(_bM);
                }
                return RedirectToAction("Index", "AdminBlog");
            }

            return View(model);
        }
    }
}