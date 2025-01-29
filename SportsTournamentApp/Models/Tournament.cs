using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsTournamentApp.Models
{
    public class Tournament
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Tournament")]
        [NotMapped]
        public string DisplayName
        {
            get
            {
                return Name + " " + StartDate.Year;
            }
        }

        public string Description { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = false)]
        public DateTime EndDate { get; set; }


        [Display(Name = "Winning Team")]
        public int? WinningTeamID { get; set; }
        public Team? WinningTeam { get; set; }

        public ICollection<Match>? Matches { get; set; }

    }
}
