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
