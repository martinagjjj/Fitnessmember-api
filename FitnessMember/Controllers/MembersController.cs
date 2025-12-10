using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessMember.Models;
using FitnessMember.Repositories;

namespace FitnessMember.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   // base route: /api/members
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        // Constructor: DI injects MemberRepository
        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        // api/members?lastName=Gjorgjevska
        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetMembers([FromQuery] string? lastName)
        {
            var members = await _memberRepository.GetAllAsync(lastName);
            return Ok(members);
        }

        // api/members
        [HttpPost]
        public async Task<ActionResult<Member>> CreateMember( Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _memberRepository.CreateAsync(member);

            return CreatedAtAction(
                nameof(GetMembers),     
                new { id = created.Id },
                created
            );
        }

        // api/members/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMember(int id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest("ID in URL and body do not match.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _memberRepository.UpdateAsync(member);

            if (updated == null)
            {
                return NotFound(); // member not found
            }

            return Ok(updated); // 200 with updated member
        }

        // api/members/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var deleted = await _memberRepository.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(); // 404 if no member with that id
            }

            return NoContent(); // 204 if deleted
        }
    }
}
