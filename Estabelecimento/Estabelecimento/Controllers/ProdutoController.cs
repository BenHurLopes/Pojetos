using Estabelecimento.Helpers;
using Estabelecimento.Models;
using NHibernate;
using System.Linq;
using System.Web.Mvc;

namespace Estabelecimento.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var produtos = session.Query<Produto>().ToList();
                return View(produtos);
            }
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var produtos = session.Get<Produto>(id);
                return View(produtos);
            }
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(produto);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var produto = session.Get<Produto>(id);
                return View(produto);
            }
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produto produto)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var produtoAlterado = session.Get<Produto>(id);
                    produtoAlterado.Codigo = produto.Codigo;
                    produtoAlterado.Nome = produto.Nome;
                    produtoAlterado.PrecoUnitario = produto.PrecoUnitario;
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(produtoAlterado);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var produto = session.Get<Produto>(id);
                return View(produto);
            }
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(Produto produto)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(produto);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
