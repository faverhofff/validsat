using System.Drawing;

namespace ValidSAT.Controles
{
    partial class Switch
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Switch));
            this.a2_ = new System.Windows.Forms.PictureBox();
            this.a0_ = new System.Windows.Forms.PictureBox();
            this.a1_ = new System.Windows.Forms.PictureBox();
            this.POS1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.POS2 = new System.Windows.Forms.PictureBox();
            this.POS0 = new System.Windows.Forms.PictureBox();
            this.pictureBox41 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.a2_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a0_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.a1_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.POS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.POS2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.POS0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).BeginInit();
            this.SuspendLayout();
            // 
            // a2_
            // 
            this.a2_.BackColor = System.Drawing.Color.Transparent;
            this.a2_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.a2_.Enabled = false;
            this.a2_.Image = global::ValidSAT.Properties.Resources.a2;
            this.a2_.Location = new System.Drawing.Point(352, 7);
            this.a2_.Name = "a2_";
            this.a2_.Size = new System.Drawing.Size(28, 28);
            this.a2_.TabIndex = 116;
            this.a2_.TabStop = false;
            this.a2_.Visible = false;
            // 
            // a0_
            // 
            this.a0_.BackColor = System.Drawing.Color.Transparent;
            this.a0_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.a0_.Image = global::ValidSAT.Properties.Resources.a0_;
            this.a0_.Location = new System.Drawing.Point(186, 7);
            this.a0_.Name = "a0_";
            this.a0_.Size = new System.Drawing.Size(25, 27);
            this.a0_.TabIndex = 115;
            this.a0_.TabStop = false;
            // 
            // a1_
            // 
            this.a1_.BackColor = System.Drawing.Color.Transparent;
            this.a1_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.a1_.Image = ((System.Drawing.Image)(resources.GetObject("a1_.Image")));
            this.a1_.Location = new System.Drawing.Point(5, 7);
            this.a1_.Name = "a1_";
            this.a1_.Size = new System.Drawing.Size(26, 29);
            this.a1_.TabIndex = 114;
            this.a1_.TabStop = false;
            this.a1_.Visible = false;
            // 
            // POS1
            // 
            this.POS1.BackColor = System.Drawing.Color.Transparent;
            this.POS1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POS1.Image = ((System.Drawing.Image)(resources.GetObject("POS1.Image")));
            this.POS1.Location = new System.Drawing.Point(4, 7);
            this.POS1.Name = "POS1";
            this.POS1.Size = new System.Drawing.Size(27, 29);
            this.POS1.TabIndex = 110;
            this.POS1.TabStop = false;
            this.POS1.Visible = false;
            this.POS1.Click += new System.EventHandler(this.label1_Click);
            this.POS1.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.POS1.MouseHover += new System.EventHandler(this.label2_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(83)))), ((int)(((byte)(130)))));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(221, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 113;
            this.label2.Text = "de la Clave CIEC";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(83)))), ((int)(((byte)(130)))));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(27, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 18);
            this.label1.TabIndex = 112;
            this.label1.Text = "del Certificado .cer";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label2_MouseEnter);
            // 
            // POS2
            // 
            this.POS2.BackColor = System.Drawing.Color.Transparent;
            this.POS2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POS2.Enabled = false;
            this.POS2.Image = ((System.Drawing.Image)(resources.GetObject("POS2.Image")));
            this.POS2.Location = new System.Drawing.Point(352, 7);
            this.POS2.Name = "POS2";
            this.POS2.Size = new System.Drawing.Size(28, 28);
            this.POS2.TabIndex = 111;
            this.POS2.TabStop = false;
            this.POS2.Visible = false;
            this.POS2.Click += new System.EventHandler(this.label1_Click);
            this.POS2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.POS2.MouseHover += new System.EventHandler(this.label2_MouseEnter);
            // 
            // POS0
            // 
            this.POS0.BackColor = System.Drawing.Color.Transparent;
            this.POS0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.POS0.Image = global::ValidSAT.Properties.Resources.a0on;
            this.POS0.Location = new System.Drawing.Point(185, 7);
            this.POS0.Name = "POS0";
            this.POS0.Size = new System.Drawing.Size(25, 27);
            this.POS0.TabIndex = 109;
            this.POS0.TabStop = false;
            this.POS0.Visible = false;
            this.POS0.Click += new System.EventHandler(this.label1_Click);
            this.POS0.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.POS0.MouseHover += new System.EventHandler(this.label2_MouseEnter);
            // 
            // pictureBox41
            // 
            this.pictureBox41.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox41.Image = global::ValidSAT.Properties.Resources.a1;
            this.pictureBox41.Location = new System.Drawing.Point(4, 5);
            this.pictureBox41.Name = "pictureBox41";
            this.pictureBox41.Size = new System.Drawing.Size(381, 33);
            this.pictureBox41.TabIndex = 106;
            this.pictureBox41.TabStop = false;
            this.pictureBox41.Click += new System.EventHandler(this.label1_Click);
            this.pictureBox41.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.pictureBox41.MouseHover += new System.EventHandler(this.label2_MouseEnter);
            // 
            // Switch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.a2_);
            this.Controls.Add(this.a0_);
            this.Controls.Add(this.a1_);
            this.Controls.Add(this.POS1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.POS2);
            this.Controls.Add(this.POS0);
            this.Controls.Add(this.pictureBox41);
            this.Name = "Switch";
            this.Size = new System.Drawing.Size(393, 42);
            this.MouseHover += new System.EventHandler(this.label2_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.a2_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a0_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.a1_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.POS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.POS2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.POS0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox41)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox41;
        private System.Windows.Forms.PictureBox POS2;
        private System.Windows.Forms.PictureBox POS0;
        private System.Windows.Forms.PictureBox POS1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox a1_;
        private System.Windows.Forms.PictureBox a0_;
        private System.Windows.Forms.PictureBox a2_;
    }
}
