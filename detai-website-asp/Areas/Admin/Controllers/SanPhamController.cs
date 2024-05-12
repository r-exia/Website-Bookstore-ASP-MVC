using detai_website_asp.Data;
using detai_website_asp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace detai_website_asp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            SanPham sanpham = new SanPham();
            IEnumerable<SelectListItem> dstheloai = _db.TheLoai.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                });
            ViewBag.DSTheLoai = dstheloai;
            if (id == 0)
            {
                return View(sanpham);
            }
            else
            {
                sanpham = _db.SanPham.Include("TheLoai").FirstOrDefault(sanpham => sanpham.Id == id);
                return View(sanpham);
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Upsert(SanPham sanpham)
        {
            if(ModelState.IsValid)
            {
                if(sanpham.Id == 0)
                {
                    _db.SanPham.Add(sanpham);
                }
                else
                {
                    _db.SanPham.Update(sanpham);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var sanpham = _db.SanPham.FirstOrDefault(sanpham => sanpham.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            else
            {
                _db.SanPham.Remove(sanpham);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
