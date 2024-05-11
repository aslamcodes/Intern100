using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        public string FeedbackMessage { get; set; }

        public int Rating { get; set; }

        public DateTime PostedDate { get; set; } = System.DateTime.Now;

        public int SolutionId { get; set; }

        public RequestSolution Solution { get; set; }


    }
}
