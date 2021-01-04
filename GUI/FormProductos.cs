using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BE;
using BLL;

namespace GUI
{
    public partial class FormProductos : Form
    {
        public FormProductos(IBLLProducto _Producto)
        {
            Producto = _Producto;
            InitializeComponent();
        }

        IBLLProducto Producto;
        EntidadProducto entidadProducto;

        private void limpiar()
        {
            txtid.Clear();
            txtnombre.Clear();
            txtnombre.Focus();
            txtprecio.Clear();
            txtstock.Clear();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            actualizargrid();
        }

        private void actualizargrid()
        {
            dgvproductos.DataSource = null;
            dgvproductos.DataSource = Producto.Listar();
        }

        private void dgvproductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dgvproductos.SelectedRows[0].Cells[0].Value.ToString();
            txtnombre.Text = dgvproductos.SelectedRows[0].Cells[1].Value.ToString();
            txtprecio.Text = dgvproductos.SelectedRows[0].Cells[2].Value.ToString();
            txtstock.Text = dgvproductos.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Regex precio = new Regex(@"\d");
            Regex stock = new Regex(@"\d");
            entidadProducto = new EntidadProducto();
            if (!string.IsNullOrEmpty(txtnombre.Text))
            {
                entidadProducto.Nombre = txtnombre.Text;
            }
            if (!string.IsNullOrEmpty(txtprecio.Text) && precio.IsMatch(txtprecio.Text))
            {
                entidadProducto.Precio = float.Parse(txtprecio.Text);
            }
            if (!string.IsNullOrEmpty(txtprecio.Text) && stock.IsMatch(txtprecio.Text))
            {
                entidadProducto.Stock = int.Parse(txtstock.Text);
            }
            Producto.Crear(entidadProducto);
            limpiar();
            actualizargrid();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Regex precio = new Regex(@"\d");
            Regex stock = new Regex(@"\d");
            entidadProducto = new EntidadProducto();

            if (dgvproductos.SelectedRows.Count > 0)
            {
                entidadProducto.Id = int.Parse(txtid.Text);

                if (!string.IsNullOrEmpty(txtnombre.Text))
                {
                    entidadProducto.Nombre = txtnombre.Text;
                }
                if (!string.IsNullOrEmpty(txtprecio.Text) && precio.IsMatch(txtprecio.Text))
                {
                    entidadProducto.Precio = float.Parse(txtprecio.Text);
                }
                if (!string.IsNullOrEmpty(txtprecio.Text) && stock.IsMatch(txtprecio.Text))
                {
                    entidadProducto.Stock = int.Parse(txtstock.Text);
                }
                Producto.Editar(entidadProducto);
            }
            else
                MessageBox.Show("Seleccione un producto de la grilla");
            limpiar();
            actualizargrid();
            entidadProducto = null;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            entidadProducto = new EntidadProducto();
            if(dgvproductos.SelectedRows.Count > 0)
            {
                entidadProducto.Id = int.Parse(txtid.Text);
            }
            Producto.Eliminar(entidadProducto);
            limpiar();
            actualizargrid();
            entidadProducto = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            actualizargrid();
        }

        private void btnprimero_Click(object sender, EventArgs e)
        {
            dgvproductos.DataSource = null;
            dgvproductos.DataSource = Producto.MostrarPrimero();
        }

        private void btnultimo_Click(object sender, EventArgs e)
        {
            dgvproductos.DataSource = null;
            dgvproductos.DataSource = Producto.MostrarUltimo();
        }
    }
}
