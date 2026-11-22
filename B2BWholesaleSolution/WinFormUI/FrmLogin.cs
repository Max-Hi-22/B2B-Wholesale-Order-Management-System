using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Services;
using WinFormUI.Utils;

namespace WinFormUI
{
    public partial class FrmLogin : Form
    {
        private readonly AuthService _authService;

        public FrmLogin()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                btnLogin.Enabled = false; // Disable the button to prevent multiple clicks
                Cursor = Cursors.WaitCursor;

                var adminUser = _authService.LoginAdmin(txtUsername.Text, txtPassword.Text);

                SessionManager.CurrentUser = adminUser;

                MessageBox.Show(
                    $"Login successfully! Hello {adminUser.UserName}",
                    "Notification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Hide();
                //using (var frmMain = new FrmMain())
                //{
                //    frmMain.ShowDialog();
                //}

                if (!SessionManager.IsLoggedIn)
                {
                    txtPassword.Clear();
                    this.Show();
                    txtUsername.Focus();
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message, "Miss information", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    ex.Message, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                txtPassword.Clear();
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "System Error: " + ex.Message, "Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
            finally
            {
                btnLogin.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
