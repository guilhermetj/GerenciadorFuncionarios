using FluentValidation;
using GerenciadorFuncionario.Data.Dtos;

namespace GerenciadorFuncionario.Validators.ProfissionalValidator
{
    public class ProfissionalUpdateValidator : AbstractValidator<ProfissionalUpdateDto>
    {
        public ProfissionalUpdateValidator()
        {
            RuleFor(p => p.NomeCompleto).Length(2, 45);
            RuleFor(p => p.Telefone).Matches("[2-9][0-9]{10}");
            RuleFor(p => p.Endereco).Length(2, 55);
            RuleFor(p => p.Rg).Length(6);
        }
    }
}
