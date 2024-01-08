using ASP.NET_Core_MVC.Data;
using ASP.NET_Core_MVC.Models.Domain;
using ASP.NET_Core_Razor_Page.Model.ViewModel;
using ASP.NET_Core_Razor_Page.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ASP.NET_Core_Razor_Page.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet(Guid id)
        {
            BlogPost = await blogPostRepository.GetAsync(id);
            
        }
        public async Task<IActionResult> OnPostEdit(Guid id)
        {
            try
            {
                //throw new Exception();
                await blogPostRepository.UpdateAsync(BlogPost);
                ViewData["Notification"] = new Notification
                {
                    Message = "Save was succesfully Updated.",
                    Type = Enums.NotificationType.Success
                };
                
            }
            catch (Exception ex)
            {

                ViewData["Notification"] = new Notification
                {
                    Message = ex.Message,
                    Type = Enums.NotificationType.Error
                };
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            if(await blogPostRepository.DeleteAsync(BlogPost.Id))
            {
                var notification = new Notification
                {
                    Message = "Blog was succesfully Deleted Successfully !",
                    Type = Enums.NotificationType.Success
                };
                TempData["MessageDescription"] = JsonSerializer.Serialize(notification);
                return RedirectToPage("/Admin/Blogs/List");
            }
            return Page();
        }
    }
}
