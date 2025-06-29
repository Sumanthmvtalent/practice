using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProjectPractice.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public Department? Department { get; set; }

    }
}
