using Application.QueuePerson.DTO;
using Application.QueuePerson.Validations.Custom;
using FluentValidation;

namespace Application.QueuePerson.Validations
{
    public class QueuePersonPostValidations : AbstractValidator<QueuePersonPostDto>
    {
        private readonly IQueuePersonValidationMethods queuePersonValidationMethods;

        public QueuePersonPostValidations
            (IQueuePersonValidationMethods queuePersonValidationMethods)
        {
            this.queuePersonValidationMethods = queuePersonValidationMethods;

            RuleFor(x => x.PersonId)
                .NotNull()
                .NotEmpty()
                .WithMessage("EL campo {PropertyName} es requerido.")
                .Custom(async (personId, context) => //Person existence
                {
                    var personExists = await queuePersonValidationMethods.PersonExists(personId);

                    if (!personExists)
                        context.AddFailure("La persona no esta registrada.");
                });

            RuleFor(x => x.QueueLineId)
                .NotNull()
                .NotEmpty()
                .WithMessage("EL campo {PropertyName} es requerido.")
                .Custom(async (queueLineId, context) => //Queue existence
                {
                    var queueExists = await queuePersonValidationMethods.QueueExists(queueLineId);

                    if (!queueExists)
                        context.AddFailure("La cola no esta registrada.");
                });

            RuleFor(x => new { x.PersonId, x.QueueLineId })
                .Custom(async (x, context) =>
                {
                    var personAttending = await queuePersonValidationMethods
                    .PersonAttending(x.PersonId, x.QueueLineId);

                    if (personAttending)
                        context.AddFailure("La persona ya se esta atendiendo en esta cola");
                });

            RuleFor(x => x)
                .Custom(async (x, context) =>
                {
                    var pregnantPersonIsFemale = await
                    queuePersonValidationMethods.PregnantPersonIsFemale(x);

                    if(!pregnantPersonIsFemale)
                        context.AddFailure("Una persona de sexo masculino no puede llevar la condicion de embarazo.");
                });

            RuleFor(x => x.ConditionsIds)
                .Custom(async (conditions, context) =>
                {
                    var conditionOutOfRange =
                    queuePersonValidationMethods.ConditionOutOfRange(conditions);

                    if (conditionOutOfRange)
                        context.AddFailure("Solo la condition 1 y 2 son asignables manualmente.");
                });
        }
    }
}
