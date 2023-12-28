using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.DTO
{
    public class AddHelpDesksReplyRequestDTO
    {
        public string reply { get; set; }
        public string videoCode { get; set; }
        public int HelpDesksId { get; set; }
    }
}
