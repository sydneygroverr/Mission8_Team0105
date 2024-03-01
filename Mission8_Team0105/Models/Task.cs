using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mission8_Team0105.Models
{


    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; } // Assuming 1 to 4 values for each quadrant

        public bool? Completed { get; set; }

        [ForeignKey("CategoryID")]
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
    }


}
