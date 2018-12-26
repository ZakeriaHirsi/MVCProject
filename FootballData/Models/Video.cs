using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FootballData.Models
{
    public class Video: StadiumAsset
    {
        [Required]
        public string Director { get; set; }
    }
}
