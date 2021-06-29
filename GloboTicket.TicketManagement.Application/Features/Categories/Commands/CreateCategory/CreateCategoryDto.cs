using System;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory
{
  public class CreateCategoryDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
  }
}