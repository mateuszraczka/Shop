using Microsoft.EntityFrameworkCore;
using Shop.Models;

public class CategoriesDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public CategoriesDbContext(DbContextOptions<CategoriesDbContext> options) : base(options)
    {

    }
}