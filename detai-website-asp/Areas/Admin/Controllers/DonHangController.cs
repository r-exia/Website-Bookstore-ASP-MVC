using detai_website_asp.Data;
using detai_website_asp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace detai_website_asp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DonHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            IEnumerable<HoaDon> hoadon = _db.HoaDon.Include("ApplicationUser").ToList();
            return View(hoadon);
        }

        public IActionResult ChiTiet(int id)
        {
            HoaDon hoadon = new HoaDon();
            IEnumerable<SelectListItem> dshoadon = _db.HoaDon.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                });
           
            if (id == 0)
            {
                return View(hoadon);
            }
            else
            {
                hoadon = _db.HoaDon.FirstOrDefault(hoadon => hoadon.Id == id);
                return View(hoadon);
            }
        }

    }
}
