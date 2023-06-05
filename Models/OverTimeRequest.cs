using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTelerikProject.Models
{
    public class OverTimeRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int employeeNumber { get; set; }
        public DateTime dateRequested { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }
        public DateTime dateCreated { get; set; }
        public bool hasBeenAssigned { get; set; }
        public string assignedToStation { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
