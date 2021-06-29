using GloboTicket.TicketManagement.Domain.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
  public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
  {
    private readonly IAsyncRepository<Event> _eventRepository;

    public DeleteEventCommandHandler(IAsyncRepository<Event> eventRepository)
    {
      _eventRepository = eventRepository;
    }

    public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
      var eventToDelete = await _eventRepository.GetByIdAsync(request.Id);
      await _eventRepository.DeleteAsync(eventToDelete);

      return Unit.Value;
    }
  }
}