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
    public class DetailsModel : PageModel
    {
        private readonly SportsTournamentApp.Data.SportsTournamentAppContext _context;

        public DetailsModel(SportsTournamentApp.Data.SportsTournamentAppContext context)
        {
            _context = context;
        }

        public Match Match { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(a => a.TeamA)
                .Include(a => a.TeamB)
                .Include(a => a.Tournament)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (match == null)
            {
                return NotFound();
            }
            else
            {
                Match = match;
            }
            return Page();
        }
    }
}
