using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Full Name.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please select a department.")]
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int FDepartmentId { get; set; }

        [Required(ErrorMessage = "Please select a gender.")]
        [ForeignKey("Gender")]
        [Display(Name = "Gender")]
        public int FGenderId { get; set; }

        [Required(ErrorMessage = "Please Enter Designation.")]
        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Address.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [ScaffoldColumn(false)]
        public int Active { get; set; } = 1;

        public Department Department { get; set; }
        public Gender Gender { get; set; }
    }
}
