using gerenciamento_Ti.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_Ti.Database
{
    public class GerenciamentoDbContext : DbContext
    {
        public GerenciamentoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<TipoEquipamento> TipoEquipamento { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<UsuarioChamado> UsuarioChamado { get; set; }
        public DbSet<MensagemChamado> MensagemChamado { get; set; }
    }
}
