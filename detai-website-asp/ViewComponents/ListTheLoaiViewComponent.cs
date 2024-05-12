namespace detai_website_asp.ViewComponent
{
    using global::detai_website_asp.Data;
    using Microsoft.AspNetCore.Mvc;


    public class ListTheLoaiViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public ListTheLoaiViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var theloai = _db.TheLoai.ToList();
            return View(theloai);
        }

    }
}
