using ASRental.Models;
using ASRental.Repository.Interfaces;
using ASRental.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        public TeamMemberService(ITeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        public async Task<bool> CreateTeamMember(TeamMember teamMember)
        {
            try
            {
                _teamMemberRepository.Create(teamMember);
                await _teamMemberRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteTeamMember(Guid id)
        {
            try
            {
                var teamMember = await GetTeamMemberById(id);
                _teamMemberRepository.Delete(teamMember);
                await _teamMemberRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<List<TeamMember>> GetAllTeamMembers()
        {
            try
            {
                return _teamMemberRepository.FindAll().OrderBy(teamMember => teamMember.MemberName).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<TeamMember> GetTeamMemberById(Guid id)
        {
            try
            {
                return _teamMemberRepository.FindByCondition(teamMember => teamMember.TeamMemberId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateTeamMember(Guid id, TeamMember teamMember)
        {
            try
            {
                await GetTeamMemberById(id);
                _teamMemberRepository.Update(teamMember);
                await _teamMemberRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool TeamMemberExists(Guid id)
        {
            return _teamMemberRepository.FindByCondition(e => e.TeamMemberId == id).Any();
        }
    }
}
