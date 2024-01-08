using ASP.NET_Core_MVC.Data;
using ASP.NET_Core_Razor_Page.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AspNetCoreRazorPagesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AspNetCoreRazorPagesDb")));
builder.Services.AddScoped<IBlogPostRepository,BlogPostRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
