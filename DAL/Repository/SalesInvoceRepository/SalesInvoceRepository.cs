using DAL.Data;
using DAL.Models;
using DAL.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.SalesInvoceRepository
{
    public class SalesInvoceRepository : ISalesInvoceRepository
    {
        private readonly ApplicationDbContext db;

        public SalesInvoceRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<SalesInvoce_VM> AddSalesInvoceAsync(SalesInvoce_VM salesInvoce)
        {
            try
            {
                var data = new SalesInvoce
                {
                    Date = salesInvoce.Date,
                    ClientId = salesInvoce.ClientId,
                    CategoryId = salesInvoce.CategoryId,
                    Quantity = salesInvoce.Quantity,
                    PercentageDiscount = salesInvoce.PercentageDiscount,
                    ValueDiscount = salesInvoce.ValueDiscount,
                };
                await db.SalesInvoces.AddAsync(data);
                var res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    return salesInvoce;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteSalesInvoceAsync(int id)
        {
            try
            {
                var data = await db.SalesInvoces.FindAsync(id);
                db.SalesInvoces.Remove(data);
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

        public async Task<SalesInvoce_VM> EditSalesInvoceAsync(SalesInvoce_VM salesInvoce)
        {
            try
            {
                var data = new SalesInvoce
                {

                    Date = salesInvoce.Date,
                    ClientId = salesInvoce.ClientId,
                    CategoryId = salesInvoce.CategoryId,
                    SalesInvoceId = salesInvoce.SalesInvoceId,
                    Quantity = salesInvoce.Quantity,
                    PercentageDiscount = salesInvoce.PercentageDiscount,
                    ValueDiscount = salesInvoce.ValueDiscount,
                };
                db.Entry(data).State = EntityState.Modified;
                int res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    salesInvoce.SalesInvoceId = data.SalesInvoceId;
                    return salesInvoce;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<SalesInvoce_VM>> GetAllSalesInvoceAsync()
        {
            try
            {
                var data = await db.SalesInvoces.Select(a => new SalesInvoce_VM
                {
                    Date = a.Date,
                    ClientId = a.ClientId,
                    CategoryId = a.CategoryId,
                    SalesInvoceId = a.SalesInvoceId,
                    Quantity = a.Quantity,
                    SellingPrice = a.Category.SellingPrice,
                    PercentageDiscount = a.PercentageDiscount,
                    ValueDiscount = a.ValueDiscount,
                    ClientName = a.Client.ClientName,
                    CategoryName = a.Category.ItemName,
                    Net = (a.Quantity * a.Category.SellingPrice) - (((a.Quantity * a.Category.SellingPrice) * (a.PercentageDiscount / 100))) - a.ValueDiscount,
                }).ToListAsync();
                return data;
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
                var data = await db.Clients.Select(a => new Client_VM { Address = a.Address, ClientId = a.ClientId, ClientName = a.ClientName, Phone = a.Phone }).ToListAsync();
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
                var data = await db.Categories.Select(a => new Category_VM { SpecyId = a.SpecyId, CategoryId = a.CategoryId, ItemName = a.ItemName, SellingPrice = a.SellingPrice, ByingPrice = a.ByingPrice, CompanyId = a.CompanyId, CompanyName = a.Company.CompanyName, SpecyName = a.Specy.SpecyName, Note = a.Note }).ToListAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SalesInvoce_VM> GetSalesInvoceByIdAsync(int id)
        {
            try
            {
                var data = await db.SalesInvoces.Where(a => a.SalesInvoceId == id).Select(a => new SalesInvoce_VM
                {
                    Date = a.Date,
                    ClientId = a.ClientId,
                    CategoryId = a.CategoryId,
                    SalesInvoceId = a.SalesInvoceId,
                    Quantity = a.Quantity,
                    SellingPrice = a.Category.SellingPrice,
                    PercentageDiscount = a.PercentageDiscount,
                    ValueDiscount = a.ValueDiscount,
                    ClientName = a.Client.ClientName,
                    CategoryName = a.Category.ItemName,
                    Net = (a.Quantity * a.Category.SellingPrice) - (((a.Quantity * a.Category.SellingPrice) * (a.PercentageDiscount / 100))) - a.ValueDiscount,
                    Total = a.Quantity * a.Category.SellingPrice
                }).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<SalesInvoce_VM> GetlastSalesInvoceAsync()
        {
            try
            {
                var data1 = await db.SalesInvoces.MaxAsync(a => a.SalesInvoceId);
                var data = await GetSalesInvoceByIdAsync(data1);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
