using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FootballData.Models
{
    public class CheckoutHistory
    {
        public int ID { get; set; }

        [Required]
        public StadiumAsset StadiumAsset { get; set; }

        [Required]
        public StadiumCard StadiumCard { get; set; }

        [Required]
        public DateTime CheckedOut { get; set; }

        public DateTime? CheckedIn { get; set; }
    }
}
