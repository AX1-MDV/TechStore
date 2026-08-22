using System.Collections.Generic;

namespace TechStore.Models
{
    public class AboutViewModel
    {
        public List<TimelineEventViewModel> Timeline { get; set; }
        public List<TeamMemberViewModel> Team { get; set; }
    }
}
