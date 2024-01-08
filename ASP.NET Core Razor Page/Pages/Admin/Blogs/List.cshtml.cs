using ASP.NET_Core_MVC.Data;
using ASP.NET_Core_MVC.Models.Domain;
using ASP.NET_Core_Razor_Page.Model.ViewModel;
using ASP.NET_Core_Razor_Page.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ASP.NET_Core_Razor_Page.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        public List<BlogPost> BlogPosts{ get; set; }

        public ListModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet()
        {
            var notificationJson = TempData["MessageDescription"];
            if(notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson.ToString());
            }
            
            BlogPosts = (await blogPostRepository.GetAllAsync())?.ToList();
        }
    }
}
