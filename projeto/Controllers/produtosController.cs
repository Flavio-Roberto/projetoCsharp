using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projeto.Models;

namespace projeto.Controllers
{
    public class produtosController : Controller
    {
        private mediadorProdutos db = new mediadorProdutos();
        private mediadorClientes dbClientes = new mediadorClientes();

        // GET: produtos
        public ActionResult Index()
        {
            return View(db.produtos.ToList());
        }

        // GET: produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produtos produtos = db.produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // GET: produtos/Create
        public ActionResult Create()
        {
            carregarComboClientes();
            return View();
        }

        // POST: produtos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,Nome,Valor,Disponivel,idclientes")] produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.produtos.Add(produtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produtos);
        }

        // GET: produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            carregarComboClientes();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produtos produtos = db.produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: produtos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,Nome,Valor,Disponivel,idclientes")] produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produtos);
        }

        // GET: produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produtos produtos = db.produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produtos produtos = db.produtos.Find(id);
            db.produtos.Remove(produtos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void carregarComboClientes()
        {
            List<clientes> c = dbClientes.clientes.ToList();
            List<SelectListItem> combo = new List<SelectListItem>();
                foreach (var item in c) {
                combo.Add(new SelectListItem
                        {
                            Value = item.ClienteId.ToString(),
                            Text = item.Nome.ToUpper() + " " + item.Sobrenome.ToUpper()
                });
            }

            ViewBag.clientes = combo;
        }
    }
}
