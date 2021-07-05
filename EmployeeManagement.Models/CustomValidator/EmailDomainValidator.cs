using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.CustomValidator
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string allowedDomain { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] domain = value.ToString().Split('@');
            if (domain.Length > 1 && domain[1].ToUpper() == allowedDomain.ToUpper())
            {
                return null;
            }
            return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
        }
    }
}
