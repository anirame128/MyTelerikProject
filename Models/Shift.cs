using System.ComponentModel.DataAnnotations.Schema;

namespace MyTelerikProject.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public string assignedToStation { get; set; }
        public DateTime ShiftDateTime { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


        public string ShiftDateTimeFormatted => $"{ShiftDateTime:MM/dd/yyyy} - {DateTime.Today.Add(StartTime):hh:mm tt} to {DateTime.Today.Add(EndTime):hh:mm tt}";



    }
}
