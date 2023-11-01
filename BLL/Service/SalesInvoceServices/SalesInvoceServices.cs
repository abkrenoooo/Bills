using BLL.Helper;
using DAL.Repository.SalesInvoceRepository;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.SalesInvoceServices
{
    public class SalesInvoceServices : ISalesInvoceServices
    {
        private readonly ISalesInvoceRepository _salesInvoceRepository;
        public SalesInvoceServices(ISalesInvoceRepository salesInvoceRepository)
        {
            _salesInvoceRepository = salesInvoceRepository;
        }
        public async Task<ResponseBody<SalesInvoce_VM>> AddSalesInvoceAsync(SalesInvoce_VM salesInvoce)
        {
            ResponseBody<SalesInvoce_VM> response = new ResponseBody<SalesInvoce_VM>();
            if (await _salesInvoceRepository.AddSalesInvoceAsync(salesInvoce) is not null)
            {
                response.message = "Sales Invoce has been Added successfully";
                response.data = new List<SalesInvoce_VM>() { salesInvoce };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = new List<SalesInvoce_VM>() { salesInvoce };
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<SalesInvoce_VM>> DeleteSalesInvoceAsync(int id)
        {
            ResponseBody<SalesInvoce_VM> response = new ResponseBody<SalesInvoce_VM>();
            var res = await _salesInvoceRepository.DeleteSalesInvoceAsync(id);
            if (!res)
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            else
            {
                response.message = "Sales Invoce has been Deleted successfully";
                response.data = null;
                response.status_code = 0;
            }
            return response;
        }

        public async Task<ResponseBody<SalesInvoce_VM>> EditSalesInvoceAsync(SalesInvoce_VM salesInvoce)
        {
            ResponseBody<SalesInvoce_VM> response = new ResponseBody<SalesInvoce_VM>();
            if (await _salesInvoceRepository.EditSalesInvoceAsync(salesInvoce) is not null)
            {
                response.message = "Sales Invoce has been Edit successfully";
                response.data = new List<SalesInvoce_VM>() { salesInvoce };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data =new List<SalesInvoce_VM>() { salesInvoce };
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Client_VM>> GetAllClientAsync()
        {
            ResponseBody<Client_VM> response = new ResponseBody<Client_VM>();
            if (await _salesInvoceRepository.GetAllClientAsync() is not null)
            {
                response.message = null;
                response.data = await _salesInvoceRepository.GetAllClientAsync();
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<SalesInvoce_VM>> GetAllSalesInvoceAsync()
        {
            ResponseBody<SalesInvoce_VM> response = new ResponseBody<SalesInvoce_VM>();
            if (await _salesInvoceRepository.GetAllSalesInvoceAsync() is not null)
            {
                response.message = null;
                response.data = await _salesInvoceRepository.GetAllSalesInvoceAsync();
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Category_VM>> GetAllCategoryAsync()
        {
            ResponseBody<Category_VM> response = new ResponseBody<Category_VM>();
            if (await _salesInvoceRepository.GetAllCategoryAsync() is not null)
            {
                response.message = null;
                response.data = await _salesInvoceRepository.GetAllCategoryAsync();
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }


        public async Task<ResponseBody<SalesInvoce_VM>> GetSalesInvoceByIdAsync(int id)
        {
            ResponseBody<SalesInvoce_VM> response = new ResponseBody<SalesInvoce_VM>();
            if (await _salesInvoceRepository.GetSalesInvoceByIdAsync(id) is not null)
            {
                response.message = null;
                response.data = new List<SalesInvoce_VM>() { await _salesInvoceRepository.GetSalesInvoceByIdAsync(id) };

                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<SalesInvoce_VM>> GetlastSalesInvoceAsync()
        {
            ResponseBody<SalesInvoce_VM> response = new ResponseBody<SalesInvoce_VM>();
            if (await _salesInvoceRepository.GetlastSalesInvoceAsync() is not null)
            {
                response.message = null;
                response.data = new List<SalesInvoce_VM>() { await _salesInvoceRepository.GetlastSalesInvoceAsync() };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }
    }
}
