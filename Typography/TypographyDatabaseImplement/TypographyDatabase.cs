using Microsoft.EntityFrameworkCore;
using TypographyDatabaseImplement.Models;


namespace TypographyDatabaseImplement
{
    public class TypographyDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=typography;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }

        public virtual DbSet<Printed> Printeds { set; get; }

        public virtual DbSet<PrintedComponent> PrintedComponents { set; get; }

        public virtual DbSet<Order> Orders { set; get; }
    }
}
