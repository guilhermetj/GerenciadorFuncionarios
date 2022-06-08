using GerenciadorFuncionario.Data.Dtos;

namespace GerenciadorFuncionario.Services.Interfaces
{
    public interface IProfissionalService
    {
        Task<IEnumerable<ProfissionalDto>> Get();
        Task<ProfissionalDetailsDto> GetById(int id);
        Task<bool> Create(ProfissionalCreateDto profissional);
        Task<bool> Update(int id, ProfissionalUpdateDto profissional);
        Task<bool> Delete(int id);
    }
}
