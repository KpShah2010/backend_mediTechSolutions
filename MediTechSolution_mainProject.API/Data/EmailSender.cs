using SendGrid;
using SendGrid.Helpers.Mail;

namespace MediTechSolution_mainProject.API.Data
{
    public class EmailSender
    {
        public async Task SendEmail(string subject, string toEmail, string name, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("19bmiit090@gmail.com", "Medi.Tech Solutions");
            var to = new EmailAddress(toEmail, name);
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
