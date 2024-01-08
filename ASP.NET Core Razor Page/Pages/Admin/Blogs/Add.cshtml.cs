using ASP.NET_Core_MVC.Data;
using ASP.NET_Core_MVC.Models.Domain;
using ASP.NET_Core_Razor_Page.Model.ViewModel;
using ASP.NET_Core_Razor_Page.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ASP.NET_Core_Razor_Page.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        public AddModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
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
            await blogPostRepository.AddAsync(blogPost);
            var notification = new Notification
            {
                Message = "Record was succesfully added!", Type = Enums.NotificationType.Success
            };
            TempData["MessageDescription"] = JsonSerializer.Serialize(notification);
            return RedirectToPage("/admin/blogs/list");
        }
    }
}
