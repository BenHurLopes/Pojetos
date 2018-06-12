using Estabelecimento.Helpers;
using Estabelecimento.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estabelecimento.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var pessoas = session.Query<Pessoa>().ToList();
                return View(pessoas);
            }
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var pessoas = session.Get<Pessoa>(id);
                return View(pessoas);
            }
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(pessoa);
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

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var pessoas = session.Get<Pessoa>(id);
                return View(pessoas);
            }
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pessoa pessoa)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var pessoaAlterada = session.Get<Pessoa>(id);
                    pessoaAlterada.Nome = pessoa.Nome;
                    pessoaAlterada.DataNascimento = pessoa.DataNascimento;
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(pessoaAlterada);
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

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var pessoa = session.Get<Pessoa>(id);
                return View(pessoa);
            }
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(Pessoa pessoa)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(pessoa);
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
