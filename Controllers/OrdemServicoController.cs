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
                    .ThenInclude(v => v.AppUser)
                .Include(o => o.Veiculo)
                    .ThenInclude(v => v.Modelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            return View(ordemServico);
        }

        // GET: OrdemServico/Create
        public IActionResult Create(int veiculoId)
        {
            var ordemServico = new OrdemServico();

            ordemServico.VeiculoId = veiculoId;
            ordemServico.Veiculo = _context.Veiculos.Include(v => v.AppUser)
                                                    .FirstOrDefault(v => v.Id == veiculoId);

            ViewData["StatusOrdemServicoId"] = new SelectList(_context.StatusOrdensServico, "Id", "Nome");

            return View(ordemServico);
        }

        // POST: OrdemServico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataEntrada,DataSaida,Descricao,StatusOrdemServicoId,VeiculoId")] OrdemServico ordemServico, int veiculoId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordemServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusOrdemServicoId"] = new SelectList(_context.StatusOrdensServico, "Id", "Cor", ordemServico.StatusOrdemServicoId);
            return View(ordemServico);
        }

        // GET: OrdemServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdensServico == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdensServico.Include(o => o.StatusOrdemServico)
                                                           .Include(o => o.Veiculo)
                                                                .ThenInclude(v => v.AppUser)
                                                           .Include(o => o.Veiculo)
                                                                .ThenInclude(v => v.Modelo)
                                                            .Include(o => o.ServicosOrdem)
                                                                .ThenInclude(s => s.Servico)
                                                            .Include(o => o.PecasOrdem)
                                                                .ThenInclude(p => p.Peca)
                                                           .FirstOrDefaultAsync(o => o.Id == id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            if (ordemServico.StatusOrdemServico.Nome != "Concluído")
            {
                ordemServico.DataSaida = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            }

            ViewData["StatusOrdemServicoId"] = new SelectList(_context.StatusOrdensServico, "Id", "Nome", ordemServico.StatusOrdemServicoId);
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome", ordemServico.VeiculoId);
            ViewData["Servicos"] = new SelectList(_context.Servicos.OrderBy(s => s.Nome), "Id", "Nome");
            ViewData["Pecas"] = new SelectList(_context.Pecas.Where(p => p.Quantidade >= 5).OrderBy(s => s.Nome), "Id", "Nome");
            return View(ordemServico);
        }

        // POST: OrdemServico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataEntrada,DataSaida,Descricao,StatusOrdemServicoId,VeiculoId")] OrdemServico ordemServico, string servicoSelected, string pecaSelected, string pecasQtd)
        {
            if (id != ordemServico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                #region Adicionar Serviço
                ordemServico.ServicosOrdem = new List<ServicoOrdem>();

                if (servicoSelected is not null)
                {
                    if (servicoSelected.Length > 1)
                    {
                        var servicos = servicoSelected.Split(",");

                        foreach (var servico in servicos)
                        {
                            var so = _context.ServicosOrdem.AsNoTracking().Any(s => s.ServicoId == int.Parse(servico) && s.OrdemServicoId == ordemServico.Id);

                            if (!so)
                            {
                                _context.Add(
                                new ServicoOrdem
                                {
                                    OrdemServicoId = ordemServico.Id,
                                    ServicoId = int.Parse(servico)
                                }
                            );
                            }
                        }
                    }
                    else if (servicoSelected.Length == 1)
                    {
                        _context.Add(
                            new ServicoOrdem
                            {
                                OrdemServicoId = ordemServico.Id,
                                ServicoId = int.Parse(servicoSelected)
                            }
                        );
                    }
                }
                #endregion

                #region Adicionar Peça
                ordemServico.PecasOrdem = new List<PecaOrdem>();

                if (pecaSelected is not null)
                {
                    if (pecaSelected.Length > 1)
                    {
                        var pecas = pecaSelected.Split(",");
                        var qtds = pecasQtd.Split(",");

                        for (int i = 0; i < pecas.Count(); i++)
                        {
                            var po = _context.PecasOrdem.AsNoTracking().Any(p => p.PecaId == int.Parse(pecas[i]) && p.OrdemServicoId == ordemServico.Id);

                            if (!po)
                            {
                                _context.Add(
                                    new PecaOrdem
                                    {
                                        OrdemServicoId = ordemServico.Id,
                                        PecaId = int.Parse(pecas[i]),
                                        Quantidade = int.Parse(qtds[i])
                                    }
                                );
                            }
                        }
                    }
                    else if (pecaSelected.Length == 1)
                    {
                        _context.Add(
                            new PecaOrdem
                            {
                                OrdemServicoId = ordemServico.Id,
                                PecaId = int.Parse(pecaSelected),
                                Quantidade = int.Parse(pecasQtd)
                            }
                        );
                    }
                }
                #endregion


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
            ViewData["Servicos"] = new SelectList(_context.Servicos.OrderBy(s => s.Nome), "Id", "Nome");
            ViewData["Pecas"] = new SelectList(_context.Pecas.Where(p => p.Quantidade >= 5).OrderBy(s => s.Nome), "Id", "Nome");
            return View(ordemServico);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var ordemServico = await _context.OrdensServico.FirstOrDefaultAsync(o => o.Id == id);

            if (ordemServico == null)
            {
                return Json(new { success = false, message = "Ordem de Serviço não encontrada " });
            }

            try
            {
                _context.OrdensServico.Remove(ordemServico);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return Json(new { success = false, message = "Ocorreu um problema inesperado! Avise ao Suporte!" });
            }

            return Json(new { success = true, message = "Ordem de Serviço excluída com sucesso!" });
        }

        public IActionResult SelecionarUsuario()
        {
            var usuarios = _context.AppUsers.ToList();

            return View(usuarios);
        }

        public IActionResult SelecionarVeiculo(string userId)
        {
            var veiculos = _context.Veiculos.Where(v => v.AppUserId == userId)
                                            .Include(v => v.Modelo)
                                                .ThenInclude(m => m.Marca)
                                            .ToList();

            return View(veiculos);
        }

        [HttpPost]
        public JsonResult VerificarStatus(int status)
        {
            var statusOrdem = _context.StatusOrdensServico.FirstOrDefault(s => s.Id == status);

            bool mostrarDataSaida = (statusOrdem.Nome == "Concluído");

            return Json(new { mostrarDataSaida });
        }

        [HttpGet]
        public JsonResult GetServicosOrdem(int id)
        {
            var servicosOrdem = _context.ServicosOrdem.Where(s => s.OrdemServicoId == id).ToList();

            return Json(servicosOrdem);
        }

        [HttpGet]
        public JsonResult GetPecasOrdem(int id)
        {
            var pecasOrdem = _context.PecasOrdem.Where(s => s.OrdemServicoId == id).ToList();

            return Json(pecasOrdem);
        }

        private bool OrdemServicoExists(int id)
        {
            return _context.OrdensServico.Any(e => e.Id == id);
        }
    }
}
