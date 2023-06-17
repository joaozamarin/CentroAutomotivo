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
    public class AgendamentoController : Controller
    {
        private readonly AppDbContext _context;

        public AgendamentoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Agendamento
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Agendamentos.Include(a => a.StatusOrdemServico)
                                                    .Include(a => a.Veiculo)
                                                        .ThenInclude(v => v.AppUser);
                                                        
            return View(await appDbContext.ToListAsync());
        }

        // GET: Agendamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .Include(a => a.StatusOrdemServico)
                .Include(a => a.Veiculo)
                    .ThenInclude(v => v.AppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // GET: Agendamento/Create
        public IActionResult Create()
        {
            ViewData["StatusOrdemServicoId"] = new SelectList(_context.StatusOrdensServico, "Id", "Cor");
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "AppUserId");
            return View();
        }

        // POST: Agendamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataHora,Telefone,DescricaoProblema,Resposta,Reboque,VeiculoId,StatusOrdemServicoId")] Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusOrdemServicoId"] = new SelectList(_context.StatusOrdensServico, "Id", "Nome", agendamento.StatusOrdemServicoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome", agendamento.VeiculoId);
            return View(agendamento);
        }

        // GET: Agendamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos.Include(a => a.Veiculo)
                                                            .ThenInclude(v => v.AppUser)
                                                         .FirstOrDefaultAsync(a => a.Id == id);
            if (agendamento == null)
            {
                return NotFound();
            }
            ViewData["StatusOrdemServicoId"] = new SelectList(_context.StatusOrdensServico.Where(s => s.TipoStatus.Nome == "Agendamento"), "Id", "Nome", agendamento.StatusOrdemServicoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome", agendamento.VeiculoId);
            return View(agendamento);
        }

        // POST: Agendamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataHora,Telefone,DescricaoProblema,Resposta,Reboque,VeiculoId,StatusOrdemServicoId")] Agendamento agendamento)
        {
            if (id != agendamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendamentoExists(agendamento.Id))
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
            ViewData["StatusOrdemServicoId"] = new SelectList(_context.StatusOrdensServico.Where(s => s.TipoStatus.Nome == "Agendamento"), "Id", "Cor", agendamento.StatusOrdemServicoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "AppUserId", agendamento.VeiculoId);
            return View(agendamento);
        }

        // GET: Agendamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Agendamentos == null)
            {
                return NotFound();
            }

            var agendamento = await _context.Agendamentos
                .Include(a => a.StatusOrdemServico)
                .Include(a => a.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        // POST: Agendamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Agendamentos == null)
            {
                return Problem("Entity set 'AppDbContext.Agendamentos'  is null.");
            }
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendamentoExists(int id)
        {
          return _context.Agendamentos.Any(e => e.Id == id);
        }
    }
}
