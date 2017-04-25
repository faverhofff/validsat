using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ValidSAT.Classes;

namespace ValidSAT.forms
{
    public partial class frmMainLogin : Form
    {
        public frmMainLogin()
        {
            InitializeComponent();


            Global.Instance.connectionState= BussinessModel.dbConnectionActive();

            this.Show();
            frmLogin login = new frmLogin(this);
            login.ShowDialog();
        }
    }
}
