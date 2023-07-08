using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BethanysPieShopDbContext>
	(
		options => {
			options.UseSqlServer(
				builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
		}
		);

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapDefaultControllerRoute(); //"{controller=Home}/{action=Index}/{id?}"
/*app.MapControllerRoute(
	name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/


app.Run();
