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
    public class TipoStatusController : Controller
    {
        private readonly AppDbContext _context;

        public TipoStatusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoStatus
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoStatuses.ToListAsync());
        }

        // GET: TipoStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoStatuses == null)
            {
                return NotFound();
            }

            var tipoStatus = await _context.TipoStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoStatus == null)
            {
                return NotFound();
            }

            return View(tipoStatus);
        }

        // GET: TipoStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoStatus tipoStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoStatus);
        }

        // GET: TipoStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoStatuses == null)
            {
                return NotFound();
            }

            var tipoStatus = await _context.TipoStatuses.FindAsync(id);
            if (tipoStatus == null)
            {
                return NotFound();
            }
            return View(tipoStatus);
        }

        // POST: TipoStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoStatus tipoStatus)
        {
            if (id != tipoStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoStatusExists(tipoStatus.Id))
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
            return View(tipoStatus);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoStatus = await _context.TipoStatuses.FirstOrDefaultAsync(m => m.Id == id);

            if (tipoStatus == null)
            {
                return Json(new { success = false, message = "Tipo Status não encontrado!" });
            }

            try
            {
                _context.TipoStatuses.Remove(tipoStatus);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return Json(new { success = false, message = "Ocorreu um problema inesperado! Avise ao Suporte!" });
            }

            return Json(new { success = true, message = "Tipo Status excluído com sucesso!" });
        }

        private bool TipoStatusExists(int id)
        {
          return _context.TipoStatuses.Any(e => e.Id == id);
        }
    }
}
