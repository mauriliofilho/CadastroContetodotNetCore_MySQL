using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnterpriseCad.Models;

namespace EnterpriseCad.Controllers
{
    public class ContatosController : Controller
    {
        private readonly Contexto _context;

        public ContatosController(Contexto context)
        {
            _context = context;
        }

        // GET: Contatos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Contato.Include(c => c.Area);
            return View(await contexto.ToListAsync());
        }


        public async Task<IActionResult> Search(string searchString)
        {
            IQueryable<Contato> contato = null;

            if (!String.IsNullOrEmpty(searchString))
            {
                contato = from m in _context.Contato
                         where m.nomeContato.Contains(searchString)
                         select m;

                contato = contato.Include(c => c.Area);
            }

            if (contato == null)
            {
                return null;
            }


            return View(await contato.ToListAsync());
        }

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato
                .Include(c => c.Area)
                .SingleOrDefaultAsync(m => m.idContato == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: Contatos/Create
        public IActionResult Create()
        {
            ViewData["idArea"] = new SelectList(_context.Areas, "idArea", "descArea");
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idContato,nomeContato,codCPF,telResidencial,telCelular,email,idArea")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idArea"] = new SelectList(_context.Areas, "idArea", "descArea", contato.idArea);
            return View(contato);
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato.SingleOrDefaultAsync(m => m.idContato == id);
            if (contato == null)
            {
                return NotFound();
            }
            ViewData["idArea"] = new SelectList(_context.Areas, "idArea", "descArea", contato.idArea);
            return View(contato);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idContato,nomeContato,codCPF,telResidencial,telCelular,email,idArea")] Contato contato)
        {
            if (id != contato.idContato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contato.idContato))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["idArea"] = new SelectList(_context.Areas, "idArea", "descArea", contato.idArea);
            return View(contato);
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contato
                .Include(c => c.Area)
                .SingleOrDefaultAsync(m => m.idContato == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contato = await _context.Contato.SingleOrDefaultAsync(m => m.idContato == id);
            _context.Contato.Remove(contato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(int id)
        {
            return _context.Contato.Any(e => e.idContato == id);
        }
    }
}
