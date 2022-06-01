using BLL.Helper;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.CompanyServices
{
    public interface ICompanyServices
    {
        public Task<ResponseBody<Company_VM>> AddCompanyAsync(Company_VM company);
        public Task<ResponseBody<Company_VM>> EditCompanyAsync(Company_VM company);
        public Task<ResponseBody<Company_VM>> DeleteCompanyAsync(int id);
        public Task<ResponseBody<Company_VM>> GetByCompanyAsync(string name);
        public Task<ResponseBody<Company_VM>> GetCompanyByIdAsync(int id);
        public Task<ResponseBody<Company_VM>> GetAllCompanyAsync();
    }
}
