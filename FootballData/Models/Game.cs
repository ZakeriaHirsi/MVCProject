using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FootballData.Models
{
    public class Game : StadiumAsset
    {
        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
