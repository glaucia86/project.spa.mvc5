using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.CRUD.Models.Model
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }

        public DateTime DataCadastro { get; set; }

        public int Quantidade { get; set; }
    }
}