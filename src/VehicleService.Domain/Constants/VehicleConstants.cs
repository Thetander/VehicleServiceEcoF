using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleService.Domain.constants
{
    public static class VehicleConstants
    {
        public static class Estados
        {
            public const string Activo = "Activo";
            public const string Mantenimiento = "Mantenimiento";
            public const string Inactivo = "Inactivo";
            public const string Reparacion = "Reparación";
            public const string Reservado = "Reservado";
        }

        public static class TiposMaquinaria
        {
            public const string Ligera = "Ligera";
            public const string Pesada = "Pesada";
        }

        public static class TiposCombustible
        {
            public const string Diesel = "Diesel";
            public const string Gasolina = "Gasolina";
            public const string Electrico = "Eléctrico";
            public const string Hibrido = "Híbrido";
        }

        public static class TiposUbicacion
        {
            public const string Planta = "Planta";
            public const string Cliente = "Cliente";
            public const string Deposito = "Depósito";
        }
    }
}

