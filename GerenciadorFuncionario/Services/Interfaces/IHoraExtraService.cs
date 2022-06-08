using GerenciadorFuncionario.Data.Dtos;

namespace GerenciadorFuncionario.Services.Interfaces
{
    public interface IHoraExtraService
    {
        Task<HoraExtraDto> GetHoraExtra(int id, int qtdHoraExtra);
    }
}
