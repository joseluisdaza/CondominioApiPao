# Guía de Migraciones - Condominio.API.Repository

## Configuración inicial

### 1. Instalar herramientas de Entity Framework (si no están instaladas)
```bash
dotnet tool install --global dotnet-ef
```

### 2. Configurar la cadena de conexión
Asegúrate de que tu `appsettings.json` tenga la cadena de conexión configurada:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CondominioDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

## Comandos de Migraciones

### Crear la primera migración
```bash
# Navegar al directorio del proyecto principal (donde está el Startup/Program.cs)
cd Condominio.API

# Crear la migración inicial
dotnet ef migrations add InitialCreate --project ../Condominio.API.Repository --startup-project .
```

### Aplicar migraciones a la base de datos
```bash
# Aplicar todas las migraciones pendientes
dotnet ef database update --project ../Condominio.API.Repository --startup-project .
```

### Comandos adicionales útiles

#### Ver el estado de las migraciones
```bash
dotnet ef migrations list --project ../Condominio.API.Repository --startup-project .
```

#### Crear una nueva migración después de cambios
```bash
dotnet ef migrations add [NombreDeLaMigracion] --project ../Condominio.API.Repository --startup-project .
```

#### Revertir a una migración específica
```bash
dotnet ef database update [NombreDeLaMigracion] --project ../Condominio.API.Repository --startup-project .
```

#### Eliminar la última migración (sin aplicar)
```bash
dotnet ef migrations remove --project ../Condominio.API.Repository --startup-project .
```

#### Generar script SQL
```bash
dotnet ef migrations script --project ../Condominio.API.Repository --startup-project .
```

## Estructura de la Base de Datos

### Tablas que se crearán:

#### PropertyOwners
- `Id` (uniqueidentifier, PK)
- `FirstName` (nvarchar(100), NOT NULL)
- `LastName` (nvarchar(100), NOT NULL)
- `CreatedAt` (datetime2, NOT NULL, DEFAULT GETUTCDATE())
- `UpdatedAt` (datetime2, NULL)

#### Properties
- `Id` (uniqueidentifier, PK)
- `OwnerId` (uniqueidentifier, FK, NOT NULL)
- `LegalId` (nvarchar(50), NOT NULL, UNIQUE)
- `Tower` (nvarchar(50), NOT NULL)
- `Floor` (int, NOT NULL)
- `Code` (nvarchar(10), NOT NULL)
- `CreatedAt` (datetime2, NOT NULL, DEFAULT GETUTCDATE())
- `UpdatedAt` (datetime2, NULL)

### Índices creados:
- `IX_PropertyOwners_FullName` en PropertyOwners (FirstName, LastName)
- `IX_Properties_LegalId` en Properties (LegalId) - UNIQUE
- `IX_Properties_Code` en Properties (Code)
- `IX_Properties_OwnerId` en Properties (OwnerId)

## Notas importantes

1. **Clean Code aplicado**: 
   - Entidades con constructors apropiados
   - Propiedades con valores por defecto
   - Propiedades computadas que no se mapean a la DB
   - Herencia de EntityBase para auditoría

2. **Mejores prácticas de EF Core**:
   - Configuraciones separadas en clases Map
   - Índices para mejorar performance
   - Relaciones con DeleteBehavior configurado
   - Propiedades de auditoría con valores por defecto en SQL

3. **Preparado para migraciones**:
   - DbSets definidos en SqlContext
   - Configuraciones aplicadas automáticamente
   - Esquema definido como constante