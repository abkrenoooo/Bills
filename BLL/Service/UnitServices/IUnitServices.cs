using BLL.Helper;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.UnitServices
{
    public interface IUnitServices
    {
        public Task<ResponseBody<Unit_VM>> AddUnitAsync(Unit_VM unit);
        public Task<ResponseBody<Unit_VM>> EditUnitAsync(Unit_VM unit);
        public Task<ResponseBody<Unit_VM>> DeleteUnitAsync(int id);
        public Task<ResponseBody<Unit_VM>> GetByUnitAsync(string name);
        public Task<ResponseBody<Unit_VM>> GetUnitByIdAsync(int id);
        public Task<ResponseBody<Unit_VM>> GetAllUnitAsync();
    }
}
