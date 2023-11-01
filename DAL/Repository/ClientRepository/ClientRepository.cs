using AutoMapper;
using DAL.Data;
using DAL.Models;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.ClientRepository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext db;

        public ClientRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Client_VM> AddClientAsync(Client_VM client)
        {
            try
            {
                var data = new Client
                {
                    ClientId = client.ClientId,
                    ClientName = client.ClientName,
                    Phone = client.Phone,
                    Address = client.Address
                };
                await db.Clients.AddAsync(data);
                var res = await db.SaveChangesAsync();
                var newCmpany = await GetByClientAsync(client.ClientName);
                if (res > 0)
                {
                    return newCmpany;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            try
            {
                var data = await db.Clients.FindAsync(id);
                db.Clients.Remove(data);
                var res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Client_VM> EditClientAsync(Client_VM client)
        {
            try
            {
                var data = new Client
                {
                    ClientId = client.ClientId,
                    ClientName = client.ClientName,
                    Phone = client.Phone,
                    Address = client.Address
                };
                db.Entry(data).State = EntityState.Modified;
                int res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    client.ClientId = data.ClientId;
                    return client;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Client_VM>> GetAllClientAsync()
        {
            try
            {
                var data = await db.Clients.Select(a => new Client_VM { ClientId = a.ClientId, ClientName = a.ClientName, Phone = a.Phone, Address = a.Address }).ToListAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Client_VM> GetByClientAsync(string name)
        {
            try
            {
                var data = await db.Clients.Where(a => a.ClientName == name).Select(a => new Client_VM { ClientId = a.ClientId, ClientName = a.ClientName, Phone = a.Phone, Address = a.Address }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Client_VM> GetClientByIdAsync(int id)
        {
            try
            {
                var data = await db.Clients.Where(a => a.ClientId == id).Select(a => new Client_VM { ClientId = a.ClientId, ClientName = a.ClientName, Phone = a.Phone, Address = a.Address }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Client_VM> GetlastClientAsync()
        {
            try
            {
                var data1 = await db.Clients.MaxAsync(a => a.ClientId);
                var data = await GetClientByIdAsync(data1);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
