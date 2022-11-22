using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItemApp.Models
{
   
    public class Item
    {
        [Key]
        public int ?Id { get; set; }

        [Required]
        [Display(Name ="Item Name")]
        public string Name { get; set; }=String.Empty;

        [Display(Name = "Description")]
        public string Description { get; set; }="";
      
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } = default;
        [Display(Name="Date")]
        public DateTime CreatedDate { get; set; }= DateTime.Now;

        
 

    }
}
