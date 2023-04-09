using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Data;
using RazorPagesMusic.Models;

namespace MusicSage.Pages_Musics
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMusic.Data.RazorPagesMusicContext _context;

        public EditModel(RazorPagesMusic.Data.RazorPagesMusicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Music Music { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Music == null)
            {
                return NotFound();
            }

            var music =  await _context.Music.FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }
            Music = music;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Music).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(Music.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MusicExists(int id)
        {
          return (_context.Music?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
