using FFP.Mappings;
using FFP.Models;
using Microsoft.EntityFrameworkCore;

namespace FFP.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TimeMap());
            modelBuilder.ApplyConfiguration(new JogadorMap());
        }

        public DbSet<Time> Times { get; set; }  
        public DbSet<Jogador> Jogadores { get; set;}
    }
}
