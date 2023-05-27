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
    public class StatusOrdemServicoController : Controller
    {
        private readonly AppDbContext _context;

        public StatusOrdemServicoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StatusOrdemServico
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusOrdensServico.ToListAsync());
        }

        // GET: StatusOrdemServico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusOrdensServico == null)
            {
                return NotFound();
            }

            var statusOrdemServico = await _context.StatusOrdensServico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statusOrdemServico == null)
            {
                return NotFound();
            }

            return View(statusOrdemServico);
        }

        // GET: StatusOrdemServico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusOrdemServico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cor")] StatusOrdemServico statusOrdemServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusOrdemServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusOrdemServico);
        }

        // GET: StatusOrdemServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusOrdensServico == null)
            {
                return NotFound();
            }

            var statusOrdemServico = await _context.StatusOrdensServico.FindAsync(id);
            if (statusOrdemServico == null)
            {
                return NotFound();
            }
            return View(statusOrdemServico);
        }

        // POST: StatusOrdemServico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cor")] StatusOrdemServico statusOrdemServico)
        {
            if (id != statusOrdemServico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusOrdemServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusOrdemServicoExists(statusOrdemServico.Id))
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
            return View(statusOrdemServico);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var statusOrdemServico = _context.StatusOrdensServico.FirstOrDefault(s => s.Id == id);

            if (statusOrdemServico == null)
            {
                return Json(new { success = false, message = "Status não encontrado!" });
            }

            try
            {
                _context.StatusOrdensServico.Remove(statusOrdemServico);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return Json(new { success = false, message = "Ocorreu um problema inesperado! Avise ao Suporte!" });
            }

            return Json(new { success = true, message = "Status excluído com sucesso!" });
        }

        private bool StatusOrdemServicoExists(int id)
        {
            return _context.StatusOrdensServico.Any(e => e.Id == id);
        }
    }
}
