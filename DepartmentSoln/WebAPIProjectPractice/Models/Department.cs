using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProjectPractice.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DName { get; set; }
        public string Location { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
