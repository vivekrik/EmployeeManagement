using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class Gender
    {
        public int Id { get; set; }
        [Display(Name = "Gender")]
        public string GenderName { get; set; }
        public int Active { get; set; } = 1;
    }
}