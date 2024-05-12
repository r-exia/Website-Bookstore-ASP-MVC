using detai_website_asp.Data;
using detai_website_asp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace detai_website_asp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.ToList();
            return View(sanpham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Grid()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }
        

        public IActionResult Details(int sanphamId)
        {
            GioHang giohang = new GioHang()
            {
                SanPhamId = sanphamId,
                SanPham = _db.SanPham.Include(sp => sp.TheLoai).FirstOrDefault(sp => sp.Id == sanphamId),
                Quantity = 1
            };
            return View(giohang);
        }

        [HttpPost]
        [Authorize] //yeu cau dang nhap
        public IActionResult Details(GioHang giohang)
        {
            var giohangdb = _db.GioHang.FirstOrDefault(sp => sp.Id == giohang.Id
            && sp.ApplicationUserId == giohang.ApplicationUserId);
            if(giohangdb == null)
            {
                _db.GioHang.Add(giohang);
            }
            else 
            {
                giohang.Quantity += giohang.Quantity;
            }
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            giohang.ApplicationUserId = claim.Value;

            _db.SaveChanges();
            return RedirectToAction("Index", "GioHang");
        }
           
        
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Blog_Details(int id)
        {
            TinTuc tintuc = _db.TinTuc.FirstOrDefault(tintuc => tintuc.Id == id);
            return View(tintuc);
        }
        public IActionResult Blog()
        {
            IEnumerable<TinTuc> tintuc = _db.TinTuc.ToList();
            return View(tintuc);
        }
    }
}