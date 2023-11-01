using BLL.Helper;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.SpecyServices
{
    public interface ISpecyServices
    {
        public Task<ResponseBody<Specy_VM>> AddSpecyAsync(Specy_VM specy);
        public Task<ResponseBody<Specy_VM>> EditSpecyAsync(Specy_VM specy);
        public Task<ResponseBody<Specy_VM>> DeleteSpecyAsync(int id);
        public Task<ResponseBody<Specy_VM>> GetBySpecyAsync(string name);
        public Task<ResponseBody<Specy_VM>> GetSpecyByIdAsync(int id);
        public Task<ResponseBody<Specy_VM>> GetAllSpecyAsync();
        public Task<ResponseBody<Company_VM>> GetAllCompanyAsync();
    }
}
