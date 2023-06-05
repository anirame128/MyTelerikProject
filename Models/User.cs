using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTelerikProject.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int employeeNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }    

        public bool isDiscontinued { get; set; }
        public string? trainingLevel { get; set; }
        public ICollection<OverTimeRequest> OverTimeRequests { get; set; }
    }
}
