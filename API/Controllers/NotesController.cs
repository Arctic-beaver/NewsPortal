using System.Text.Json;
using System.Text.Json.Nodes;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly DataContext _context;
        public NotesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }

        [HttpGet("note/{id}")]
        public async Task<ActionResult<Note>> GetNote(string id)
        {
            return await _context.Notes.FindAsync(id);
        }

        [HttpPost("note")]
        public async Task<ActionResult<Note>> AddNote(InputNoteModel newNoteInputModel)
        {
            try {
                Note newNoteEntity = new Note(newNoteInputModel);
                await _context.Notes.AddAsync(newNoteEntity);
                _context.SaveChanges();
            } catch (Exception ex) {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPatch("note/{id}")]
        public async Task<ActionResult<Note>> UpdateNote(InputNoteModel newNoteInputModel, string id)
        {
            try {
                Note newNoteEntity = new Note(newNoteInputModel);
                Note oldNote = await _context.Notes.FindAsync(id);
                oldNote.UpdateNote(newNoteInputModel);
                _context.Notes.Update(oldNote);
                _context.SaveChanges();
            } catch (Exception ex) {
                return BadRequest();
            }

            return Ok();
        }
    }
}