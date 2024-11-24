using CoreAPIDevam_1.Models.ContextClasses;
using CoreAPIDevam_1.Models.Entities;
using CoreAPIDevam_1.Models.ViewModels.Categories.RequestModels;
using CoreAPIDevam_1.Models.ViewModels.Categories.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreAPIDevam_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        MyContext _db;

        public CategoryController(MyContext db)
        {
            _db = db;
        }


        //ID'ya göre Kategori getirme, Kategori ekleme, silme ve güncelleme


        [HttpGet]
        public IActionResult GetCategories()
        {
            List<CategoryResponseModel> categories = _db.Categories.Select(x => new CategoryResponseModel
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();


            return Ok(categories);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetCategory(int id)
        {
            //Category c =await _db.Categories.FindAsync(id);
            //CategoryResponseModel crm = new CategoryResponseModel()
            //{
            //    ID = c.ID,
            //    CategoryName = c.CategoryName,
            //    Description = c.Description
            //};

            CategoryResponseModel? crm = await _db.Categories.Where(x => x.ID == id).Select(x => new CategoryResponseModel
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).FirstOrDefaultAsync();

            return Ok(crm);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryRequestModel createcategory)
        {




            Category c = new()
            {
                CategoryName = createcategory.CategoryName,
                Description = createcategory.Description
            };
            await _db.Categories.AddAsync(c);
            await _db.SaveChangesAsync();
            return Ok("Kategori eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequestModel updateCategory)
        {
            Category? c = await _db.Categories.FindAsync(updateCategory.ID);
            c.CategoryName = updateCategory.CategoryName;
            c.Description = updateCategory.Description;
            await _db.SaveChangesAsync();
            return Ok("Güncelleme basarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            Category? c = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(c);
            await _db.SaveChangesAsync();
            return Ok("Silme işlemi basarılıdır");
        }
    }
}
