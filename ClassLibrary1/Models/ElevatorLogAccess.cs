namespace ElevatorEF.Models
{
    public class ElevatorLogAccess
    {
        public int Id { get; set; }

        public int floorno { get; set; }

        public int weight { get; set; }

        public DateTime dateTime { get; set; }

      //  public LiftLog? log { get; set; }

        // int count
        // liftlog .start==floorno
    }
}
