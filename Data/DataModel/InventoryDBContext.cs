using Microsoft.EntityFrameworkCore;
using ChemeaseWeb.Models;
using ChemeaseWeb.Models.tables;
namespace ChemeaseWeb.Data.DataModel
{
	public class InventoryDBContext : DbContext
	{
		public InventoryDBContext(DbContextOptions<InventoryDBContext> options):base(options)
		{

		}
		//public virtual DbSet<Product>Products { get; set; }
		//public DbSet<Login> Users { get; set; }
		public DbSet<UserAccount> UserAccount { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserAccount>().HasNoKey();
        //}
    }
}
