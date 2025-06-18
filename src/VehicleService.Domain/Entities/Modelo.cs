using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VehicleService.Domain.Enums;

namespace VehicleService.Domain.Entities
{
    public class Modelo
    {
        public int ModeloId { get; set; }
        public int MarcaId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Año { get; set; }
        public TipoCombustible TipoCombustible { get; set; }
        public decimal ConsumoEstandar { get; set; }
        public decimal PorcentajeTolerancia { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
        public DateTime ActualizadoEn { get; set; } = DateTime.UtcNow;

        public virtual Marca Marca { get; set; } = null!;
        public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}