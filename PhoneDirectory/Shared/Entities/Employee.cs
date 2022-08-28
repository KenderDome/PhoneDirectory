using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneDirectory.Shared.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public int? Extension { get; set; }
        public string? Notes { get; set; }
        [Required(ErrorMessage = "Employee title is required.")]
        public int? EmployeeTypeId { get; set; }
        public EmployeeType? EmployeeType { get; set; }

        public List<Department>? Departments { get; set; }
    }
}
