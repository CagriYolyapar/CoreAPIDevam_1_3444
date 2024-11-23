using Microsoft.EntityFrameworkCore;
using CoreAPIDevam_1.Extensions;
using CoreAPIDevam_1.CustomTools;
using CoreAPIDevam_1.Models.Entities;

namespace CoreAPIDevam_1.Models.ContextClasses
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> opt):base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddCategoryData();

            
           

           
          
        }

        public DbSet<Category> Categories { get; set; }
    }
}
