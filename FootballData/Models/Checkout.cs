using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FootballData.Models
{
    public class Checkout
    {
        public int ID { get; set; }

        [Required]
        public StadiumAsset StadiumAsset { get; set; }
        public StadiumCard StadiumCard { get; set; }
        public DateTime CheckedOut { get; set; }
        public DateTime Due { get; set; }

    }
}
