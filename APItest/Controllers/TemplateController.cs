using APItest.Data;
using APItest.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APItest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateController : Controller
    {


        private readonly MyDbContext myDbContext;

        public TemplateController(MyDbContext _myDbContext)
        {
            this.myDbContext = _myDbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get notes from db
            return Ok(await myDbContext.TemplateEntities.ToListAsync());

        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetEntityById")]
        public async Task<IActionResult> GetEntityById([FromRoute] Guid id)
        {
            var dbEntry = (await myDbContext.TemplateEntities.FindAsync(id));

            if (dbEntry == null) return NotFound();
            return Ok(dbEntry);


        }

        [HttpPost]
        public async Task<IActionResult> AddNote(TemplateEntity dbEntry)
        {
            dbEntry.Id = Guid.NewGuid();
            await myDbContext.TemplateEntities.AddAsync(dbEntry);
            await myDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEntityById), new { id = dbEntry.Id }, dbEntry);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateNote([FromRoute] Guid id, [FromBody] TemplateEntity updateDBentry)
        {
            var existingDBentry = await myDbContext.TemplateEntities.FindAsync(id);
            if (existingDBentry == null) return NotFound();

            existingDBentry.TemplateField1 = updateDBentry.TemplateField1;
            existingDBentry.TemplateField2 = updateDBentry.TemplateField2;
            existingDBentry.IsVisible = updateDBentry.IsVisible;
            await myDbContext.SaveChangesAsync();

            return Ok(existingDBentry);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteDbEntry([FromRoute] Guid id)
        {
            var existingDBentry = myDbContext.TemplateEntities.Find(id);
            if (existingDBentry == null) return NotFound();

            myDbContext.TemplateEntities.Remove(existingDBentry);
            await myDbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
