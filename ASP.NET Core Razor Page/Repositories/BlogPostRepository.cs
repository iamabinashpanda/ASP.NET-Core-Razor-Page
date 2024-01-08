using ASP.NET_Core_MVC.Data;
using ASP.NET_Core_MVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Razor_Page.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly AspNetCoreRazorPagesDbContext aspNetCoreRazorPagesDbContext;

        public BlogPostRepository(AspNetCoreRazorPagesDbContext aspNetCoreRazorPagesDbContext)
        {
            this.aspNetCoreRazorPagesDbContext = aspNetCoreRazorPagesDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await aspNetCoreRazorPagesDbContext.BlogPosts.AddAsync(blogPost);
            await aspNetCoreRazorPagesDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlogPost = await aspNetCoreRazorPagesDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBlogPost != null)
            {
                aspNetCoreRazorPagesDbContext.Remove(existingBlogPost);
                await aspNetCoreRazorPagesDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await aspNetCoreRazorPagesDbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            return await aspNetCoreRazorPagesDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await aspNetCoreRazorPagesDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.Visible = blogPost.Visible;

            }
            await aspNetCoreRazorPagesDbContext.SaveChangesAsync();
            return existingBlogPost;
        }
    }
}
