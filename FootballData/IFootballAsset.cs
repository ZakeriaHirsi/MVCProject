using FootballData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballData
{
    public interface IFootballAsset
    {
        IEnumerable<StadiumAsset> GetAll();
        StadiumAsset GetByID(int id);
        void Add(StadiumAsset newAsset);
        string GetCreator(int id);
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetISBN(int id);
        StadiumBranch GetCurrentLocation(int id);
    }
}
