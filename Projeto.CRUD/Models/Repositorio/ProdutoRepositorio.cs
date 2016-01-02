using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.CRUD.Models.Model;

namespace Projeto.CRUD.Models.Repositorio
{
    public class ProdutoRepositorio
    {
        /// <summary>
        /// Criamos uma lista estática, uma vez que o foco não é o banco:
        /// </summary>
        private static List<ProdutoModel> _listaProdutos;

        /// <summary>
        /// Construtor da Classe:
        /// </summary>
        public ProdutoRepositorio()
        {
            //Caso a lista não for instanciada, criará uma nova instância:
            if (_listaProdutos == null)
            {
                _listaProdutos = new List<ProdutoModel>();

                //Para iniciar já com um dado na lista:
                _listaProdutos.Add(new ProdutoModel
                {
                    ProdutoId = 1,
                    Nome = "Mouse Microsoft",
                    Preco = 18.20,
                    DataCadastro = DateTime.Now,
                    Quantidade = 1
                });
            }
        }

        /// <summary>
        /// Método para Cadastrar uma nova Pessoa:
        /// </summary>
        /// <param name="produto"></param>
        public void Cadastrar(ProdutoModel produto)
        {
            //O Id do Produto já iniciará com 1
            var y = 1;

            //Criamos um laço para que possa incrementar o Id do Produto
            //A cada cadastro novo de um determinado Produto irá incrementar
            while (_listaProdutos.Any(x => x.ProdutoId == y))
                y++;
            produto.ProdutoId = y;

            _listaProdutos.Add(produto);
        }

        /// <summary>
        /// Método para retornar o objeto que possuir o "ID" expecífico:
        /// </summary> 
        public ProdutoModel GetById(int id)
        {
            return _listaProdutos.SingleOrDefault(x => x.ProdutoId == id);
        }

        /// <summary>
        /// Método para atualizar a Pessoa. Mas, antes vai averiguar se já tem algum dato referente a determinada Pessoa:
        /// </summary>
        public void Atualizar(ProdutoModel produto)
        {
            var produtoJaCadastrado = GetById(produto.ProdutoId);
            if (produtoJaCadastrado != null)
            {
                foreach (var propertyInfo in typeof(ProdutoModel).GetProperties().Where(x=> x.Name != "ProdutoId"))
                {
                    //O primeiro parâmetro: "pessoaJaRegistrada é o objeto antigo
                    //O segundo parâmetro: "propertyInfo" vai setear o novo valor
                    propertyInfo.SetValue(produtoJaCadastrado, propertyInfo.GetValue(produto));
                }
            }
        }

        /// <summary>
        /// Método para Deletar uma Pessoa:
        /// </summary>
        public void Deletar(int id)
        {
           //Antes de deletar uma determinada Pessoa, temos que primeiro encontrar qual "id" queremos deletar: 
            var obj = GetById(id);

            //Depois que encontrar o determinado "id" que eu quero remover aí.....
            _listaProdutos.Remove(obj);
        }

        /// <summary>
        ///Método para listar todas as Pessoas: SelectAll
        /// </summary>
        public IEnumerable<ProdutoModel> Listar()
        {
            //se for nulo retornará null, senão retornará a lista completa
            return _listaProdutos ?? _listaProdutos;
        }
    }
}