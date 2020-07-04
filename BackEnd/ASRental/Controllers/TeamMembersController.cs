using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASRental.Data;
using ASRental.Models;
using ASRental.Services.Interfaces;

namespace ASRental.Controllers
{
    public class TeamMembersController : Controller
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamMembersController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }


        public IActionResult TeamMembers()
        {
            return View();
        }

        //GET: TeamMembers
        public async Task<IActionResult> Index()
        {
            return View(await _teamMemberService.GetAllTeamMembers());
        }

        // GET: TeamMembers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _teamMemberService.GetTeamMemberById(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        // GET: TeamMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamMemberId,MemberName,MemberRank,Description")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                await _teamMemberService.CreateTeamMember(teamMember);
                return RedirectToAction(nameof(Create));
            }
            return View(teamMember);
        }

        // GET: TeamMembers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _teamMemberService.GetTeamMemberById(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            return View(teamMember);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TeamMemberId,MemberName,MemberRank,Description")] TeamMember teamMember)
        {
            if (id != teamMember.TeamMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _teamMemberService.UpdateTeamMember(id, teamMember);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_teamMemberService.TeamMemberExists(teamMember.TeamMemberId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teamMember);
        }

        // GET: TeamMembers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = await _teamMemberService.GetTeamMemberById(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _teamMemberService.DeleteTeamMember(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

