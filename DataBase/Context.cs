using System.Data.Entity;

namespace DataBase
{
    class Context : DbContext
    {
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<SupporterGroup> SupporterGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Footballer>()
                .Property(f => f.DateOfBirth)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Manager>()
                .Property(m => m.DateOfBirth)
                .HasColumnType("datetime2");
        }
    }
}
