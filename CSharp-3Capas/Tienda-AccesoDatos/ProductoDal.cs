using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Tienda_Entidades;

namespace Tienda_AccesoDatos
{
    public class ProductoDAL
    {
        //Primero y siguiendo el orden de las acciones CRUD
        //Crearemos un Método que se encarga de insertar un nuevo Producto es nuestra tabla Producto
        /// <summary>
        /// Inserta un nuevo Producto en la tabla Producto
        /// </summary>
        /// <param name="producto">Entidad contenedora de los valores a insertar</param>
        /// <autor>José Luis García Bautista</autor>
        public void Insert(EProducto producto)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            //using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxString"].ToString()))
            SqlConnection cnx = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
            {
                cnx.Open();
                //Declaramos nuestra consulta de Acción Sql parametrizada
                const string sqlQuery= "INSERT INTO Producto (Id, Descripcion, Marca, Precio) VALUES (@Id, @descripcion, @marca, @precio)";
                SqlCommand cmd = new SqlCommand(sqlQuery, cnx);
                {
                    //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                    //ya no leeremos controles sino usaremos las propiedades del Objeto EProducto de nuestra capa
                    //de entidades...
                    cmd.Parameters.AddWithValue("@Id", producto.Id);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista de Productos ordenados por el campo Id de manera Ascendente
        /// </summary>
        /// <returns>Lista de productos</returns>
        /// <autor>José Luis García Bautista</autor>
        public List<EProducto> GetAll()
        {
            //Declaramos una lista del objeto EProducto la cual será la encargada de
            //regresar una colección de los elementos que se obtengan de la BD
            //
            //La lista substituye a DataTable utilizado en el proyecto de ejemplo
            List<EProducto> productos = new List<EProducto>();
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            //using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxString"].ToString()))
            SqlConnection cnx = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
            {
                cnx.Open();

                const string sqlQuery = "SELECT * FROM Producto ORDER BY Id ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    //
                    //Preguntamos si el DataReader fue devuelto con datos
                    while (dataReader.Read())
                    {
                        //
                        //Instanciamos al objeto Eproducto para llenar sus propiedades
                        EProducto producto = new EProducto
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"]),
                            Marca = Convert.ToString(dataReader["Marca"]),
                            Precio = Convert.ToDecimal(dataReader["Precio"])
                        };
                        //
                        //Insertamos el objeto Producto dentro de la lista Productos
                        productos.Add(producto);
                    }
                }
            }
            return productos;
        }

        /// <summary>
        /// Devuelve un Objeto Producto
        /// </summary>
        /// <param name="idProducto">Id del producto a buscar</param>
        /// <returns>Un registro con los valores del Producto</returns>
        /// <autor>José Luis García Bautista</autor>
        public EProducto GetByid(int idProducto)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            SqlConnection cnx = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
            //using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxString"].ToString()))
            {
                cnx.Open();

                const string sqlGetById = "SELECT * FROM Producto WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlGetById, cnx))
                {
                    //
                    //Utilizamos el valor del parámetro idProducto para enviarlo al parámetro declarado en la consulta
                    //de selección SQL
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        EProducto producto = new EProducto
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Descripcion = Convert.ToString(dataReader["Descripcion"]),
                            Marca = Convert.ToString(dataReader["Marca"]),
                            Precio = Convert.ToDecimal(dataReader["Precio"])
                        };

                        return producto;//el producto ya existe
                    }
                }
            }

            return null; //No existe el producto
        }

        /// <summary>
        /// Actualiza el Producto correspondiente al Id proporcionado
        /// </summary>
        /// <param name="producto">Valores utilizados para hacer el Update al registro</param>
        /// <autor>José Luis García Bautista</autor>
        public void Update(EProducto producto)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            //using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxString"].ToString()))
            SqlConnection cnx = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
            {
                cnx.Open();
                const string sqlQuery =
                    "UPDATE Producto SET Descripcion = @descripcion, Marca = @marca, Precio = @precio WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@id", producto.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>
        /// <param name="idproducto">Id del registro a Eliminar</param>
        /// <autor>José Luis García Bautista</autor>
        public void Delete(int idproducto)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            //using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxString"].ToString()))
            SqlConnection cnx = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
            {
                cnx.Open();
                const string sqlQuery = "DELETE FROM Producto WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", idproducto);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

