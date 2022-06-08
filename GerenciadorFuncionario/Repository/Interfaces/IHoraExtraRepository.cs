using GerenciadorFuncionario.Data.Dtos;

namespace GerenciadorFuncionario.Repository.Interfaces
{
    public interface IHoraExtraRepository
    {
        Task<HoraExtraDto> GetHoraExtra(int id, int qtdHoraExtra);
    }
}
