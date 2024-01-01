using ASP.NET_Core_MVC.Data;
using ASP.NET_Core_MVC.Models.Domain;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Core_Razor_Page.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly AspNetCoreRazorPagesDbContext aspNetCoreRazorPagesDbContext;
        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public EditModel(AspNetCoreRazorPagesDbContext aspNetCoreRazorPagesDbContext)
        {
            this.aspNetCoreRazorPagesDbContext = aspNetCoreRazorPagesDbContext;
        }

        public void OnGet(Guid id)
        {
            BlogPost = aspNetCoreRazorPagesDbContext.BlogPosts.FirstOrDefault(x => x.Id == id);
            
        }
        public IActionResult OnPostEdit(Guid id)
        {
            var existingBlogPost = aspNetCoreRazorPagesDbContext.BlogPosts.FirstOrDefault(x => x.Id == id);
            if(existingBlogPost != null)
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible = BlogPost.Visible;

            }
            aspNetCoreRazorPagesDbContext.SaveChanges();
            return RedirectToPage("/admin/blogs/list");
        }

        public IActionResult OnPostDelete(Guid id)
        {
            var existingBlogPost = aspNetCoreRazorPagesDbContext.BlogPosts.FirstOrDefault(x => x.Id == id);
            if( existingBlogPost != null)
            {
                aspNetCoreRazorPagesDbContext.Remove(existingBlogPost);
                aspNetCoreRazorPagesDbContext.SaveChanges();
            }
            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
