using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestComplexGrid.ViewModels
{
    public class DepartmentViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Department { get; set; }
        [Required]
        [UIHint("LocationSelector")]
        public LocationViewModel Location { get; set; }
        public bool Active { get; set; }

    }
}
