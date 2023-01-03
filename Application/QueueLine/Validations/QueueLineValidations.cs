using Application.QueueLine.DTO;
using FluentValidation;

namespace Application.QueueLine.Validations
{
    public class QueueLineValidations : AbstractValidator<QueueLinePostDto>
    {
        public QueueLineValidations()
        {
            RuleFor(x => x.QueueName)
                .NotEmpty().NotNull()
                .WithMessage("El campo {PropertyName} es requerido.");

            RuleFor(x => x.Description)
                .NotEmpty().NotNull()
                .WithMessage("El campo {PropertyName} es requerido.");
        }
    }
}