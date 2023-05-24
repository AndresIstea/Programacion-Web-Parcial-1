using System.ComponentModel.DataAnnotations;

namespace CrudParcial1.Models
{
    public class Venta
    {
        public int Id { get; set; }
        [Required]
        public string nombreCliente { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
