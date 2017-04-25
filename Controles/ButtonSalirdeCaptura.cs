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
    public partial class ButtonSalirdeCaptura : UserControl
    {

        public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
        public event ButtonClickedEventHandler OnUserControlButtonClicked;
        public event keyEventHandler onChange;
        public delegate void keyEventHandler(object sender, Keys codigo);


        public ButtonSalirdeCaptura()
        {
            InitializeComponent();
            panel1.Click += new EventHandler(OnButtonClicked);
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackgroundImage = global::ValidSAT.Properties.Resources.b_3_on;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackgroundImage = global::ValidSAT.Properties.Resources.b_3_off;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackgroundImage = global::ValidSAT.Properties.Resources.b_3_off;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
        }

        public void setOn()
        {
            panel1.BackgroundImage = global::ValidSAT.Properties.Resources.b_3_on;
        }
        public void setOff()
        {
            panel1.BackgroundImage = global::ValidSAT.Properties.Resources.b_3_off;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            // Delegate the event to the caller
            if (OnUserControlButtonClicked != null)
                OnUserControlButtonClicked(this, e);
        }

        private void ButtonSalirdeCaptura_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
                if (onChange != null)
                    onChange(this, e.KeyCode);
        }
    }
}
