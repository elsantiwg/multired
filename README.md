
Este repositorio contiene un proyecto completo en .NET Core MVC que implementa un sistema de inventario avanzado llamado "Multired". El sistema gestiona inventarios, usuarios con diferentes niveles de permisos, integración con base de datos relacional, funcionalidades de ventas, búsqueda por fechas, un dashboard con gráficas, exportación de datos en PDF y Excel, búsqueda en tiempo real del inventario, y más. Se utilizan múltiples tecnologías y herramientas modernas para garantizar un desarrollo robusto y eficiente.

Características
Gestión de Usuarios y Permisos: Implementación de roles y permisos para diferentes tipos de usuarios.
Base de Datos Relacional: Utilización de SQL Server para el almacenamiento de datos, gestionado con SQL Server Management Studio (SSMS).
Framework MVC: Desarrollo basado en .NET Core MVC para una estructura clara y modular.
Entity Framework Core: Acceso a la base de datos mediante Entity Framework Core para una gestión de datos eficiente.
Bootstrap: Diseño responsivo y moderno de la interfaz de usuario utilizando Bootstrap.
Firebase: Integración con Firebase para el sistema de correos automáticos, como la recuperación de contraseñas.
Generación de Documentos: Uso de DinkToPdf para generar documentos PDF a partir de HTML.
Seguridad Avanzada: Implementación de Isopoh.Cryptography.Argon2 para el almacenamiento seguro de contraseñas.
NuGet: Gestión de paquetes NuGet para la integración de bibliotecas y herramientas adicionales.
Swagger: Documentación de APIs utilizando Swashbuckle.AspNetCore para una documentación interactiva.
Estructura del Proyecto
BLL/: Capa de lógica de negocio (Business Logic Layer).
Contiene los servicios y lógica de aplicación.
DAL/: Capa de acceso a datos (Data Access Layer).
Contiene los repositorios y contexto de base de datos.
Entity/: Entidades del dominio y modelos de datos.
IOC/: Configuración de Inversión de Control (Inversion of Control).
Configuración de servicios y dependencias.
Controllers/: Controladores que manejan las solicitudes HTTP y la lógica de negocio.
Views/: Vistas HTML que renderizan la interfaz de usuario utilizando Razor syntax.
wwwroot/: Archivos estáticos como CSS, JavaScript y archivos para exportación de documentos.
Scripts/: Scripts SQL y otros scripts necesarios para la configuración de la base de datos.
Startup.cs: Configuración inicial y configuración de servicios para la aplicación MVC.
Objetivos del Proyecto
Desarrollo Eficiente: Utilización de tecnologías modernas y buenas prácticas para un desarrollo ágil y robusto.
Mejora de la Experiencia del Usuario: Implementación de una interfaz de usuario intuitiva y responsiva.
Seguridad: Garantía de seguridad en la gestión de usuarios y datos sensibles.
Flexibilidad y Escalabilidad: Diseño modular que permite la expansión y mantenimiento sencillo del sistema.
