using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignaVersionamento.Context;
using SignaVersionamento.Models;

namespace SignaVersionamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly LocalContext _context;

        public LocalController(LocalContext context)
        {
            _context = context;

            if (_context.Local.Count() == 0)
            {                
                _context.Local.Add(new LocalModel { Id=1,Ambiente = "PacotesVersao",Localizacao=@"C:\Users\Douglas\Desktop\Versionamento\PacoteVersao"});
                _context.SaveChanges();

                _context.Local.Add(new LocalModel { Id=2,Ambiente = "Dev",Localizacao=@"C:\Users\Douglas\Desktop\Versionamento\Dev"});
                _context.SaveChanges();

                _context.Local.Add(new LocalModel { Id=3,Ambiente = "QA",Localizacao=@"C:\Users\Douglas\Desktop\Versionamento\QA"});
                _context.SaveChanges();

                _context.Local.Add(new LocalModel { Id=4,Ambiente = "PP",Localizacao=@"C:\Users\Douglas\Desktop\Versionamento\PP"});
                _context.SaveChanges();

                _context.Local.Add(new LocalModel { Id=5,Ambiente = "Prod",Localizacao=@"C:\Users\Douglas\Desktop\Versionamento\Prod"});
                _context.SaveChanges();
            }
        }    

        // GET: api/Local
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalModel>>> GetLocal()
        {
            return await _context.Local.ToListAsync();
        }

        // GET: api/Local/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocalModel>> GetLocal(long id)
        {
            var local = await _context.Local.FindAsync(id);

            if (local == null)
            {
                return NotFound();
            }

            return local;
        }    
        

        // POST: api/Local
        [HttpPost]
        public async Task<ActionResult<LocalModel>> PostLocal(LocalModel item)
        {
            _context.Local.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLocal), new { id = item.Id }, item);
        }


        // PUT: api/Local/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocal(long id, LocalModel item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/Local/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocal(long id)
        {
            var local = await _context.Local.FindAsync(id);

            if (local == null)
            {
                return NotFound();
            }

            _context.Local.Remove(local);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    
    }

}