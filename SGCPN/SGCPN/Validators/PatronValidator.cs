using FluentValidation;
using SGCPN.Models;

namespace SGCPN.Validators
{
    public class PatronValidator : AbstractValidator<Patron>
    {
        public PatronValidator()
        {
            RuleFor(patron => patron.PatronName)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")

                .NotNull()
                .WithMessage("Nome não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("Nome precisa ter ao menos 3 caracteres")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(patron => patron.Password)
                .NotEmpty()
                .WithMessage("Senha não pode ser vazia")

                .NotNull()
                .WithMessage("Senha não pode ser vazia")

                .MinimumLength(8)
                .WithMessage("Senha precisa ter ao menos 8 caracteres")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(patron => patron.Email)
                .NotEmpty()
                .WithMessage("Email não pode ser vazio")

                .NotNull()
                .WithMessage("Email não pode ser vazio")

                .EmailAddress()
                .WithMessage("O email precisa ser válido");

            RuleFor(patron => patron.Sex)
                .NotEmpty()
                .WithMessage("Sexo não pode ser vazia")

                .NotNull()
                .WithMessage("Sexo não pode ser vazia")

                .MinimumLength(3)
                .WithMessage("Sexo precisa ter ao menos 3 caracteres")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(patron => patron.RgOrCnpj)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .Matches(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})")
                .WithMessage("CPF ou CNPJ inválido!");

            RuleFor(patron => patron.Telephone)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .MinimumLength(10)
                .WithMessage("O número deve ter 10 algarismos contando com o DDD")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(patron => patron.Cellphone)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .MinimumLength(10)
                .WithMessage("O número deve ter 11 algarismos contando com o DDD")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(patron => patron.Address)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("Campo precisa ter ao menos 3 caracteres")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(patron => patron.County)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("Campo precisa ter ao menos 3 caracteres")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(patron => patron.State)
                .NotEmpty()
                .WithMessage("Campo não pode ser vazio")

                .NotNull()
                .WithMessage("Campo não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("Campo precisa ter ao menos 3 caracteres")

                .MaximumLength(100)
                .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(patron => patron.AddressComplement)
               .NotEmpty()
               .WithMessage("Campo não pode ser vazio")

               .NotNull()
               .WithMessage("Campo não pode ser vazio")

               .MinimumLength(3)
               .WithMessage("Campo precisa ter ao menos 3 caracteres")

               .MaximumLength(100)
               .WithMessage("Campo não pode exceder 100 caracteres");

            RuleFor(patron => patron.ZipCode)
               .NotEmpty()
               .WithMessage("Campo não pode ser vazio")

               .NotNull()
               .WithMessage("Campo não pode ser vazio")

               .MinimumLength(7)
               .WithMessage("Campo precisa ter ao menos 7 caracteres")

               .MaximumLength(100)
               .WithMessage("Campo não pode exceder 100 caracteres");
        }

    }
}
