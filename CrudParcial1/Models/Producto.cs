using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CrudParcial1.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
