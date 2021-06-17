using Microsoft.EntityFrameworkCore;
using Practice_7_WEB.Models.InitialModelsDB;
using System.Collections.Generic;
namespace Practice_7_WEB.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Drill> Drills { get; set; }
        public DbSet<Circular> Circulars { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        ////protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        ////{
        ////    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=instrumentsdb;Trusted_Connection=True;");
        ////}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Drill>().HasOne(i => i.Instrument)
        //    //    .WithMany(d => d.Drills)
        //    //    .HasForeignKey(i => i.InstrumentId);
        //    //modelBuilder.Entity<Circular>().HasOne(i => i.Instrument)
        //    //   .WithMany(d => d.Circulars)
        //    //   .HasForeignKey(i => i.InstrumentId);
        //    //data = new dataManager();
        //    //Instrument makita = new Instrument { Id = 1, Manufacturer = "Makita" };
        //    //Instrument bosh = new Instrument { Id = 2, Manufacturer = "Bosh" };

        //    //modelBuilder.Entity<Instrument>().HasData(
        //    //     makita, bosh
        //    //    );
        //    //modelBuilder.Entity<Drill>().HasData(
        //    //     new List<Drill>(data.GetDrills(makita))
        //    //    ) ;
        //    //modelBuilder.Entity<Circular>().HasData(
        //    //     new List<Circular>(data.GetCirculars(bosh))
        //    //    );
        //    //modelBuilder.Entity<Drill>().HasData(
        //    //     new List<Drill>(data.GetDrills(makita))
        //    //    );
        //    //modelBuilder.Entity<Circular>().HasData(
        //    //     new List<Circular>(data.GetCirculars(bosh))
        //    //    );
        //}
    }
}
