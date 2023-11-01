using BLL.Helper;
using DAL.Repository.ClientRepository;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.ClientServices
{
    public class ClientServices : IClientServices
    {
        private readonly IClientRepository _clientRepository;
        public ClientServices(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<ResponseBody<Client_VM>> AddClientAsync(Client_VM client)
        {
            ResponseBody<Client_VM> response = new ResponseBody<Client_VM>();
            var ClientName = await _clientRepository.GetByClientAsync(client.ClientName);
            if (ClientName is not null && client.ClientId != ClientName.ClientId)
            {
                response.message = "CLIENT NAME has already existed before";
                response.data = new List<Client_VM>() { client };
                response.status_code = -2;
            }
            else if (await _clientRepository.AddClientAsync(client) is not null)
            {
                response.message = "CLIENT has been Added successfully";
                response.data = new List<Client_VM>() { await _clientRepository.GetByClientAsync(client.ClientName) };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = new List<Client_VM>() { client };
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Client_VM>> DeleteClientAsync(int id)
        {
            ResponseBody<Client_VM> response = new ResponseBody<Client_VM>();
            var res = await _clientRepository.DeleteClientAsync(id);
            if (!res)
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            else
            {
                response.message = "CLIENT has been Deleted successfully";
                response.data = null;
                response.status_code = 0;
            }
            return response;
        }
        public async Task<ResponseBody<Client_VM>> EditClientAsync(Client_VM client)
        {
            ResponseBody<Client_VM> response = new ResponseBody<Client_VM>();
            var ClientName = await _clientRepository.GetByClientAsync(client.ClientName.ToString());
            if (ClientName is not null && client.ClientId != ClientName.ClientId)
            {
                response.message = "CLIENT NAME has already existed before";
                response.data = new List<Client_VM>() { client };
                response.status_code = -2;
            }
            else if (await _clientRepository.EditClientAsync(client) is not null)
            {
                response.message = "CLIENT has been Edit successfully";
                response.data = new List<Client_VM>() { client };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = new List<Client_VM>() { client };
                response.status_code = -1;
            }
            return response;
        }
        public async Task<ResponseBody<Client_VM>> GetAllClientAsync()
        {
            ResponseBody<Client_VM> response = new ResponseBody<Client_VM>();
            if (await _clientRepository.GetAllClientAsync() is not null)
            {
                response.message = null;
                response.data = await _clientRepository.GetAllClientAsync();
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

        public async Task<ResponseBody<Client_VM>> GetByClientAsync(string name)
        {
            ResponseBody<Client_VM> response = new ResponseBody<Client_VM>();
            if (await _clientRepository.GetByClientAsync(name) is not null)
            {
                response.message = null;
                response.data = new List<Client_VM>() { await _clientRepository.GetByClientAsync(name) };
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

        public async Task<ResponseBody<Client_VM>> GetClientByIdAsync(int id)
        {
            ResponseBody<Client_VM> response = new ResponseBody<Client_VM>();
            if (await _clientRepository.GetClientByIdAsync(id) is not null)
            {
                response.message = null;
                response.data = new List<Client_VM>() { await _clientRepository.GetClientByIdAsync(id) };
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
        public async Task<ResponseBody<Client_VM>> GetlastClientAsync()
        {
            ResponseBody<Client_VM> response = new ResponseBody<Client_VM>();
            if (await _clientRepository.GetlastClientAsync() is not null)
            {
                response.message = null;
                response.data = new List<Client_VM>() { await _clientRepository.GetlastClientAsync() };
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
