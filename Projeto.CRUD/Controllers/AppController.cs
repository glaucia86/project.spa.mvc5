using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.CRUD.Models.Model;
using Projeto.CRUD.Models.Negocio;

namespace Projeto.CRUD.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index()
        {
            return View();
        }

        //Método: Cadastrar
        //POST: App
        [HttpPost]
        public void Cadastrar(ProdutoModel produto)
        {
            try
            {
                new ProdutoNegocio().Cadastrar(produto);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar o Produto " + ex.Message);
            }
        }

        //Método: Editar:
        //GET: App
        public ActionResult Editar(int id)
        {
            try
            {
                //Para realizar a edição, primeiro temos que localizar o id, para depois
                //realizar a atualização:
                var produto = new ProdutoNegocio().GetById(id);

                return Json(produto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar o Produto " + ex.Message);
            }
        }

        //Método: Atualizar:
        //POST: App
        [HttpPost]
        public void Atualizar(ProdutoModel produto)
        {
            try
            {
                new ProdutoNegocio().Atualizar(produto);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o Produto " + ex.Message);
            }
        }

        //Método: Deletar:
        public void Deletar(int id)
        {
            try
            {
                new ProdutoNegocio().Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao delatar o Produto " + ex.Message);
            }
        }

        //Método: Listar todos os Produtos:
        //GET: App
        [HttpGet]
        public ActionResult Listar()
        {
            try
            {
                var listaProdutos = new ProdutoNegocio().Listar();
                return Json(listaProdutos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar o(s) Produto(s) " + ex.Message);
            }
        }
    }
}