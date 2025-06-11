<!--Titulo principal-->
<div id="user-content-toc">
  <ul align="center">
    <summary>
      <!--Titulo-->
      <h2 style="display: inline-bloc">CSharp-3Capas</h2>
      <br>
      <!--Divizor horizontal (gradiant)-->
      <img src="https://user-images.githubusercontent.com/73097560/115834477-dbab4500-a447-11eb-908a-139a6edaec5c.gif">
    </summary>
  </ul>
</div>

<div id="user-content-toc">
  <!--Caso de estudio-->
  <h3 align="center">Objetivo</h3>
  <p align="justify">
    Desarrollar proyecto bajo la arquitectura de tres capas -capa de presentación, capa de negocio y capa de acceso a datos-. 
  </p>
</div>

<div id="user-content-toc">
  <!--Caso de estudio-->
  <h3 align="center">Herramienta para utilizar</h3>
  <p align="justify">
    Visual Studio C# .NET y SQL Server
  </p>
</div>

<div>
  <!--Caso de estudio-->
  <div>
    <p>
      <h3 align="center">Instalación de Visual Studio .NET  2019 y de MicroSoft SQL Server</h3>
    </p>
    <ol>
      <li>Descargar e instalar el software Visual Studio .NET 2019/2022</li>
      <li>Descargar el instalar el software Microsoft SQL Server</li>
    </ol>
  </div>
</div>

<div>
  <!--Caso de estudio-->
  <div>
    <p>
      <h3 align="center">Creación Proyecto Vacío del tipo Windows Form y tres proyectos adicionales del tipo Biblioteca de Clases.</h3>
    </p>
    <ol>
      <li>Abrir Visual Studio .NET 2019/2022 y crear un proyecto vacío con el nombre de  “CSharp-3Capas”.</li>
      <pre><code>Create a New Project->Empty Project (.NET Framework)</code></pre>
      <pre><code>Proyect name: CSharp-3Capas 
Location: especificar carpeta para guardar el proyecto</code></pre>
      <p>Primera Capa:</p>
      <li>Ir al “Explorador de soluciones” (panel derecho) y hacer clic derecho sobre el proyecto que acabamos de crear “Solution ‘CSharp-3Capas’”.</li>
      <li>Del menú desplegable seleccionar Add->New Project->Windows Form App (.NET Framework)</li>
      <li>En el campo Nombre escribir “Tienda-Presentacion” y presionar el botón “Crear”.</li>
      <p><br>Segunda Capa:</p>
      <li>Ir al “Explorador de soluciones” y hacer clic derecho sobre el proyecto que acabamos de crear “Solution ‘CSharp-3Capas’”.</li>
      <li>Del menú desplegable seleccionar Add->New Project->Windows Form Control Library (.NET Framework)</li>
      <li>En el campo Nombre escribir “Tienda-LogicaNegocio” y presionar el botón “Crear”.</li>
      <p><br>Tercera Capa:</p>
      <li>Ir al “Explorador de soluciones” y hacer clic derecho sobre el proyecto que acabamos de crear “Solution ‘CSharp-3Capas’”.</li>
      <li>Del menú desplegable seleccionar Add->New Project->Windows Form Control Library (.NET Framework)</li>
      <li>En el campo Nombre escribir “Tienda-AccesoDatos” y presionar el botón “Crear”.</li>
      <p><br>Entidades:</p>
      <li>Ir al “Explorador de soluciones” y hacer clic derecho sobre el proyecto que acabamos de crear “Solution ‘CSharp-3Capas’”.</li>
      <li>Del menú desplegable seleccionar Add->New Project->Windows Form Control Library (.NET Framework)</li>
      <li>En el campo Nombre escribir “Tienda-Entidades” y presionar el botón “Crear”.</li>
      <p><br>Indicar cuál será el Proyecto Ejecutable:</p>
      <li>Clic derecho sobre el proyecto “TiendaPresentacion” del paso 4 y del menú desplegable elegir “Set as StartUp Project”, para indicar la ejecución del proyecto.</li>
      <p><br>Eliminar Proyecto Vacío:</p>
      <li>Eliminar el proyecto vacío que se creó en el paso 1, ya que solo se utilizó para crear los proyectos adicionales. Clic sobre “ProjectCSharp-3Capas” (que está debajo de “Solution ‘CSharp-3Capas’”), clic derecho y elegir “Remove” y botón aceptar.</li>
    </ol>
  </div>
</div>

<div>
  <!--Caso de estudio-->
  <div>
    <p>
      <h3 align="center">Capa de Entidades</h3>
    </p>
    <p>La Capa Entidades contendrá un objeto llamado Producto con 5 propiedades publicas cada uno de ellos respetando el tipo de dato con el cual estará declarado en la base de datos. </p>
    <pre><code>Nota: Si tuviéramos más tablas en nuestra base de datos tendríamos que crear la misma cantidad de objetos en nuestra capa de Entidades y dentro contendrían la misma cantidad de propiedades como campos tiene la tabla siempre respetando el tipo de dato con lo que estos campos están declarados.</code></pre>
    <ol start="16">
      <li>Ir al proyecto “Tienda-Entidades” para agregar una nueva clase llamada “EProducto”</li>
      <pre><code>Clic derecho sobre Tienda-Entidades->Add->Class y en el nombre de la clase poner EProducto.cs y botón “Add”.</code></pre>
      <li>Con las siguientes líneas de código</li>
      <pre><code>using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
<enter></enter>
namespace Tienda_Entidades 
{ 
    public class EProducto 
    {</code></pre>
    </ol>
  </div>
</div>

[Ver código completo](./CSharp-3Capas/Tienda-Entidades/EProducto.cs)

<div>
  <!--Caso de estudio-->
  <div>
    <p>
      <h3 align="center">Capa de Acceso a Datos</h3>
    </p>
    <p>La base de datos que usaremos contiene una sola tabla llamada “Producto”.</p>
    <ol start="18">
      <p>Crear Base de Datos SQL Server:</p>
      <li>Agregar conexión a la base de datos. Ir al panel superior derecho "Solution Explorer" y dar clic derecho sobre “Tienda-Acceso a Datos”->Add->New Item->Data->Service-based database y en el nombre poner “Database1.mdf” y botón “Add”.</li>
      <li>Agregar la tabla Producto. Clic derecho sobre el archivo Database1.mdf y elegir Open para abrir ventana de “Server Explorer”. Luego clic derecho en Tables->Add New Table y nombre de la tabla Producto con los campos siguientes:</li>
      <pre><code>Id int 
descripcion nvarchar(20) 
marca nvarchar(10) 
precio nvarchar(10)</code></pre>
      <pre><code>Nota: Todos los campos de la tabla deben ser NOT NULL (quitar la palomita de la columna Allow Null).</code></pre>
      <li>Renombrar la tabla default Table”. Ir a la parte inferior de la ventana y poner Producto, para quedar así:</li>
      <pre><code>CREATE TABLE [dbo].[Producto] 
( 
    [Id] INT NOT NULL PRIMARY KEY,  
    [descripcion] NCHAR(20) NOT NULL,  
    [marca] NCHAR(10) NOT NULL,  
    [precio] NCHAR(10) NOT NULL 
)</code></pre>
      <p>Actualizar la base de datos dando clic en “Update” en el lado superior izquierdo de la ventana superior y luego clic en el botón “Update Database” de la ventana emergente.</p>
      <p><br>Archivo de Configuración:</p>
      <li>Agregar un archivo de configuración llamado “App.config” en la capa de acceso a datos que contendrá la cadena de conexión a la base de datos.</li>
      <pre><code>Clic derecho en Tienda-AccesoDatos->Add->General->Application Configuration File y en el nombre del archivo poner “App.config” y botón “Add”.</code></pre>
      <li>Abrir el archivo App.config y copiar las siguientes líneas de código:</li>
      <pre><code>&lt;?xml version="1.0" encoding="utf-8" ?&gt;
&lt;configuration&gt;
  &lt;configSections&gt;
  &lt;/configSections&gt;
  &lt;connectionStrings&gt;
    &lt;add name="cnxString" 
      <enter></enter>
      connectionString="DataSource=(LocalDB)\MSSQLLocalDB;AttachDbFilename= 
      |DataDirectory|\Database1.mdf;Integrated Security=True" 
      providerName="System.Data.SqlClient" /&gt;
  &lt;/connectionStrings&gt;
&lt;/configurationv</code></pre>
    </ol>
  </div>
</div>

<div>
  <!--Caso de estudio-->
  <div>
    <p>Observar que desde los diferentes métodos se hace uso del objeto EProducto declarado en la capa de Entidades. Observar también como la clase ProductosDal no valida que el valor de las propiedades de EProducto contengan datos o sean del tipo de dato correcto porque es trabajo de la capa de lógica de negocio.</p>
    <ol start="23">
      <li>Agregar una nueva clase llamada “ProductoDal”. Para ello clic derecho sobre Tienda-AccesoDatos->Add->Class y en el nombre del archivo poner “ProductoDal.cs” con las líneas de código del anexo 1.</li>
      <li>Agregar referencias a Tienda-Entidades. Para ello clic derecho sobre Tienda-AccesoDatos->Add->Reference->Projects->Solution, enseguida palomear Tienda-Entidades y botón “Ok”.</li>
    </ol>
  </div>
</div>

<div>
  <!--Caso de estudio-->
  <div>
    <p>
      <h3 align="center">Capa Lógica de Negocio</h3>
    </p>
    <p>Analizar cada uno de los métodos y funciones que se crearon en nuestro primer objeto de nuestra capa de negocio, observe:</p>
    <ul>
      <li>Cada uno de ellos tiene una sola responsabilidad.</li>
      <li>La capa de negocio cumple otras tareas y no solo la de ser un puente entre nuestra capa de datos y nuestra capa de presentación.</li>
      <li>Se usan únicamente objetos y no controles, recuerde que esta capa tampoco sabe qué tipo de proyecto es el que la estará usando.</li>
      <li>Observe que en esta capa también se utiliza la capa de entidades.</li>
    </ul>
    <ol start="25">
      <li>Agregar referencias a Tienda-AccesoDatos y Tienda-Entidades. Para ello clic derecho sobre Tienda-LogicaNegocio->Add->Reference->Projects->Solution, enseguida palomear Tienda-AccesoDatos y Tienda-Entidades y botón “Ok”.</li>
      <li>Agregar la clase llamada ‘ProductoBol” haciendo clic derecho sobre Tienda-LogicaNegocio->Add->Class y en el nombre de la clase poner “ProductoBol.cs”; enseguida abrir la clase recién creada para copiar el código del anexo 2.</li>
    </ol>
  </div>
</div>

<div>
  <!--Caso de estudio-->
  <div>
    <p>
      <h3 align="center">Capa de Presentación</h3>
    </p>
    <p>Será la encargada de interactuar con el usuario, la vista de todo nuestro sistema, la encargada de recoger las peticiones del usuario y de pasar esta misma a la capa de Lógica de Negocio, todo lo que el usuario requiera se la solicitará a ésta y todo lo que Lógica de Negocio devuelva ésta se la mostrará al usuario en forma de datos.</p>
    <ol start="27">
      <li>Establecer referencia a Tienda-LogicaNegocio y Tienda-Entidades. Para ello clic derecho sobre Tienda-Presentacion->Add->Reference->Projects->Solution, enseguida palomear Tienda-LogicaNegocio y Tienda-Entidades y botón “Ok”.</li>
      <li>En el formulario llamado “Form1.cs” diseñar una interfaz como se indica el anexo 3.</li>
      <li>Abrir Form1.cs a nivel de código y copiar el código del anexo 4.</li>
      <li>Ejecutar el proyecto haciendo clic “Start” de la parte superior central del ambiente de Visual Studio .NET.</li>
    </ol>
  </div>
</div>

<div>
  <!--Caso de estudio-->
  <div>
    <p>
      <h3 align="center">Modificando la conexión a la base de datos.</h3>
    </p>
    <p>En caso de error en la conexión realizar los siguientes pasos:</p>
    <ol start="31">
      <li>Ir a ventana “Server Explorer” al lado izquierdo de Visual Studio, clic derecho sobre Database1.mdf->Modify Connection y en la ventana elegir botón “Browse” para ir a la carpeta del proyecto</li>
      <pre><code>C:\....\Tienda-AccesoDatos\bin\Debug</code></pre>
      <p>Para elegir el archivo de la base de datos Database1.mdf, ya que en esta subcarpeta ..\bin\Debug es la default.</p>
      <p>Cada vez que se ejecuta el proyecto busca este archivo en el directorio “..bin\debug” justo en la carpeta raíz.</p>
    </ol>
  </div>
</div>
