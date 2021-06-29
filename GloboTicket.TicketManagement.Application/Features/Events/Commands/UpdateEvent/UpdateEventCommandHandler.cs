using AutoMapper;
using GloboTicket.TicketManagement.Domain.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
  public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
  {
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
    {
      _eventRepository = eventRepository;
      _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
      var eventToUpdate = await _eventRepository.GetByIdAsync(request.Id);

      _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

      await _eventRepository.UpdateAsync(eventToUpdate);

      return Unit.Value;
    }
  }
}