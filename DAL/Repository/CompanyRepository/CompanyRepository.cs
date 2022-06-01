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

namespace DAL.Repository.CompanyRepository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext db;

        public CompanyRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Company_VM> AddCompanyAsync(Company_VM company)
        {
            try
            {
                var data = new Company
                {
                    CompanyId = company.CompanyId,
                    CompanyName = company.CompanyName,
                    Note = company.Note
                };
                await db.Companies.AddAsync(data);
                var res = await db.SaveChangesAsync();
                var newCmpany =await GetByCompanyAsync(company.CompanyName);
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

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            try
            {
                var data = await db.Companies.FindAsync(id);
                db.Companies.Remove(data);
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

        public async Task<Company_VM> EditCompanyAsync(Company_VM company)
        {
            try
            {
                var data = new Company 
                { 
                    CompanyId = company.CompanyId,
                    CompanyName = company.CompanyName,
                    Note = company.Note 
                };
                db.Entry(data).State = EntityState.Modified;
                int res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    company.CompanyId = data.CompanyId;
                    return company;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Company_VM>> GetAllCompanyAsync()
        {
            var data = await db.Companies.Select(a => new Company_VM { CompanyId = a.CompanyId, CompanyName = a.CompanyName, Note = a.Note }).ToListAsync();
            return data;
        }

        public async Task<Company_VM> GetByCompanyAsync(string name)
        {
            var data = await db.Companies.Where(a => a.CompanyName == name).Select(a => new Company_VM { CompanyId = a.CompanyId, CompanyName = a.CompanyName, Note = a.Note }).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Company_VM> GetCompanyByIdAsync(int id)
        {
            var data = await db.Companies.Where(a => a.CompanyId== id).Select(a => new Company_VM { CompanyId = a.CompanyId, CompanyName = a.CompanyName, Note = a.Note }).FirstOrDefaultAsync();
            return data;
        }
    }
}
