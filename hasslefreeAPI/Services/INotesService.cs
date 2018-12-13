using hasslefreeAPI.Models;
using System.Collections.Generic;

namespace hasslefreeAPI.Services
{
    public interface INotesService
    {
        IEnumerable<NotesDto> GetAllNotes();
        NotesDto GetNoteById(int noteId);
        NotesDto CreateNote(NotesDto objNotesDto);
        NotesDto UpdateNote(NotesDto objNotesDto);
        void DeleteNote(int noteId);
    }
}
