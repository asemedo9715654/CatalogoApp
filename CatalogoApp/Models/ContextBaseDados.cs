using System.Data.Entity;

namespace CatalogoApp.Models
{
    public class ContextBaseDados : DbContext
    {
        public DbSet<TableInfo> TableInfo { get; set; }
        public DbSet<FieldInfo> FieldInfo { get; set; }
    }
}
