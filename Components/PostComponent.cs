using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aznew.Models;
using Microsoft.AspNetCore.Mvc;

namespace aznew.Components
{
    [ViewComponent(Name = "Post")]
    public class PostComponent : ViewComponent
    {
        private readonly DataContext _context;

        public PostComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listOfPost = (from p in _context.viewPostMenus
                              where (p.IsActive == true)
                              orderby p.PostID descending
                              select p).Take(10).ToList();

            //Take(8): get the latest 8 news
            return await Task.FromResult((IViewComponentResult)View("Default", listOfPost));
        }
    }
}