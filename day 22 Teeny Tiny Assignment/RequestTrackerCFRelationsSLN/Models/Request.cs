﻿using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; }

        public int RequestRaisedBy { get; set; }

        public Employee RaisedByEmployee { get; set; }

        public int? RequestClosedBy { get; set; }


        public Employee RequestClosedByEmployee { get; set; }

        public ICollection<RequestSolution> RequestSolutions { get; set; }//No effect on the table

        public override string ToString()
        {
            return $"Request Number: {RequestNumber}, Request Message: {RequestMessage}, Request Date: {RequestDate}, Request Status: {RequestStatus}, Request Raised By: {RequestRaisedBy}, Request Closed By: {RequestClosedBy}";
        }
    }
}
