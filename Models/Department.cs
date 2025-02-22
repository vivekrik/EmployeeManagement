using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Department")]

        public string DepartmentName { get; set; }
        public int Active { get; set; } = 1;

    }
}