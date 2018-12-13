using System;

namespace hasslefreeAPI.Models
{
    public class NotesDto
    {
        public int NotesId { get; set; }
        public int ActivityId { get; set; }
        public string Notes1 { get; set; }
        public bool FlagActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
