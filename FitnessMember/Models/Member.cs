using System.ComponentModel.DataAnnotations;  //for data annotations like [Key]
using System.ComponentModel.DataAnnotations.Schema; //for [ForeignKey]
using FitnessMember.Models; 
using Microsoft.EntityFrameworkCore;


namespace FitnessMember.Models        
{ 
    //to check if the email is unique
    [Index(nameof(Email), IsUnique = true)]
    public class Member     //defines a Member model
    {
        //attributes of a fitness member
        [Key]
        public int Id { get; set; }     //EF Core automatically recognizes "Id" as the primary key, Usually auto-incremented
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
         public DateOnly DateOfBirth { get; set; }

        public DateTime MembershipStartDate { get; set; } = DateTime.UtcNow;  //default to current UTC time

        // // Foreign key to Trainer, establishing relationship between Member and FitnessClass, 1:N
         public int? FitnessClassId { get; set; }
        // // Navigation property to access the associated Trainer entity
          [ForeignKey("FitnessClassId")]
        // // navigation property to access the associated FitnessClass entity

        // Foreign key (nullable – member may not be enrolled in a class)
        // Navigation property – the class this member belongs to
        public FitnessClass? FitnessClass { get; set; }
    }
}