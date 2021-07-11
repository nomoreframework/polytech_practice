using Microsoft.EntityFrameworkCore;
using Practice_7_WEB.Services.InitialDBService;

namespace Practice_7_WEB.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Drill> Drills { get; set; }
        public DbSet<Circular> Circulars { get; set; }
        InitialDbService service;
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    }
}
