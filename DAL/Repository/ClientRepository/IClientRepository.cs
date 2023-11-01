using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.ClientRepository
{
    public interface IClientRepository
    {
        public Task<Client_VM> AddClientAsync(Client_VM company);
        public Task<Client_VM> EditClientAsync(Client_VM company);
        public Task<bool> DeleteClientAsync(int id);
        public Task<Client_VM> GetByClientAsync(string name);
        public Task<List<Client_VM>> GetAllClientAsync();
        public Task<Client_VM> GetClientByIdAsync(int id);
        public Task<Client_VM> GetlastClientAsync();

    }
}
