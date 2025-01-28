using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsTournamentApp.Data;
using SportsTournamentApp.Models;

namespace SportsTournamentApp.Pages.Tournaments
{
    public class CreateModel : PageModel
    {
        private readonly SportsTournamentApp.Data.SportsTournamentAppContext _context;

        public CreateModel(SportsTournamentApp.Data.SportsTournamentAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["WinningTeamID"] = new SelectList(_context.Team, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Tournament Tournament { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tournament.Add(Tournament);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
