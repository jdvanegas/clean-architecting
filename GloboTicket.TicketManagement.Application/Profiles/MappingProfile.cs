﻿using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Profiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Event, EventListVm>();
      CreateMap<Event, EventDetailVm>();
      CreateMap<Category, CategoryDto>();

      CreateMap<Category, CategoryListVm>();
      CreateMap<Category, CategoryEventListVm>();
      CreateMap<Event, CategoryEventDto>();

      CreateMap<Event, CreateEventCommand>().ReverseMap();
      CreateMap<Event, UpdateEventCommand>().ReverseMap();

      CreateMap<Category, CreateCategoryDto>();
    }
  }
}