using BLL.Helper;
using DAL.Repository.CategoryRepository;
using DAL.Repository.ClientRepository;
using DAL.Repository.CompanyRepository;
using DAL.Repository.SpecyRepository;
using DAL.Repository.UnitRepository;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class AssistController : Controller
    {
        private readonly IUnitRepository _unitRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ISpecyRepository _specyRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IClientRepository _clientRepository;

        public AssistController(ICompanyRepository companyRepository, ISpecyRepository specyRepository, IUnitRepository unitRepository, ICategoryRepository categoryRepository, IClientRepository clientRepository)
        {
            _companyRepository = companyRepository;
            _specyRepository = specyRepository;
            _unitRepository = unitRepository;
            _categoryRepository = categoryRepository;
            _clientRepository = clientRepository;
        }

        public async Task<IActionResult> CheckeCompanyName(Company_VM company)
        {
            ResponseBody<Company_VM> response = new ResponseBody<Company_VM>();
            if (company.CompanyName == null || company.CompanyName == "")
            {
                response.message = "COMPANY NAME is Required";
                response.data = null;
                response.status_code = 1;
            }
            else
            {
                var CompanyName = await _companyRepository.GetByCompanyAsync(company.CompanyName);
                if (CompanyName is not null && company.CompanyId != CompanyName.CompanyId)
                {
                    response.message = "COMPANY NAME has already existed before";
                    response.data = new List<Company_VM>() { company };
                    response.status_code = -1;
                }
                else
                {
                    response.message = null;
                    response.data = null;
                    response.status_code = 0;
                }
            }
            return Json(response);
        }

        public async Task<IActionResult> CheckeSpecyName(Specy_VM specy)
        {
            ResponseBody<Specy_VM> response = new ResponseBody<Specy_VM>();
            if (specy.SpecyName == null || specy.SpecyName == "")
            {
                response.message = "SPECY NAME is Required";
                response.data = null;
                response.status_code = 1;
            }
            else
            {
                var SpecyName = await _specyRepository.GetBySpecyAsync(specy.SpecyName);
                if (SpecyName is not null && specy.SpecyId != SpecyName.SpecyId)
                {
                    response.message = "SPECY NAME has already existed before";
                    response.data = new List<Specy_VM>() { specy };
                    response.status_code = -1;
                }
                else
                {
                    response.message = null;
                    response.data = null;
                    response.status_code = 0;
                }
            }
            return Json(response);
        }

        public async Task<IActionResult> CheckeUnitName(Unit_VM unit)
        {
            ResponseBody<Unit_VM> response = new ResponseBody<Unit_VM>();
            if (unit.UnitName == null || unit.UnitName == "")
            {
                response.message = "UNIT NAME is Required";
                response.data = null;
                response.status_code = 1;
            }
            else
            {
                var UnitName = await _unitRepository.GetByUnitAsync(unit.UnitName);
                if (UnitName is not null && unit.UnitId != UnitName.UnitId)
                {
                    response.message = "UNIT NAME has already existed before";
                    response.data = new List<Unit_VM>() { unit };
                    response.status_code = -1;
                }
                else
                {
                    response.message = null;
                    response.data = null;
                    response.status_code = 0;
                }
            }
            return Json(response);
        }

        public async Task<IActionResult> CheckeItemName(Category_VM category)

        {
            ResponseBody<Category_VM> response = new ResponseBody<Category_VM>();
            if (category.ItemName == null || category.ItemName == "")
            {
                response.message = "ITEM NAME is Required";
                response.data = null;
                response.status_code = 1;
            }
            else
            {
                var CategoryName = await _categoryRepository.GetByCategoryAsync(category.ItemName);
                if (CategoryName is not null && category.CategoryId != CategoryName.CategoryId)
                {
                    response.message = "ITEM NAME has already existed before";
                    response.data = new List<Category_VM>() { category };
                    response.status_code = -1;
                }
                else
                {
                    response.message = null;
                    response.data = null;
                    response.status_code = 0;
                }
            }
            return Json(response);
        }

        public async Task<IActionResult> CheckeClientName(Client_VM client)
        {
            ResponseBody<Client_VM> response = new ResponseBody<Client_VM>();
            if (client.ClientName == null || client.ClientName == "")
            {
                response.message = "CLIENT NAME is Required";
                response.data = null;
                response.status_code = 1;
            }
            else
            {
                var ClientName = await _clientRepository.GetByClientAsync(client.ClientName);
                if (ClientName is not null && client.ClientId != ClientName.ClientId)
                {
                    response.message = "CLIENT NAME has already existed before";
                    response.data = new List<Client_VM>() { client };
                    response.status_code = -2;
                }
                else
                {
                    response.message = null;
                    response.data = null;
                    response.status_code = 0;
                }
            }
            return Json(response);
        }

        public async Task<IActionResult> GetSellingPrice(string categoryName)
        {
            if (categoryName != null && categoryName != "Choose Item")
            {
                var CategoryName = await _categoryRepository.GetByCategoryAsync(categoryName);
                return Json(CategoryName.SellingPrice);
            }
            return Json("Unknow Error");
        }
    }
}
