using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Name { get; set; }
        public int DisplayOder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;



    }
}
