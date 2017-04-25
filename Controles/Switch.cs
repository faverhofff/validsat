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

        string EllipseBG = "#5e9a97";
        string EllipseBorder = "#ffffff";

        Color EllipseBackColor;
        Color EllipseBorderBackColor;

        Color EnabledUnCheckedColor = ColorTranslator.FromHtml("#bcbfc4");
        Color EnabledUnCheckedEllipseBorderColor = ColorTranslator.FromHtml("#a9acb0");

        Color DisabledEllipseBackColor = ColorTranslator.FromHtml("#c3c4c6");
        Color DisabledEllipseBorderBackColor = ColorTranslator.FromHtml("#90949a");

        int PointAnimationNum = 170;


        public event keyEventHandler onChange;
        public delegate void keyEventHandler(object sender, Keys codigo);

        public int KeyValue { get; set; }
        
        public Switch()
        {
            InitializeComponent();
            AnimationTimer.Tick += new EventHandler(AnimationTick);
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            var G = pevent.Graphics;
            G.SmoothingMode = SmoothingMode.AntiAlias;
            //G.Clear(Parent.BackColor);

            EllipseBackColor = ColorTranslator.FromHtml(EllipseBG);
            EllipseBorderBackColor = ColorTranslator.FromHtml(EllipseBorder);

            G.FillEllipse(new SolidBrush(Enabled ? EllipseBackColor : Color.White ), PointAnimationNum, 2, 25, 25);
            G.DrawEllipse(new Pen(Enabled ? EllipseBorderBackColor : EnabledUnCheckedEllipseBorderColor ), PointAnimationNum, 2, 25, 25);

        }

        private void Switch_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AnimationTimer.Start();
        }

        void AnimationTick(object sender, EventArgs e)
        {
            if (KeyValue == 1 && PointAnimationNum >= 5)
            {
                PointAnimationNum -= 10;
                this.Invalidate();
            }
            if (KeyValue == 2 && PointAnimationNum <= 350)
            {
                PointAnimationNum += 10;
                this.Invalidate();
            }
            if (KeyValue == 0 && PointAnimationNum < 170)
            {
                PointAnimationNum += 10;
                this.Invalidate();
            }
            if (KeyValue == 0 && PointAnimationNum > 170)
            {
                PointAnimationNum -= 10;
                this.Invalidate();
            }
        }

        public void setPos(int pos)
        {
            if ((pos == 0 && KeyValue == 1) || (pos == 2 && KeyValue == 0))
            {
                moveRight();
                return;
            }
            if ((pos == 1 && KeyValue == 0) || (pos == 0 && KeyValue == 2))
            {
                moveLeft();
                return;
            }

            if (pos == 2 && KeyValue == 1)
            {
                moveLeft(); moveLeft();
                return;
            }
            if (pos == 1 && KeyValue == 2)
            {
                moveRight(); moveRight();
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            moveLeft();
        }

        private void Switch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                moveLeft();

            if (e.KeyCode == Keys.Right)
                moveRight();

            setPos(KeyValue);
            //Focus();

        }

        private void moveLeft()
        {
            if (KeyValue == 0)
                KeyValue = 1;
            else if (KeyValue == 2)
                KeyValue = 0;
            else KeyValue = 1;

            if (onChange != null)
                onChange(this, Keys.Left);

            //AnimationTimer.Tick += new EventHandler(AnimationTick);

            //Focus();
        }

        private void moveRight()
        {
            if (KeyValue == 0)
                KeyValue = 2;
            else if (KeyValue == 1)
                KeyValue = 0;
            else
                KeyValue = 2;

            if (onChange != null)
                onChange(this, Keys.Right);

            //AnimationTimer.Tick += new EventHandler(AnimationTick);

            //Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            moveRight();
        }

        private void Switch_Load(object sender, EventArgs e)
        {

        }

        private void Switch_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                moveLeft();

            if (e.KeyCode == Keys.Right)
                moveRight();

            if (e.KeyCode == Keys.Enter)
                if (onChange != null)
                    onChange(this, Keys.Enter);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (KeyValue == 1)
                moveRight();
            if (KeyValue == 2)
                moveLeft();

            KeyValue = 0;
        }
    }
}
