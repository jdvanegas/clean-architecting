using FluentValidation;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
  public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
  {
    public CreateCategoryCommandValidator()
    {
      RuleFor(p => p.Name).NotEmpty().NotNull();
    }
  }
}