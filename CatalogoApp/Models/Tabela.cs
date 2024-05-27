using System.ComponentModel.DataAnnotations;

namespace CatalogoApp.Models
{
    public class Tabela
    {
        [Key]
        public int   IdTabela { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdCatalogo { get; set; }
        public Catalogo Catalogo { get; set; }
        public List<Campo> Campos { get; set; }
    }
}
