using FluentValidation;
using SGCPN.Models;

namespace SGCPN.Validators
{
    public class InstitutionValidator : AbstractValidator<Institution>
    {
        public InstitutionValidator()
        {
            RuleFor(institution => institution.InstitutionName)
               .NotEmpty()
               .WithMessage("Nome não pode ser vazio")

               .NotNull()
               .WithMessage("Nome não pode ser vazio")

               .MinimumLength(3)
               .WithMessage("Nome precisa ter ao menos 3 caracteres")

               .MaximumLength(100)
               .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(institution => institution.Password)
                .NotEmpty()
                .WithMessage("Senha não pode ser vazia")

                .NotNull()
                .WithMessage("Senha não pode ser vazia")

                .MinimumLength(8)
                .WithMessage("Senha precisa ter ao menos 8 caracteres")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(institution => institution.Cnpj)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .Matches(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})")
                .WithMessage("CPF ou CNPJ inválido!");

            RuleFor(institution => institution.Email)
                .NotEmpty()
                .WithMessage("Email não pode ser vazio")

                .NotNull()
                .WithMessage("Email não pode ser vazio")

                .EmailAddress()
                .WithMessage("O email precisa ser válido");

            RuleFor(institution => institution.ResponsibleName)
                .NotEmpty()
                .WithMessage("Nome do Responsável não pode ser vazio")

                .NotNull()
                .WithMessage("Nome do Responsável não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("Nome do Responsável precisa ter ao menos 3 caracteres")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            

            RuleFor(institution => institution.Telephone)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .MinimumLength(10)
                .WithMessage("O número deve ter 10 algarismos contando com o DDD")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(institution => institution.Cellphone)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .MinimumLength(10)
                .WithMessage("O número deve ter 11 algarismos contando com o DDD")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(institution => institution.Address)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("Campo precisa ter ao menos 3 caracteres")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(institution => institution.County)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("Campo precisa ter ao menos 3 caracteres")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(institution => institution.State)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("Campo precisa ter ao menos 3 caracteres")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(institution => institution.AddressComplement)
               .NotEmpty()
               .WithMessage("Campo não pode ser vazio")

               .NotNull()
               .WithMessage("Campo não pode ser vazio")

               .MinimumLength(3)
               .WithMessage("Campo precisa ter ao menos 3 caracteres")

               .MaximumLength(100)
               .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(institution => institution.ZipCode)
               .NotEmpty()
               .WithMessage("Campo não pode ser vazio")

               .NotNull()
               .WithMessage("Campo não pode ser vazio")

               .MinimumLength(7)
               .WithMessage("Campo precisa ter ao menos 7 caracteres")

               .MaximumLength(100)
               .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(institution => institution.Description)
               .NotEmpty()
               .WithMessage("Campo não pode ser vazio")

               .NotNull()
               .WithMessage("Campo não pode ser vazio")

               .MinimumLength(3)
               .WithMessage("Campo precisa ter ao menos 3 caracteres")

               .MaximumLength(300)
               .WithMessage("Campo não pode exceder 300 caracteres");
        }
    }
}
