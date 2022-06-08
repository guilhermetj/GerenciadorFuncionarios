using GerenciadorFuncionario.Models;

namespace GerenciadorFuncionario.Repository.Interfaces
{
    public interface IProfissionalRepository
    {
        Task<IEnumerable<Profissional>> Get();
        Task<Profissional> GetById(int id);
        void Create(Profissional profissional);
        void Update(Profissional profissional);
        void Delete(Profissional profissional);
        Task<bool> SaveChangesAsync();

    }
}
