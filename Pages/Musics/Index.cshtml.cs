using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RazorPagesMusic.Data;
using RazorPagesMusic.Models;

namespace MusicSage.Pages_Musics
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMusic.Data.RazorPagesMusicContext _context;

        public IndexModel(RazorPagesMusic.Data.RazorPagesMusicContext context)
        {
            _context = context;
        }

        public IList<Music> Music { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string ? SearchString {get; set;}
        public SelectList ? Keys {get; set;}
        [BindProperty(SupportsGet = true)]
        public string ? MusicKey {get; set;}

        public async Task OnGetAsync()
        {
            IQueryable<string> keyQuery = from m in _context.Music
                                            orderby m.Key
                                            select m.Key;
            var musics = from m in _context.Music
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                musics = musics.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MusicKey))
            {
                musics = musics.Where(x => x.Key == MusicKey);
            }

            Keys = new SelectList(await keyQuery.Distinct().ToListAsync());
            Music = await musics.ToListAsync();
        }
    }
}
