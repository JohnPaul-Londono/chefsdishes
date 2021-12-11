using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chefsdishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public List<Dish> myDishes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}