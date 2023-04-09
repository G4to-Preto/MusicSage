using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Data;
using RazorPagesMusic.Models;

namespace MusicSage.Pages_Musics
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMusic.Data.RazorPagesMusicContext _context;

        public DetailsModel(RazorPagesMusic.Data.RazorPagesMusicContext context)
        {
            _context = context;
        }

      public Music Music { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Music == null)
            {
                return NotFound();
            }

            var music = await _context.Music.FirstOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }
            else 
            {
                Music = music;
            }
            return Page();
        }
    }
}
