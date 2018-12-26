using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FootballData.Models
{
    public abstract class StadiumAsset
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public string Author { get; set; }

        public string ImageURL { get; set; }

        public int NumberOfCopies { get; set; }

        public virtual StadiumBranch Location { get; set; }
    }
}
