using hasslefreeAPI.Models;
using hasslefreeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.Controllers
{
    [Route("api/[controller]")]
    public class NoteController: Controller
    {
        private readonly INotesService _notesService;
        public NoteController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet("GetNotes")]
        public IEnumerable<NotesDto> GetAllNotes()
        {
            return _notesService.GetAllNotes();
        }

        [HttpGet("GetNoteById")]
        public NotesDto GetNote(int noteId)
        {
            return _notesService.GetNoteById(noteId);
        }

        [HttpPost("PostNote")]
        public NotesDto SaveNote([FromBody] NotesDto model)
        {

            return _notesService.CreateNote(model);
        }

        [HttpPost("UpdateNote")]
        public NotesDto Update([FromBody] NotesDto model)
        {

            return _notesService.UpdateNote(model);
        }

        [HttpPost("DeleteNote")]
        public void Delete(int noteId)
        {

            _notesService.DeleteNote(noteId);
        }
    }
}
