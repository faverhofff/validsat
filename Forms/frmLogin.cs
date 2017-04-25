using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidSAT.Classes;
using ValidSAT.DataAccess;
using ValidSAT.dialogs;

namespace ValidSAT.forms
{
    public partial class frmLogin : Form
    {
        private Form _mainInstance = null;

        public frmLogin(Form instance)
        {
            InitializeComponent();
            this._mainInstance = instance;
            
            txt_user.onKey += Txt_user_onKey;      
        }

        private void Txt_user_onKey(object sender, Keys codigo)
        {
            if (codigo.Equals(Keys.Enter) || codigo.Equals(Keys.NumPad2) || codigo.Equals(Keys.Down))
                txt_password.Focus();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ingresarButton_MouseEnter(object sender, EventArgs e)
        {
        }

        private void ingresarButton_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void salirButton2MouseEnter(object sender, EventArgs e)
        {
            ingresarButton.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_off;
            salirButton2.BackgroundImage = global::ValidSAT.Properties.Resources.salir_on;
        }

        private void salirButton2MouseLeave(object sender, EventArgs e)
        {
            salirButton2.BackgroundImage = global::ValidSAT.Properties.Resources.salir_off;
        }

        private void _enableIngresarButton()
        {
        }

        private void _validaUsuario()
        {
            if (txt_user.Text.Trim()=="" && txt_password.Text.Trim() == "")
            {
                ValidSAT.Classes.MessageBox.showAdviseModal("Proporcione el Nombre de Usuario y/o Contraseña por favor.");
                txt_user.Focus();
                return;
            }

            if (Global.Instance.connectionState == ConnectionState.Closed)
            {
                ValidSAT.Classes.MessageBox.showAdviseModal("Contacte al personal de ValidSAT. El servidor de base de datos no respode. Gracias");
                txt_user.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                Global.Instance.userLogin = BussinessModel.ValidarUsuarioDeEmpresa(txt_user.Text, txt_password.Text);
            } catch(Exception e)
            {
                ValidSAT.Classes.MessageBox.showAdviseModal("Contacte al personal de ValidSAT. El servidor de base de datos no respode. Gracias");
                this.Show(); this.Focus();
                return;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
            
            if(Global.Instance.userLogin == null)
            {
                Classes.MessageBox.showAdviseModal("Verifique su Nombre de Usario tecleado, no se encuentra, o comuniquese con el personal de ValidSAT. Gracias");
                ingresarButton.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_off;
                txt_user.Focus();
                return;
            }

            Global.Instance.can_Alta = Global.Instance.userLogin.emp_aplicadespachocontable == 1 && BussinessModel.cantidadEmpresasAdministrados(Global.Instance.userLogin.emp_empresa) <= Global.Instance.userLogin.emp_rfcsampara;

            this.Visible = false;
            this._mainInstance.Visible = false;

            frmMainMenu main = new frmMainMenu();
            main.ShowDialog();

        }

        private void txt_password_onKey(object sender, Keys codigo)
        {
            if (codigo.Equals(Keys.Enter) || codigo.Equals(Keys.NumPad2) || codigo.Equals(Keys.Down))
            {
                ingresarButton.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_on;
                ingresarButton.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_on;
                salirButton2.BackgroundImage = global::ValidSAT.Properties.Resources.salir_off;
                ingresarButton.Focus();
            }
            if (codigo.Equals(Keys.Up) || codigo.Equals(Keys.NumPad8))
            {
                txt_user.Focus();
            }
            if (codigo == Keys.Escape)
                Application.Exit();

        }

        private void ingresarButton_MouseEnter_1(object sender, EventArgs e)
        {
            salirButton2.BackgroundImage = global::ValidSAT.Properties.Resources.salir_off;
            ingresarButton.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_on;
        }

        private void ingresarButton_MouseLeave_1(object sender, EventArgs e)
        {
            ingresarButton.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_off;
        }

        private void ingresarButton_Enter(object sender, EventArgs e)
        {
            ingresarButton.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_on;
            salirButton2.BackgroundImage = global::ValidSAT.Properties.Resources.salir_off;
        }

        private void salirButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void salirButton2Enter(object sender, EventArgs e)
        {
            ingresarButton.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_off;
            salirButton2.BackgroundImage = global::ValidSAT.Properties.Resources.salir_on;
        }

        private void ingresarButton2_MouseEnter(object sender, EventArgs e)
        {
        }

        private void ingresarButton2_Enter(object sender, EventArgs e)
        {
            ingresarButton2.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_on;
            salirButton2.BackgroundImage = global::ValidSAT.Properties.Resources.salir_off;
        }

        private void ingresarButton2_leave(object sender, EventArgs e)
        {
            ingresarButton2.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_off;
        }

        private void salirButton2_MouseLeave(object sender, EventArgs e)
        {
            salirButton2.BackgroundImage = global::ValidSAT.Properties.Resources.salir_off;
        }

        private void salirButton_Enter(object sender, EventArgs e)
        {
            salirButton2.BackgroundImage = global::ValidSAT.Properties.Resources.salir_on;
        }

        private void salirButton_Leave(object sender, EventArgs e)
        {
            salirButton2.BackgroundImage = global::ValidSAT.Properties.Resources.salir_off;
        }

        private void ingresarButton_Leave(object sender, EventArgs e)
        {
            ingresarButton2.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_off;
        }

        private void ingresarButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void ingresarButton2_Click(object sender, EventArgs e)
        {
            this._validaUsuario();
        }

        private void ingresarButton_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                this._validaUsuario();

            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        private void salirButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.NumPad2)
                txt_user.Focus();
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.NumPad8)
                txt_password.Focus();
        }

        private void salirButton_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.NumPad2)
                txt_user.Focus();

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.NumPad8)
                txt_user.Focus();

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        private void txt_user_OnPreviewKeyDown(object sender, EventArgs e)
        {
            if (e.Equals(Keys.Escape))
                Application.Exit();
        }

        private void txt_password_OnPreviewKeyDown(object sender, EventArgs e)
        {
            if (e.Equals(Keys.Escape))
                Application.Exit();
        }

        private void txt_user_onKey_1(object sender, Keys codigo)
        {
            if (codigo == Keys.Escape)
                Application.Exit();
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
