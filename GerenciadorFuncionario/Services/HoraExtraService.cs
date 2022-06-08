
using GerenciadorFuncionario.Data.Dtos;
using GerenciadorFuncionario.Repository.Interfaces;
using GerenciadorFuncionario.Services.Interfaces;

namespace GerenciadorFuncionario.Services
{
    public class HoraExtraService : IHoraExtraService
    {
        private readonly IHoraExtraRepository _repository;

        public HoraExtraService(IHoraExtraRepository repository)
        {
            _repository = repository;
        }
        public async Task<HoraExtraDto> GetHoraExtra(int id, int qtdHoraExtra)
        {
            return await _repository.GetHoraExtra(id, qtdHoraExtra);
        }
    }
}
