using BLL.Helper;
using BLL.Service.CategoryServices;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }


        public async Task<IActionResult> AddCategory()
        {
            var Company = await _categoryServices.GetAllCompanyAsync();
            ViewBag.Company = Company.data.ToList();
            var Specy = await _categoryServices.GetAllSpecyAsync();
            ViewBag.Specy = Specy.data.ToList();
            return View();
        }

        public async Task<IActionResult> UpdateCategory(Category_VM category)
        {
            if (ModelState.IsValid)
            {
                var state = await _categoryServices.EditCategoryAsync(category);
                return Json(state);
            }
            else
            {
                return View(category);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category_VM category)
        {
            if (ModelState.IsValid)
            {
                var state = await _categoryServices.AddCategoryAsync(category);
                return Json(state);
            }
            else
            {
                return View(category);
            }
        }

        public async Task<IActionResult> EditCategory(int id)
        {
            var state = await _categoryServices.GetCategoryByIdAsync(id);
            return Json(state);
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var state = await _categoryServices.DeleteCategoryAsync(id);
            return Json(state);
        }

        public async Task<IActionResult> LoadData(int PageNumber = 1, int PageSize = 10)
        {
            var state = await _categoryServices.GetAllCategoryAsync();
            var pagedData = Pagination.PagedResult(state.data.ToList(), PageNumber, PageSize);
            return Json(pagedData);
        }
    }
}
