using FFP.Models;
using FFP.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FFP.Controllers
{
    public class JogadorController : Controller
    {
        private readonly JogadorService _jogadorService;

        public JogadorController(JogadorService jogadorService)
        {
            _jogadorService= jogadorService;
        }
        public async Task<IActionResult> Index()
        {
            var listJogadores = await _jogadorService.GetJogadores();
            return View(listJogadores);
        }

        [HttpPost]

        public async Task<IActionResult> Create(Jogador jogador)
        {
            await _jogadorService.Create(jogador);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return BadRequest("Bad Request!");
            }
            var jogador = await _jogadorService.GetJogadorById(id.Value);
            if(jogador == null)
            {
                return BadRequest("Bad Request!");
            }

            return View(jogador);   
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, Jogador jogador)
        {
            if(id != jogador.Id)
            {
                return BadRequest("O id é inválido");
            }

            try
            {
                await _jogadorService.Update(jogador);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Bad Request");
            }

            var obj = await _jogadorService.GetJogadorById(id.Value); // Por ser opcional, precisa usar o "Value"
            if (obj == null)
            {
                return BadRequest("Bad Request");
            }

            return View(obj);
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> Delete(Jogador id)
        {
            try
            {
                await _jogadorService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}
