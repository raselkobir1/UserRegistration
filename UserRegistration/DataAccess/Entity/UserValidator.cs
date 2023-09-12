using FluentValidation;
using System.Text.RegularExpressions;

namespace UserRegistration.DataAccess.Entity
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(user => user.FullName)
               .NotEmpty()
               .WithMessage("Full name is required.")
               .Must(BeValidFullName)
               .WithMessage("Full name cannot contain special characters.");

            RuleFor(obj => obj.UserName)
                .NotEmpty()
                .WithMessage("User name is required")
                .MinimumLength(6)
                .WithMessage("Minimum length 6 character")
                .Must(BeValidUserName)
                .WithMessage("Username can only contain letters and numbers.");

            RuleFor(obj => obj.Password)
                .NotEmpty()
                .WithMessage("Your password cannot be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(20).WithMessage("Your password length must not exceed 20.");

            RuleFor(obj => obj.Email).NotEmpty().MaximumLength(200)
               .Matches(@"^[a-zA-Z0-9](?!.*[._-]{2})[a-zA-Z0-9._-]*[a-zA-Z0-9]@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.[a-zA-Z]{2,6}$")
               .WithMessage("Invalid email address");

            RuleFor(user => user.Address)
               .NotEmpty()
               .WithMessage("Address is required.")
               .Must(BeValidAddress)
               .WithMessage("Address cannot contain special characters.");

            RuleFor(user => user.MobileNumber)
                .NotEmpty()
                .MaximumLength(15)
                .WithMessage("Mobile number is required.")
                .Must(BeValidPhoneNumber)
                .WithMessage("Mobile number must contain only numeric characters.");
        }
        private bool BeValidUserName(string username)
        {
            var pattern = "^[a-zA-Z0-9]+$";
            return !string.IsNullOrEmpty(username) && Regex.IsMatch(username, pattern);
        }

        private bool BeValidAddress(string address)
        {
            // Use a regular expression to check if the address contains only letters, numbers, and common punctuation.
            var pattern = "^[a-zA-Z0-9.,' -]+$";
            return !string.IsNullOrEmpty(address) && Regex.IsMatch(address, pattern);
        }

        private bool BeValidPhoneNumber(string phoneNumber)
        {
            // Use a regular expression to check if the phone number contains only numeric characters.
            var pattern = "^[0-9]+$";
            return !string.IsNullOrEmpty(phoneNumber) && Regex.IsMatch(phoneNumber, pattern);
        }
        private bool BeValidFullName(string fullName)
        {
            // Use a regular expression to check if the full name contains only letters and spaces.
            var pattern = "^[A-Za-z ]+$";
            return !string.IsNullOrEmpty(fullName) && Regex.IsMatch(fullName, pattern);
        }
    }
}
