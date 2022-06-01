using BLL.Helper;
using BLL.Service.CompanyServices;
using DAL.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyServices _companyServices;

        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        public ActionResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(Company_VM company)
        {
            if (ModelState.IsValid)
            {
                var state = await _companyServices.AddCompanyAsync(company);
                return Json(state);
            }
            else
            {
                return View(company);
            }

        }
        public async Task<IActionResult> UpdateCompany(Company_VM company)
        {
            if (ModelState.IsValid)
            {
                var state = await _companyServices.EditCompanyAsync(company);
                return Json(state);
            }
            else
            {
                return View(company);
            }

        }

        public async Task<IActionResult> EditCompany(int id)
        {
            var state = await _companyServices.GetCompanyByIdAsync(id);
            return Json(state);
        }

        public async Task<IActionResult> DeleteCompany(int id)
        {
            var state = await _companyServices.DeleteCompanyAsync(id);
            return Json(state);
        }

        public async Task<IActionResult> LoadData(int PageNumber = 1,int PageSize = 10)
        {
            var state = await _companyServices.GetAllCompanyAsync();
            var pagedData = Pagination.PagedResult(state.data.ToList(), PageNumber, PageSize);
           
            return Json(pagedData);
        }
    }
}
