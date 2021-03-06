using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csharp_bibliotecaMvc.Data;
using csharp_bibliotecaMvc.Models;
namespace csharp_bibliotecaMvc.Controllers
{
    public class ModelViewController : Controller
    {
        private readonly BibliotecaContext _context;
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLibro(ViewModel l)
        {
        Libro libro = new Libro();
            if (ModelState.IsValid)
            {
                libro.Titolo = l.libro.Titolo;
                libro.Anno = l.libro.Anno;
                libro.Stato = l.libro.Stato;
                libro.ISBN = l.libro.ISBN;
                libro.Autore = l.libro.Autore;
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index", libro);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
