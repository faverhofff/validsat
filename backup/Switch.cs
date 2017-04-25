using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ValidSAT.Classes;
using System.Drawing.Drawing2D;

namespace ValidSAT.Controles
{
    public partial class Switch : UserControl
    {

        Timer AnimationTimer = new Timer { Interval = 1 };
        GraphicsPath RoundedRectangle;

        string EllipseBG = "#508ef5";
        string EllipseBorder = "#3b73d1";

        Color EllipseBackColor;
        Color EllipseBorderBackColor;

        Color EnabledUnCheckedColor = ColorTranslator.FromHtml("#bcbfc4");
        Color EnabledUnCheckedEllipseBorderColor = ColorTranslator.FromHtml("#a9acb0");

        Color DisabledEllipseBackColor = ColorTranslator.FromHtml("#c3c4c6");
        Color DisabledEllipseBorderBackColor = ColorTranslator.FromHtml("#90949a");

        int PointAnimationNum = 4;


        public event keyEventHandler onChange;
        public delegate void keyEventHandler(object sender, Keys codigo);

        public int KeyValue { get; set; }
        
        public Switch()
        {
            InitializeComponent();
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            var G = pevent.Graphics;
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.Clear(Parent.BackColor);

            EllipseBackColor = ColorTranslator.FromHtml(EllipseBG);
            EllipseBorderBackColor = ColorTranslator.FromHtml(EllipseBorder);

            //G.FillPath(new SolidBrush(Color.FromArgb(115, Enabled ? EllipseBackColor : EnabledUnCheckedColor)), RoundedRectangle);
            //G.DrawPath(new Pen(Color.FromArgb(50, Enabled ? EllipseBackColor : EnabledUnCheckedColor)), RoundedRectangle);

            G.FillEllipse(new SolidBrush(Enabled ? EllipseBackColor : Color.White ), PointAnimationNum, 0, 18, 18);
            G.DrawEllipse(new Pen(Enabled ? EllipseBorderBackColor : EnabledUnCheckedEllipseBorderColor ), PointAnimationNum, 0, 18, 18);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Switch_MouseEnter();
        }

        public void Switch_Click(int pos = -1)
        {
            if (pos==0)
            {
                //POS0.Visible = false;
                POS1.Visible = false;
                POS2.Visible = false;
                for (int i = 0; i <= 100; i++)
                {
                    POS0.Left -= i;
                    
                }
                a1_.Visible = false;
                a2_.Visible = false;
                a0_.Visible = true;
            }

            if (pos == 1)
            {
                POS0.Visible = false;
                POS1.Visible = false;
                POS2.Visible = false;
                a1_.Visible = true;
                a2_.Visible = false;
                a0_.Visible = false;
            }

            if (pos == 2)
            {
                POS0.Visible = false;
                POS1.Visible = false;
                POS2.Visible = false;
                a1_.Visible = false;
                a2_.Visible = false;
                a0_.Visible = false;
            }

            if (POS2.Visible == true)
            {
                KeyValue = 1;
                POS1.Visible = true;
                POS2.Visible = false;
                if (onChange != null)
                    onChange(this, Keys.A);
                return;
            }
            if (POS1.Visible == true)
            {
                KeyValue = 2;
                POS2.Visible = true;
                POS1.Visible = false;
                if (onChange != null)
                    onChange(this, Keys.A);
                return;
            }
            if (POS0.Visible == true)
            {
                KeyValue = 1;
                POS1.Visible = true;
                POS0.Visible = false;
                if (onChange != null)
                    onChange(this, Keys.A);
                return;
            }
        }

        private void Switch_MouseEnter()
        {
            if (a2_.Visible == true)
            {
                POS2.Visible = true;
                a2_.Visible = false;
                return;
            }
            if (a1_.Visible == true)
            {
                POS1.Visible = true;
                a1_.Visible = false;
                return;
            }
            if (a0_.Visible == true)
            {
                POS0.Visible = true;
                a0_.Visible = false;
                return;
            }
        }

        private void Switch_MouseLeave()
        {
            if (POS2.Visible == true)
            {
                POS2.Visible = false;
                a2_.Visible = true;
            }
            if (POS1.Visible == true)
            {
                POS1.Visible = false;
                a1_.Visible = true;
            }
            if (POS0.Visible == true)
            {
                POS0.Visible = false;
                a0_.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Switch_Click();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            Switch_MouseEnter();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            Switch_MouseLeave();
        }
    }
}
