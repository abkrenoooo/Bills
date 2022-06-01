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

namespace DAL.Repository.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Category_VM> AddCategoryAsync(Category_VM category)
        {
            try
            {
                var data = new Category
                {
                    CompanyId = category.CompanyId,
                    CategoryId = category.CategoryId,
                    SpecyId = category.SpecyId,
                    ByingPrice = category.ByingPrice,
                    ItemName = category.ItemName,
                    SellingPrice = category.SellingPrice,
                    Note = category.Note,

                };
                await db.Categories.AddAsync(data);
                var res = await db.SaveChangesAsync();
                var newCategory = await GetByCategoryAsync(category.ItemName);
                if (res > 0)
                {
                    return category;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var data = await db.Categories.FindAsync(id);
                db.Categories.Remove(data);
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

        public async Task<Category_VM> EditCategoryAsync(Category_VM category)
        {
            try
            {
                var data = new Category
                {
                    CompanyId = category.CompanyId,
                    CategoryId = category.CategoryId,
                    SpecyId = category.SpecyId,
                    ByingPrice = category.ByingPrice,
                    ItemName = category.ItemName,
                    SellingPrice = category.SellingPrice,
                    Note = category.Note,
                };
                db.Entry(data).State = EntityState.Modified;
                int res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    category.CategoryId = data.CategoryId;
                    return category;
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
        public async Task<List<Specy_VM>> GetAllSpecyAsync()
        {
            try
            {
                var data = await db.Species.Select(a => new Specy_VM { SpecyId = a.SpecyId, CompanyId = a.CompanyId, SpecyName = a.SpecyName, Note = a.Note }).ToListAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<Category_VM>> GetAllCategoryAsync()
        {
            try
            {
                var data = await db.Categories.Select(a => new Category_VM { CompanyName = a.Company.CompanyName, SpecyName = a.Specy.SpecyName, CategoryId = a.CategoryId, ItemName = a.ItemName, SellingPrice = a.SellingPrice, SpecyId = a.SpecyId, CompanyId = a.CompanyId, ByingPrice = a.ByingPrice, Note = a.Note }).ToListAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Category_VM> GetByCategoryAsync(string name)
        {
            try
            {
                var data = await db.Categories.Where(a => a.ItemName == name).Select(a => new Category_VM { CompanyName = a.Company.CompanyName, SpecyName = a.Specy.SpecyName, CategoryId = a.CategoryId, ItemName = a.ItemName, SellingPrice = a.SellingPrice, SpecyId = a.SpecyId, CompanyId = a.CompanyId, ByingPrice = a.ByingPrice, Note = a.Note }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Category_VM> GetCategoryByIdAsync(int id)
        {
            try
            {
                var data = await db.Categories.Where(a => a.CategoryId == id).Select(a => new Category_VM { CompanyName = a.Company.CompanyName, SpecyName = a.Specy.SpecyName, CategoryId = a.CategoryId, ItemName = a.ItemName, SellingPrice = a.SellingPrice, SpecyId = a.SpecyId, CompanyId = a.CompanyId, ByingPrice = a.ByingPrice, Note = a.Note }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
