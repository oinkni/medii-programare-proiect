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
    public class IndexModel : PageModel
    {
        private readonly SportsTournamentApp.Data.SportsTournamentAppContext _context;
        public string FirstNameFilter { get; set; }
        public string LastNameFilter { get; set; }
        public string PositionFilter { get; set; }

        public IndexModel(SportsTournamentApp.Data.SportsTournamentAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Player> Player { get;set; } = default!;

        public async Task OnGetAsync(string firstNameSearchString, 
            string lastNameSearchString, 
            string positionSearchString)
        {
            FirstNameFilter = firstNameSearchString;
            LastNameFilter = lastNameSearchString;
            PositionFilter = positionSearchString;

            Player = await _context.Player
                .Include(p => p.Team)
                .ToListAsync();


                Player = _context.Player.Where(s =>
                    (String.IsNullOrEmpty(FirstNameFilter) || s.FirstName.Contains(FirstNameFilter))
                    &&
                    (String.IsNullOrEmpty(LastNameFilter) || s.LastName.Contains(LastNameFilter))
                    &&
                    (String.IsNullOrEmpty(PositionFilter) || s.Position.Contains(PositionFilter))
                );
        }
    }
}
