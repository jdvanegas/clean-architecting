using GloboTicket.TicketManagement.Domain.Models.Mail;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Domain.Contracts.Infrastructure
{
  public interface IEmailService
  {
    Task<bool> SendEmail(Email email);
  }
}