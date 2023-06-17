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
    public class VeiculoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public VeiculoController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Veiculo
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Veiculos.Include(v => v.AppUser).Include(v => v.Modelo);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Veiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Veiculos == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculos
                .Include(v => v.AppUser)
                .Include(v => v.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // GET: Veiculo/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.AppUsers.Where(u => u.IsAdmin == false), "Id", "Nome");
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Nome");
            return View();
        }

        // POST: Veiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Placa,Imagem,ModeloId,AppUserId")] Veiculo veiculo, IFormFile imagem)
        {
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Nome", veiculo.AppUserId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Nome", veiculo.ModeloId);

            if (ModelState.IsValid)
            {
                if (imagem != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
                    string uploads = Path.Combine(wwwRootPath, @"imagens\veiculos");
                    string newFile = Path.Combine(uploads, fileName);

                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    using (var stream = new FileStream(newFile, FileMode.Create))
                    {
                        imagem.CopyTo(stream);
                    }
                    veiculo.Imagem = @"\imagens\veiculos\" + fileName;
                }

                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        // GET: Veiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Veiculos == null)
            {
                return NotFound();
            }

            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Nome", veiculo.AppUserId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Nome", veiculo.ModeloId);
            return View(veiculo);
        }

        // POST: Veiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Placa,Imagem,ModeloId,AppUserId")] Veiculo veiculo, IFormFile imagem)
        {
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Nome", veiculo.AppUserId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Nome", veiculo.ModeloId);

            if (id != veiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imagem != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);
                        string uploads = Path.Combine(wwwRootPath, @"imagens\veiculos");
                        string newFile = Path.Combine(uploads, fileName);

                        if (!Directory.Exists(uploads))
                        {
                            Directory.CreateDirectory(uploads);
                        }

                        using (var stream = new FileStream(newFile, FileMode.Create))
                        {
                            imagem.CopyTo(stream);
                        }
                        veiculo.Imagem = @"\imagens\veiculos\" + fileName;
                    }
                    else
                    {
                        veiculo.Imagem = _context.Veiculos.AsNoTracking().FirstOrDefault(v => v.Id == veiculo.Id).Imagem;
                    }
                    _context.Update(veiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoExists(veiculo.Id))
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
            return View(veiculo);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var veiculo = _context.Veiculos.FirstOrDefault(s => s.Id == id);

            var osVeiculo = _context.OrdensServico.Where(o => o.VeiculoId == id).ToList();

            if (veiculo == null)
            {
                return Json(new { success = false, message = "Veículo não encontrado!" });
            }

            if (osVeiculo.Count > 0)
            {
                return Json(new { success = false, message = "Há Ordem de Serviço cadastrada para esse Veículo!" });
            }

            try
            {
                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return Json(new { success = false, message = "Ocorreu um problema inesperado! Avise ao Suporte!" });
            }

            return Json(new { success = true, message = "Veículo excluído com sucesso!" });
        }

        private bool VeiculoExists(int id)
        {
            return _context.Veiculos.Any(e => e.Id == id);
        }
    }
}
