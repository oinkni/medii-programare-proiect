using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsTournamentApp.Data;
using SportsTournamentApp.Models;

namespace SportsTournamentApp.Pages.Players
{
    public class DeleteModel : PageModel
    {
        private readonly SportsTournamentApp.Data.SportsTournamentAppContext _context;

        public DeleteModel(SportsTournamentApp.Data.SportsTournamentAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(a => a.Team)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (player == null)
            {
                return NotFound();
            }
            else
            {
                Player = player;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FindAsync(id);
            if (player != null)
            {
                Player = player;
                _context.Player.Remove(Player);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
