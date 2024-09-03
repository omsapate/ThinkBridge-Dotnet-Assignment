using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManager.Models
{
    public class Documents
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FileId { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        [Required]
        public string Data { get; set; }
    }
}
