using FootballData.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballData
{
    public class FootballContext : DbContext
    {
        public FootballContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BranchHours> BranchHours { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Hold> Holds { get; set; }
        public DbSet<StadiumAsset> StadiumAssets { get; set; }
        public DbSet<StadiumBranch> StadiumBranches { get; set; }
        public DbSet<StadiumCard> StadiumCards { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Video> Videos { get; set; }

    }
}
