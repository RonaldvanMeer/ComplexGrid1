using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestComplexGrid.ViewModels
{
    public class LocationViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }
        public bool Active { get; set; }

    }
}
