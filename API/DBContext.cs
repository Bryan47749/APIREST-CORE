using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new Usuario.MapeoDB(modelBuilder.Entity<Usuario>());
            new Categoria.MapeoDB(modelBuilder.Entity<Categoria>());
            new Post.MapeoDB(modelBuilder.Entity<Post>());
            new Images.MapeoDB(modelBuilder.Entity<Images>());

        }
    }
}
