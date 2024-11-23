using CoreAPIDevam_1.Models.ContextClasses;
using CoreAPIDevam_1.Models.ViewModels.Categories.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
