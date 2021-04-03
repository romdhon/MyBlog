using Microsoft.EntityFrameworkCore;
namespace Blogger.Models
{
    public class ColorContext : DbContext
    {
        public ColorContext(DbContextOptions<ColorContext> options) : base(options)
        {
        }
        public DbSet<Color> ColorItems {get; set;}
    }
}