using detai_website_asp.Data;
using detai_website_asp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace detai_website_asp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TinTucController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TinTucController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            IEnumerable<TinTuc> tintuc = _db.TinTuc.ToList();
            return View(tintuc);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TinTuc tintuc)
        {
            if(ModelState.IsValid)
            {
                _db.TinTuc.Add(tintuc);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == 0 )
            {
                return NotFound();
            }
            var tintuc = _db.TinTuc.Find(id);
            return View(tintuc);
        }
        [HttpPost]
        public IActionResult Edit(TinTuc tintuc)
        {
            if(ModelState.IsValid)
            {
                _db.TinTuc.Update(tintuc);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var tintuc = _db.TinTuc.Find(id);
            return View(tintuc);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var tintuc = _db.TinTuc.Find(id);
            if (tintuc == null)
            {
                return NotFound();
            }
            _db.TinTuc.Remove(tintuc);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
