using System.ComponentModel.DataAnnotations;

namespace SportsTournamentApp.Models
{
    public class Tournament
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }
    }
}
