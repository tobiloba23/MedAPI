using MedChart.PocosLayer;
using Microsoft.EntityFrameworkCore;

namespace MedChart.DataAccessLayer.DbContexts
{
    public class MedChartContext : DbContext
    {
        public MedChartContext()
        {
        }
        public MedChartContext(DbContextOptions<MedChartContext> options)
            : base(options)
        {
        }

        public DbSet<BloodWorkPoco> BloodWorks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<BloodWorkPoco>()
                .Property(p => p.DateCreated)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<BloodWorkPoco>()
                .Property(p => p.Description)
                .HasColumnType("varchar(100)");
        }
    }
}
