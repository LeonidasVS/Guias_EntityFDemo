using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CustomerRepository customerRepo = new CustomerRepository();
        private void btnObtener_Click(object sender, EventArgs e)
        {
            var cliente = customerRepo.ObtenerTodos();

            dataGridView1.DataSource = cliente;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cliente = customerRepo.ObtenerPorID(txtBuscador.Text);
            List<Customers> listado = new List<Customers>
            {
                cliente
            };

            dataGridView1.DataSource = listado;

        }
    }
}
