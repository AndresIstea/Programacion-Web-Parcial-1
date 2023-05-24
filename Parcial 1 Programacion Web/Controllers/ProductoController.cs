using Microsoft.AspNetCore.Mvc;
using Parcial_1_Programacion_Web.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Parcial_1_Programacion_Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private List<Producto> _productos = new List<Producto>();
        public ProductoController() {
            _productos.Add(new Producto { Id = 1, Tipo = "Cafe", Descripcion = "Expresso", Precio = 800 });
            _productos.Add(new Producto { Id = 2, Tipo = "Cafe", Descripcion = "Cappuccino", Precio = 1200 });
            _productos.Add(new Producto { Id = 3, Tipo = "Cafe", Descripcion = "Latte", Precio = 1400 });
            _productos.Add(new Producto { Id = 4, Tipo = "Nevado", Descripcion = "Chococaramelo ", Precio = 1800 });
            _productos.Add(new Producto { Id = 5, Tipo = "Cafe", Descripcion = "En Grano Colina 454gr", Precio = 8500.99 });
            _productos.Add(new Producto { Id = 6, Tipo = "Cafe", Descripcion = "En Grano Volcan 454gr", Precio = 8525.99 });
            _productos.Add(new Producto { Id = 7, Tipo = "Cafe", Descripcion = "Molido Cumbre Descafeinado 340gr", Precio = 5995.99 });
            _productos.Add(new Producto { Id = 8, Tipo = "Cafetera", Descripcion = "Moka Pedrini Infinity 3 Tazas", Precio = 21450 });
            _productos.Add(new Producto { Id = 9, Tipo = "Cafetera", Descripcion = "Bodum Chambord cobre 8 pocillos", Precio = 63800 });
            _productos.Add(new Producto { Id = 10, Tipo = "Vaso", Descripcion = "Vaso Térmico Juan Valdez", Precio = 4500 });
            _productos.Add(new Producto { Id = 11, Tipo = "Vaso", Descripcion = "Botella Juan Valdez", Precio = 4500 });

        }

        // GET: <ProductoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _productos;
        }

        // GET <ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = _productos.FirstOrDefault(x => x.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }
    }
}
