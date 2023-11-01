using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.CompanyRepository
{
    public interface ICompanyRepository
    {
        public Task<Company_VM> AddCompanyAsync(Company_VM company);
        public Task<Company_VM> EditCompanyAsync(Company_VM company);
        public Task<bool> DeleteCompanyAsync(int id);
        public Task<Company_VM> GetByCompanyAsync(string name);
        public Task<List<Company_VM>> GetAllCompanyAsync();
        public Task<Company_VM> GetCompanyByIdAsync(int id);
    }
}
