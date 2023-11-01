using BLL.Helper;
using BLL.Service.UnitServices;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitServices _unitServices;

        public UnitController(IUnitServices unitServices)
        {
            _unitServices = unitServices;
        }


        public IActionResult AddUnit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUnit(Unit_VM unit)
        {
            if (ModelState.IsValid)
            {
                var state = await _unitServices.AddUnitAsync(unit);
                return Json(state);
            }
            else
            {
                return View(unit);
            }
        }
        public async Task<IActionResult> UpdateUnit(Unit_VM unit)
        {
            if (ModelState.IsValid)
            {
                var state = await _unitServices.EditUnitAsync(unit);
                return Json(state);
            }
            else
            {
                return View(unit);
            }
        }

        public async Task<IActionResult> EditUnit(int id)
        {
            var state = await _unitServices.GetUnitByIdAsync(id);
            return Json(state);
        }

        public async Task<IActionResult> DeleteUnit(int id)
        {
            var state = await _unitServices.DeleteUnitAsync(id);
            return Json(state);
        }

        public async Task<IActionResult> LoadData(int PageNumber = 1, int PageSize = 10)
        {
            var state = await _unitServices.GetAllUnitAsync();
            var pagedData = Pagination.PagedResult(state.data.ToList(), PageNumber, PageSize);
            return Json(pagedData);
        }
    }
}
