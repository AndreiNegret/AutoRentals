using ASRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
    public interface ITeamMemberService
    {
        public Task<List<TeamMember>> GetAllTeamMembers();
        public Task<TeamMember> GetTeamMemberById(Guid id);
        public Task<bool> UpdateTeamMember(Guid id, TeamMember teamMember);
        public Task<bool> CreateTeamMember(TeamMember teamMember);
        public Task<bool> DeleteTeamMember(Guid id);
        public bool TeamMemberExists(Guid id);
    }
}
