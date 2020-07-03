using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Models
{
    public class TeamMember
    {
        public Guid TeamMemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberRank { get; set; }
        public string Description { get; set; }
    }
}
