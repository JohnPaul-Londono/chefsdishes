using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chefsdishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required(ErrorMessage ="Please enter a name.")]
        public string dishName { get; set; }
        [Required(ErrorMessage ="Please put in calories.")]
        [Range(1,int.MaxValue, ErrorMessage ="Calories must be more than 0.")]
        public int numCal { get; set; }
        [Required]
        [Range(1,5, ErrorMessage ="Please have a taste level")]
        public int taste { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="Must be at least 3 Characters.")]
        public string Description { get; set; }

        public int ChefId { get; set; } 
        public Chef myChef { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}