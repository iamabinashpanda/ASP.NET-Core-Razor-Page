using ASP.NET_Core_MVC.Data;
using ASP.NET_Core_MVC.Models.Domain;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

        public async Task OnGet(Guid id)
        {
            BlogPost = await aspNetCoreRazorPagesDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
            
        }
        public async Task<IActionResult> OnPostEdit(Guid id)
        {
            var existingBlogPost = await aspNetCoreRazorPagesDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
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
            await aspNetCoreRazorPagesDbContext.SaveChangesAsync();
            return RedirectToPage("/admin/blogs/list");
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            var existingBlogPost = aspNetCoreRazorPagesDbContext.BlogPosts.FirstOrDefault(x => x.Id == id);
            if( existingBlogPost != null)
            {
                aspNetCoreRazorPagesDbContext.Remove(existingBlogPost);
                await aspNetCoreRazorPagesDbContext.SaveChangesAsync();
            }
            return RedirectToPage("/Admin/Blogs/List");
        }
    }
}
