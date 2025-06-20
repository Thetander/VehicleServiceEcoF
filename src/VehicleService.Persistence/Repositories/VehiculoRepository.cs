using Microsoft.EntityFrameworkCore;
using VehicleService.Domain.Entities;
using VehicleService.Domain.Enums;
using VehicleService.Domain.Repositories;

namespace VehicleService.Persistence.Repositories
{
    public class VehiculoRepository : RepositoryBase<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(VehicleDbContext context) : base(context)
        {
        }

        public async Task<Vehiculo?> GetByCodigoAsync(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return null;

            return await Context.Vehiculos
                .Include(v => v.Modelo)
                    .ThenInclude(m => m.Marca)
                .Include(v => v.Tipo)
                .FirstOrDefaultAsync(v => v.Codigo == codigo);
        }

        public async Task<Vehiculo?> GetByPlacaAsync(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return null;

            return await Context.Vehiculos
                .Include(v => v.Modelo)
                    .ThenInclude(m => m.Marca)
                .Include(v => v.Tipo)
                .FirstOrDefaultAsync(v => v.Placa == placa);
        }

        public async Task<IEnumerable<Vehiculo>> GetByTipoMaquinariaAsync(TipoMaquinaria tipoMaquinaria)
        {
            return await Context.Vehiculos
                .Include(v => v.Modelo)
                    .ThenInclude(m => m.Marca)
                .Include(v => v.Tipo)
                .Where(v => v.TipoMaquinaria == tipoMaquinaria)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vehiculo>> GetByEstadoAsync(EstadoVehiculo estado)
        {
            return await Context.Vehiculos
                .Include(v => v.Modelo)
                    .ThenInclude(m => m.Marca)
                .Include(v => v.Tipo)
                .Where(v => v.Estado == estado)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculosActivosAsync()
        {
            return await GetByEstadoAsync(EstadoVehiculo.Activo);
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculosDisponiblesAsync()
        {
            return await Context.Vehiculos
                .Include(v => v.Modelo)
                    .ThenInclude(m => m.Marca)
                .Include(v => v.Tipo)
                .Where(v => v.Estado == EstadoVehiculo.Activo || v.Estado == EstadoVehiculo.Reservado)
                .ToListAsync();
        }

        public async Task<bool> ExistsByCodigoAsync(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return false;

            return await Context.Vehiculos.AnyAsync(v => v.Codigo == codigo);
        }

        public async Task<bool> ExistsByPlacaAsync(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            return await Context.Vehiculos.AnyAsync(v => v.Placa == placa);
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculosConMantenimientoVencidoAsync()
        {
            var fechaActual = DateTime.Now;
            return await Context.Vehiculos
                .Include(v => v.Modelo)
                    .ThenInclude(m => m.Marca)
                .Include(v => v.Tipo)
                .Where(v => v.FechaProximoMantenimiento.HasValue &&
                           v.FechaProximoMantenimiento.Value <= fechaActual)
                .ToListAsync();
        }

        public async Task<Vehiculo?> GetVehiculoConDetallesAsync(int vehiculoId)
        {
            return await Context.Vehiculos
                .Include(v => v.Modelo)
                    .ThenInclude(m => m.Marca)
                .Include(v => v.Tipo)
                .Include(v => v.EstadosOperacionales.OrderByDescending(e => e.FechaInicio))
                .FirstOrDefaultAsync(v => v.VehiculoId == vehiculoId);
        }
    }
}