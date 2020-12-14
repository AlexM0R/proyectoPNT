using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoPNT_MVC.Context;
using ProyectoPNT_MVC.Models;

namespace ProyectoPNT_MVC.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly ProyectoPNTDatabaseContext _context;

        public ArticuloController(ProyectoPNTDatabaseContext context)
        {
            _context = context;
        }

        // GET: Articulo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articulos.ToListAsync());
        }

        // GET: Articulo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .FirstOrDefaultAsync(m => m.id == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articulo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articulo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,numeroArticulo,precio,descripcion,nombre,imagen,stock,talle")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articulo);
        }

        // GET: Articulo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            return View(articulo);
        }

        // POST: Articulo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,numeroArticulo,precio,descripcion,nombre,imagen,stock,talle")] Articulo articulo)
        {
            if (id != articulo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloExists(articulo.id))
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
            return View(articulo);
        }

        // GET: Articulo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .FirstOrDefaultAsync(m => m.id == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("All")]
        public JsonResult devolverArticulos(String[] filtros)
        {
            var filtrosTipo = new List<String>();
            String talle = null;
            var articulos = _context.Set<Articulo>();
            var articulosReturn = new List<Articulo>();

            for (int i = 0; i < filtros.Length; i++)
            {
                var filtro = filtros[i];
                if (filtro.Equals("Remera") || filtro.Equals("Campera") || filtro.Equals("Buzo") || filtro.Equals("Pantalon")|| filtro.Equals("Zapatilla"))
                {
                    filtrosTipo.Add(filtro);
                }
                if (filtro.Equals("S") || filtro.Equals("M") || filtro.Equals("L") || filtro.Equals("XL"))
                {
                    talle = filtro;
                }
            }

            if (filtrosTipo.Count > 0 && talle != null) {
                foreach (Articulo a in articulos)
                {
                    if (a.talle.Equals(talle)) {
                        var seCumple = false;
                        int i = 0;
                        while (i < filtrosTipo.Count && !seCumple)
                        {
                            if (a.nombre.Contains(filtrosTipo[i]))
                            {
                                articulosReturn.Add(a);
                                seCumple = true;
                            }
                            i++;
                        }
                    }
                }
            }
            else if (filtrosTipo.Count == 0 && talle != null) {
                foreach (Articulo a in articulos)
                {
                    if (a.talle.Equals(talle))
                    {
                        articulosReturn.Add(a);
                    }
                }
            }
            else if (filtrosTipo.Count > 0 && talle == null) {
                foreach (Articulo a in articulos)
                {
                    var seCumple = false;
                    int i = 0;
                    while (i < filtrosTipo.Count && !seCumple)
                    {
                        if (a.nombre.Contains(filtrosTipo[i]))
                        {
                            articulosReturn.Add(a);
                            seCumple = true;
                        }
                        i++;
                    }
                }
            }
            else {
                articulosReturn = articulos.ToList();
            }

            return Json(articulosReturn);
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.id == id);
        }
    }
}
