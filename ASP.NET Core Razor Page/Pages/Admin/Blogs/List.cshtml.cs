using ASP.NET_Core_MVC.Data;
using ASP.NET_Core_MVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Core_Razor_Page.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly AspNetCoreRazorPagesDbContext aspNetCoreRazorPagesDbContext;

        public List<BlogPost> BlogPosts{ get; set; }

        public ListModel(AspNetCoreRazorPagesDbContext aspNetCoreRazorPagesDbContext)
        {
            this.aspNetCoreRazorPagesDbContext = aspNetCoreRazorPagesDbContext;
        }

        public void OnGet()
        {
            BlogPosts = aspNetCoreRazorPagesDbContext.BlogPosts.ToList();
        }
    }
}
