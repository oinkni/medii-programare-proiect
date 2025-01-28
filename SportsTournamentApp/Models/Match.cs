using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsTournamentApp.Models
{
    public class Match
    {
        public int ID { get; set; }

        [Display(Name = "Team A")]
        public int TeamAID { get; set; }
        public Team? TeamA { get; set; }

        [Display(Name = "Team B")]
        public int? TeamBID { get; set; }
        public Team? TeamB { get; set; }

        [Display(Name = "Match Date")]
        [DataType(DataType.DateTime)]
        public DateTime MatchDate { get; set; }

        [Display(Name = "Result")]
        [NotMapped]
        public string Result
        {
            get
            {
                if(null != ScoreTeamA && null != ScoreTeamB) { 
                    return ScoreTeamA + " - " + ScoreTeamB;
                } else {
                    return "TBD";
                }
            }
        }

        [Display(Name = "Score Team A")]
        public int? ScoreTeamA { get; set; }


        [Display(Name = "Score Team B")]
        public int? ScoreTeamB {  get; set; }    

        public string Location { get; set; }

        [Display(Name = "Tournament")]
        public int? TournamentID { get; set; }
        public Tournament? Tournament { get; set; } 
    }
}
