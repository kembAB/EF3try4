using Microsoft.EntityFrameworkCore;
using System;
using MVCWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MVCWebApp.Models.Person;
using MVCWebApp.Models.City;
using MVCWebApp.Models.Country;
//using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations;
using MVCWebApp.Models.Language;
using MVCWebApp.Models.Language.ViewModels;

namespace MVCWebApp.EFwk
{
    public class personSeedDbContext:DbContext
    {
        public personSeedDbContext(DbContextOptions<personSeedDbContext> options) : base(options)
        {

        }

        public DbSet<personproperties> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        //Added to accomodate new requiremnte s
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            //one -to-one
            modelBuilder.Entity<City>()
                .Property<string>("CountryForeignKey");
            modelBuilder.Entity<personproperties>()
                .Property<int>("CityForeignKey");

         
            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(co => co.Cities)
            .HasForeignKey("CountryForeignKey");

            modelBuilder.Entity<personproperties>()
                .HasOne(p => p.City)
                .WithMany(c => c.People)
            .HasForeignKey("CityForeignKey");



            //many-to-many relastionship 
            modelBuilder.Entity<PersonLanguage>()
                  .HasOne(pl => pl.Language)
                  .WithMany(p => p.PersonLanguages)
                  .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Language)
                .WithMany(c => c.PersonLanguages)
                .HasForeignKey(pl => pl.LanguageName);

            //defaut countries seed

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryName = "Sweden" },
                new Country { CountryName = "USA" },
                new Country { CountryName = "UK" });

         
            modelBuilder.Entity<City>().HasData(
            new { ID = 1, CityName = "Lund", CountryForeignKey = "Sweden" },
            new { ID = 2, CityName = "Gothenburg", CountryForeignKey = "USA" },
            new { ID = 3, CityName = "Stockholm", CountryForeignKey = "UK" });

            //default valusees for person
            modelBuilder.Entity<personproperties>().HasData(
                new { ID = 1, Name = "John Stwart", PhoneNumber = "0786574567", CityForeignKey = 1 },
                new { ID = 2, Name = "Josefine Gustafsson", PhoneNumber = "0786544567", CityForeignKey = 2 },
                new { ID = 3, Name = "Andrew  Monnet", PhoneNumber = "0786894567", CityForeignKey = 3 });

   
            //default languages for peeople
            modelBuilder.Entity<PersonLanguage>().HasData(
                new PersonLanguage { PersonId = 1, LanguageName = "Swedish" },
                new PersonLanguage { PersonId = 2, LanguageName = "English" },
                new PersonLanguage { PersonId = 3, LanguageName = "scotish" });

        }
    }
}


        
