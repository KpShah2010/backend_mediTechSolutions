using SendGrid.Helpers.Mail;
using SendGrid;

namespace MediTechSolution_mainProject.API.Data
{
    public class EmailSenderDoctor
    {
        public async Task SendEmail(string subject, string DocEmail, string name, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("19bmiit090@gmail.com", "Medi.Tech Solutions");
            var to = new EmailAddress(DocEmail, name);
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
