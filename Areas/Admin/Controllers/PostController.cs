using aznew.Models;
using aznews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Core;

namespace aznews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly DataContext _context;

        public PostController(DataContext context)
        {
            _context = context;
        }

        // Post
        [Route("/Admin/post-index{page:int}.html", Name = "PostIndex")]
        public IActionResult Index(int page = 1)
        {
            var post = _context.Posts.OrderByDescending(p => p.PostID);

            int pageSize = 5; // Số bài viết trên 1 trang;
            PagedList<tblPost> models = new(post, page, pageSize);

            if (models == null)
            {
                return NotFound();
            }

            return View(models);
        }
        public IActionResult Create()
{
    var mnList = (from m in _context.Menus
                  select new SelectListItem()
                  {
                      Text = m.MenuName,
                      Value = m.MenuID.ToString()
                  }).ToList();

    mnList.Insert(0, new SelectListItem()
    {
        Text = "--- Select ---",
        Value = string.Empty
    });

    ViewBag.mnList = mnList;
    return View();
}

[HttpPost]
public IActionResult Create(tblPost post)
{
    //Có thể kiểm tra dữ liệu ở đây trước khi thêm vào bảng
    if (ModelState.IsValid)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();
    }

    return RedirectToAction("Index");
}



    }
}