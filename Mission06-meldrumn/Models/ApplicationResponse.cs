using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_meldrumn.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        public string Title { get; set; }
        public short Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; } //dropdown
        public string Edited { get; set; } // originally set to bool but output results on database were zeros 
        public string LentTo { get; set; }
        public string Notes { get; set; }

        // Build Foreign Key Relationship
        public int CategoryID { get; set; } //dropdown
        public Category Category { get; set; }
    }
}
