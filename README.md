# 🚗 VehicleService - Microservicio de Gestión de Vehículos

![Status](https://img.shields.io/badge/Status-In%20Development-orange)
![Version](https://img.shields.io/badge/Version-1.0.0-blue)
![License](https://img.shields.io/badge/License-MIT-yellow)

## 📋 Descripción

VehicleService es un microservicio para la gestión de vehículos desarrollado en .NET 9 siguiendo los principios de **Clean Architecture**. Este servicio está diseñado para manejar el catálogo de vehículos, información técnica, disponibilidad y operaciones relacionadas con la flota vehicular.

## 🛠️ Stack Tecnológico

### 🔧 Tecnologías Utilizadas

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET%209.0-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![OpenAPI](https://img.shields.io/badge/OpenAPI-6BA539?style=for-the-badge&logo=openapi-initiative&logoColor=white)
![REST API](https://img.shields.io/badge/REST%20API-FF6B6B?style=for-the-badge&logo=api&logoColor=white)

### 🗄️ Base de Datos (Planificado)

![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)

### 🐳 DevOps (Futuro)

![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
![Kubernetes](https://img.shields.io/badge/kubernetes-%23326ce5.svg?style=for-the-badge&logo=kubernetes&logoColor=white)

## 🏗️ Arquitectura

El proyecto sigue los principios de **Clean Architecture** y está organizado en las siguientes capas:

```
📁 VehicleServiceEcoF/
├── 🌐 VehicleService.API/          # Capa de presentación (REST API endpoints)
├── 🧠 VehicleService.Application/  # Lógica de aplicación y casos de uso
├── 🎯 VehicleService.Domain/       # Entidades de dominio y reglas de negocio
├── 🔧 VehicleService.Infrastructure/ # Implementaciones técnicas
└── 💾 VehicleService.Persistence/  # Acceso a datos
```

## ✨ Características Planificadas

- 🚗 **Catálogo de Vehículos**: Gestión completa de información vehicular
- 🔍 **Búsqueda Avanzada**: Filtros por marca, modelo, año, tipo, etc.
- 📊 **Estados de Vehículos**: Disponible, en mantenimiento, alquilado, etc.
- 🛠️ **Historial de Mantenimiento**: Registro de servicios y reparaciones
- 📝 **Especificaciones Técnicas**: Detalles completos de cada vehículo
- 🏷️ **Categorización**: Tipos de vehículo (sedán, SUV, camión, etc.)
- 🔄 **API RESTful**: Endpoints claros y documentados
- 📖 **Documentación OpenAPI**: Swagger integrado

## 📡 Endpoints API (En Desarrollo)

### Gestión de Vehículos
```
GET    /api/vehicles          # Listar todos los vehículos
GET    /api/vehicles/{id}     # Obtener vehículo por ID
POST   /api/vehicles          # Crear nuevo vehículo
PUT    /api/vehicles/{id}     # Actualizar vehículo
DELETE /api/vehicles/{id}     # Eliminar vehículo
```

### Búsqueda y Filtros
```
GET    /api/vehicles/search   # Búsqueda con filtros
GET    /api/vehicles/brands   # Listar marcas disponibles
GET    /api/vehicles/models   # Listar modelos por marca
```

### Estados y Disponibilidad
```
GET    /api/vehicles/available     # Vehículos disponibles
PUT    /api/vehicles/{id}/status   # Actualizar estado
GET    /api/vehicles/maintenance   # Vehículos en mantenimiento
```

## 🚀 Inicio Rápido

### Requisitos Previos

![.NET 9](https://img.shields.io/badge/.NET-9.0-purple?style=for-the-badge&logo=.net&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)

### 🛠️ Desarrollo Local

1. **Clona el repositorio**
   ```bash
   git clone https://github.com/Thetander/VehicleServiceEcoF.git
   cd VehicleServiceEcoF
   ```

2. **Restaura los paquetes NuGet**
   ```bash
   dotnet restore
   ```

3. **Ejecuta el proyecto**
   ```bash
   dotnet run --project src/VehicleService.API
   ```

4. **Accede a la documentación API**
   ```
   HTTP:  http://localhost:5231
   HTTPS: https://localhost:7081
   OpenAPI: https://localhost:7081/openapi/v1.json
   ```

### 🧪 Testing

```bash
# Ejecutar todos los tests
dotnet test

# Con cobertura de código
dotnet test --collect:"XPlat Code Coverage"
```

## 🔧 Configuración

### Configuración por Defecto

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Puertos por Defecto

- **5231**: HTTP (desarrollo)
- **7081**: HTTPS (desarrollo)

## 🗄️ Modelo de Datos (Planificado)

### Entidades Principales

```csharp
// Vehículo principal
public class Vehicle
{
    public int Id { get; set; }
    public string Make { get; set; }      // Marca
    public string Model { get; set; }     // Modelo
    public int Year { get; set; }         // Año
    public string VIN { get; set; }       // Número de identificación
    public VehicleType Type { get; set; } // Tipo de vehículo
    public VehicleStatus Status { get; set; } // Estado actual
    // ... más propiedades
}

// Tipos de vehículo
public enum VehicleType
{
    Sedan,
    SUV,
    Truck,
    Van,
    Motorcycle,
    Bus
}

// Estados del vehículo
public enum VehicleStatus
{
    Available,
    Rented,
    Maintenance,
    OutOfService
}
```

## 📊 Roadmap

### ✅ Fase 1 - Fundación (Actual)
- [x] Estructura del proyecto Clean Architecture
- [x] API básica con .NET 9
- [x] Configuración inicial OpenAPI

### 🔄 Fase 2 - Core Features (En Desarrollo)
- [ ] Implementar entidades de dominio
- [ ] Configurar Entity Framework
- [ ] Endpoints CRUD básicos
- [ ] Validaciones de negocio

### 📋 Fase 3 - Features Avanzadas
- [ ] Sistema de búsqueda y filtros
- [ ] Gestión de estados
- [ ] Historial de mantenimiento
- [ ] Integración con AuthService

### 🚀 Fase 4 - Producción
- [ ] Dockerización
- [ ] CI/CD Pipeline
- [ ] Monitoring y Logging
- [ ] Documentación completa

## 📖 Documentación

- **OpenAPI/Swagger**: Disponible en `/openapi/v1.json`
- **Archivo HTTP**: Incluido en `VehicleService.API.http` para testing
- **Arquitectura**: Sigue Clean Architecture principles

## 🛡️ Seguridad (Planificado)

- 🔐 Integración con AuthService para autenticación
- 🛡️ Autorización basada en roles
- ✅ Validación de entrada en todos los endpoints
- 🔍 Auditoría de operaciones críticas

## 🧪 Testing Strategy

### Tipos de Test Planificados
- **Unit Tests**: Lógica de dominio y aplicación
- **Integration Tests**: APIs y base de datos
- **Performance Tests**: Carga y rendimiento
- **Contract Tests**: Interacción con otros servicios

## 🤝 Contribuir

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

### Estándares de Código

- Seguir convenciones de C# y .NET
- Mantener cobertura de tests > 80%
- Documentar APIs con XML comments
- Seguir principios SOLID

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## 👨‍💻 Autor

**Thetander**
- GitHub: [@Thetander](https://github.com/Thetander)

## 🔗 Servicios Relacionados

- 🔐 **AuthService**: Autenticación y autorización
- 💰 **EconomyService**: Gestión financiera y precios
- 📊 **ReportingService**: Reportes y analíticas

## 📞 Soporte

Si tienes alguna pregunta o problema, por favor abre un [issue](https://github.com/Thetander/VehicleServiceEcoF/issues) en GitHub.

---

⭐ **¡No olvides darle una estrella al proyecto si te ha sido útil!** ⭐