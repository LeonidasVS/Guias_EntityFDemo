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
            LlenarCampos(cliente);

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var cliente = crearCleinte();

            var resultado = customerRepo.InsertarClientes(cliente);

            if (resultado>0)
            {
                MessageBox.Show("Cliente Insertado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Customers crearCleinte()
        {
            var cliente = new Customers() { 
            
                CustomerID=txtCustomerID.Text,
                CompanyName = txtCompanyName.Text,
                ContactName=txtContactName.Text,
                ContactTitle=txtContactTitle.Text,
                Address=txtAddress.Text,
            };

            return cliente;
        }
        private void LlenarCampos(Customers customer)
        {

            if (customer!=null)
            {
                txtCustomerID.Text = customer.CustomerID;
                txtCompanyName.Text = customer.CompanyName;
                txtContactName.Text = customer.ContactName;
                txtContactTitle.Text = customer.ContactTitle;
                txtAddress.Text = customer.Address;
            }
            else
            {
                MessageBox.Show("Cliente no encontrado");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var clienteUpdate = crearCleinte();

            var resultado = customerRepo.UpdateCliente(clienteUpdate);

            if (resultado>0)
            {
                MessageBox.Show("Cliente Actualizado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                List<Customers> cliente = new List<Customers>
                {
                    clienteUpdate
                };

                dataGridView1.DataSource = cliente;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            var eliminados = customerRepo.ELiminarCLiente(txtCustomerID.Text);

            if (eliminados>0)
            {
                MessageBox.Show("Cliente Eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
