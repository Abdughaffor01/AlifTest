using Domain;
using MimeKit.Text;
namespace Infrastructure;

public interface IEmailService
{
    void SendEmail(MessageDto model, TextFormat format);
}