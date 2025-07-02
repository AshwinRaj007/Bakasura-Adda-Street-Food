using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BakasuraAddaFoodStreet.Model
{
    public class MasterUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
    }
}
