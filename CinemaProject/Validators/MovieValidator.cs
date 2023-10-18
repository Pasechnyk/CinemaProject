using DataAccess.Data.Entities;
using FluentValidation;

namespace CinemaProject.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name)
                .NotNull()
                .MaximumLength(100);
            RuleFor(x => x.TicketPrice)
                .NotEmpty().WithMessage("Price is required value.")
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Description).Length(10, 1000);
            RuleFor(x => x.ImageUrl)
                .Must(ValidateUri).WithMessage("{PropertyName} must be a valid URL address.");
        }

        public bool ValidateUri(string? uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return true;
            }
            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
