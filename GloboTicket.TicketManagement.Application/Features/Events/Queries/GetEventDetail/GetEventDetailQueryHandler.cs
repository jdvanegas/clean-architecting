using AutoMapper;
using GloboTicket.TicketManagement.Domain.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
  public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
  {
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IAsyncRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public GetEventDetailQueryHandler(
      IAsyncRepository<Event> eventRepository,
      IAsyncRepository<Category> categoryRepository,
      IMapper mapper)
    {
      _eventRepository = eventRepository;
      _categoryRepository = categoryRepository;
      _mapper = mapper;
    }

    public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
    {
      var @event = await _eventRepository.GetByIdAsync(request.Id);
      var eventDetailVm = _mapper.Map<EventDetailVm>(@event);

      var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);
      eventDetailVm.Category = _mapper.Map<CategoryDto>(category);

      return eventDetailVm;
    }
  }
}