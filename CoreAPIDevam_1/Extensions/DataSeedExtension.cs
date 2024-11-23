using CoreAPIDevam_1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreAPIDevam_1.Extensions
{
    public static class DataSeedExtension
    {
        public static void AddCategoryData(this ModelBuilder modelBuilder)
        {
            Category c = new Category()
            {
                ID = 1,
                CategoryName = "Tatlılar",
                Description = "Deneme verisidir"
            };

            modelBuilder.Entity<Category>().HasData(c);
        }
    }
}
