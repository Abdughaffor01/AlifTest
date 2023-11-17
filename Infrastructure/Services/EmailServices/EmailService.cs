using Domain;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;

namespace Infrastructure;

public class EmailService : IEmailService
{
    private readonly EmailConfiguration _configuration;
    private readonly ILogger<EmailService> _logger;

    public EmailService(EmailConfiguration configuration, ILogger<EmailService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }
    
    public void SendEmail(MessageDto message, TextFormat format)
    {
        var emailMessage = CreateEmailMessage(message, format);
        Send(emailMessage);
    }

    private MimeMessage CreateEmailMessage(MessageDto message, TextFormat format)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("mail", _configuration.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(format) { Text = message.Content };

        return emailMessage;
    }

    private void Send(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            client.Connect(_configuration.SmtpServer, _configuration.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(_configuration.UserName, _configuration.Password);
            client.Send(mailMessage);
        }
        catch
        {
            //log an error message or throw an exception or both.
            throw;
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
        }
    }
}