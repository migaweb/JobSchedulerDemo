using FluentValidation.Results;
using JobSchedulerDemo.Application.Dtos;

namespace JobSchedulerDemo.Application.Exceptions;

public class ValidationException : ApplicationException
{
  public List<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();

  public ValidationException(ValidationResult validationResult)
  {
    ValidationErrors = validationResult.Errors
      .Select(q => new ValidationError(PropertyName: q.PropertyName, Error: q.ErrorMessage))
      .ToList();
  }
}
