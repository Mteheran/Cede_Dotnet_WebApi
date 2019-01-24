using Cede_Dotnet_WebApi.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cede_Dotnet_WebApi.ADOSample.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // from ADO
            //dataGridView1.DataSource = DepartamentoData.GetDepartamentos();

            //from EF
            dataGridView1.DataSource =  DepartamentoEF.GetDepartamentos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           bool result = DepartamentoData.InsertDepartamento(new Models.Departamento() { Nombre = txtNombre.Text });

            if (!result)
            {
                MessageBox.Show("Error al guardar");
            }
            else
            {
                txtNombre.Text = string.Empty;
                dataGridView1.DataSource = DepartamentoData.GetDepartamentos();
            }    

        }
    }
}
