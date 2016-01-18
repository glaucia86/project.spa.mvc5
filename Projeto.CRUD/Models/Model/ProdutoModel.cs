using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.CRUD.Models.Model
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage="Nome é um campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Preço é um campo obrigatório")]
        public double Preco { get; set; }

        [Required(ErrorMessage="Data de Cadastro é um campo obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage="Quantidade é um campo obrigatório")]
        public int Quantidade { get; set; }
    }
}