using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<CategoryListVm>>> GetAllCategories()
    {
      var dtos = await _mediator.Send(new GetCategoriesListQuery());
      return Ok(dtos);
    }

    [HttpGet("with-events")]
    public async Task<ActionResult<IEnumerable<CategoryListVm>>> GetAllCategoriesWithEvents(bool includeHistory)
    {
      var getCategoryListWithEventsQuery = new GetCategoriesListWithEventsQuery { IncludeHystory = includeHistory };
      var dtos = await _mediator.Send(getCategoryListWithEventsQuery);
      return Ok(dtos);
    }
  }
}