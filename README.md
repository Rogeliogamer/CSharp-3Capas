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
    <ol>
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
