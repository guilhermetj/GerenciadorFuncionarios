using AutoMapper;
using GerenciadorFuncionario.Data.Dtos;
using GerenciadorFuncionario.Models;

namespace GerenciadorFuncionario.Helpers
{
    public class TesteStrudiosTIProfile : Profile
    {
        public TesteStrudiosTIProfile()
        {
            CreateMap<Profissional, ProfissionalDto>();
            CreateMap<Profissional, ProfissionalDetailsDto>();
            CreateMap<ProfissionalCreateDto, Profissional>();
            CreateMap<ProfissionalUpdateDto, Profissional>();
        }
    }
}
