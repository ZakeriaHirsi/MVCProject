using FootballData;
using FootballData.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_With_.NETCore.Models.Catalog;
using System.Collections.Generic;
using System.Linq;

namespace MVC_With_.NETCore.Controllers
{
    //handles all the data that comes back from the data source
    //pushes it to a view model which will use it to display in the view
    public class CatalogController : Controller
    {
        private IFootballAsset __Assets;
        public CatalogController(IFootballAsset assets)
        {
            __Assets = assets;
        }

        public IActionResult Index()
        {
            IEnumerable<StadiumAsset> _AssetModels = __Assets.GetAll();

            IEnumerable<AssetIndexListingModel> _ListingResult = _AssetModels
                .Select(result => new AssetIndexListingModel
                {
                    ID = result.ID,
                    ImageURL = result.ImageURL,
                    Creator = __Assets.GetCreator(result.ID),
                    Title = result.Title,
                    Type = __Assets.GetType(result.ID)
                });
            AssetIndexModel _Model = new AssetIndexModel
            {
                Assets = _ListingResult
            };

            return View(_Model);
        }
    }
}
