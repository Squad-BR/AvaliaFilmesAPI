using AvaliaFilmesAPI.Domain;
using AvaliaFilmesAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AvaliaFilmesAPI.Data.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        }
}
