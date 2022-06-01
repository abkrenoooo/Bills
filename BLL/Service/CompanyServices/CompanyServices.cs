using BLL.Helper;
using DAL.Repository.CompanyRepository;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.CompanyServices
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyServices(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<ResponseBody<Company_VM>> AddCompanyAsync(Company_VM company)
        {
            ResponseBody<Company_VM> response = new ResponseBody<Company_VM>();
            var CompanyName = await _companyRepository.GetByCompanyAsync(company.CompanyName);
            if (CompanyName is not null && company.CompanyId != CompanyName.CompanyId)
            {
                response.message = "COMPANY NAME has already existed before";
                response.data = new List<Company_VM>() { company };
                response.status_code = 1;
            }
            else if (await _companyRepository.AddCompanyAsync(company) is not null)
            {
                response.message = "COMPANY has been Added successfully";
                response.data = new List<Company_VM>() { await _companyRepository.GetByCompanyAsync(company.CompanyName) };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = new List<Company_VM>() { company };
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Company_VM>> DeleteCompanyAsync(int id)
        {
            ResponseBody<Company_VM> response = new ResponseBody<Company_VM>();
            var res = await _companyRepository.DeleteCompanyAsync(id);
            if (!res)
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            else
            {
                response.message = "COMPANY has been Deleted successfully";
                response.data = null;
                response.status_code = 0;
            }
            return response;
        }
        public async Task<ResponseBody<Company_VM>> EditCompanyAsync(Company_VM company)
        {
            ResponseBody<Company_VM> response = new ResponseBody<Company_VM>();
            var CompanyName = await _companyRepository.GetByCompanyAsync(company.CompanyName.ToString());
            if (CompanyName is not null && company.CompanyId != CompanyName.CompanyId)
            {
                response.message = "COMPANY NAME has already existed before";
                response.data = new List<Company_VM>() { company };
                response.status_code = 1;
            }
            else if (await _companyRepository.EditCompanyAsync(company) is not null)
            {
                response.message = "COMPANY has been Edit successfully";
                response.data = new List<Company_VM>() { company };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = response.data = new List<Company_VM>() { company };
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Company_VM>> GetAllCompanyAsync()
        {
            ResponseBody<Company_VM> response = new ResponseBody<Company_VM>();
            if (await _companyRepository.GetAllCompanyAsync() is not null)
            {
                response.message = null;
                response.data = await _companyRepository.GetAllCompanyAsync();
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = response.data = null;
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Company_VM>> GetByCompanyAsync(string name)
        {
            ResponseBody<Company_VM> response = new ResponseBody<Company_VM>();
            if (await _companyRepository.GetByCompanyAsync(name) is not null)
            {
                response.message = null;
                response.data = new List<Company_VM>() { await _companyRepository.GetByCompanyAsync(name) };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = response.data = null;
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Company_VM>> GetCompanyByIdAsync(int id)
        {
            ResponseBody<Company_VM> response = new ResponseBody<Company_VM>();
            if (await _companyRepository.GetCompanyByIdAsync(id) is not null)
            {
                response.message = null;
                response.data = new List<Company_VM>() { await _companyRepository.GetCompanyByIdAsync(id) };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = response.data = null;
                response.status_code = -1;
            }
            return response;
        }
    }
}
