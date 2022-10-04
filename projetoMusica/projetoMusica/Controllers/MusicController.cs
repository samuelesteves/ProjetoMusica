using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetoMusica.Models;
using static projetoMusica.Data.Context;

namespace projetoMusica.Controllers
{
    public class MusicController : Controller
    {
        private readonly AppCont _appCont;


        public MusicController(AppCont appCont)
        {
            _appCont = appCont;
        }

        public IActionResult Index()
        {
            var allMusics = _appCont.musics.ToList();
            return View(allMusics);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _appCont.musics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,musicName,Artist,Genre,Explicit,releaseDate")] Music music)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(music);
                await _appCont.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(music);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var music = await _appCont.musics.FindAsync(id);

            if(music == null)
            {
                return NotFound();
            }

            return View(music);

        }

        private bool musicExists(int id)
        {
            return _appCont.musics.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind("Id,musicName,Artist,Genre,Explicit,releaseDate")] Music music)
        {
            if (id != music.Id)         
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appCont.Update(music);
                    await _appCont.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!musicExists(music.Id))
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
            return View(music);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _appCont.musics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var music = await _appCont.musics.FindAsync(id);
            _appCont.musics.Remove(music);
            await _appCont.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
