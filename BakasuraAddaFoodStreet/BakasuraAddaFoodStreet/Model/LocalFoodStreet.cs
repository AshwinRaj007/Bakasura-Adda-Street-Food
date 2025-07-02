using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakasuraAddaFoodStreet.Model
{
    public class LocalFoodStreet
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StreetID {  get; set; }
        [Required , MaxLength(200)]
        public string StreetName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string StallImage { get; set; }
        public string FoodItems { get; set; }
    }
}
