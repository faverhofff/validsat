using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ValidSAT.dialogs
{
    public partial class frmDialog : Form
    {
        private Form _modal;
        public frmDialog(string Text)
        {
            InitializeComponent();
            label2.Text = Text;
            this._init(Text);
        }

        public frmDialog(string Text, Form modal)
        {
            InitializeComponent();
            this._modal = modal;
            label2.Text = Text;
            this._init(Text);
        }

        private void _init(string Text)
        {
            this.Opacity = 65;
            //this.Size = new System.Drawing.Size(206, 36);

            Timer formCloser = new Timer();
            formCloser.Interval = 15000;
            formCloser.Enabled = true;
            formCloser.Tick += new EventHandler(formClose_Tick);

            this.Opacity = 0.65;

             // _prepareText(Text);
            pictureBox1.Focus();

        }

        private void formClose_Tick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this._setLeave();            
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this._setOver();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this._setOver();
        }
        
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this._setLeave();
        }


        private void _setOver()
        {
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(140)))), ((int)(((byte)(132)))));
            label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(140)))), ((int)(((byte)(132))))); ;
        }

        private void _setLeave()
        {
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(193)))), ((int)(((byte)(180)))));
            label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(193)))), ((int)(((byte)(180)))));
        }

        private string _prepareText(string text)
        {
            /*
            string _text = text;
            for(int i=0; i <= text.Length / 60; i++)
            {
                _text = _text.Insert(60 * i, "\n");
            }
            */
            return text;
        }

        private void label1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        private void frmDialog_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        private void frmDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._modal.Close();
        }
    }
}
