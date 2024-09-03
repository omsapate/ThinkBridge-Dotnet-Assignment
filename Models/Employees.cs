using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTaskManager.Models
{
    public class Employees
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeID { get; set; }

        [StringLength(50)]
        public string? EmployeeName { get; set; }

        public long ManagerID { get; set; }

        [StringLength(50)]
        public string? Role { get; set; }
    }
}
