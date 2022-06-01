using BLL.Helper;
using DAL.Repository.SalesReportRepository;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.SalesReportServices
{
    public class SalesReportServices : ISalesReportServices
    {
        private readonly ISalesReportRepository _salesReportRepository;
        public SalesReportServices(ISalesReportRepository salesReportRepository)
        {
            _salesReportRepository = salesReportRepository;
        }
        public async Task<ResponseBody<SalesInvoce_VM>> GetAllSalesInvoceAsync()
        {
            ResponseBody<SalesInvoce_VM> response = new ResponseBody<SalesInvoce_VM>();
            if (await _salesReportRepository.GetAllSalesInvoceAsync() is not null)
            {
                response.message = null;
                response.data = await _salesReportRepository.GetAllSalesInvoceAsync();
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
        public async Task<ResponseBody<SalesInvoce_VM>> GeToDataByFromDate(DateTime from)
        {
            ResponseBody<SalesInvoce_VM> response = new ResponseBody<SalesInvoce_VM>();
            if (await _salesReportRepository.GeToDataByFromDate(from) is not null)
            {
                response.message = null;
                response.data = await _salesReportRepository.GeToDataByFromDate(from); ;
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
        public async Task<ResponseBody<SalesInvoce_VM>> GetAllSalesInvoce(DateTime from, DateTime to)
        {
            ResponseBody<SalesInvoce_VM> response = new ResponseBody<SalesInvoce_VM>();
            if (await _salesReportRepository.GetAllSalesInvoce(from, to) is not null)
            {
                response.message = null;
                response.data = await _salesReportRepository.GetAllSalesInvoce(from, to);
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
