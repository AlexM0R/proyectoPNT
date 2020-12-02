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

        public async Task<IActionResult> crearCarrito(int id, int idUser)
        {
            var carrito = await _context.Carrito.FindAsync(id, idUser);
            if (carrito == null) {
                Carrito c = new Carrito();
                c.articuloId = id;
                c.usuarioId = idUser;
                c.cantArticulos = 1;
                _context.Add(c);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            carrito.cantArticulos++;
            _context.Update(carrito);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        public async Task<IActionResult> eliminarArticuloCarrito(int id, int idUser) {
            var carrito = await _context.Carrito
                .Include(c => c.articulo)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.articuloId == id && m.usuarioId == idUser);
            if (carrito == null) {
                return NotFound();
            }

            if (carrito.cantArticulos > 1)
            {
                carrito.cantArticulos--;
                _context.Update(carrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else if (carrito.cantArticulos == 1) {
                _context.Remove(carrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        private bool CarritoExists(int id)
        {
            return _context.Carrito.Any(e => e.articuloId == id);
        }
    }
}
