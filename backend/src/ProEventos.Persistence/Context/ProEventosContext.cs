using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Context
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>()
                .HasKey(SP => new { SP.EventId, SP.SpeakerId });

            modelBuilder.Entity<Event>()
                .HasMany(e => e.SocialMedias)
                .WithOne(rs => rs.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
               .HasMany(e => e.SocialMedias)
               .WithOne(rs => rs.Speaker)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}