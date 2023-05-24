using Microsoft.AspNetCore.Mvc;
using CrudParcial1.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CrudParcial1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly Parcial1Context _context;
        public ProductoController(Parcial1Context context) 
        {
            _context = context;
        }

        // GET: ProductoController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            //return await _context.Productos.ToListAsync();
            return await _context.Productos.Include(x => x.Ventas).ToListAsync();
        }

        // GET: ProductoController/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProductoById(int id)
        {
            var producto = await _context.Productos.Include(x => x.Ventas).FirstOrDefaultAsync(x => x.Id == id);
            //var producto = await _context.Productos.Include(x => x.Ventas).FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: ProductoController/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return CreatedAtAction("GetProductoById", new { id = producto.Id }, producto);

        }

        // POST: ProductoController
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductoById", new { id = producto.Id }, producto);
        }

        // DELETE: ProductoController/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(x => x.Id == id);
        }
    }
}
