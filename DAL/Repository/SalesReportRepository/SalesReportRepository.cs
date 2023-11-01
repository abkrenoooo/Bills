using DAL.Data;
using DAL.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.SalesReportRepository
{
    public class SalesReportRepository : ISalesReportRepository
    {
        private readonly ApplicationDbContext db;

        public SalesReportRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<SalesInvoce_VM>> GetAllSalesInvoceAsync()
        {
            try
            {
                var data = await db.SalesInvoces.Select(a => new SalesInvoce_VM
                {
                    Date = a.Date,
                    DateName= a.Date.Date.ToShortDateString()
                }).Distinct().ToListAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<SalesInvoce_VM>> GeToDataByFromDate(DateTime from)
        {
            try
            {
                var data = await db.SalesInvoces.Where(x => x.Date <= from).Select(a => new SalesInvoce_VM
                {
                    Date = a.Date,
                    DateName = a.Date.Date.ToShortDateString()
                }).Distinct().ToListAsync();
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<List<SalesInvoce_VM>> GetAllSalesInvoce(DateTime from, DateTime to)
        {
            try
            {
                var data = await db.SalesInvoces.Where(x => x.Date <= from&&x.Date>=to).Select(a => new SalesInvoce_VM
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
    }
}
