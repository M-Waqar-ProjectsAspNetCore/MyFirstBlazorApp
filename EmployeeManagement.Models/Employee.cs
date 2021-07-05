using EmployeeManagement.Models.CustomValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [MinLength(2,ErrorMessage = "FirstName Must be greater then 2 characters.")]
        public string FirstName { get; set; }
        [Required]
        //[Compare("FirstName")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [EmailDomainValidator(allowedDomain = "pragimtech.com",ErrorMessage = "Domain Not Valid.")]
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string PhotoPath { get; set; }
    }
}
