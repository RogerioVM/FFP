using FFP.Context;
using FFP.Models;
using FFP.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FFP.Controllers
{
    public class TimeController : Controller
    {
        private readonly TimeService _timeService;

        public TimeController(TimeService timeService)
        {
            _timeService = timeService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _timeService.GetTimes();
            return View(list);
        }


        /*public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);

                Modificar quando for carregar jogadores
        }
        */

        [HttpPost]
        public async Task<IActionResult> Create(Time time)
        {
            await _timeService.Create(time);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Bad Request");

            }

            var obj = await _timeService.GetTimeById(id.Value);
            if (obj == null)
            {
                return BadRequest("Bad Request");
            }

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Time time)
        {
            if (id != time.Id) // Valida o id recebido, ou se tem a tabela no DB
            {
                return BadRequest("Bad Request");
            }
            try
            {
                await _timeService.Update(time);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                throw;
            }
        }

        //GET: Time/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Bad Request");
            }

            var obj = await _timeService.GetTimeById(id.Value); // Por ser opcional, precisa usar o "Value"
            if (obj == null)
            {
                return BadRequest("Bad Request");
            }

            return View(obj);
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Delete(Time id)
        {
            try
            {
                await _timeService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

    }
}
