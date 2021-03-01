using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogMeImFamous.DAL;
using BlogMeImFamous.Models;

namespace BlogMeImFamous.Controllers
{
    public class CommentaireController : Controller
    {
        private readonly BlogContext _context;

        public CommentaireController()
        {
            _context = new BlogContext();
        }

        // GET: Commentaire
        public async Task<IActionResult> Index()
        {
            return View(await _context.Commentaires.ToListAsync());
        }

        // GET: Commentaire/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaire = await _context.Commentaires
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentaire == null)
            {
                return NotFound();
            }

            return View(commentaire);
        }

        // GET: Commentaire/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Commentaire/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Contenu,DatePublication")] Commentaire commentaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commentaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commentaire);
        }

        // GET: Commentaire/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaire = await _context.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return NotFound();
            }
            return View(commentaire);
        }

        // POST: Commentaire/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Contenu,DatePublication")] Commentaire commentaire)
        {
            if (id != commentaire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentaireExists(commentaire.Id))
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
            return View(commentaire);
        }

        // GET: Commentaire/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaire = await _context.Commentaires
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentaire == null)
            {
                return NotFound();
            }

            return View(commentaire);
        }

        // POST: Commentaire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commentaire = await _context.Commentaires.FindAsync(id);
            _context.Commentaires.Remove(commentaire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentaireExists(int id)
        {
            return _context.Commentaires.Any(e => e.Id == id);
        }
    }
}
