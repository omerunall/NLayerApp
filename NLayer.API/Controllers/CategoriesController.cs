using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        //api/categories/GetSingleCategoryByIdWithsProduct/id
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSingleCategoryByIdWithsProduct(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }
    }
}
