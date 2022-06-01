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

namespace DAL.Repository.UnitRepository
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDbContext db;

        public UnitRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Unit_VM> AddUnitAsync(Unit_VM unit)
        {
            try
            {
                var data = new Unit()
                {
                    UnitId = unit.UnitId,
                    UnitName = unit.UnitName,
                    Note = unit.Note,
                };
                await db.Units.AddAsync(data);
                var res = await db.SaveChangesAsync();
                var newSpecy = await GetByUnitAsync(unit.UnitName);
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

        public async Task<bool> DeleteUnitAsync(int id)
        {
            try
            {
                var data = await db.Units.FindAsync(id);
                db.Units.Remove(data);
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

        public async Task<Unit_VM> EditUnitAsync(Unit_VM unit)
        {
            try
            {
                var data = new Unit()
                {
                    UnitId = unit.UnitId,
                    UnitName = unit.UnitName,
                    Note = unit.Note,
                };
                db.Entry(data).State = EntityState.Modified;
                int res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    return unit;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<Unit_VM>> GetAllUnitAsync()
        {
            try
            {
                var data = await db.Units.Select(a => new Unit_VM { UnitId = a.UnitId, UnitName = a.UnitName, Note = a.Note }).ToListAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Unit_VM> GetByUnitAsync(string name)
        {
            try
            {
                var data = await db.Units.Where(a => a.UnitName == name).Select(a => new Unit_VM { UnitId = a.UnitId, UnitName = a.UnitName, Note = a.Note }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Unit_VM> GetUnitByIdAsync(int id)
        {
            try
            {
                var data = await db.Units.Where(a => a.UnitId == id).Select(a => new Unit_VM { UnitId = a.UnitId, UnitName = a.UnitName, Note = a.Note }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
