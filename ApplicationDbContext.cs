using Microsoft.EntityFrameworkCore;
using ShortenURL.Entities;
using ShortenURL.Service;

namespace ShortenURL
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
        }


        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedUrl>(builder =>
            {
                builder.Property(s => s.Code).HasMaxLength(UrlShorteningService.NumberOfCharInShortLink);

                builder.HasIndex(s => s.Code).IsUnique();
            });
        }

    }
}
