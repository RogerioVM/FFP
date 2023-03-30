using FFP.Context;
using FFP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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




    }
}
