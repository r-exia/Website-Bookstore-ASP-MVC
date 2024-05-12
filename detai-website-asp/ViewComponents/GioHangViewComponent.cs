namespace detai_website_asp.ViewComponent
{

    using global::detai_website_asp.Data;
    using Microsoft.AspNetCore.Mvc;


    public class GioHangViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public GioHangViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var giohang = _db.GioHang.ToList();
            return View(giohang);
        }

    }
}
