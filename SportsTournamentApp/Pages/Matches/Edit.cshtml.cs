using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsTournamentApp.Data;
using SportsTournamentApp.Models;

namespace SportsTournamentApp.Pages.Matches
{
    public class EditModel : PageModel
    {
        private readonly SportsTournamentApp.Data.SportsTournamentAppContext _context;

        public EditModel(SportsTournamentApp.Data.SportsTournamentAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Match Match { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match =  await _context.Match
                 .Include(a => a.TeamA)
                .Include(a => a.TeamB)
                .Include(a => a.Tournament)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (match == null)
            {
                return NotFound();
            }
            Match = match;
            ViewData["TeamAID"] = new SelectList(_context.Team, "ID", "Name");
            ViewData["TeamBID"] = new SelectList(_context.Team, "ID", "Name");
            ViewData["TournamentID"] = new SelectList(_context.Tournament, "ID", "DisplayName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(Match.ID))
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

        private bool MatchExists(int id)
        {
            return _context.Match.Any(e => e.ID == id);
        }
    }
}
