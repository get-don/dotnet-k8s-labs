using System.ComponentModel.DataAnnotations;

namespace TodoServer.Validations;

public class NotWhiteSpaceAttribute : ValidationAttribute

{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string str || string.IsNullOrWhiteSpace(str))
        {
            return new ValidationResult("Content cannot be empty or whitespace.");
        }

        return ValidationResult.Success;
    }
}
