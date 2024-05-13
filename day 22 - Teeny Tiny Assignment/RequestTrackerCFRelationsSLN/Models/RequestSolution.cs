using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class RequestSolution
    {
        [Key]
        public int SolutionNumber { get; set; }
        public string SolutionMessage { get; set; }


        public bool isAccepted { get; set; } = false;
        public DateTime PostedDate { get; set; } = System.DateTime.Now;
        public DateTime? AcceptedDate { get; set; } = null;


        public int SolutionPostedBy { get; set; }

        // Assuming the Admin is also an employee
        public Employee PostedBy { get; set; }

        public int RequestNumber { get; set; }

        // Navigation Property to Request
        public Request ForRequest { get; set; }

        // Navigation Property to Feedbaack
        public ICollection<Feedback> FeedbacksForSolution { get; set; }

        public override string ToString()
        {
            return $"Solution Number: {SolutionNumber}\n" +
                   $"Solution Message: {SolutionMessage}\n" +
                   $"Posted Date: {PostedDate}\n" +
                   $"Request Number: {RequestNumber}\n";
        }
    }
}
