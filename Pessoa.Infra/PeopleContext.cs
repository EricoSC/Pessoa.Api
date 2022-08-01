using Microsoft.EntityFrameworkCore;
using Pessoa.Entity.Endereco;
using Pessoa.Entity.Pessoal;

namespace Pessoa.Infra
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) { }

        public DbSet<People> Pessoas { get; set; }
        public DbSet<Adress> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .HasOne(p => p.Endereco)
                .WithOne(a => a.Pessoa)
                .HasForeignKey<Adress>(a => a.PessoaId);

            

        }
    }

}