using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_With_.NETCore.Models.Catalog
{
    public class AssetIndexListingModel
    {
        public int ID { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Type { get; set; }
    }
}
