using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsTournamentApp.Data;
using SportsTournamentApp.Models;

namespace SportsTournamentApp.Pages.Matches
{
    public class IndexModel : PageModel
    {
        private readonly SportsTournamentApp.Data.SportsTournamentAppContext _context;

        public IndexModel(SportsTournamentApp.Data.SportsTournamentAppContext context)
        {
            _context = context;
        }

        public IList<Match> Match { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Match = await _context.Match
                .Include(m => m.TeamA)
                .Include(m => m.TeamB)
                .Include(m => m.Tournament).ToListAsync();
        }
    }
}
