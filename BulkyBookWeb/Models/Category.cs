﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be bettween 1 and 100 only!!")]
        public int DisplayOder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;



    }
}
