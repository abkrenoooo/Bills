using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.SalesInvoceRepository
{
    public interface ISalesInvoceRepository
    {
        public Task<SalesInvoce_VM> AddSalesInvoceAsync(SalesInvoce_VM salesInvoce);
        public Task<SalesInvoce_VM> EditSalesInvoceAsync(SalesInvoce_VM salesInvoce);
        public Task<bool> DeleteSalesInvoceAsync(int id);
        public Task<List<SalesInvoce_VM>> GetAllSalesInvoceAsync();
        public Task<List<Client_VM>> GetAllClientAsync();
        public Task<List<Category_VM>> GetAllCategoryAsync();
        public Task<SalesInvoce_VM> GetSalesInvoceByIdAsync(int id);
        public Task<SalesInvoce_VM> GetlastSalesInvoceAsync();
    }
}
