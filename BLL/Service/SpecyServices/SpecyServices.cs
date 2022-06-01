using BLL.Helper;
using DAL.Repository.SpecyRepository;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.SpecyServices
{
    public class SpecyServices : ISpecyServices
    {
        private readonly ISpecyRepository _specyRepository;
        public SpecyServices(ISpecyRepository specyRepository)
        {
            _specyRepository = specyRepository;
        }
        public async Task<ResponseBody<Specy_VM>> AddSpecyAsync(Specy_VM specy)
        {
            ResponseBody<Specy_VM> response = new ResponseBody<Specy_VM>();
            var specyName = await _specyRepository.GetBySpecyAsync(specy.SpecyName);
            if (specyName is not null && specy.SpecyId != specyName.SpecyId)
            {
                response.message = "SPECY NAME has already existed before";
                response.data = new List<Specy_VM>() { specy };
                response.status_code = 1;
            }

            else if (await _specyRepository.AddSpecyAsync(specy) is not null)
            {
                response.message = "SPECY has been Added successfully";
                response.data = new List<Specy_VM>() { await _specyRepository.GetBySpecyAsync(specy.SpecyName) };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = new List<Specy_VM>() { specy };
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Specy_VM>> DeleteSpecyAsync(int id)
        {
            ResponseBody<Specy_VM> response = new ResponseBody<Specy_VM>();
            var res = await _specyRepository.DeleteSpecyAsync(id);
            if (!res)
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = 1;
            }
            else
            {
                response.message = "SPECY has been Deleted successfully";
                response.data = null;
                response.status_code = 0;
            }
            return response;
        }
        public async Task<ResponseBody<Specy_VM>> EditSpecyAsync(Specy_VM specy)
        {
            ResponseBody<Specy_VM> response = new ResponseBody<Specy_VM>();
            var specyName = await _specyRepository.GetBySpecyAsync(specy.SpecyName.ToString());
            if (specyName is not null && specy.SpecyId != specyName.SpecyId)
            {
                response.message = "SPECY NAME has already existed before";
                response.data = new List<Specy_VM>() { specy };
                response.status_code = 1;
            }
            else if (await _specyRepository.EditSpecyAsync(specy) is not null)
            {
                response.message = "SPECY has been Edit successfully";
                response.data = new List<Specy_VM>() { specy };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }
        public async Task<ResponseBody<Specy_VM>> GetAllSpecyAsync()
        {
            ResponseBody<Specy_VM> response = new ResponseBody<Specy_VM>();
            if (await _specyRepository.GetAllSpecyAsync() is not null)
            {
                response.message = null;
                response.data = await _specyRepository.GetAllSpecyAsync();
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Specy_VM>> GetBySpecyAsync(string name)
        {
            ResponseBody<Specy_VM> response = new ResponseBody<Specy_VM>();
            if (await _specyRepository.GetBySpecyAsync(name) is not null)
            {
                response.message = null;
                response.data = new List<Specy_VM>() { await _specyRepository.GetBySpecyAsync(name) };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Specy_VM>> GetSpecyByIdAsync(int id)
        {
            ResponseBody<Specy_VM> response = new ResponseBody<Specy_VM>();
            if (await _specyRepository.GetSpecyByIdAsync(id) is not null)
            {
                response.message = null;
                response.data = new List<Specy_VM>() { await _specyRepository.GetSpecyByIdAsync(id) };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Company_VM>> GetAllCompanyAsync()
        {
            ResponseBody<Company_VM> response = new ResponseBody<Company_VM>();
            if (await _specyRepository.GetAllCompanyAsync() is not null)
            {
                response.message = null;
                response.data = await _specyRepository.GetAllCompanyAsync();
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            
            return response;
        }
    }
}
