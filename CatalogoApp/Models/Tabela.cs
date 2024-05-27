namespace CatalogoApp.Models
{
    public class Tabela
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Campo> Fields { get; set; }
    }
}
