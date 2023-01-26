using SGCPN.Models;
using FluentValidation;
using System.Text.RegularExpressions;


namespace SGCPN.AdministratorValidation
{
    public class AdmininistratorValidator : AbstractValidator<Administrator>
    {
        public AdmininistratorValidator()
        {
            RuleFor(x => x.Name)

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio")

                .NotNull()
                .WithMessage("O nome não pode ser nulo")

                .MinimumLength(3)
                .WithMessage("O nome deve conter no mínimo 3 caracteres")

                .MaximumLength(100)
                .WithMessage("O nome deve conter no máximo 100 caracteres");

            RuleFor(x => x.Email)

                .NotEmpty()
                .WithMessage("O email não pode ser vazio")

                .NotNull()
                .WithMessage("O email não pode ser nulo")

                .EmailAddress()
                .WithMessage("Formato de email inválido");

            RuleFor(x => x.Password)

                .NotEmpty()
                .WithMessage("A senha não pode ser vazia")

                .NotNull()
                .WithMessage("A senha não pode ser nula")

                .MinimumLength(5)
                .WithMessage("A senha deve conter no mínimo 5 caracteres")

                .MaximumLength(20)
                .WithMessage("A senha deve conter no máximo 20 caracteres");

            RuleFor(x => x.Celullar)

                .NotEmpty()
                .WithMessage("O celular não pode ser vazio")

                .MinimumLength(12)
                .WithMessage("O celular deve conter no mínimo 12 caracteres")

                .MaximumLength(20)
                .WithMessage("O celular deve conter no máximo 20 caracteres");

            RuleFor(x => x.Cep)

                .NotEmpty()
                .WithMessage("O cep não pode ser vazio")

                .MinimumLength(10)
                .WithMessage("O cep deve conter no mínimo 10 caracteres")

                .MaximumLength(20)
                .WithMessage("O cep deve conter no máximo 20 caracteres"); 

            RuleFor(x => x.Cnpj)

                .NotEmpty()
                .WithMessage("O CNPJ não pode ser vazio")

                .MinimumLength(14)
                .WithMessage("O CNPJ deve conter no mínimo 14 caracteres")

                .MaximumLength(14)
                .WithMessage("O CNPJ deve conter no máximo 14 caracteres");

            RuleFor(x => x.County)

                .NotEmpty()
                .WithMessage("O município não pode ser vazio")

                .NotNull()
                .WithMessage("O município não pode ser nulo");

            RuleFor(x => x.Address)

                .NotEmpty()
                .WithMessage("O endereço não pode ser vazio")

                .NotNull()
                .WithMessage("O endereço não pode ser nulo");

            RuleFor(x => x.State)

                .NotEmpty()
                .WithMessage("O estado não pode ser vazio")

                .NotNull()
                .WithMessage("O estado não pode ser nulo");

            RuleFor(x => x.Sex)

                .NotEmpty()
                .WithMessage("O campo não pode ser vazio")

                .NotNull()
                .WithMessage("O campo não pode ser nulo");

            RuleFor(x => x.Telephone)

               .NotEmpty()
               .WithMessage("O telefone não pode ser vazio")

               .MinimumLength(20)
               .WithMessage("O telefone deve conter no mínimo 14 caracteres")

               .MaximumLength(25)
               .WithMessage("O telefone deve conter no máximo 14 caracteres");

            RuleFor(x => x.Number)

               .NotEmpty()
               .WithMessage("O número não pode ser vazio")

               .NotNull()
               .WithMessage("O número não pode ser nulo");

            RuleFor(x => x.AddressComplement)

               .NotEmpty()
               .WithMessage("O complemento não pode ser vazio")

               .NotNull()
               .WithMessage("O complemento não pode ser nulo");

        }


    }

}
