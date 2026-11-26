using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormUI.Utils;

namespace WinFormUI
{
    public partial class FrmMain : Form
    {
        private Form _activeForm = null;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load_1(object sender, EventArgs e)
        {
            this.CenterToScreen();

            if (SessionManager.IsLoggedIn)
                lblCurrentUser.Text = $"Logged in as: {SessionManager.CurrentUser.UserName} ({SessionManager.CurrentUser.Role})";

            OpenChildForm(new FrmItemManagement());
        }

        private void OpenChildForm(Form childForm)
        {
            foreach (var oldForm in pnlContent.Controls.OfType<Form>().ToList())
            {
                oldForm.Close();
                oldForm.Dispose();
            }

            pnlContent.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void mnuItems_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmItemManagement());
        }


        private void mnuAgents_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmAgentManagement());
        }

        private void mnuOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmOrderManagement());
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to log out?", "Confirm", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                SessionManager.Clear();
                this.Close();
            }
        }

        private void mnuDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmDashboard());
        }
        private void lblCurrentUser_Click(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
