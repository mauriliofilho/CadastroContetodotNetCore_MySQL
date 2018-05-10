using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnterpriseCad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System.ComponentModel;
using System.Text;
using EnterpriseCad.Helpers;
using System.Data;

namespace EnterpriseCad.Controllers
{
    public class ContatoVMController : Controller
    {
        public IQueryable<Contato> contato;

        private readonly Contexto _context;

        public ContatoVMController(Contexto context)
        {
            _context = context;
        }
        // GET: ContatoVM
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {
                contato = from m in _context.Contato
                          where m.nomeContato.Contains(searchString)
                          select m;


                contato = contato.Include(c => c.Area).ThenInclude(x => x.Empresa);

                HttpContext.Session.SetObjectAsJson("SessionContato", contato);

            }
            if (!contato.Any())
            {
                return View("SemReg");
            }

            return View("Search", contato);
            
        }


        [HttpGet]
        public FileContentResult ExportToExcel()
        {
            var contato = HttpContext.Session.GetObjectFromJson<List<Contato>>("SessionContato");

            //List<Technology> technologies = StaticData.Technologies;
            string[] columns = { "Codigo CNPJ", "Empresa", "Contato", "CPF", "Tel.Residencial", "Tel.Celular", "Email", "Area Atuação" };
            byte[] filecontent = ExcelExportHelper.ExportExcel(contato, "Contatos", true, columns);
            return File(filecontent, ExcelExportHelper.ExcelContentType, "Contatos.xlsx");

        }

        

        // GET: ContatoVM/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContatoVM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContatoVM/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContatoVM/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContatoVM/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContatoVM/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContatoVM/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}