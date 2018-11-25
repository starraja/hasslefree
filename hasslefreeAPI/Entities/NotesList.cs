using System;
using System.Collections.Generic;

namespace hasslefreeAPI.Entities
{
    public partial class NotesList
    {
        public int NotesId { get; set; }
        public string NotesDescription { get; set; }
        public string Source { get; set; }
        public int? ReferenceId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public UserMaster CreatedByNavigation { get; set; }
        public UserMaster ModifiedByNavigation { get; set; }
    }
}
