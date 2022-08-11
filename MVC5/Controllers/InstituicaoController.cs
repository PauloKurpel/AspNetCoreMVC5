using Microsoft.AspNetCore.Mvc;
using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC5.Controllers
{
    public class InstituicaoController : Controller
    {
        //uma listagem de dados que estamos simulando o banco, por que estamos sem banco
        private static IList<Instituicao> _instituicaos = new List<Instituicao>()
        {
            new Instituicao(){InstituicaoID = 1, Nome= "UniParaná", Endereco="Paraná"},
            new Instituicao(){InstituicaoID = 2, Nome= "UniSanta", Endereco="Santa Catarina"},
            new Instituicao(){InstituicaoID = 3, Nome= "UniSaoPaulo", Endereco="São Paulo"},
            new Instituicao(){InstituicaoID = 5, Nome= "UniSulgrandense", Endereco="Rio Grande do Sul"},
            new Instituicao(){InstituicaoID = 6, Nome= "UniCarioca", Endereco="Rio de Janeiro"}
        };


        public IActionResult Index()
        {
            return View(_instituicaos);
        }

        //CRIAR NOVO
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instituicao instituicao)
        {
            _instituicaos.Add(instituicao);
            instituicao.InstituicaoID = _instituicaos.Select(i => i.InstituicaoID).Max() + 1;

            return RedirectToAction("Index");
        }

        // EDITAR
        public ActionResult Edit(long id)
        {
            return View(_instituicaos.Where(i => i.InstituicaoID == id).FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao)
        {

            _instituicaos.Remove(_instituicaos.Where(i => i.InstituicaoID == instituicao.InstituicaoID).FirstOrDefault());
            _instituicaos.Add(instituicao);

            return RedirectToAction("Index");
        }

        // DETALHES
        public ActionResult Details(long id)
        {
            return View(_instituicaos.Where(i => i.InstituicaoID == id).FirstOrDefault());
        }

        // DELETAR
        public ActionResult Delete(long id)
        {
            return View(_instituicaos.Where(i => i.InstituicaoID == id).FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Instituicao instituicao)
        {
            _instituicaos.Remove(_instituicaos.Where(i => i.InstituicaoID == instituicao.InstituicaoID).FirstOrDefault());
            return RedirectToAction("Index");
        }
    }
}
