using AutoMapper;
using GloboTicket.TicketManagement.Domain.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Exceptions;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Domain.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Domain.Models.Mail;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
  public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
  {
    private readonly IEventRepository _eventRepository;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;

    public CreateEventCommandHandler(IEventRepository eventRepository, IEmailService emailService, IMapper mapper)
    {
      _eventRepository = eventRepository;
      _emailService = emailService;
      _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
      var validator = new CreateEventCommandValidator(_eventRepository);
      var validationResult = await validator.ValidateAsync(request);

      if (!validationResult.IsValid)
        throw new ValidationException(validationResult);

      var @event = _mapper.Map<Event>(request);
      @event = await _eventRepository.AddAsync(@event);

      var email = new Email { To = "jdvanegas4@gmail.com", Body = $"A new event was created: {request}", Subject = "A new event created" };

      try
      {
        await _emailService.SendEmail(email);
      }
      catch (Exception)
      {
        //TODO: this shouldn't stop the API from doing else so this can be logged
      }

      return @event.Id;
    }
  }
}