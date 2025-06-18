using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VehicleService.Domain.Enums;

namespace VehicleService.Domain.Entities
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public int TipoId { get; set; }
        public int ModeloId { get; set; }
        public string Placa { get; set; } = string.Empty;
        public TipoMaquinaria TipoMaquinaria { get; set; }
        public int AñoFabricacion { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal OdometroInicial { get; set; }
        public decimal OdometroActual { get; set; }
        public decimal CapacidadCombustible { get; set; }
        public string CapacidadMotor { get; set; } = string.Empty;
        public EstadoVehiculo Estado { get; set; }
        public DateTime? FechaUltimoMantenimiento { get; set; }
        public DateTime? FechaProximoMantenimiento { get; set; }
        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
        public DateTime ActualizadoEn { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual TipoVehiculo Tipo { get; set; } = null!;
        public virtual Modelo Modelo { get; set; } = null!;
        public virtual ICollection<EstadoOperacionalVehiculo> EstadosOperacionales { get; set; } = new List<EstadoOperacionalVehiculo>();
    }
}


