using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManager.Models
{
    public class Task
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TaskId { get; set; }

        public Documents? Documents { get; set; }

        public string? Notes { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        [ForeignKey("Employee")]
        public long EmployeeID { get; set; }
    }
}
