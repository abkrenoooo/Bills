using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.UnitRepository
{
    public interface IUnitRepository
    {
        public Task<Unit_VM> AddUnitAsync(Unit_VM unit);
        public Task<Unit_VM> EditUnitAsync(Unit_VM unit);
        public Task<bool> DeleteUnitAsync(int id);
        public Task<Unit_VM> GetByUnitAsync(string name);
        public Task<List<Unit_VM>> GetAllUnitAsync();
        public Task<Unit_VM> GetUnitByIdAsync(int id);
    }
}
