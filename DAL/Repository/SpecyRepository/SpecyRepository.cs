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

namespace DAL.Repository.SpecyRepository
{
    public class SpecyRepository : ISpecyRepository
    {
        private readonly ApplicationDbContext db;

        public SpecyRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Specy_VM> AddSpecyAsync(Specy_VM specy)
        {
            try
            {
                var data = new Specy()
                {
                    SpecyId = specy.SpecyId,
                    CompanyId = specy.CompanyId,
                    SpecyName = specy.SpecyName,
                    Note = specy.Note,
                };
                await db.Species.AddAsync(data);
                var res = await db.SaveChangesAsync();
                var newSpecy = await GetBySpecyAsync(specy.SpecyName);
                if (res > 0)
                {
                    return newSpecy;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteSpecyAsync(int id)
        {
            try
            {
                var data = await db.Species.FindAsync(id);
                db.Species.Remove(data);
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

        public async Task<Specy_VM> EditSpecyAsync(Specy_VM specy)
        {
            try
            {
                var data = new Specy()
                {
                    SpecyId = specy.SpecyId,
                    CompanyId = specy.CompanyId,
                    SpecyName = specy.SpecyName,
                    Note = specy.Note,
                };
                db.Entry(data).State = EntityState.Modified;
                int res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    return specy;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Specy_VM>> GetAllSpecyAsync()
        {
            try
            {
                var data = await db.Species.Select(a => new Specy_VM { CompanyName = a.Company.CompanyName, SpecyId = a.SpecyId, CompanyId = a.CompanyId, SpecyName = a.SpecyName, Note = a.Note }).ToListAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Specy_VM> GetBySpecyAsync(string name)
        {
            try
            {
                var data = await db.Species.Where(a => a.SpecyName == name).Select(a => new Specy_VM { CompanyName = a.Company.CompanyName, SpecyId = a.SpecyId, CompanyId = a.CompanyId, SpecyName = a.SpecyName, Note = a.Note }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Specy_VM> GetSpecyByIdAsync(int id)
        {
            try
            {
                var data = await db.Species.Where(a => a.SpecyId == id).Select(a => new Specy_VM { CompanyName = a.Company.CompanyName, SpecyId = a.SpecyId, CompanyId = a.CompanyId, SpecyName = a.SpecyName, Note = a.Note }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<Company_VM>> GetAllCompanyAsync()
        {
            try
            {
                var data = await db.Companies.Select(a => new Company_VM { CompanyId = a.CompanyId, CompanyName = a.CompanyName, Note = a.Note }).ToListAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
