using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
//Hacemos las importaciones del espacio de nombres de los dos proyectos que referenciamos
//observe como esta capa solo referencio a Tienda-AccessData y no a Tienda-Presentacion
//observe también como aquí no es requerida la referencia a System.Data.SqlServerCe
using Tienda_AccesoDatos;
using Tienda_Entidades;
namespace Tienda_LogicaNegocios
{
    public class ProductoBol
    {
        //Instanciamos nuestra clase ProductoDal para poder utilizar sus miembros
        private ProductoDAL _productoDal = new ProductoDAL();
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //
        //Creamos nuestro método para Insertar un nuevo Producto, observe como este método tampoco valida los el contenido
        //de las propiedades, sino que manda a llamar a una Función que tiene como tarea única hacer esta validación
        //
        public void Registrar(EProducto producto)
        {
            if (ValidarProducto(producto))
            {
                if (_productoDal.GetByid(producto.Id) == null)
                {
                    _productoDal.Insert(producto);
                }
                else
                    _productoDal.Update(producto);

            }
        }

        public List<EProducto> Todos()
        {
            return _productoDal.GetAll();
        }

        public EProducto TraerPorId(int idProduct)
        {
            stringBuilder.Clear();

            if (idProduct == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _productoDal.GetByid(idProduct);
            }
            return null;
        }

        public void Eliminar(int idProduct)
        {
            stringBuilder.Clear();

            if (idProduct == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _productoDal.Delete(idProduct);
            }
        }

        private bool ValidarProducto(EProducto producto)
        {
            stringBuilder.Clear();

            if (string.IsNullOrEmpty(producto.Descripcion)) stringBuilder.Append("El campo Descripción es obligatorio");
            if (string.IsNullOrEmpty(producto.Marca)) stringBuilder.Append(Environment.NewLine + "El campo Marca es obligatorio");
            if (producto.Precio <= 0) stringBuilder.Append(Environment.NewLine + "El campo Precio es obligatorio");

            return stringBuilder.Length == 0;
        }
    }
}
