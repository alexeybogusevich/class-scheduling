using System.Collections.Generic;

namespace KNU.IS.ClassScheduling.Logic.Models.CSP
{
    public class SelectionScope
    {
        public ISet<int> RoomsTaken { get; set; } = new HashSet<int>();
        public ISet<int> InstructorsTaken { get; set; } = new HashSet<int>();
        public ISet<int> GroupsTaken { get; set; } = new HashSet<int>();

        public int GetTotalTakenVariables()
        {
            return RoomsTaken.Count + InstructorsTaken.Count + GroupsTaken.Count;
        }
    }
}
