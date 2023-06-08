using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentroAutomotivo.Data;
using CentroAutomotivo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CentroAutomotivo.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ClienteController(AppDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;

            var os = _context.OrdensServico.Include(o => o.StatusOrdemServico)
                                           .Include(o => o.Veiculo)
                                           .OrderByDescending(o => o.DataEntrada)
                                           .FirstOrDefault(o => o.StatusOrdemServico.Nome != "Concluído" && o.Veiculo.AppUserId == user.Id);
            
            if (os is not null)
                return View(os.Id);
            
            return View(0);
        }

        public async Task<IActionResult> CadastrarVeiculo()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var veiculo = new Veiculo();

            veiculo.AppUserId = user.Id;
            veiculo.AppUser = await _context.AppUsers.FirstOrDefaultAsync(u => u.Id == user.Id);

            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Nome");
            return View(veiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarVeiculo([Bind("Id,Nome,Placa,Imagem,ModeloId,AppUserId")] Veiculo veiculo, IFormFile imagem)
        {
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
            veiculo.AppUser = await _context.AppUsers.AsNoTracking().FirstAsync(u => u.Id == veiculo.AppUserId);

            return View(veiculo);
        }

        public async Task<IActionResult> MeusVeiculos()
        {
            var user = _userManager.GetUserAsync(User).Result;

            var veiculos = await _context.Veiculos.Include(v => v.Modelo)
                                                  .Where(v => v.AppUserId == user.Id)
                                                  .ToListAsync();

            return View(veiculos);
        }

        public async Task<IActionResult> Detalhes([FromQuery] int veiculoId)
        {
            var veiculo = await _context.Veiculos.Include(v => v.Modelo)
                                                    .ThenInclude(m => m.Marca)
                                                 .Include(v => v.OrdensServico)
                                                    .ThenInclude(o => o.PecasOrdem)
                                                        .ThenInclude(p => p.Peca)
                                                 .Include(v => v.OrdensServico)
                                                    .ThenInclude(o => o.ServicosOrdem)
                                                        .ThenInclude(s => s.Servico)
                                                 .Include(v => v.OrdensServico)
                                                    .ThenInclude(o => o.StatusOrdemServico)
                                                 .Include(v => v.AppUser)
                                                 .FirstOrDefaultAsync(v => v.Id == veiculoId);

            return View(veiculo);
        }

        public async Task<IActionResult> StatusServico(int id)
        {
            var user = _userManager.GetUserAsync(User).Result;

            var os = await _context.OrdensServico.Include(o => o.StatusOrdemServico)
                                                 .Include(o => o.Veiculo)
                                                    .ThenInclude(v => v.AppUser)
                                                 .Include(o => o.Veiculo)
                                                    .ThenInclude(v => v.Modelo)
                                                        .ThenInclude(m => m.Marca)
                                                 .Include(o => o.ServicosOrdem)
                                                    .ThenInclude(s => s.Servico)
                                                 .Include(o => o.PecasOrdem)
                                                    .ThenInclude(p => p.Peca)
                                                 .FirstOrDefaultAsync(o => o.Id == id && o.Veiculo.AppUserId == user.Id);
            
            if (os is not null)
                return View(os);
            
            return NotFound();
        }
    }
}