using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GSMC20241103.Models;

namespace GSMC20241103.Controllers
{
    public class ComputadorasController : Controller
    {
        private readonly GSMC20241103DBContext _context;

        public ComputadorasController(GSMC20241103DBContext context)
        {
            _context = context;
        }

        // GET: Computadoras
        public async Task<IActionResult> Index()
        {
              return _context.Computadoras != null ? 
                          View(await _context.Computadoras.ToListAsync()) :
                          Problem("Entity set 'GSMC20241103DBContext.Computadoras'  is null.");
        }

        // GET: Computadoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Computadoras == null)
            {
                return NotFound();
            }

            var computadora = await _context.Computadoras
                 .Include(s => s.Componente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computadora == null)
            {
                return NotFound();
            }
            ViewBag.Accion = "Details";
            return View(computadora);
        }

        // GET: Computadoras/Create
        public IActionResult Create()
        {
            var computadora = new Computadora();

            computadora.Componente = new List<Componente>();
            computadora.Precio = 0;
            computadora.Componente.Add(new Componente
            {
            });
            ViewBag.Accion = "Create";
            return View(computadora);
        }

        // POST: Computadoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Marca,Modelo,Precio,Componente")] Computadora computadora)
        {
           
                _context.Add(computadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
          //  return View(computadora);
        }
        [HttpPost]
        public ActionResult AgregarDetalles([Bind("Id,Nombre,Marca,Modelo,Precio,Componente")] Computadora computadora, string accion)
        {
            computadora.Componente.Add(new Componente { });
            ViewBag.Accion = accion;
            return View(accion, computadora);
        }

        public ActionResult EliminarDetalles([Bind("Id,Nombre,Marca,Modelo,Precio,Componente")] Computadora computadora, int index, string accion)
        {
            var det = computadora.Componente[index];
            if (accion == "Edit" && det.Id > 0)
            {
                det.Id = det.Id * -1;
            }
            else
            {
                computadora.Componente.RemoveAt(index);
            }

            ViewBag.Accion = accion;
            return View(accion, computadora);
        }
        // GET: Computadoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Computadoras == null)
            {
                return NotFound();
            }

            var computadora = await _context.Computadoras
                 .Include(s => s.Componente)
                 .FirstAsync(s => s.Id == id);
            if (computadora == null)
            {
                return NotFound();
            }
            ViewBag.Accion = "Edit";
            return View(computadora);
        }

        // POST: Computadoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Marca,Modelo,Precio")] Computadora computadora)
        {
            if (id != computadora.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(computadora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputadoraExists(computadora.Id))
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

        // GET: Computadoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Computadoras == null)
            {
                return NotFound();
            }

            var computadora = await _context.Computadoras
                 .Include(s => s.Componente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computadora == null)
            {
                return NotFound();
            }
            ViewBag.Accion = "Delete";
            return View(computadora);
        }

        // POST: Computadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Computadoras == null)
            {
                return Problem("Entity set 'GSMC20241103DBContext.Computadoras'  is null.");
            }
            var computadora = await _context.Computadoras.FindAsync(id);
            if (computadora != null)
            {
                _context.Computadoras.Remove(computadora);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputadoraExists(int id)
        {
          return (_context.Computadoras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
