using System.ComponentModel.DataAnnotations;

namespace SportsTournamentApp.Models
{
    public class Team
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Coach { get; set; }

        [DataType(DataType.Date)]
        public DateTime FoundingDate { get; set; }
    }
}
