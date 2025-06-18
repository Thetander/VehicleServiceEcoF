using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleService.Domain.Entities
{
    internal class TipoVehiculo
    {
        public string TipoVehiculoId { get; private set; } 
        public string nombre { get; private set; }  = string.Empty;
        public string tipoMaquinariaVehiculoId { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public DateTime CreadoEn { get; private set; } = DateTime.UtcNow;
        public DateTime ActualizadoEn { get; private set; } = DateTime.UtcNow;

    }
}
