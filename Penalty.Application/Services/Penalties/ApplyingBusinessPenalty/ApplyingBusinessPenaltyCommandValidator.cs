using FluentValidation;

namespace Penalty.Application.Services.Penalties.ApplyingBusinessPenalty
{
    public class ApplyingBusinessPenaltyCommandValidator : 
        AbstractValidator<ApplyingBusinessPenaltyCommand>
    {
        public ApplyingBusinessPenaltyCommandValidator()
        {
            RuleFor(d => d.Country)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("1001")
                .WithMessage("sorry, you have type a valid country name");
            RuleFor(d => d.StartDate)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("1001")
                .WithMessage("sorry, you have to type a valid start date");
            RuleFor(d => d.EndDate)
                .NotNull()
                .NotEmpty()
                .WithErrorCode("1001")
                .WithMessage("sorry, you have to type a valid start date")
                .GreaterThan(d => d.StartDate)
                .WithErrorCode("2001")
                .WithMessage("sorry, end date must be grater than start date");

        }
    }
}
