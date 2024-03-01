using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8_Team0105.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string? CategoryName { get; set; }
    }
}
