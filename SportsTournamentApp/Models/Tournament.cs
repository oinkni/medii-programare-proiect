using System.ComponentModel.DataAnnotations;

namespace SportsTournamentApp.Models
{
    public class Tournament
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }
        public int? WinnerID { get; set; }
        public Team? Winner { get; set; }
        public bool Spotlight { get; set; }
    }
}
