using BLL.Helper;
using BLL.Service.SalesInvoceServices;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class SalesInvoceController : Controller
    {
        private readonly ISalesInvoceServices _salesInvoceServices;
        public static int num = 1;
        public SalesInvoceController(ISalesInvoceServices salesInvoceServices)
        {
            _salesInvoceServices = salesInvoceServices;
        }
        public async Task<IActionResult> AddSalesInvoce()
        {
            var Clients = await _salesInvoceServices.GetAllClientAsync();
            ViewBag.Clients = Clients.data.ToList();
            var Specy = await _salesInvoceServices.GetAllCategoryAsync();
            ViewBag.Specy = Specy.data.ToList();
            var last = await _salesInvoceServices.GetlastSalesInvoceAsync();
            if (last.data is not null)
            {
                ViewBag.Number = Math.Max(num, last.data.Select(x => x.SalesInvoceId).FirstOrDefault() + 1);
                if (num < last.data.Select(x => x.SalesInvoceId).FirstOrDefault() + 1)
                {
                    num = last.data.Select(x => x.ClientId).FirstOrDefault() + 1;
                }
            }
            else
            {
                ViewBag.Number=num;
            }
            
            return View();
        }

        public async Task<IActionResult> UpdateSalesInvoce(SalesInvoce_VM salesInvoce)
        {
            if (ModelState.IsValid)
            {
                var state = await _salesInvoceServices.EditSalesInvoceAsync(salesInvoce);
                if (state.status_code == 0)
                {
                    var last = await _salesInvoceServices.GetlastSalesInvoceAsync();
                    if (last.data is not null)
                    {
                        state.status_code = Math.Max(num, last.data.Select(x => x.SalesInvoceId).FirstOrDefault() + 1);
                        num = state.status_code;
                    }
                }
                return Json(state);
            }
            else
            {
                return View(salesInvoce);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSalesInvoce(SalesInvoce_VM salesInvoce)
        {
            if (ModelState.IsValid)
            {
                var state = await _salesInvoceServices.AddSalesInvoceAsync(salesInvoce);
                num++;
                if (state.status_code == 0)
                {
                    var last = await _salesInvoceServices.GetlastSalesInvoceAsync();
                    if (last.data is not null)
                    {
                        state.status_code = Math.Max(num, last.data.Select(x => x.SalesInvoceId).FirstOrDefault() + 1);
                        num = state.status_code;
                    }
                }
                return Json(state);
            }
            else
            {
                return View(salesInvoce);
            }
        }

        public async Task<IActionResult> EditSalesInvoce(int id)
        {
            var state = await _salesInvoceServices.GetSalesInvoceByIdAsync(id);
            if (state.status_code == 0)
            {
                var last = await _salesInvoceServices.GetlastSalesInvoceAsync();
                if (last.data is not null)
                {
                    state.status_code = Math.Max(num, last.data.Select(x => x.SalesInvoceId).FirstOrDefault() + 1);
                    num = state.status_code;
                }
            }
            return Json(state);
        }

        public async Task<IActionResult> DeleteSalesInvoce(int id)
        {
            var state = await _salesInvoceServices.DeleteSalesInvoceAsync(id);
            if (state.status_code == 0)
            {
                var last = await _salesInvoceServices.GetlastSalesInvoceAsync();
                if (last.data is not null)
                {
                    state.status_code = Math.Max(num, last.data.Select(x => x.SalesInvoceId).FirstOrDefault() + 1);
                    num = state.status_code;
                }
            }
            return Json(state);
        }

        public async Task<IActionResult> LoadData(int PageNumber = 1, int PageSize = 10)
        {
            var state = await _salesInvoceServices.GetAllSalesInvoceAsync();
            if (state.status_code == 0)
            {
                var last = await _salesInvoceServices.GetlastSalesInvoceAsync();
                if (last.data is not null)
                {
                    ViewBag.SalesInvoce = Math.Max(num, last.data.Select(x => x.SalesInvoceId).FirstOrDefault() + 1);
                    if (num < last.data.Select(x => x.SalesInvoceId).FirstOrDefault() + 1)
                    {
                        num = last.data.Select(x => x.ClientId).FirstOrDefault() + 1;
                    }
                }
                else
                {
                    ViewBag.SalesInvoce = num;
                }
            }
            var pagedData = Pagination.PagedResult(state.data.ToList(), PageNumber, PageSize);
            return Json(pagedData);
        }
    }
}
