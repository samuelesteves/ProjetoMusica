using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoMusica.Models;
using static projetoMusica.Data.Context;

namespace projetoMusica.Controllers
{
    public class ArtistController : Controller
    {
        private readonly AppCont _appCont;


        public ArtistController(AppCont appCont)
        {
            _appCont = appCont;
        }

        public IActionResult Index()
        {
            var allArtists = _appCont.artists.ToList();
            return View(allArtists);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _appCont.artists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,artistName,mainInstrument,mainGenre,born,group")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(artist);
                await _appCont.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(artist);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _appCont.artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);

        }

        private bool artistExists(int id)
        {
            return _appCont.artists.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,artistName,mainInstrument,mainGenre,born,group")] Artist artist)
        {
            if (id != artist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appCont.Update(artist);
                    await _appCont.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!artistExists(artist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }

                return RedirectToAction("Index");

            }
            return View(artist);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _appCont.artists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = await _appCont.artists.FindAsync(id);
            _appCont.artists.Remove(artist);
            await _appCont.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
