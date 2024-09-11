# API Libros y Autores

API REST para gestionar libros y autores (Prueba técnica), desarrollada en **ASP.NET Core Web API**.

## Tecnologías

- .NET 8.0
- Entity Framework Core
- SQL Server
- Swagger

##Querys utilizadas para crear BD

1. Crear base de datos:
   
  CREATE DATABASE LibrosAutoresDB;
  GO
  
2. Crear tabla Autores:

  USE LibrosAutoresDB;
GO

CREATE TABLE Autores (
    Id INT IDENTITY(1,1) PRIMARY KEY, 
    Rut NVARCHAR(12) NOT NULL UNIQUE, 
    NombreCompleto NVARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    CiudadProcedencia NVARCHAR(50),
    CorreoElectronico NVARCHAR(100) NOT NULL
);
GO

3. Crear tabla Libros

CREATE TABLE Libros (
    Id INT IDENTITY(1,1) PRIMARY KEY, 
    Titulo NVARCHAR(200) NOT NULL,
    Año INT NOT NULL,
    Genero NVARCHAR(50) NOT NULL,
    NumeroPaginas INT NOT NULL,
    AutorId INT NOT NULL,             
    FOREIGN KEY (AutorId) REFERENCES Autores(Id) ON DELETE CASCADE
);
GO


   
## Instalación

1. Clona este repositorio:

    ```bash
    git clone https://github.com/HuguitoS2r/BackendLibroAutorNet.git   
    ```

2. Navega al directorio del proyecto:

    ```bash
    cd nombre-del-proyecto
    ```

3. Restaura las dependencias:

    ```bash
    dotnet restore
    ```

4. Configura la cadena de conexión en **`appsettings.json`**:

    ```json
    "ConnectionStrings": {
      "cadenaSQL": "Server=localhost;Database=LibrosAutoresDB;Trusted_Connection=True;"
    }
    ```

5. Aplica las migraciones para crear la base de datos:

    ```bash
    dotnet ef database update
    ```

## Ejecución

1. Ejecuta la aplicación:

    ```bash
    dotnet run
    ```

2. La API estará disponible en: `http://localhost:5062`

3. Documentación Swagger: `http://localhost:5062/swagger/index.html`

## Rutas de la API

- **POST /api/Autor**: Registrar un autor.
- **POST /api/Libro**: Registrar un libro.
- **GET /api/Libro**: Buscar libros.

Se adjuntan imágenes del backend funcionando y cumpliendo con los requerimientos: ![testAutorSwagger](https://github.com/user-attachments/assets/cb98e82f-d33b-4524-8b02-36b598e3c51d)
![SelectLibros](https://github.com/user-attachments/assets/40fb6881-214e-463a-b2fa-c42dca5106bd)
![SelectAutores](https://github.com/user-attachments/assets/b061f61a-9b9a-47bb-8de7-9b4f756d70d3)
![LibroRegistrado](https://github.com/user-attachments/assets/2a3195a2-2cf4-4147-99b3-1321967416be)
![IndexAPIs](https://github.com/user-attachments/assets/50b79a07-eee1-4079-9de7-2f6981bfbf79)
![ErrorMax](https://github.com/user-attachments/assets/8aa97ed4-02ab-453a-a909-3b052414e712)
![AutorNoRegistrado](https://github.com/user-attachments/assets/fcd691d3-0d6a-47f5-aa36-1be0e55c359e)

