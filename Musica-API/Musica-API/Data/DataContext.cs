using Microsoft.EntityFrameworkCore;
using Musica_API.Models;

namespace Musica_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=Notebook-Elaine\\SQLEXPRESS;database=musicdb;trusted_connection=true;TrustServerCertificate=True");
        }

        public DbSet<MusicModel> Musics { get; set; }

    }
}
