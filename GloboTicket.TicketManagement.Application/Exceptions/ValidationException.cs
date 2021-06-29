using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Exceptions
{
  public class ValidationException : ApplicationException
  {
    public IEnumerable<string> ValidationErrors { get; set; }

    public ValidationException(ValidationResult validationResult)
    {
      ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage);
    }
  }
}