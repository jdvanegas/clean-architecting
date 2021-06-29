using GloboTicket.TicketManagement.Domain.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Domain.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Infrastructure.Mail
{
  public class EmailService : IEmailService
  {
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> mailSettings)
    {
      _emailSettings = mailSettings.Value;
    }

    public async Task<bool> SendEmail(Email email)
    {
      var client = new SendGridClient(_emailSettings.ApiKey);
      var to = new EmailAddress(email.To);

      var from = new EmailAddress { Email = _emailSettings.FromAddress, Name = _emailSettings.FromName };

      var sendGridMessage = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
      var response = await client.SendEmailAsync(sendGridMessage);

      var sentSuccessfully = response.StatusCode == System.Net.HttpStatusCode.Accepted
        || response.StatusCode == System.Net.HttpStatusCode.OK;

      return sentSuccessfully;
    }
  }
}