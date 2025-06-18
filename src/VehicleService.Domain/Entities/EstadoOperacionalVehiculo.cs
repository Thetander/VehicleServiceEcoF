using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VehicleService.Domain.Enums;

namespace VehicleService.Domain.Entities
{
    public class EstadoOperacionalVehiculo
    {
        public int EstadoId { get; set; }
        public int VehiculoId { get; set; }
        public EstadoVehiculo Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string RegistradoPor { get; set; } = string.Empty;
        public DateTime CreadoEn { get; set; }

        // Navigation properties
        public virtual Vehiculo Vehiculo { get; set; } = null!;
    }
}