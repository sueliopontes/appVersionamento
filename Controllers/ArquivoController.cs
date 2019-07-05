using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignaVersionamento.Context;
using SignaVersionamento.Models;
using SignaVersionamento.Services;


namespace SignaVersionamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly ArquivoContext _context;

        //private readonly ArquivoService _arquivoService;

        public ArquivoController(ArquivoContext context)
        {
            _context = context;

            //_arquivoService = arquivoService;

            ArquivoService arquivoService = new ArquivoService();

            //List<ArquivoModel> arquivoModel = arquivoService.GetArquivos();  

            //arquivoModel(item => _context.Arquivos.Add(item).SaveChanges());

            if (_context.Arquivos.Count() == 0)
            {                
            // _context.Arquivos.Add(new ArquivoModel { Nome = "Item1" });
                foreach(ArquivoModel arquivo in arquivoService.GetArquivosFisico())
                {
                    _context.Arquivos.Add(arquivo);
                    _context.SaveChanges();
                    

                }
                //_context.Arquivos.Add(_arquivoService());
                //_context.SaveChanges();
            }
            
        }
    

        // GET: api/Arquivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArquivoModel>>> GetArquivos()
        {
            return await _context.Arquivos.ToListAsync();
        }

        // GET: api/Arquivo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArquivoModel>> GetArquivo(long id)
        {
            var arquivo = await _context.Arquivos.FindAsync(id);

            if (arquivo == null)
            {
                return NotFound();
            }

            return arquivo;
        }    
        

        // POST: api/Arquivo
        [HttpPost]
        public async Task<ActionResult<ArquivoModel>> PostArquivo(ArquivoModel item)
        {
            _context.Arquivos.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArquivo), new { id = item.Id }, item);
        }


        // PUT: api/Arquivo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArquivo(long id, ArquivoModel item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/Arquivo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArquivo(long id)
        {
            var arquivo = await _context.Arquivos.FindAsync(id);

            if (arquivo == null)
            {
                return NotFound();
            }

            _context.Arquivos.Remove(arquivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    
    }

}