using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoPNT_MVC.Context;
using ProyectoPNT_MVC.Models;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ProyectoPNT_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ProyectoPNTDatabaseContext _context;

        public UsuarioController(ProyectoPNTDatabaseContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult RegisterUser()
        {
            return View();
        }

        public IActionResult LoginUser()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombreUsuario,nombreCompleto,contraseña,direccion,mail,tipoUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                usuario.carritoId = usuario.id;
                usuario.comprasId = usuario.id;
                usuario.deseadosId = usuario.id;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombreUsuario,nombreCompleto,contraseña,direccion,mail,tipoUsuario")] Usuario usuario)
        {
            if (id != usuario.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.id))
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
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(String nombreUsuario, String contraseña) {
            if (ModelState.IsValid) {
                var usuario = _context.Usuarios.Where(u => u.nombreUsuario.Equals(nombreUsuario) && u.contraseña.Equals(contraseña)).FirstOrDefault();
                if (usuario != null)
                {
                    HttpContext.Session.SetString("LoginUsuario", usuario.id.ToString());
                    return RedirectToAction(nameof(Index));
                }

            }
            return View();
        }

        public ActionResult LogoutUser()
        {
            HttpContext.Session.SetString("LoginUsuario", "");
            return RedirectToAction(nameof(LoginUser));
        }
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.id == id);
        }
    }
}
