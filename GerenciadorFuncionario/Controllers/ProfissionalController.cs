using GerenciadorFuncionario.Data.Dtos;
using GerenciadorFuncionario.Models;
using GerenciadorFuncionario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;

namespace GerenciadorFuncionario.Controllers
{
    public class ProfissionalController : Controller
    {
        private readonly ILogger<ProfissionalController> _logger;
        private readonly IProfissionalService _service;
        public ProfissionalController(ILogger<ProfissionalController> logger, IProfissionalService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var profissional = await _service.Get();

            return View(profissional);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profissional = await _service.GetById(id);


            return profissional != null ? Ok(profissional) : NotFound("Profissional não encontrado");
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProfissionalCreateDto request)
        {

            if (ModelState.IsValid)
            {
                await _service.Create(request);

                return RedirectToAction("Index");
            }
            return View();
        }
        //createview
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProfissionalUpdateDto request)
        {
            var profissional = await _service.GetById(request.Id);
            if (profissional == null)
            {
                ModelState.AddModelError(string.Empty, "Profissional não existe");
            }

            if (ModelState.IsValid)
            {
                await _service.Update(request.Id, request);

                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var profissional = await _service.GetById(id);

            return View(profissional);

        }

        [HttpPost, ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profissional = await _service.GetById(id);
            if (profissional == null)
            {
                ModelState.AddModelError(string.Empty, "Profissional não existe");
            }

            if (ModelState.IsValid)
            {
                await _service.Delete(id);

                return RedirectToAction("Index");
           }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var profissional = await _service.GetById(id);

            return View(profissional);

        }
    }
}