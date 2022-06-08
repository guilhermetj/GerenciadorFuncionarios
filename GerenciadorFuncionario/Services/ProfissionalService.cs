using AutoMapper;
using GerenciadorFuncionario.Data.Dtos;
using GerenciadorFuncionario.Extensions;
using GerenciadorFuncionario.Models;
using GerenciadorFuncionario.Repository.Interfaces;
using GerenciadorFuncionario.Services.Interfaces;

namespace GerenciadorFuncionario.Services
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly IProfissionalRepository _repository;
        private readonly IMapper _mapper;
        public ProfissionalService(IProfissionalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProfissionalDto>> Get()
        {
            var profissioanais = await _repository.Get();
            return _mapper.Map<IEnumerable<ProfissionalDto>>(profissioanais);
        }
        public async Task<ProfissionalDetailsDto> GetById(int id)
        {
            var profissionais = await _repository.GetById(id);
            return _mapper.Map<ProfissionalDetailsDto>(profissionais);
        }
        public async Task<bool> Create(ProfissionalCreateDto profissional)
        {
            var profissionalCreate = _mapper.Map<Profissional>(profissional);
            _repository.Create(profissionalCreate);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> Update(int id, ProfissionalUpdateDto profissional)
        {
            var profissionalBanco = await _repository.GetById(id);
            if(profissionalBanco == null)
            {
                throw new NotFoundException("Profissional não encontrado");
            }
            var profissionalUpdate = _mapper.Map(profissional, profissionalBanco);

            _repository.Update(profissionalUpdate);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var profissionalBanco = await _repository.GetById(id);
            if (profissionalBanco == null)
            {
                throw new NotFoundException("Profissional não encontrado");
            }
            _repository.Delete(profissionalBanco);

            return await _repository.SaveChangesAsync();
        }
    }
}
