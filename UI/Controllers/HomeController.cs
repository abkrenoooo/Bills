using BLL.Helper;
using BLL.Service.SalesReportServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ISalesReportServices _salesReportServices;

        public HomeController(ILogger<HomeController> logger, ISalesReportServices salesReportServices)
        {
            _logger = logger;
            _salesReportServices = salesReportServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> SalesReportAsync()
        {
            var state = await _salesReportServices.GetAllSalesInvoceAsync();
            ViewBag.From = state.data;
            return View();
        }
        public async Task<IActionResult> GeToDataByFromDate(DateTime From)
        {
            var state = await _salesReportServices.GeToDataByFromDate(From);
            return Json(state.data);
        }

        public async Task<IActionResult> LoadData(DateTime from, DateTime to, int PageNumber = 1, int PageSize = 10)
        {
            var state = await _salesReportServices.GetAllSalesInvoce(from, to);
            var pagedData = Pagination.PagedResult(state.data.ToList(), PageNumber, PageSize);
            return Json(pagedData);
        }
    }
}
