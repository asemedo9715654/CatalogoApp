using System.Data.Entity;

namespace CatalogoApp.Models
{
    public class ContextBaseDados : DbContext
    {
        public DbSet<Catalogo> Catalogo { get; set; }
        public DbSet<Tabela> Tabela { get; set; }
        public DbSet<Campo> Campo { get; set; }
    }
}
