namespace ElevatorEF.Models
{
    public class LiftLog
    {
        public int id { get; set; }

        public int? empId { get; set; }

        public int? start { get; set; }

        public int? end { get; set; }

        public DateTime? dateTime { get; set; }

        public Employee?  employee { get; set; }
    }
}
