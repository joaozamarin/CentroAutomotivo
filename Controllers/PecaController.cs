using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentroAutomotivo.Data;
using CentroAutomotivo.Models;
using Microsoft.AspNetCore.Authorization;

namespace CentroAutomotivo.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PecaController : Controller
    {
        private readonly AppDbContext _context;

        public PecaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Peca
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pecas.ToListAsync());
        }

        // GET: Peca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pecas == null)
            {
                return NotFound();
            }

            var peca = await _context.Pecas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peca == null)
            {
                return NotFound();
            }

            return View(peca);
        }

        // GET: Peca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Quantidade,Preco")] Peca peca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peca);
        }

        // GET: Peca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pecas == null)
            {
                return NotFound();
            }

            var peca = await _context.Pecas.FindAsync(id);
            if (peca == null)
            {
                return NotFound();
            }
            return View(peca);
        }

        // POST: Peca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Quantidade,Preco")] Peca peca)
        {
            if (id != peca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PecaExists(peca.Id))
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
            return View(peca);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var peca = _context.Pecas.FirstOrDefault(s => s.Id == id);

            if (peca == null)
            {
                return Json(new { success = false, message = "Peça não encontrada!" });
            }

            try
            {
                _context.Pecas.Remove(peca);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return Json(new { success = false, message = "Ocorreu um problema inesperado! Avise ao Suporte!" });
            }

            return Json(new { success = true, message = "Peça excluída com sucesso!" });
        }

        private bool PecaExists(int id)
        {
            return _context.Pecas.Any(e => e.Id == id);
        }
    }
}
