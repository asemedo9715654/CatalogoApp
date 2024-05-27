using System.ComponentModel.DataAnnotations;

namespace CatalogoApp.Models
{
    public class Catalogo
    {
        [Key]
        public int IdCatalogo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string StringDaConexao { get; set; }
        public List<Tabela> Tabelas { get; set; }
    }
}
