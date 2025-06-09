using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Hacemos las importaciones del espacio de nombres de los dos proyectos que referenciamos
//observe como esta capa solo referencio a Tienda-LogicNegocio y a Tienda-Entidades
//observe como no se referencia a la clase de acceso a Datos
using Tienda_LogicaNegocio;
using Tienda_Entidades;
using Tienda_LogicaNegocios;

namespace Tienda_Presentacion
{
    public partial class Form1 : Form
    {
        //Creamos las instancias de la clase Eproducto y ProductoBol
        private EProducto _producto;
        private readonly ProductoBol _productoBol = new ProductoBol();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //
        //Creamos los métodos generales llenando y leyendo objetos
        //
        private void Guardar()
        {
            try
            {
                if (_producto == null) _producto = new EProducto();

                _producto.Id = Convert.ToInt32(txtId.Text);
                _producto.Descripcion = txtDescripcion.Text;
                _producto.Marca = txtMarca.Text;
                _producto.Precio = Convert.ToDecimal(txtPrecio.Text);

                _productoBol.Registrar(_producto);

                if (_productoBol.stringBuilder.Length != 0)
                {
                    MessageBox.Show(_productoBol.stringBuilder.ToString(), "Para continuar:");
                }
                else
                {
                    MessageBox.Show("Producto registrado/actualizado con éxito");

                    TraerTodos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void TraerTodos()
        {
            List<EProducto> productos = _productoBol.Todos();

            if (productos.Count > 0)
            {
                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.DataSource = productos;
                dgvDatos.Columns["columnId"].DataPropertyName = "Id";
                dgvDatos.Columns["columnDescripcion"].DataPropertyName = "Descripcion";
                dgvDatos.Columns["columnMarca"].DataPropertyName = "Marca";
                dgvDatos.Columns["columnPrecio"].DataPropertyName = "Precio";
            }
            else
                MessageBox.Show("No existen producto Registrado");
        }

        private void TraerPorId(int id)
        {
            try
            {
                _producto = _productoBol.TraerPorId(id);

                if (_producto != null)
                {
                    txtId.Text = Convert.ToString(_producto.Id);
                    txtDescripcion.Text = _producto.Descripcion;
                    txtMarca.Text = _producto.Marca;
                    txtPrecio.Text = Convert.ToString(_producto.Precio);
                }
                else
                    MessageBox.Show("El Producto solicitado no existe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        private void Eliminar(int id)
        {
            try
            {
                _productoBol.Eliminar(id);

                MessageBox.Show("Producto eliminado satisfactoriamente");

                TraerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error inesperado");
            }
        }

        //
        //
        //Usamos nuestros metodos y funciones generales, observe como no hemos repetido codigo en ningun lado
        //haciendo con esto que nuestras tareas de actualizacion sean mas sencillas para nosotros o para
        //al asignado en realizarlas...
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && !string.IsNullOrWhiteSpace(txtId.Text))
            {
                e.SuppressKeyPress = true;

                TraerPorId(Convert.ToInt32(txtId.Text));
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                Guardar();
            }
        }

        

        

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtId.Text))
            {
                TraerPorId(Convert.ToInt32(txtId.Text));
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtId.Text))
            {
                Eliminar(Convert.ToInt32(txtId.Text));
            }
        }
    }
}