using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoPNT_MVC.Context;
using ProyectoPNT_MVC.Models;

namespace ProyectoPNT_MVC.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ProyectoPNTDatabaseContext _context;

        public CarritoController(ProyectoPNTDatabaseContext context)
        {
            _context = context;
        }

        // GET: Carrito
        public async Task<IActionResult> Index()
        {
            var proyectoPNTDatabaseContext = _context.Carrito.Include(c => c.articulo).Include(c => c.usuario);
            return View(await proyectoPNTDatabaseContext.ToListAsync());
        }

        // GET: Carrito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito
                .Include(c => c.articulo)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.articuloId == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // GET: Carrito/Create
        public IActionResult Create()
        {
            ViewData["articuloId"] = new SelectList(_context.Articulos, "id", "descripcion");
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "id", "contraseña");
            return View();
        }

        // POST: Carrito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("articuloId,usuarioId")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["articuloId"] = new SelectList(_context.Articulos, "id", "descripcion", carrito.articuloId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "id", "contraseña", carrito.usuarioId);
            return View(carrito);
        }

        // GET: Carrito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }
            ViewData["articuloId"] = new SelectList(_context.Articulos, "id", "descripcion", carrito.articuloId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "id", "contraseña", carrito.usuarioId);
            return View(carrito);
        }

        // POST: Carrito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("articuloId,usuarioId")] Carrito carrito)
        {
            if (id != carrito.articuloId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoExists(carrito.articuloId))
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
            ViewData["articuloId"] = new SelectList(_context.Articulos, "id", "descripcion", carrito.articuloId);
            ViewData["usuarioId"] = new SelectList(_context.Usuarios, "id", "contraseña", carrito.usuarioId);
            return View(carrito);
        }

        // GET: Carrito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carrito
                .Include(c => c.articulo)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.articuloId == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // POST: Carrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrito = await _context.Carrito.FindAsync(id);
            _context.Carrito.Remove(carrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoExists(int id)
        {
            return _context.Carrito.Any(e => e.articuloId == id);
        }
    }
}
