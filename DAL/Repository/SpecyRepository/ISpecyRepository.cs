using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.SpecyRepository
{
    public interface ISpecyRepository
    {
        public Task<Specy_VM> AddSpecyAsync(Specy_VM specy);
        public Task<Specy_VM> EditSpecyAsync(Specy_VM specy);
        public Task<bool> DeleteSpecyAsync(int id);
        public Task<Specy_VM> GetBySpecyAsync(string name);
        public Task<List<Specy_VM>> GetAllSpecyAsync();
        public Task<List<Company_VM>> GetAllCompanyAsync();
        public Task<Specy_VM> GetSpecyByIdAsync(int id);
    }
}
