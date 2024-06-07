using Rotalarim.Data.Abstract;
using Rotalarim.Data.Concrete;
using Rotalarim.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RotalarimContext>(options =>{
    options.UseSqlite(builder.Configuration["ConnectionStrings:Sql_connection"]);
    
});

builder.Services.AddScoped<IPostRepository ,EfPostRepository>();
builder.Services.AddScoped<ITagRepository ,EfTagRepository>();


var app = builder.Build();

app.UseStaticFiles();

SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name : "post_details",
    pattern : "posts/{url}",
    defaults : new {controller = "Posts", action = "Details"} //sayfanın yönlendireceği yer
);

app.MapControllerRoute(
    name : "posts_by_tag",
    pattern : "posts/tag/{tag}",
    defaults : new {controller = "Posts", action = "Index"} //sayfanın yönlendireceği yer
);

app.MapControllerRoute(
    name : "default",
    pattern : "{controller=Home}/{action=Index}/{id?}"
);

app.Run(); 
