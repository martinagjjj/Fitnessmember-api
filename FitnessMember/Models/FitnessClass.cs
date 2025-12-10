using System.ComponentModel.DataAnnotations;  //for data annotations like [Key]
using System.ComponentModel.DataAnnotations.Schema; //for [ForeignKey]
using FitnessMember.Models; //to access Member class


namespace FitnessMember.Models
{
    public class FitnessClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;   //to resolve the warnings when -- dotnet build

        [Required]
        [MaxLength(100)]
        public string Instructor { get; set; } =string.Empty;

        // When this class happens (date & time)
        public DateTime Schedule { get; set; }

        // Navigation property – one FitnessClass has many Members
        public List<Member> Members { get; set; } = new();
    }
}
