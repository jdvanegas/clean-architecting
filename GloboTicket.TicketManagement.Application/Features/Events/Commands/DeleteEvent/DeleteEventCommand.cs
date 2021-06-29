using MediatR;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
  public class DeleteEventCommand : IRequest
  {
    public Guid Id { get; set; }
  }
}