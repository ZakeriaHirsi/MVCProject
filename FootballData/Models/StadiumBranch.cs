using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FootballData.Models
{
    public class StadiumBranch
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Stadium Name Must be 30 Characters")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Telephone{ get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
        public virtual IEnumerable<StadiumAsset> StadiumAssets { get; set; }

        public string ImageURL { get; set; }

    }
}
