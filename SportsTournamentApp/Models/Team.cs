using System.ComponentModel.DataAnnotations;

namespace SportsTournamentApp.Models
{
    public class Team
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Coach { get; set; }


        [Display(Name = "Founding Date")]
        [DataType(DataType.Date)]
        public DateTime FoundingDate { get; set; }

        public ICollection<Player>? Players { get; set; }
    }
}
