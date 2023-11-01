using BLL.Helper;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.SalesReportServices
{
    public interface ISalesReportServices
    {
        public Task<ResponseBody<SalesInvoce_VM>> GetAllSalesInvoceAsync();
        public Task<ResponseBody<SalesInvoce_VM>> GeToDataByFromDate(DateTime from);
        public Task<ResponseBody<SalesInvoce_VM>> GetAllSalesInvoce(DateTime from, DateTime to);
    }
}
