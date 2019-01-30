using Cede_Dotnet_MedicalAppointment_EF.Context;
using Cede_Dotnet_MedicalAppointment_EF.Entities;
using Cede_Dotnet_MedicalAppointment_EF.Entities.Enums;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Cede_Dotnet_MedicalAppointment_Test
{
    public partial class Form1 : Form
    {
        MedicalAppointmentContext context { get; set; } = new MedicalAppointmentContext();
        IQueryable<User> Users { get; set; }
        User userSelected { get; set; }


        public Form1()
        {
            InitializeComponent();            

            Users = from u in context.Users
                    where u.UserStatus == UserStatus.Active
                    select u;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillView();

            context.Database.Log = Log;
        }

      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            userSelected = dataGridView1.SelectedRows.Count > 0 ?  (User)dataGridView1.SelectedRows[0]?.DataBoundItem : null;
            FillUser();
        }

        #region Methods

        void Log(string log)
        {
            lstLog.Items.Add(log);
        }

        private void FillView()
        {
            dataGridView1.DataSource = Users.ToList();
        }

        void FillUser()
        {
            txtName.Text = userSelected?.Name;
            txtLastName.Text = userSelected?.LastName;
            txtNit.Text = userSelected?.Nit;
            if (userSelected != null)            
                dtpBirthday.Value = userSelected.BirthDay == DateTime.MinValue ? dtpBirthday.MinDate : userSelected.BirthDay;            
            else
             dtpBirthday.Value = dtpBirthday.MinDate;

            if (userSelected != null)
                dtpNitDate.Value = userSelected.NitDate == DateTime.MinValue ? dtpNitDate.MinDate : userSelected.NitDate;
            else dtpNitDate.Value = dtpNitDate.MinDate;
        }

        void SetUser()
        {
            userSelected = userSelected ?? new User();

            userSelected.Name = txtName.Text;
            userSelected.LastName = txtLastName.Text;
            userSelected.Nit = txtNit.Text;
            userSelected.BirthDay = dtpBirthday.Value;
            userSelected.NitDate = dtpNitDate.Value;
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetUser();

            if (context.Users.Count(u => u.UserId == userSelected.UserId) == 0)
            {
                context.Users.Add(userSelected);
                context.SaveChanges();
            }
            else
            {
                context.Database.ExecuteSqlCommand($@" Update [dbo].[User] SET
                                                       Name = '{userSelected.Name}',
                                                       LastName = '{userSelected.LastName}',
                                                       Nit = '{userSelected.Nit}',
                                                       BirthDay = '{userSelected.BirthDay}',
                                                       NitDate = '{userSelected.NitDate}'         
                                                       WHERE UserId = '{userSelected.UserId}'  ");
            }

            FillView();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            userSelected = new User();

            FillUser();
        }
    }
}
