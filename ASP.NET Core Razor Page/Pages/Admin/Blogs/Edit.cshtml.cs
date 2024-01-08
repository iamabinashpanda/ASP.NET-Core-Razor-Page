using ASP.NET_Core_MVC.Data;
using ASP.NET_Core_MVC.Models.Domain;
using ASP.NET_Core_Razor_Page.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
            await blogPostRepository.UpdateAsync(BlogPost);
            //return RedirectToPage("/admin/blogs/list");
            ViewData["MessageDescription"] = "Save was succesfully saved.";
            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            if(await blogPostRepository.DeleteAsync(BlogPost.Id))
            {
                return RedirectToPage("/Admin/Blogs/List");
            }
            return Page();
        }
    }
}
