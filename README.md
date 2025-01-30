# API TareasCRUD

API RESTful ASP.NET Core Prueba CRUD Tareas Clean Architecture

## **Configuración del entorno**

### **Requisitos previos**
Antes de iniciar, asegúrate de tener instalado lo siguiente:
- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
- [Postman](https://www.postman.com/downloads/) o cualquier cliente API para pruebas
- [Git](https://git-scm.com/) (opcional)

### **Configuración del proyecto**
1. Clona el repositorio:
   ```bash
   git clone https://github.com/nosferak/APITareasCRUD.git
   cd sistema-pedidos
2.  Configura la cadena de conexión en el archivo appsettings.json del proyecto TareasCRUD.WebAPI:
    ```json
    {"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=DBTareas;Trusted_Connection=True;TrustServerCertificate=True;"}}

### **Instrucciones para ejecutar la APIo**
1. Restaura los paquetes NuGet:
   ```bash
   dotnet restore

2. Genera y aplica las migraciones de EF Core:
   ```bash
   dotnet ef migrations add InitialCreate --project TareasCRUD.Infrastructure --startup-project TareasCRUD.WebApi
   dotnet ef database update --project TareasCRUD.Infrastructure --startup-project TareasCRUD.WebApi

3. Ejecuta la API:
   ```bash
   dotnet run 

 4. Accede a la documentación de Swagger:
   - Navega a https://localhost:5001/swagger para explorar y probar los endpoints.

    
