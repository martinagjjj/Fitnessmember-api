using System.Collections.Generic;  
using System.Linq;      // for LINQ methods like Where()
using System.Threading.Tasks;   // for async methods
using FitnessMember.Data;
using FitnessMember.Models;
using Microsoft.EntityFrameworkCore; // for EF Core methods like ToListAsync(), Include()

namespace FitnessMember.Repositories
{
    // This class implements the IMemberRepository interface using EF Core and FitnessDbContext
    // This is where we put the actual database logic, implementing the methods defined in the interface
    public class MemberRepository : IMemberRepository
    {
        // Gives us access to the database via EF Core
        private readonly FitnessDbContext _context;     

        // Constructor injection: ASP.NET Core will automatically give us a FitnessDbContext instance
        public MemberRepository(FitnessDbContext context) // called when creating an instance of MemberRepository
        {
            _context = context;
        }

        // GET all members
        // Returns a list of all members in the database
        // Optional parameter lastName allows filtering by LastName using a WHERE clause
        public async Task<List<Member>> GetAllAsync(string? lastName = null)
        {
            // If a lastName is provided, filter by it
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                return await _context.Members
                    .Include(m => m.FitnessClass)          // Eager loading of FitnessClass
                    .Where(m => m.LastName == lastName)    // WHERE LastName = lastName
                    .ToListAsync();                        // Executes the query and returns a list
            }

            // If no lastName filter is provided, return all members
            return await _context.Members
                .Include(m => m.FitnessClass)              // Eager loading of FitnessClass
                .ToListAsync();                            // Executes the query and returns a list
        }


        // CREATE a member
        // Adds a new member to the Members table
        public async Task<Member> CreateAsync(Member member)
        {
            // Reads the member data from the Member object passed in and adds it to the Members DbSet
            _context.Members.Add(member);

            // Saves the changes to the database
            await _context.SaveChangesAsync();

            // Returns the newly created member, now with its database-generated Id
            return member;
        }

        // UPDATE a member
        // Updates an existing member in the database
        public async Task<Member?> UpdateAsync(Member member)
        {
           _context.Members.Update(member);


            await _context.SaveChangesAsync();
            return member;



            var existing = await _context.Members.FindAsync(member.Id);
//check
if (existing == null)
{
    return null;
}

existing.FirstName = member.FirstName;
existing.LastName = member.LastName;
existing.Email = member.Email;
existing.DateOfBirth = member.DateOfBirth;
existing.MembershipStartDate = member.MembershipStartDate;
existing.FitnessClassId = member.FitnessClassId;

await _context.SaveChangesAsync();
return existing;

        }

        // DELETE a member by ID
        // Removes a member from the database if it exists
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Members.FindAsync(id);

            if (existing == null)
            {
                return false;
            }

            _context.Members.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
