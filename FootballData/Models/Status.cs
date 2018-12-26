using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FootballData.Models
{
    public class Status
    {
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
