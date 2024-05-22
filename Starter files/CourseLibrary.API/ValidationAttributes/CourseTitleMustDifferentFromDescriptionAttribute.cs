using CourseLibrary.API.Models;
using System.ComponentModel.DataAnnotations;

namespace CourseLibrary.API.ValidationAttributes
{
    public class CourseTitleMustDifferentFromDescriptionAttribute : ValidationAttribute
    {
        public CourseTitleMustDifferentFromDescriptionAttribute()
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is not CourseForManipulationDto course)
            {
                throw new Exception($"Attribute " + 
                    $"{nameof(CourseTitleMustDifferentFromDescriptionAttribute)}" +
                    $"must be applied to a " +
                    $"{nameof(CourseForManipulationDto)} or derived type.");
            }

            if (course.Title == course.Description)
            {
                return new ValidationResult(
                    "The provided description should be different from the title.",
                    new[] { nameof(CourseForCreationDto)});
            }

            return ValidationResult.Success;
        }
    }
}
