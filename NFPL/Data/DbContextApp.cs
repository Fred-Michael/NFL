using Microsoft.EntityFrameworkCore;
using NFPL.Models;

namespace NFPL.Data
{
    public class DbContextApp : DbContext
    {
        public DbContextApp(DbContextOptions<DbContextApp> options) : base(options) {}

        public DbSet<Team> Teams { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Division> Divisions { get; set; }

        //onModelCreate that seeds the database with initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Conference>().HasData(
                new Conference { ConferenceID = "afc", Name = "AFC" }, //american football conference
                new Conference { ConferenceID = "nfc", Name = "NFC" }  //national football conference
                );

            modelBuilder.Entity<Division>().HasData(
               new Division { DivisionID = "north", Name = "North" },
               new Division { DivisionID = "south", Name = "South" },
               new Division { DivisionID = "east", Name = "East"},
               new Division { DivisionID = "west", Name = "West"}
               );

            modelBuilder.Entity<Team>().HasData(
                new { TeamID = "ari", Name = "Arizona Cardinals", ConferenceID = "nfc", DivisionID = "west", TeamLogo = "ARI.png" },
                new { TeamID = "atl", Name = "Atlanta Falcons", ConferenceID = "nfc", DivisionID = "south", TeamLogo = "ATL.png" },
                new { TeamID = "bal", Name = "Baltimore Ravens", ConferenceID = "afc", DivisionID = "north", TeamLogo = "BAL.png" },
                new { TeamID = "buf", Name = "Buffalo Bills", ConferenceID = "afc", DivisionID = "east", TeamLogo = "BUF.png" },
                new { TeamID = "car", Name = "Carolina Panthers", ConferenceID = "nfc", DivisionID = "south", TeamLogo = "CAR.png" },
                new { TeamID = "chi", Name = "Chicago Bears", ConferenceID = "nfc", DivisionID = "north", TeamLogo = "CHI.png" },
                new { TeamID = "cin", Name = "Cincinnati Bengals", ConferenceID = "afc", DivisionID = "north", TeamLogo = "CIN.png" },
                new { TeamID = "cle", Name = "Cleveland Browns", ConferenceID = "afc", DivisionID = "north", TeamLogo = "CLE.png" },
                new { TeamID = "dal", Name = "Dallas Cowboys", ConferenceID = "nfc", DivisionID = "east", TeamLogo = "DAL.png" },
                new { TeamID = "den", Name = "Denver Broncos", ConferenceID = "afc", DivisionID = "west", TeamLogo = "DEN.png" },
                new { TeamID = "det", Name = "Detroit Lions", ConferenceID = "nfc", DivisionID = "north", TeamLogo = "DET.png" },
                new { TeamID = "gb", Name = "Green Bay Packers", ConferenceID = "nfc", DivisionID = "north", TeamLogo = "GB.png" },
                new { TeamID = "hou", Name = "Houston Texans", ConferenceID = "afc", DivisionID = "south", TeamLogo = "HOU.png" },
                new { TeamID = "ind", Name = "Indianapolis Colts", ConferenceID = "afc", DivisionID = "south", TeamLogo = "IND.png" },
                new { TeamID = "jax", Name = "Jacksonville Jaguars", ConferenceID = "afc", DivisionID = "south", TeamLogo = "JAX.png" },
                new { TeamID = "kc", Name = "Kansas City Chiefs", ConferenceID = "afc", DivisionID = "west", TeamLogo = "KC.png" },
                new { TeamID = "lac", Name = "Los Angeles Chargers", ConferenceID = "afc", DivisionID = "west", TeamLogo = "LAC.png" },
                new { TeamID = "lar", Name = "Los Angeles Rams", ConferenceID = "nfc", DivisionID = "west", TeamLogo = "LAR.png" },
                new { TeamID = "mia", Name = "Miami Dolphins", ConferenceID = "afc", DivisionID = "east", TeamLogo = "MIA.png" },
                new { TeamID = "min", Name = "Minnesota Vikings", ConferenceID = "nfc", DivisionID = "north", TeamLogo = "MIN.png" },
                new { TeamID = "ne", Name = "New England Patriots", ConferenceID = "afc", DivisionID = "east", TeamLogo = "NE.png" },
                new { TeamID = "no", Name = "New Orleans Saints", ConferenceID = "nfc", DivisionID = "south", TeamLogo = "NO.png" },
                new { TeamID = "nyg", Name = "New York Giants", ConferenceID = "nfc", DivisionID = "east", TeamLogo = "NYG.png" },
                new { TeamID = "nyj", Name = "New York Jets", ConferenceID = "afc", DivisionID = "east", TeamLogo = "NYJ.png" },
                new { TeamID = "oak", Name = "Oakland Raiders", ConferenceID = "afc", DivisionID = "west", TeamLogo = "OAK.png" },
                new { TeamID = "phi", Name = "Philadelphia Eagles", ConferenceID = "nfc", DivisionID = "east", TeamLogo = "PHI.png" },
                new { TeamID = "pit", Name = "Pittsburgh Steelers", ConferenceID = "afc", DivisionID = "north", TeamLogo = "PIT.png" },
                new { TeamID = "sea", Name = "Seattle Seahawks", ConferenceID = "nfc", DivisionID = "west", TeamLogo = "SEA.png" },
                new { TeamID = "sf", Name = "San Francisco 49ers", ConferenceID = "nfc", DivisionID = "west", TeamLogo = "SF.png" },
                new { TeamID = "tb", Name = "Tampa Bay Buccaneers", ConferenceID = "nfc", DivisionID = "south", TeamLogo = "TB.png" },
                new { TeamID = "ten", Name = "Tennessee Titans", ConferenceID = "afc", DivisionID = "south", TeamLogo = "TEN.png" },
                new { TeamID = "was", Name = "Washington Redskins", ConferenceID = "nfc", DivisionID = "east", TeamLogo = "WAS.png" }
               );
        }
    }
}