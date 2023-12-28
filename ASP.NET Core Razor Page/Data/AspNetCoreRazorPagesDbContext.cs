﻿using ASP.NET_Core_MVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_MVC.Data
{
    public class AspNetCoreRazorPagesDbContext : DbContext
    {
        public AspNetCoreRazorPagesDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
