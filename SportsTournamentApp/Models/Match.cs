using System.ComponentModel.DataAnnotations;

namespace SportsTournamentApp.Models
{
    public class Match
    {
        public int ID { get; set; }

        public int? TeamAID { get; set; }
        public Team? TeamA { get; set; }

        public int? TeamBID { get; set; }
        public Team? TeamB { get; set; }
        [DataType(DataType.DateTime)]

        public DateTime MatchDate { get; set; }

        public int ScoreTeamA { get; set; }

        public int ScoreTeamB {  get; set; }    

        public string Location { get; set; }

        public int? TournamentID { get; set; }
        public Tournament? Tournament { get; set; } 
    }
}
