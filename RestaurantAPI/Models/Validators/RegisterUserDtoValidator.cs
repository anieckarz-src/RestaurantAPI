using FluentValidation;
using RestaurantAPI.Data;
using System.Linq;

namespace RestaurantAPI.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {

        public RegisterUserDtoValidator(RestaurantDbContext dbContext)
        {
            RuleFor(x=>x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password).MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(e=> e.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    bool isPresent = dbContext.Users.Any(u => u.Email == value);
                     
                    if (isPresent)
                    {
                        context.AddFailure("Email", "Email is taken");
                    }
                });
        }
    }
}
