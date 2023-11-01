using BLL.Helper;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.ClientServices
{
    public interface IClientServices
    {
        public Task<ResponseBody<Client_VM>> AddClientAsync(Client_VM client);
        public Task<ResponseBody<Client_VM>> EditClientAsync(Client_VM client);
        public Task<ResponseBody<Client_VM>> DeleteClientAsync(int id);
        public Task<ResponseBody<Client_VM>> GetByClientAsync(string name);
        public Task<ResponseBody<Client_VM>> GetClientByIdAsync(int id);
        public Task<ResponseBody<Client_VM>> GetAllClientAsync();
        public Task<ResponseBody<Client_VM>> GetlastClientAsync();
    }
}
