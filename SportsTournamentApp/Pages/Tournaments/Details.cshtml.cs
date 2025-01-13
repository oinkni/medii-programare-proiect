using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsTournamentApp.Data;
using SportsTournamentApp.Models;

namespace SportsTournamentApp.Pages.Tournaments
{
    public class DetailsModel : PageModel
    {
        private readonly SportsTournamentApp.Data.SportsTournamentAppContext _context;

        public DetailsModel(SportsTournamentApp.Data.SportsTournamentAppContext context)
        {
            _context = context;
        }

        public Tournament Tournament { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournament.FirstOrDefaultAsync(m => m.ID == id);
            if (tournament == null)
            {
                return NotFound();
            }
            else
            {
                Tournament = tournament;
            }
            return Page();
        }
    }
}
