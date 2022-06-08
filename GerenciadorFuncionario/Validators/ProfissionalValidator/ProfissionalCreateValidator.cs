using FluentValidation;
using GerenciadorFuncionario.Data.Dtos;

namespace GerenciadorFuncionario.Validators.ProfissionalValidator
{
    public class ProfissionalCreateValidator : AbstractValidator<ProfissionalCreateDto>
    {
        public ProfissionalCreateValidator()
        {
            RuleFor(p => p.NomeCompleto).NotEmpty().NotNull().Length(2, 45);
            RuleFor(p => p.Telefone).NotEmpty().NotNull().Matches("[2-9][0-9]{10}");
            RuleFor(p => p.Salario).NotEmpty().NotNull();
            RuleFor(p => p.Endereco).NotEmpty().NotNull().Length(2, 55);
            RuleFor(p => p.Rg).NotEmpty().NotNull().Length(6);
        }
    }
}
