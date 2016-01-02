using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.CRUD.Models.Model;
using Projeto.CRUD.Models.Repositorio;

namespace Projeto.CRUD.Models.Negocio
{
    /// <summary>
    /// Essa classe só serve para poder transitar os dados de uma camada para outra
    /// </summary>
    public class ProdutoNegocio
    {
        public void Cadastrar(ProdutoModel produto)
        {
            new ProdutoRepositorio().Cadastrar(produto);
        }

        public void Atualizar(ProdutoModel produto)
        {
            new ProdutoRepositorio().Atualizar(produto);
        }

        public void Deletar(int idProduto)
        {
            new ProdutoRepositorio().Deletar(idProduto);
        }

        public ProdutoModel GetById(int id)
        {
            return new ProdutoRepositorio().GetById(id);
        }

        public IEnumerable<ProdutoModel> Listar()
        {
            return new ProdutoRepositorio().Listar();
        }
    }
}