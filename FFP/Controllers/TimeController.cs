using FFP.Context;
using FFP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FFP.Controllers
{
    public class TimeController : Controller
    {
        private readonly DataContext _dataContext;

        public TimeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //GET: Times
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Times.ToListAsync());
        }

        //GET: Times/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _dataContext.Times == null)
            {
                return NotFound();
            }

            var time = await _dataContext.Times
                .FirstOrDefaultAsync(t => t.Id == id);

            if(time == null)
            {
                return NotFound();
            }

            return View(time);
        }

        //GET: Time/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Time/Create
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id, Nome")] Time time)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Add(time);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(time);
        }

        //GET: Time/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _dataContext.Times == null) // Valida o id recebido, ou se tem a tabela no DB
            {
                return NotFound();
            }
            var time = await _dataContext.Times
                              .FindAsync(id); // Armazena o id buscado do DB.
            if (time == null)
            {
                return NotFound();
            }

            return View(time);
        }

        //Post
        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome")] Time time)
        {
            if (id != time.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _dataContext.Update(time);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DBConcurrencyException)
                {

                    if (!TimeExists(time.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(time);
        }

        //GET: Time/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _dataContext.Times == null) // Valida o id passado pelo usuario, ou se tem a tabela no DB
            {
                return NotFound();
            }
            var time = await _dataContext.Times
                            .FirstOrDefaultAsync(t => t.Id == id) ; // Armazena o id buscado do DB.
            if (time == null)
            {
                return NotFound();
            }

            return View(time);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_dataContext.Times == null)
            {
                return Problem("Entity set 'FFP.Times' is null");
            }
            var time = await _dataContext.Times.FindAsync(id);

            if(time != null) 
            {
                _dataContext.Times.Remove(time);
            }
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool TimeExists(int id)
        {
            return _dataContext.Times.Any(t => t.Id == id);
        }
    }
}
