﻿using System.ComponentModel.DataAnnotations;

namespace CatalogoApp.Models
{
    public class Campo
    {
        [Key]
        public int IdCampo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdTabela { get; set; }
        public Tabela Tabela { get; set; }

        
    }
}
