namespace detai_website_asp.ViewComponent { 

    using global::detai_website_asp.Data;
    using Microsoft.AspNetCore.Mvc;


    public class TheLoaiViewComponent : ViewComponent
{
    private readonly ApplicationDbContext _db;
    public TheLoaiViewComponent(ApplicationDbContext db)
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
