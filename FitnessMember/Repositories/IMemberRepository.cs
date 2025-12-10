using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessMember.Models;

namespace FitnessMember.Repositories
{
    // Contract for all member-related data operations
    public interface IMemberRepository
    {
        // 1) Returns all members. If lastName is provided, filter by LastName and include FitnessClass
        Task<List<Member>> GetAllAsync(string? lastName = null);

        // 2) Adds a new member and returns the created entity
        Task<Member> CreateAsync(Member member);

        // 3) Updates an existing member and returns the updated entity, or null if not found
        Task<Member?> UpdateAsync(Member member);

        // 4) Deletes a member by ID, returns true if successful, false if not found
        Task<bool> DeleteAsync(int id);
    }
}




