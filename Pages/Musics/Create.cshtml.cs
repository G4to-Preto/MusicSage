using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMusic.Data;
using RazorPagesMusic.Models;

namespace MusicSage.Pages_Musics
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMusic.Data.RazorPagesMusicContext _context;

        public CreateModel(RazorPagesMusic.Data.RazorPagesMusicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Music Music { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Music == null || Music == null)
            {
                return Page();
            }

            _context.Music.Add(Music);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
