namespace detai_website_asp.ViewComponent
{

    using global::detai_website_asp.Data;
    using Microsoft.AspNetCore.Mvc;


    public class TinTucViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public TinTucViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var tintuc = _db.TinTuc.ToList();
            return View(tintuc);
        }

    }
}
