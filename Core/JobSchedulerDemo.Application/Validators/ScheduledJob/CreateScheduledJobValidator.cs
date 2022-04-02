using FluentValidation;
using JobSchedulerDemo.Application.Constants;
using JobSchedulerDemo.Application.Dtos;

namespace JobSchedulerDemo.Application.Validators.ScheduledJob
{
  public class CreateScheduledJobValidator : AbstractValidator<CreateScheduledJobDto>
  {
    public CreateScheduledJobValidator()
    {
      RuleFor(p => p.Name).NotEmpty()
                          .WithMessage(ValidationMessageConstants.RequiredMessage)
                          .NotNull()
                          .WithMessage(ValidationMessageConstants.RequiredMessage);
    }
  }
}
