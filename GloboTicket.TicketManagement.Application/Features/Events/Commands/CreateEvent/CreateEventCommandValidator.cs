using FluentValidation;
using GloboTicket.TicketManagement.Domain.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
  public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
  {
    private readonly IEventRepository _eventRepository;

    public CreateEventCommandValidator(IEventRepository eventRepository)
    {
      _eventRepository = eventRepository;
      RuleFor(p => p.Name).NotEmpty().NotNull().MaximumLength(50);

      RuleFor(p => p.Date).NotEmpty().NotNull().GreaterThan(DateTime.Now);

      RuleFor(p => p.Price).NotEmpty().GreaterThan(0);

      RuleFor(e => e).MustAsync(EventNameAndDateUnique)
        .WithMessage("An event with the same name and date already exists.");
    }

    private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
    {
      return !(await _eventRepository.ExistEventNameAndDate(e.Name, e.Date));
    }
  }
}