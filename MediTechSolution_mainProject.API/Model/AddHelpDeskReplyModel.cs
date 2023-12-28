using System.ComponentModel.DataAnnotations.Schema;

namespace MediTechSolution_mainProject.API.Model
{
    public class AddHelpDeskReplyModel
    {
        public int Id { get; set; }
        public string reply { get; set; }
        public string videoCode { get; set; }

        [ForeignKey("AddHelpDeskModel")]
        public int HelpDesksId { get; set; }

        public AddHelpDeskModel AddHelpDeskModel { get; set; }
    }
}
