using ASP.NET_Core_MVC.Data;
using ASP.NET_Core_MVC.Models.Domain;
using ASP.NET_Core_Razor_Page.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Core_Razor_Page.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly AspNetCoreRazorPagesDbContext aspNetCoreRazorPagesDbContext;

        public AddModel(AspNetCoreRazorPagesDbContext aspNetCoreRazorPagesDbContext)
        {
            this.aspNetCoreRazorPagesDbContext = aspNetCoreRazorPagesDbContext;
        }

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var blogPost = new BlogPost
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible
            };
            aspNetCoreRazorPagesDbContext.BlogPosts.Add(blogPost);
            aspNetCoreRazorPagesDbContext.SaveChanges();
        }
    }
}
