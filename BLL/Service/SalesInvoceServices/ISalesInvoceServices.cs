using BLL.Helper;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.SalesInvoceServices
{
    public interface ISalesInvoceServices
    {
        public Task<ResponseBody<SalesInvoce_VM>> AddSalesInvoceAsync(SalesInvoce_VM salesInvoce);
        public Task<ResponseBody<SalesInvoce_VM>> EditSalesInvoceAsync(SalesInvoce_VM salesInvoce);
        public Task<ResponseBody<SalesInvoce_VM>> DeleteSalesInvoceAsync(int id);
        public Task<ResponseBody<SalesInvoce_VM>> GetSalesInvoceByIdAsync(int id);
        public Task<ResponseBody<SalesInvoce_VM>> GetAllSalesInvoceAsync();
        public Task<ResponseBody<Client_VM>> GetAllClientAsync();
        public Task<ResponseBody<Category_VM>> GetAllCategoryAsync();
        public Task<ResponseBody<SalesInvoce_VM>> GetlastSalesInvoceAsync();
    }
}
