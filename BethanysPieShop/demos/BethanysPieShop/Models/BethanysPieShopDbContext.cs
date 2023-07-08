using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models;

public class BethanysPieShopDbContext:DbContext
{
	public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options) 
		: base (options)
	{ }


	//esto le hace saber a EF con que modelos va trabajar la BD
	//permite recuperar tanto recuperar datos como escribir
	public DbSet<Category> Categories { get; set; }
	public DbSet<Pie> Pies { get; set; }

}
