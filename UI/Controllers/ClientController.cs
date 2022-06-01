using BLL.Helper;
using BLL.Service.ClientServices;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientServices _clientServices;
        public static int num = 1;
        public ClientController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        public async Task<ActionResult> AddClientAsync()
        {
            var last = await _clientServices.GetlastClientAsync();
            if (last.data is not null)
            {
                ViewBag.Number = Math.Max(num, last.data.Select(x => x.ClientId).FirstOrDefault() + 1);
                if (num < last.data.Select(x => x.ClientId).FirstOrDefault() + 1)
                {
                    num = last.data.Select(x => x.ClientId).FirstOrDefault() + 1;
                }
            }
            else
            {
                ViewBag.Number = num;
            }
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddClient(Client_VM client)
        {
            if (ModelState.IsValid)
            {
                var state = await _clientServices.AddClientAsync(client);
                num++;
                if (state.status_code == 0)
                {
                    var last = await _clientServices.GetlastClientAsync();
                    if (last.data is not null)
                    {
                        state.status_code = Math.Max(num, last.data.Select(x => x.ClientId).FirstOrDefault() + 1);
                        num = state.status_code;
                    }
                }
                return Json(state);
            }
            else
            {
                return View(client);
            }
        }
        public async Task<IActionResult> UpdateClient(Client_VM client)
        {
            if (ModelState.IsValid)
            {
                var state = await _clientServices.EditClientAsync(client);
                if (state.status_code == 0)
                {
                    var last = await _clientServices.GetlastClientAsync();
                    if (last.data is not null)
                    {
                        state.status_code = Math.Max(num, last.data.Select(x => x.ClientId).FirstOrDefault() + 1);
                        num = state.status_code;
                    }
                }
                return Json(state);
            }
            else
            {
                return View(client);
            }
        }

        public async Task<IActionResult> EditClient(int id)
        {

            var state = await _clientServices.GetClientByIdAsync(id);
            if (state.status_code == 0)
            {
                var last = await _clientServices.GetlastClientAsync();
                if (last.data is not null)
                {
                    state.status_code = Math.Max(num, last.data.Select(x => x.ClientId).FirstOrDefault() + 1);
                    num = state.status_code;
                }
            }
            return Json(state);
        }

        public async Task<IActionResult> DeleteClient(int id)
        {
            var state = await _clientServices.DeleteClientAsync(id);
            if (state.status_code == 0)
            {
                var last = await _clientServices.GetlastClientAsync();
                if (last.data is not null)
                {
                    state.status_code = Math.Max(num, last.data.Select(x => x.ClientId).FirstOrDefault() + 1);
                    num = state.status_code;
                }
            }
            return Json(state);
        }

        public async Task<IActionResult> LoadData(int PageNumber = 1, int PageSize = 10)
        {

            var state = await _clientServices.GetAllClientAsync();
            if (state.status_code == 0)
            {
                var last = await _clientServices.GetlastClientAsync();
                if (last.data is not null)
                {
                    ViewBag.Client = Math.Max(num, last.data.Select(x => x.ClientId).FirstOrDefault() + 1);
                    if (num < last.data.Select(x => x.ClientId).FirstOrDefault() + 1)
                    {
                        num = last.data.Select(x => x.ClientId).FirstOrDefault() + 1;
                    }
                }
                else
                {
                    ViewBag.Client = num;
                }
            }
            var pagedData = Pagination.PagedResult(state.data.ToList(), PageNumber, PageSize);
            return Json(pagedData);
        }
    }
}
