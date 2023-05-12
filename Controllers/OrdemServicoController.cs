using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentroAutomotivo.Data;
using CentroAutomotivo.Models;

namespace CentroAutomotivo.Controllers
{
    public class OrdemServicoController : Controller
    {
        private readonly AppDbContext _context;

        public OrdemServicoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OrdemServico
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.OrdensServico.Include(o => o.StatusOrdemServico)
                                                     .Include(o => o.Veiculo)
                                                        .ThenInclude(v => v.AppUser)
                                                     .OrderByDescending(o => o.DataEntrada);

            return View(await appDbContext.ToListAsync());
        }

        // GET: OrdemServico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdensServico == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdensServico
                .Include(o => o.StatusOrdemServico)
                .Include(o => o.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            return View(ordemServico);
        }

        // GET: OrdemServico/Create
        public IActionResult Create()
        {
            var ordemServico = new OrdemServico();

            ViewData["StatusOrdemServicoId"] = new SelectList(_context.StatusOrdensServico, "Id", "Nome");
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome");

            return View(ordemServico);
        }

        // POST: OrdemServico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataEntrada,DataSaida,Descricao,StatusOrdemServicoId,VeiculoId")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordemServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusOrdemServicoId"] = new SelectList(_context.StatusOrdensServico, "Id", "Cor", ordemServico.StatusOrdemServicoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "AppUserId", ordemServico.VeiculoId);
            return View(ordemServico);
        }

        // GET: OrdemServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdensServico == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdensServico.FindAsync(id);
            if (ordemServico == null)
            {
                return NotFound();
            }
            ViewData["StatusOrdemServicoId"] = new SelectList(_context.StatusOrdensServico, "Id", "Cor", ordemServico.StatusOrdemServicoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "AppUserId", ordemServico.VeiculoId);
            return View(ordemServico);
        }

        // POST: OrdemServico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataEntrada,DataSaida,Descricao,StatusOrdemServicoId,VeiculoId")] OrdemServico ordemServico)
        {
            if (id != ordemServico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordemServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemServicoExists(ordemServico.Id))
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
            ViewData["StatusOrdemServicoId"] = new SelectList(_context.StatusOrdensServico, "Id", "Cor", ordemServico.StatusOrdemServicoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "AppUserId", ordemServico.VeiculoId);
            return View(ordemServico);
        }

        // GET: OrdemServico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdensServico == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdensServico
                .Include(o => o.StatusOrdemServico)
                .Include(o => o.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            return View(ordemServico);
        }

        // POST: OrdemServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdensServico == null)
            {
                return Problem("Entity set 'AppDbContext.OrdensServico'  is null.");
            }
            var ordemServico = await _context.OrdensServico.FindAsync(id);
            if (ordemServico != null)
            {
                _context.OrdensServico.Remove(ordemServico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdemServicoExists(int id)
        {
          return _context.OrdensServico.Any(e => e.Id == id);
        }
    }
}
