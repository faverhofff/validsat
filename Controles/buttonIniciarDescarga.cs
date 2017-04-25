using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ValidSAT.Controles
{
    public partial class buttonIniciarDescarga : UserControl
    {
        public buttonIniciarDescarga()
        {
            InitializeComponent();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox2.Image = global::ValidSAT.Properties.Resources.b_1_on;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.Image = global::ValidSAT.Properties.Resources.b_1_on;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.Image = global::ValidSAT.Properties.Resources.b_1_off;
        }
    }
}
