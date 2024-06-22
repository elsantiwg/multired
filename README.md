# Proyecto Multired: Sistema Avanzado de Inventario

Este repositorio contiene un proyecto completo en .NET Core MVC que implementa el sistema de inventario avanzado "Multired". El sistema ofrece funcionalidades robustas para la gestión de inventarios, usuarios con diferentes niveles de permisos, integración con bases de datos relacionales, funciones de ventas, búsqueda avanzada, generación de reportes en PDF y Excel, dashboard interactivo con gráficas, y más. Utiliza múltiples tecnologías modernas para asegurar un desarrollo eficiente y escalable.

## Características Principales

- **Gestión de Usuarios y Permisos:** Implementación de roles y permisos para diferentes tipos de usuarios.
- **Base de Datos Relacional:** Utilización de SQL Server gestionado con SQL Server Management Studio (SSMS).
- **Framework MVC:** Desarrollo basado en .NET Core MVC para una estructura clara y modular.
- **Entity Framework Core:** Acceso eficiente a la base de datos mediante Entity Framework Core.
- **Bootstrap:** Interfaz de usuario responsiva y moderna utilizando Bootstrap.
- **Integración con Firebase:** Envío de correos automáticos, como recuperación de contraseñas.
- **Generación de Documentos:** Uso de DinkToPdf para generar documentos PDF a partir de HTML.
- **Seguridad Avanzada:** Almacenamiento seguro de contraseñas con Isopoh.Cryptography.Argon2.
- **Gestión de Paquetes NuGet:** Integración de bibliotecas y herramientas adicionales.
- **Documentación de APIs:** Utilización de Swashbuckle.AspNetCore para documentación interactiva con Swagger.

## Estructura del Proyecto

- **BLL/:** Capa de lógica de negocio (Business Logic Layer). Contiene servicios y lógica de aplicación.
- **DAL/:** Capa de acceso a datos (Data Access Layer). Repositorios y contexto de base de datos.
- **Entity/:** Entidades del dominio y modelos de datos.
- **IOC/:** Configuración de Inversión de Control para configuración de servicios y dependencias.
- **Controllers/:** Controladores que manejan solicitudes HTTP y lógica de negocio.
- **Views/:** Vistas HTML que renderizan la interfaz de usuario con Razor syntax.
- **wwwroot/:** Archivos estáticos como CSS, JavaScript y archivos para exportación de documentos.
- **Scripts/:** Scripts SQL y otros para configuración de la base de datos.
- **Startup.cs:** Configuración inicial y servicios para la aplicación MVC.

## Objetivos del Proyecto

- **Desarrollo Eficiente:** Utilización de tecnologías modernas y buenas prácticas para un desarrollo ágil y robusto.
- **Mejora de la Experiencia del Usuario:** Implementación de una interfaz de usuario intuitiva y responsiva.
- **Seguridad:** Garantía de seguridad en la gestión de usuarios y datos sensibles.
- **Flexibilidad y Escalabilidad:** Diseño modular para expansión y mantenimiento sencillo del sistema.

