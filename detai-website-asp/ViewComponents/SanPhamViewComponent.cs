
namespace detai_website_asp.ViewComponent
{
    using global::detai_website_asp.Data;
    using Microsoft.AspNetCore.Mvc;
    namespace detai_website_asp.ViewComponents
    {
        public class SanPhamViewComponent : ViewComponent
        {
            private readonly ApplicationDbContext _db;
            public SanPhamViewComponent(ApplicationDbContext db)
            {
                _db = db;
            }
            public IViewComponentResult Invoke()
            {
                var sanpham = _db.SanPham.ToList();
                return View(sanpham);
            }
        }
    }
}