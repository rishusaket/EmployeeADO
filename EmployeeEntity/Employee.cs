using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmployeeADO.EmployeeEntity
{
    public class Employee
    {
        [Key]
        [Display(Name ="Id")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter a valid name")]
        [StringLength(10)]
        public string name { get; set; }
        [Required(ErrorMessage = "Please enter a valid gender")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Please enter a valid location")]
        [Remote("IsLocationAvailable", "Employee",ErrorMessage = "Location already exist")]
        public string location { get; set; }
    }
}
