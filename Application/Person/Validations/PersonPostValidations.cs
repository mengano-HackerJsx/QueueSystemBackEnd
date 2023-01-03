using Application.Person.DTO;
using FluentValidation;

namespace Application.Person.Validations
{
    public class PersonPostValidations : AbstractValidator<PersonPostDto>
    {
        public PersonPostValidations()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("El campo {PropertyName} es requerido.")
                .Must(FirstCapLetter)
                .WithMessage("La primera letra debe ser mayuscula.");
        }

        private bool FirstCapLetter(string name)
        {
            var firtsLetter = name[0].ToString();

            if (firtsLetter != firtsLetter.ToUpper()) return false;

            return true;
        }
    }
}
