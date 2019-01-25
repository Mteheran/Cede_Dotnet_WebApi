using Cede_Dotnet_MedicalAppointment_EF.Context;
using Cede_Dotnet_MedicalAppointment_EF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cede_Dotnet_MedicalAppointment_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var context = new MedicalAppointmentContext();
            dataGridView1.DataSource = context.Users.Where(p=> p.Genre == Genre.Male).ToList();
        }
    }
}
