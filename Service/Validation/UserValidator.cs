using FluentValidation;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation
{
    public class UserValidator : AbstractValidator<UserCreateDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(200).WithMessage("Email cannot exceed 200 characters")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Email must be a valid email address");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("Invalid user role specified");
        }

    }

}
