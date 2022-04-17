using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using learningSystem.Entities;

namespace learningSystem.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(LearningSystemDbContext dbContext)
        {
            //nonempty & email format
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            //8 signs & Uppercase letter & lowercase letter & digit & special sign
            RuleFor(x => x.Password)
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("Uppercase required (i.e. ABC)")
                .Matches("[a-z]").WithMessage("Lowercase required (i.e. abc)")
                .Matches("[0-9]").WithMessage("Digit required (i.e. 123)")
                .Matches("[^a-zA-Z0-9]").WithMessage("Special sign required (i.e. @#!)");
            
            //confirmation matches passowrd 
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password)
                .WithMessage("Passwords do not match");//safety&UX reasons

            //custom rule for unique
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "Emails' already in use! Try another one");
                    }
                });
        }
    }
}
