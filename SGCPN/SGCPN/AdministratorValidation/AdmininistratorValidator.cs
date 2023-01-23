using SGCPN.Models;
using FluentValidation;
using System.Text.RegularExpressions;


namespace SGCPN.AdministratorValidation
{

    public class AdmininistratorValidator : AbstractValidator<Administrator>
    {

        public AdmininistratorValidator(string pattern)
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

                .Must(pass => Regex.IsMatch(pass, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"))
                .WithMessage("Formato de senha inválido");

            RuleFor(x => x.Celullar)
                .NotEmpty()

                .WithMessage("O celular não pode ser vazio")

                .Must(cel => Regex.IsMatch(cel, @"^\([1 - 9]{ 2}\) (?:[2 - 8] | 9[1 - 9])[0 - 9]{ 3}\-[0 - 9]{ 4}$"))

                .WithMessage("Formato de celular inválido");

            RuleFor(x => x.Cep)
                .NotEmpty()

                .WithMessage("O cep não pode ser vazio")

                .Must(cep => Regex.IsMatch(cep, @"\^([\d]{ 2})\.?([\d]{ 3})\-? ([\d]{ 3})/"))

                .WithMessage("Formato de cep inválido");


            RuleFor(x => x.Cnpj)

              .NotEmpty()

              .WithMessage("O CNPJ não pode ser vazio")

              .Must(cnpj => Regex.IsMatch(cnpj, @"(^\d{ 2}\.\d{ 3}\.\d{ 3}\/\d{ 4}\-\d{ 2}$)"))

              .WithMessage("Formato de cnpj inválido");


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

               .Must(tel => Regex.IsMatch(tel, @"^\([0-9]{2}?(\s|-)?(9?[0-9]{4})-?([0-9]{4}$)"))

               .WithMessage("Formato de telefone inválido");


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
