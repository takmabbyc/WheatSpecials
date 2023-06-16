using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WheatSpecials.Models.Database
{
    [Table("WheatBeers")]
    public class WheatBeer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AlcoholPercentage { get; set; }

        public string ImageUrl { get; set; }
    }
}
