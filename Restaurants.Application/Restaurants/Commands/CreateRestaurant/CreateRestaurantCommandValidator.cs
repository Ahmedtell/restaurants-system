using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        private readonly List<string> validCategories = ["Italian", "Mexican", "Jappanase", "Indin"];
        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Restaurant name is required!")
                .Length(3, 255).WithName("Restaurant name must be between 3 ad 255");


            RuleFor(dto => dto.Category)
                .Must(category => validCategories.Contains(category))
                .WithMessage("Provide valid category from the valid categories list");

            //RuleFor(dto => dto.Category).Custom((value, context) =>
            //{
            //    var isValidCategory = validCategories.Contains(value);
            //    if (!isValidCategory)
            //    {
            //        context.AddFailure(nameof(RestaurantDto.Category), "Invalid category, please choose from the valid categories list");
            //    }
            //});

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(dto => dto.Category)
                .NotEmpty().WithMessage("Insert a valid category");

            RuleFor(dto => dto.ContactEmail)
                .EmailAddress()
                .WithMessage("Please provide valid email address");

            RuleFor(dto => dto.ContactNumber)
                .Matches(@"^\d{10}$")
                .WithMessage("Contact number must be exactly 10 digits");

            RuleFor(dto => dto.PostalCode)
                .Matches(@"^\d{2}-\d{3}")
                .WithMessage("Please provide a valid postal code (XX-XXX");
        }

    }
}
