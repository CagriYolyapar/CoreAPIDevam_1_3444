using CoreAPIDevam_1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreAPIDevam_1.CustomTools
{
    public static class DataSeedStructure
    {
        public static void AddCategory(ModelBuilder modelBuilder)
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
