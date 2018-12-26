using FootballData;
using FootballData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballServices
{
    public class StadiumAssetService : IFootballAsset
    {
        private FootballContext __Context;

        public StadiumAssetService(FootballContext context)
        {
            __Context = context;
        }

        
        public void Add(StadiumAsset newAsset)
        {
            __Context.Add(newAsset);
            __Context.SaveChanges();
        }

        public IEnumerable<StadiumAsset> GetAll()
        {
            return __Context.StadiumAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location);
        }

        public StadiumAsset GetByID(int id)
        {
            return GetAll().FirstOrDefault(asset => asset.ID == id);
        }

        public string GetCreator(int id)
        {
            if( __Context.StadiumAssets.OfType<Book>().Where(asset => asset.ID == id).Any())
            {
                return __Context.StadiumAssets.OfType<Book>().Where(asset => asset.ID == id).FirstOrDefault().Author;
            }
            else if(__Context.StadiumAssets.OfType<Video>().Where(asset => asset.ID == id).Any())
            {
                return __Context.StadiumAssets.OfType<Video>().Where(asset => asset.ID == id).FirstOrDefault().Director;
            }
            else if (__Context.StadiumAssets.OfType<Game>().Where(asset => asset.ID == id).Any())
            {
                return __Context.StadiumAssets.OfType<Game>().Where(asset => asset.ID == id).FirstOrDefault().Publisher;
            }

            return "Unknown";

        }

        public StadiumBranch GetCurrentLocation(int id)
        {
            return __Context.StadiumAssets.FirstOrDefault(asset => asset.ID == id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            if(__Context.Books.Any(book => book.ID == id))
            {
                return __Context.Books.FirstOrDefault(book => book.ID == id).DeweyIndex;
            }
            return "";
        }

        public string GetISBN(int id)
        {
            if(__Context.Books.Any(book => book.ID == id))
            {
                return __Context.Books.FirstOrDefault(book => book.ID == id).ISBN;
            }
            return "";
        }

        public string GetTitle(int id)
        {
            return __Context.StadiumAssets.FirstOrDefault(s => s.ID == id).Title;
        }

        public string GetType(int id)
        {
            if (__Context.Books.Any(book => book.ID == id))
            {
                return "Book";
            }
            else if(__Context.Videos.Any(video => video.ID == id))
            {
                return "Video";
            }
            else if(__Context.Games.Any(game => game.ID == id))
            {
                return "Game";
            }

            return "Unknown";
        }
    }
}
