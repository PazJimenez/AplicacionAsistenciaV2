# Aplicación de Asistencia de Empleados

![C#](https://img.shields.io/badge/C%23-Language-green)
![.NET](https://img.shields.io/badge/.NET%20Framework-4.7.2-blueviolet)
![WinForms](https://img.shields.io/badge/Windows%20Forms-Desktop-blue)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-red)
![NUnit](https://img.shields.io/badge/NUnit-Test%20Structure-lightgrey)

## 📌 Descripción
Aplicación de escritorio desarrollada como proyecto académico, orientada a la gestión de asistencia de empleados.  
Permite autenticar usuarios, registrar entradas y salidas, administrar empleados y generar reportes de asistencia con opción de exportación a Excel.

El proyecto fue desarrollado en **Visual Studio 2022**, utilizando **C# y .NET Framework 4.7.2**, como parte de la asignatura **Integración II**.

---

## 🧭 Flujo general de la aplicación

1. **Inicio de la aplicación**
   - El usuario accede a la aplicación y se muestra la pantalla de inicio de sesión.
   - Debe ingresar su **ID y contraseña**, los cuales son validados contra la base de datos.
   - Si el ID es incorrecto, el sistema informa el error.
   - Si la contraseña es incorrecta, se notifica al usuario.
   - Al ingresar credenciales válidas, el usuario accede al sistema.

2. **Registro de asistencia**
   - Tras el inicio de sesión, se muestra la vista principal de asistencia.
   - El usuario puede:
     - Marcar **entrada**
     - Marcar **salida**
   - El sistema registra automáticamente la fecha y hora del evento.
   - La vista incluye un reloj visible en pantalla.

3. **Gestión de empleados**
   - A través de una segunda pestaña, se accede a la gestión de empleados.
   - Se muestra un formulario para:
     - Crear nuevos empleados
     - Modificar empleados existentes
   - En la parte inferior se visualiza una tabla con todos los empleados registrados.
   - Al hacer doble clic sobre un empleado, sus datos se cargan automáticamente en el formulario, facilitando su edición.

4. **Generación de reportes**
   - En la tercera pestaña, el usuario puede generar reportes de asistencia.
   - El sistema permite seleccionar:
     - Tipo de reporte (general, inasistencia, atraso o salida adelantada)
     - RUT específico o todos los empleados
     - Rango de fechas (fecha de inicio y término)
   - Los resultados se muestran en una tabla.
   - El reporte puede **exportarse a Excel**.

---

## 🛠️ Tecnologías utilizadas
- C#
- .NET Framework 4.7.2
- Windows Forms
- Entity Framework
- Microsoft SQL Server
- Visual Studio 2022
- NUnit (estructura de pruebas unitarias)
- Exportación de reportes a Excel

---

## 🔐 Funcionalidades principales

### 🔑 Autenticación
- Inicio de sesión mediante **ID y contraseña**
- Control de acceso a las funcionalidades del sistema

---

### ⏱️ Registro de asistencia
- Vista para **marcar entrada y salida** de empleados
- Registro de fechas y horas de asistencia

---

### 👥 Gestión de empleados
- Crear nuevos empleados
- Modificar información de empleados existentes
- Visualización de empleados en **tablas de datos**

---

### 📊 Reportes de asistencia
- Generación de informes por:
  - Asistencia general
  - Atrasos
  - Salidas adelantadas
  - Inasistencias
- Filtros por:
  - RUT específico
  - Todos los empleados
- Visualización de resultados en **tablas**
- **Exportación de reportes a Excel**

---

## 📂 Estructura general del proyecto
- 'Controller': lógica de negocio y controladores
- 'Model': entidades y acceso a datos
- 'View': formularios y vistas de la aplicación
- Proyecto de pruebas con NUnit
- Configuración y dependencias administradas por Visual Studio

---

## 🗄️ Base de datos
La aplicación utiliza **Microsoft SQL Server** como sistema de base de datos para el almacenamiento de la información de empleados y registros de asistencia.

---

## 🧪 Pruebas
El proyecto incluye una estructura de pruebas unitarias utilizando **NUnit**.  
No obstante, estas pruebas no se encuentran completamente operativas debido a incompatibilidades entre la versión del framework y el entorno de desarrollo actual.

La estructura se mantiene con fines académicos.

---

## 🚧 Estado del proyecto
Proyecto académico **finalizado**.  
Actualmente no se encuentra en desarrollo activo.

---

## ℹ️ Notas
- El proyecto fue desarrollado hace un tiempo y puede requerir ajustes para ejecutarse en entornos actuales.
- La configuración de la base de datos puede necesitar adaptación según el entorno local.

---

## 🖼️ Capturas de pantalla

### Login
![Login](docs/images/Login.png)

### Registro de asistencia
![Asistencia](docs/images/Marcar_Asistencia.png)

### Gestión de empleados
![Empleados](docs/images/Crear_usuario.png)

### Reportes
![Reportes](docs/images/Reportes.png)

---

## 👤 Autor
Andrea Paz
