using BLL.Helper;
using BLL.Service.SpecyServices;
using DAL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class SpecyController : Controller
    {
        private readonly ISpecyServices _specyServices;

        public SpecyController(ISpecyServices specyServices)
        {
            _specyServices = specyServices;
        }


        public async Task<IActionResult> AddSpecy()
        {
            var Company = await _specyServices.GetAllCompanyAsync();
            ViewBag.Company = Company.data.ToList();
            return View();
        }

        public async Task<IActionResult> UpdateSpecy(Specy_VM specy)
        {
            if (ModelState.IsValid)
            {
                var state = await _specyServices.EditSpecyAsync(specy);
                return Json(state);
            }
            else
            {
                return View(specy);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSpecy(Specy_VM specy)
        {
            if (ModelState.IsValid)
            {
                var state = await _specyServices.AddSpecyAsync(specy);
                return Json(state);
            }
            else
            {
                return View(specy);
            }
        }

        public async Task<IActionResult> EditSpecy(int id)
        {
            var state = await _specyServices.GetSpecyByIdAsync(id);
            return Json(state);
        }

        public async Task<IActionResult> DeleteSpecy(int id)
        {
            var state = await _specyServices.DeleteSpecyAsync(id);
            return Json(state);
        }

        public async Task<IActionResult> LoadData(int PageNumber = 1, int PageSize = 10)
        {
            var state = await _specyServices.GetAllSpecyAsync();
            var pagedData = Pagination.PagedResult(state.data.ToList(), PageNumber, PageSize);
            return Json(pagedData);
        }
    }
}
