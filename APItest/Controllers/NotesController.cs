using APItest.Data;
using APItest.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APItest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly MyDbContext myDbContext;

        public NotesController(MyDbContext _myDbContext)
        {
            this.myDbContext = _myDbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            //get notes from db
            return Ok(await myDbContext.Notes.ToListAsync());

        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetNoteById")]
        public async Task<IActionResult> GetNoteById([FromRoute] Guid id)
        {
            //get notes from db
          //  return Ok(await notesDbContext.Notes.FirstOrDefaultAsync(x => x.Id==id));

            var note = (await myDbContext.Notes.FindAsync(id));

            if (note == null) return NotFound();
            return Ok(note);


        }

        [HttpPost]
        public async Task<IActionResult> AddNote(Note note)
        {
            note.Id = Guid.NewGuid();
            await myDbContext.Notes.AddAsync(note);
            await myDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNoteById),new {id=note.Id}, note);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateNote([FromRoute] Guid id, [FromBody] Note updateNote)
        {
            var existingNote = await myDbContext.Notes.FindAsync(id);
            if (existingNote == null) return NotFound();

            existingNote.Title = updateNote.Title;
            existingNote.Description = updateNote.Description;
            existingNote.IsVisible = updateNote.IsVisible;
            await myDbContext.SaveChangesAsync();

            return Ok(existingNote);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteNote([FromRoute] Guid id)
        {
            var existingNode = myDbContext.Notes.Find(id);
            if (existingNode == null) return NotFound();

            myDbContext.Notes.Remove(existingNode);
            await myDbContext.SaveChangesAsync();
            
            return Ok();
        }

    }
}
