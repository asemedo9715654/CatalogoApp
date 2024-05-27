using System.Data.Entity;

namespace CatalogoApp.Models
{
    public class ContextBaseDados : DbContext
    {
        public DbSet<Tabela> TableInfo { get; set; }
        public DbSet<Campo> FieldInfo { get; set; }
    }
}
