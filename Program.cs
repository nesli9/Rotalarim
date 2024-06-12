using Rotalarim.Data.Abstract;
using Rotalarim.Data.Concrete;
using Rotalarim.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RotalarimContext>(options =>{options.UseSqlite(builder.Configuration["ConnectionStrings:Sql_connection"]);});

builder.Services.AddScoped<IPostRepository ,EfPostRepository>();
builder.Services.AddScoped<ITagRepository ,EfTagRepository>();
builder.Services.AddScoped<ICommentRepository ,EfCommentRepository>();
builder.Services.AddScoped<IUserRepository ,EfUserRepository>();//IUser olan kısmı talep edilir EfUser kısmı türetilip gönderilir


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(); //cookie özelliği uygulamaya tanıtıldı

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting(); //aşağıdaki middleware lerden önce mutlaka routing yapılandırılması lazım sıra önemli!
app.UseAuthentication(); //middleware olarak adlandırılırlar
app.UseAuthorization();//yetkilendirme (uygulamanın belli bölümlerini kullanmaya yarar)

SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name : "post_details",
    pattern : "posts/details/{url}",
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
