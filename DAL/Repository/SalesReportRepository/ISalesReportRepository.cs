using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.SalesReportRepository
{
    public interface ISalesReportRepository
    {
        public Task<List<SalesInvoce_VM>> GetAllSalesInvoceAsync();
        public Task<List<SalesInvoce_VM>> GeToDataByFromDate(DateTime from);
        public Task<List<SalesInvoce_VM>> GetAllSalesInvoce(DateTime from, DateTime to);

    }
}
