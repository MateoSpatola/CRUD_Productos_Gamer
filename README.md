# CRUD - Productos Gamer
### ● Resumen de la Aplicación:
La aplicación es una herramienta para la gestión de productos relacionados con el mundo gamer, como monitores, teclados y mouses.
Está conectada a una base de datos (SQL Server), en la cual se guardan los productos en tiempo real, con la posibilidad de modificar o eliminar dichos productos.
Ademas, segun el usuario que inicie sesión, tendra distintos permisos para utilizar las funcionalidades de la aplicacion (segun los roles: administrador, supervisor, y vendedor).

##### ● Muestra de la aplicación funcionando (formulario principal):
![Muestr Formulario Login](Muestra%20Funcionamiento/Captura_CRUD_Formulario_Principal.png)

##### ● Muestra de la aplicación funcionando (formulario login):
![Muestr Formulario Login](Muestra%20Funcionamiento/Captura_CRUD_Formulario_Login.png)

#### Permite a los usuarios realizar las siguientes acciones:
- Agregar nuevos productos, incluidos monitores, teclados y mouses, proporcionando detalles como nombre, marca, costo y especificaciones adicionales específicas de cada tipo de producto.
- Modificar productos existentes para actualizar su información.
- Eliminar productos del inventario.
- Visualizar la disponibilidad de un producto específico.
- Ordenar los productos en el inventario según diferentes criterios, como stock o nombre.
- Cargar un archivo XML (backup) con datos de productos o guardar el inventario actual en un archivo XML (backup).
- Visualizar registros de actividad de usuarios.

#### Uso de la Aplicación:
- Al iniciar la aplicación, se muestra una ventana de inicio de sesión donde el usuario debe ingresar su correo y contraseña para acceder.
- Una vez autenticado, el usuario accede a la ventana principal de la aplicación (dependiendo del tipo de usuario tendra distintos permisos).
- En esta ventana, puede realizar las acciones mencionadas anteriormente, como agregar, modificar o eliminar productos, ver disponibilidad, ordenar productos y gestionar archivos de datos (exportar e importar backups en formato xml).
- La aplicación también proporciona información sobre el usuario autenticado y la fecha actual junto con la hora en tiempo real.

### ● Diagrama de clases Generales:
##### ● Entidades:
![Diagrama de clases Entidades](Diagramas%20de%20clases/Diagramas%20Generales/DiagramaDeClaseEntidades.png)

##### ● App:
![Diagrama de clases App](Diagramas%20de%20clases/Diagramas%20Generales/DiagramaDeClaseApp.png)

##### ● BibliotecaExcepciones:
![Diagrama de clases Biblioteca Excepciones](Diagramas%20de%20clases/Diagramas%20Generales/DiagramaDeClaseBibliotecaExcepciones.png)

##### ● Testing:
![Diagrama de clases Testing](Diagramas%20de%20clases/Diagramas%20Generales/DiagramaDeClaseTesting.png)

### ● Diagrama de clases Individuales (para mejor visualizacion):
##### ● Entidades:
![Diagrama ProductoGamer](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20Entidades/DiagramaProductoGamer.png)
![Diagrama Monitor](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20Entidades/DiagramaMonitor.png)
![Diagrama Mouse](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20Entidades/DiagramaMouse.png)
![Diagrama Teclado](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20Entidades/DiagramaTeclado.png)
![Diagrama Inventario](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20Entidades/DiagramaInventario.png)
![Diagrama Acceso Inventario](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20Entidades/DiagramaAccesoInventario.png)
![Diagrama Delegados](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20Entidades/DiagramaDelegados.png)
![Diagrama Enumerados](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20Entidades/DiagramaEnumerados.png)
![Diagrama Interfaces](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20Entidades/DiagramaInterfaces.png)
![Diagrama ProductoEventArgs](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20Entidades/DiagramaProductoEventArgs.png)

##### ● App:
![Diagrama FrmLogin](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20App/DiagramaFrmLogin.png)
![Diagrama Usuario](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20App/DiagramaUsuario.png)
![Diagrama FrmPrincipal](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20App/DiagramaFrmPrincipal.png)
![Diagrama FrmProducto](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20App/DiagramaFrmProducto.png)
![Diagrama FrmMonitor](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20App/DiagramaFrmMonitor.png)
![Diagrama FrmMouse](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20App/DiagramaFrmMouse.png)
![Diagrama FrmTeclado](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20App/DiagramaFrmTeclado.png)
![Diagrama FrmVisualizadorLog](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20App/DiagramaFrmVisualizadorLog.png)
![Diagrama Resources](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20App/DiagramaResources.png)
![Diagrama Program](Diagramas%20de%20clases/Diagramas%20Individuales/Diagramas%20App/DiagramaProgram.png)

El diagrama de clases representa la lógica de negocio de la aplicación. Ha sido creado con la herramienta del Visual Studio y está actualizado a la última versión entregada de la solución. Muestra la estructura y las relaciones entre las clases que componen la aplicación, lo que facilita la comprensión de su funcionamiento interno.
