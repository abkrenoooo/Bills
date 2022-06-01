using BLL.Helper;
using DAL.Repository.UnitRepository;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.UnitServices
{
    public class UnitServices : IUnitServices
    {
        private readonly IUnitRepository _unitRepository;
        public UnitServices(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public async Task<ResponseBody<Unit_VM>> AddUnitAsync(Unit_VM unit)
        {
            ResponseBody<Unit_VM> response = new ResponseBody<Unit_VM>();
            var specyName = await _unitRepository.GetByUnitAsync(unit.UnitName);
            if (specyName is not null && unit.UnitId != specyName.UnitId)
            {
                response.message = "UNIT NAME has already existed before";
                response.data = new List<Unit_VM>() { unit };
                response.status_code = 1;
            }
            else if (await _unitRepository.AddUnitAsync(unit) is not null)
            {
                response.message = "UNIT has been Added successfully";
                response.data = new List<Unit_VM>() { await _unitRepository.GetByUnitAsync(unit.UnitName) };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = new List<Unit_VM>() { unit };
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Unit_VM>> DeleteUnitAsync(int id)
        {
            ResponseBody<Unit_VM> response = new ResponseBody<Unit_VM>();
            var res = await _unitRepository.DeleteUnitAsync(id);
            if (!res)
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            else
            {
                response.message = "UNIT has been Deleted successfully";
                response.data = null;
                response.status_code = 0;
            }
            return response;
        }
        public async Task<ResponseBody<Unit_VM>> EditUnitAsync(Unit_VM unit)
        {
            ResponseBody<Unit_VM> response = new ResponseBody<Unit_VM>();
            var specyName = await _unitRepository.GetByUnitAsync(unit.UnitName);
            if (specyName is not null && unit.UnitId != specyName.UnitId)
            {
                response.message = "UNIT NAME has already existed before";
                response.data = new List<Unit_VM>() { unit };
                response.status_code = 1;
            }
            else if (await _unitRepository.EditUnitAsync(unit) is not null)
            {
                response.message = "UNIT has been Edit successfully";
                response.data = new List<Unit_VM>() { unit };
                response.status_code = 0;
            }
            else
            {
                response.data = new List<Unit_VM>() { unit };
                response.message = "Unknown error";
                response.status_code = -1;
            }
            return response;
        }
        public async Task<ResponseBody<Unit_VM>> GetAllUnitAsync()
        {
            ResponseBody<Unit_VM> response = new ResponseBody<Unit_VM>();
            if (await _unitRepository.GetAllUnitAsync() is not null)
            {
                response.message = null;
                response.data = await _unitRepository.GetAllUnitAsync();
                response.status_code = 0;
            }
            else
            {
                response.data = null;
                response.message = "Unknown error";
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Unit_VM>> GetByUnitAsync(string name)
        {
            ResponseBody<Unit_VM> response = new ResponseBody<Unit_VM>();
            if (await _unitRepository.GetByUnitAsync(name) is not null)
            {
                response.message = null;
                response.data = new List<Unit_VM>() { await _unitRepository.GetByUnitAsync(name) };
                response.status_code = 0;
            }
            else
            {
                response.data = null;
                response.message = "Unknown error";
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Unit_VM>> GetUnitByIdAsync(int id)
        {
            ResponseBody<Unit_VM> response = new ResponseBody<Unit_VM>();
            if (await _unitRepository.GetUnitByIdAsync(id) is not null)
            {
                response.message = null;
                response.data = new List<Unit_VM>() { await _unitRepository.GetUnitByIdAsync(id) };
                response.status_code = 0;
            }
            else
            {
                response.data = null;
                response.message = "Unknown error";
                response.status_code = -1;
            }
            return response;
        }
    }
}
