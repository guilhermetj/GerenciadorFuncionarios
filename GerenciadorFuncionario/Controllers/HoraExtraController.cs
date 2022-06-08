using GerenciadorFuncionario.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFuncionario.Controllers
{
    public class HoraExtraController : Controller
    {
        private readonly IHoraExtraService _serviceHoraExtra;
        private readonly IProfissionalService _profissionalService;

        public HoraExtraController(IHoraExtraService serviceHoraExtra, IProfissionalService profissionalService)
        {
            _serviceHoraExtra = serviceHoraExtra;
            _profissionalService = profissionalService;
        }
        [Route("HoraExtra")]
        public async Task<IActionResult> Index()
        {
            var profissional = await _profissionalService.Get();
            return View(profissional);
        }
        
        [HttpPost]
        public async Task<IActionResult> Resumo(int id, int qtdHoraExtra)
        {
            var resumoHoraextra = await _serviceHoraExtra.GetHoraExtra(id, qtdHoraExtra);

            return View(resumoHoraextra);
        }
    }
}
