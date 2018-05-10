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
    public class AreasController : Controller
    {
        private readonly Contexto _context;

        public AreasController(Contexto context)
        {
            _context = context;
        }

        // GET: Areas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Areas.Include(a => a.Empresa);
            return View(await contexto.ToListAsync());
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Areas
                .Include(a => a.Empresa)
                .SingleOrDefaultAsync(m => m.idArea == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            ViewData["idEmpresa"] = new SelectList(_context.Empresas, "idEmpresa", "nomeEmpresa");
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idArea,descArea,idEmpresa,dataCriacao")] Area area)
        {
            if (ModelState.IsValid)
            {
                _context.Add(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idEmpresa"] = new SelectList(_context.Empresas, "idEmpresa", "nomeEmpresa", area.idEmpresa);
            return View(area);
        }

        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Areas.SingleOrDefaultAsync(m => m.idArea == id);
            if (area == null)
            {
                return NotFound();
            }
            ViewData["idEmpresa"] = new SelectList(_context.Empresas, "idEmpresa", "nomeEmpresa", area.idEmpresa);
            return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idArea,descArea,idEmpresa,dataCriacao")] Area area)
        {
            if (id != area.idArea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(area);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaExists(area.idArea))
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
            ViewData["idEmpresa"] = new SelectList(_context.Empresas, "idEmpresa", "nomeEmpresa", area.idEmpresa);
            return View(area);
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Areas
                .Include(a => a.Empresa)
                .SingleOrDefaultAsync(m => m.idArea == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var area = await _context.Areas.SingleOrDefaultAsync(m => m.idArea == id);
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaExists(int id)
        {
            return _context.Areas.Any(e => e.idArea == id);
        }
    }
}
