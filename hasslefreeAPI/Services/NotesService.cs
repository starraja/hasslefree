using AutoMapper;
using hasslefreeAPI.Entities;
using hasslefreeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hasslefreeAPI.Services
{
    public class NotesService: INotesService
    {
        private readonly HassleFreeContext _context;
        private readonly IMapper _mapper;

        public NotesService(HassleFreeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<NotesDto> GetAllNotes()
        {
            return _mapper.Map<NotesDto[]>(_context.Notes.ToArray().Where(x => x.FlagActive == true));
        }

        public NotesDto GetNoteById(int noteId)
        {
            return _mapper.Map<NotesDto>(_context.Notes.
               SingleOrDefault(x => x.NotesId == noteId && x.FlagActive == true));
        }

        public NotesDto CreateNote(NotesDto objNotesDto)
        {
            Notes objNotes = _mapper.Map<Notes>(objNotesDto);
            objNotes.CreatedDateTime = DateTime.Now;
            objNotes.CreatedBy = 1;
            _context.Notes.Add(objNotes);
            _context.SaveChanges();

            return _mapper.Map<NotesDto>(_context.Notes.
               SingleOrDefault(x => x.NotesId == objNotesDto.NotesId));
        }

        public NotesDto UpdateNote(NotesDto objNotesDto)
        {
            Notes objNotes = _mapper.Map<Notes>(objNotesDto);
            Notes objNotesData = _context.Notes.Find(objNotesDto.NotesId);
            objNotes.ModifiedDateTime = DateTime.Now;
            objNotes.ModifiedBy = 1;
            _context.Entry(objNotesData).CurrentValues.SetValues(objNotes);
            _context.SaveChanges();
            return _mapper.Map<NotesDto>(_context.Notes.
               SingleOrDefault(x => x.NotesId == objNotesDto.NotesId));
        }

        public void DeleteNote(int noteId)
        {
            Notes objNotes = _context.Notes.Find(noteId);
            objNotes.FlagActive = false;
            _context.Entry(objNotes).CurrentValues.SetValues(objNotes);
            _context.SaveChanges();
        }
    }
}
