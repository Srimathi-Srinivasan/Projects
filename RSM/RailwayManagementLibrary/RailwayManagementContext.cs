using Microsoft.EntityFrameworkCore;

namespace RailwayManagementLibrary
{
    public class RailwayManagementContext : DbContext
    {
        private const string connectionString = "Server=.;Database=RailwayManagementDB;Trusted_Connection=True;";

        public RailwayManagementContext()
        {

        }

        public RailwayManagementContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Train> Trains { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<TrainScheduleReport> Reports { get; set; }
    }
}