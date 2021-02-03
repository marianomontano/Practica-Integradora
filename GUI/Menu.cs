using System;
using System.Windows.Forms;
using Autofac;
using Servicios;

namespace GUI
{
    public partial class Menu : Form
    {
        private int childFormNumber = 0;

        public Menu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var container = ContainerConfig.Configurar();
            using (var scope = container.BeginLifetimeScope())
            {
                var form = scope.Resolve<FormProductos>();
                form.MdiParent = this;
                form.Show();
            }
        }
    }
}
