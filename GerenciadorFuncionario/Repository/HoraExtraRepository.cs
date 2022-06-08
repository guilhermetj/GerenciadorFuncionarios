using GerenciadorFuncionario.Data;
using GerenciadorFuncionario.Data.Dtos;
using GerenciadorFuncionario.Extensions;
using GerenciadorFuncionario.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorFuncionario.Repository
{
    public class HoraExtraRepository : IHoraExtraRepository
    {
        private readonly GerenciadorFuncionarioDbContext _context;
        public HoraExtraRepository(GerenciadorFuncionarioDbContext context)
        {
            _context = context;
        }
        public async Task<HoraExtraDto> GetHoraExtra(int id, int qtdHoraExtra)
        {
            var profissionalBanco = await _context.profissionais
                                    .Where(p => p.Id == id)
                                    .FirstOrDefaultAsync();
            if(profissionalBanco == null)
            {
                throw new NotFoundException("Profissional não encontrado");
            }
            var valorHoraExtra = 0.05 * profissionalBanco.Salario;

            var totalHoraExtra = qtdHoraExtra * valorHoraExtra;

            HoraExtraDto resume = new HoraExtraDto
            {
                IdProfissional = profissionalBanco.Id,
                NomeProfissioanl = profissionalBanco.NomeCompleto,
                SalarioProfissional = profissionalBanco.Salario,
                QtdHoraExtra = qtdHoraExtra,
                ValorHoraExtra = valorHoraExtra,
                SalarioHoraExtra = profissionalBanco.Salario + totalHoraExtra
            };

            return resume;
        }
    }
}
