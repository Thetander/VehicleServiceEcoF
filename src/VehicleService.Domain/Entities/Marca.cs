using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleService.Domain.Entities
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
        public DateTime ActualizadoEn { get; set; } = DateTime.UtcNow;

     
        public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
    }
}