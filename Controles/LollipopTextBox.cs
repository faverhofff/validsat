using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

[DefaultEvent("TextChanged")]
public class LollipopTextBox : Control
{

    #region  Variables

    /// <summary>
    /// Evento 
    /// </summary>
    public event keyEventHandler onKey;
    

    /// <summary>
    /// Manejador de evento
    /// </summary>
    /// <param name="sender">Objeto que envia el log</param>
    public delegate void keyEventHandler(object sender, Keys codigo);

    TextBox LollipopTB = new TextBox();
    HorizontalAlignment ALNType;

    int maxchars = 32767;
    bool readOnly;
    bool previousReadOnly;
    bool multiline;
    bool isPasswordMasked = false;
    bool Enable = true;

    Timer AnimationTimer = new Timer { Interval = 1 };
    FontManager font = new FontManager();

    bool Focus = false;
    char passwordchar = ' ';

    float SizeAnimation = 0;
    float SizeInc_Dec;

    float PointAnimation;
    float PointInc_Dec;

    string fontColor = "#999999";
    string focusColor = "#508ef5";
    string backgroundcolor_rgb = "#ffffff";
    CharacterCasing charactercasing = 0;

    Color EnabledFocusedColor;
    Color EnabledStringColor;

    Color enableunfocusedcolor = ColorTranslator.FromHtml("#067069");

    Color DisabledUnFocusedColor = ColorTranslator.FromHtml("#e9ecee");
    private MaterialTextBox materialTextBox1;
    Color DisabledStringColor = ColorTranslator.FromHtml("#067069");

    #endregion
    #region  Properties

    public HorizontalAlignment TextAlignment
    {
        get
        {
            return ALNType;
        }
        set
        {
            ALNType = value;
            Invalidate();
        }
    }

    [Category("Behavior")]
    public int MaxLength
    {
        get
        {
            return maxchars;
        }
        set
        {
            maxchars = value;
            LollipopTB.MaxLength = MaxLength;
            Invalidate();
        }
    }
    [Category("Behavior")]
    public bool Multiline
    {
        get
        {
            return multiline;
        }
        set
        {
            multiline = value;
            if (LollipopTB != null)
            {
                LollipopTB.Multiline = value;

                if (value)
                {
                    LollipopTB.Location = new Point(-3, 1);
                    LollipopTB.Width = Width + 3;
                    LollipopTB.Height = Height - 6;
                }
                else
                {
                    LollipopTB.Location = new Point(0, 1);
                    LollipopTB.Width = Width;
                    Height = 24;
                }
            }
        }
    }
    [Category("Behavior")]
    public bool UseSystemPasswordChar
    {
        get
        {
            return isPasswordMasked;
        }
        set
        {
            LollipopTB.UseSystemPasswordChar = UseSystemPasswordChar;
            isPasswordMasked = value;
            Invalidate();
        }
    }

    [Category("Behavior")]
    public bool ReadOnly
    {
        get
        {
            return readOnly;
        }
        set
        {
            readOnly = value;
            if (LollipopTB != null)
            {
                LollipopTB.ReadOnly = value;
            }
        }
    }

    [Category("Behavior")]
    public bool IsEnabled
    {
        get { return Enable; }
        set
        {
            Enable = value;

            if (IsEnabled)
            {
                readOnly = previousReadOnly;
                LollipopTB.ReadOnly = previousReadOnly;
                LollipopTB.ForeColor = EnabledStringColor;
            }
            else
            {
                previousReadOnly = ReadOnly;
                ReadOnly = true;
                LollipopTB.ForeColor = DisabledStringColor;
            }

            Invalidate();
        }
    }

    [Category("Appearance")]
    public string FocusedColor
    {
        get { return focusColor; }
        set
        {
            focusColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public string EnabledUnFocusedColor_LI
    {
        get { return ColorTranslator.ToHtml(enableunfocusedcolor); ; }
        set
        {
            enableunfocusedcolor = ColorTranslator.FromHtml(value);
            Invalidate();
        }
    }

    [Category("Appearance")]
    public string FontColor
    {
        get { return fontColor; }
        set
        {
            fontColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Font Font_LI
    {
        get { return Font; }
        set
        {
            Font = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public CharacterCasing CharacterCasing_LI
    {
        get { return charactercasing; }
        set
        {
            charactercasing = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public char PasswordChar_LI
    {
        get { return passwordchar; }
        set
        {
            passwordchar = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public string BackgroundColor_RGB
    {
        get { return backgroundcolor_rgb; }
        set
        {
            backgroundcolor_rgb = value;
            Invalidate();
        }
    }

    [Browsable(false)]
    public bool Enabled
    {
        get { return base.Enabled; }
        set { base.Enabled = value; }
    }

    [Browsable(false)]
    public Font Font
    {
        get { return base.Font; }
        set { base.Font = value; }
    }

    [Browsable(false)]
    public Color ForeColor
    {
        get { return base.ForeColor; }
        set { base.ForeColor = value; }
    }

    #endregion
    #region  Events

    protected void OnKeyDown(object Obj, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            LollipopTB.SelectAll();
            e.SuppressKeyPress = true;
        }
        if (e.Control && e.KeyCode == Keys.C)
        {
            LollipopTB.Copy();
            e.SuppressKeyPress = true;
        }
        if (e.Control && e.KeyCode == Keys.X)
        {
            LollipopTB.Cut();
            e.SuppressKeyPress = true;
        }
    }
    protected override void OnTextChanged(System.EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }

    protected override void OnGotFocus(System.EventArgs e)
    {
        base.OnGotFocus(e);
        LollipopTB.Focus();
        LollipopTB.SelectionLength = 0;
    }
    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);

        PointAnimation = Width / 2;
        SizeInc_Dec = Width / 18;
        PointInc_Dec = Width / 36;

        LollipopTB.Width = Width;


        if (multiline)
        {
            LollipopTB.Location = new Point(-3, 1);
            LollipopTB.Width = Width + 3;
            LollipopTB.Height = Height - 6;
        }
        else
        {
            LollipopTB.Location = new Point(0, 1);
            LollipopTB.Width = Width;
            Height = 24;
        }
    }

    public delegate void PreviewKeyDownEventHandler(object sender, EventArgs e);
    public event PreviewKeyDownEventHandler OnPreviewKeyDown;

    #endregion


    public void AddTextBox()
    {
        LollipopTB.Location = new Point(0, 1);
        LollipopTB.Size = new Size(Width, 20);
        LollipopTB.Text = Text;
        
        LollipopTB.BorderStyle = BorderStyle.None;
        LollipopTB.TextAlign = HorizontalAlignment.Left;
        LollipopTB.Font = font.Roboto_Regular10;
        LollipopTB.UseSystemPasswordChar = UseSystemPasswordChar;
        LollipopTB.Multiline = false;
        LollipopTB.ScrollBars = ScrollBars.None;
        LollipopTB.KeyDown += OnKeyDown;
        LollipopTB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(materialTextBox1_PreviewKeyDown);

        LollipopTB.GotFocus += (sender, args) => Focus = true; AnimationTimer.Start();
        LollipopTB.LostFocus += (sender, args) => Focus = false; AnimationTimer.Start();
    }

    public LollipopTextBox()
    {
        Width = 300;
        DoubleBuffered = true;
        previousReadOnly = ReadOnly;

        AddTextBox();
        Controls.Add(LollipopTB);

        LollipopTB.TextChanged += (sender, args) => Text = LollipopTB.Text;
        base.TextChanged += (sender, args) => LollipopTB.Text = Text;

        AnimationTimer.Tick += new EventHandler(AnimationTick);
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        base.OnPaint(e);
        Bitmap B = new Bitmap(Width, Height);
        Graphics G = Graphics.FromImage(B);
        G.Clear(Color.Transparent);

        EnabledStringColor = ColorTranslator.FromHtml(fontColor);
        EnabledFocusedColor = ColorTranslator.FromHtml(focusColor);

        LollipopTB.TextAlign = TextAlignment;
        LollipopTB.ForeColor = IsEnabled ? EnabledStringColor : DisabledStringColor;
        LollipopTB.UseSystemPasswordChar = UseSystemPasswordChar;
        LollipopTB.Font = Font_LI;

        if ( PasswordChar_LI!=' ')
            LollipopTB.PasswordChar = PasswordChar_LI;

        string[] colors = BackgroundColor_RGB.Split(',');
        if (colors.Count() == 3)
            LollipopTB.BackColor = Color.FromArgb(Convert.ToInt16(colors[0]), Convert.ToInt16(colors[1]), Convert.ToInt16(colors[2]));

        LollipopTB.CharacterCasing = CharacterCasing_LI;

        G.DrawLine(new Pen(new SolidBrush(IsEnabled ? (this.Tag!=null ? ColorTranslator.FromHtml(this.Tag.ToString()) :  ColorTranslator.FromHtml( EnabledUnFocusedColor_LI )) : DisabledUnFocusedColor)), new Point(0, Height - 2), new Point(Width, Height - 2));
        if (IsEnabled)
        { G.FillRectangle(new SolidBrush(EnabledFocusedColor), PointAnimation, (float)Height - 3, SizeAnimation, 1); }

        e.Graphics.DrawImage((Image)(B.Clone()), 0, 0);
        G.Dispose();
        B.Dispose();
    }

    protected void AnimationTick(object sender, EventArgs e)
    {
        if (Focus)
        {
            if (SizeAnimation < Width)
            {
                SizeAnimation += SizeInc_Dec;
                this.Invalidate();
            }

            if (PointAnimation > 0)
            {
                PointAnimation -= PointInc_Dec;
                this.Invalidate();
            }
        }
        else
        {
            if (SizeAnimation > 0)
            {
                SizeAnimation -= SizeInc_Dec;
                this.Invalidate();
            }

            if (PointAnimation < Width / 2)
            {
                PointAnimation += PointInc_Dec;
                this.Invalidate();
            }
        }
    }

    private void InitializeComponent()
    {
            this.materialTextBox1 = new MaterialTextBox();
            this.SuspendLayout();
            // 
            // materialTextBox1
            // 
            this.materialTextBox1.FocusedColor = "#508ef5";
            this.materialTextBox1.FontColor = "#999999";
            this.materialTextBox1.IsEnabled = true;
            this.materialTextBox1.Location = new System.Drawing.Point(0, 0);
            this.materialTextBox1.MaxLength = 32767;
            this.materialTextBox1.Multiline = false;
            this.materialTextBox1.Name = "materialTextBox1";
            this.materialTextBox1.ReadOnly = false;
            this.materialTextBox1.Size = new System.Drawing.Size(300, 24);
            this.materialTextBox1.TabIndex = 0;
            this.materialTextBox1.Text = "materialTextBox1";
            this.materialTextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox1.UseSystemPasswordChar = false;
            this.materialTextBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.materialTextBox1_PreviewKeyDown);
            this.ResumeLayout(false);

    }

    private void materialTextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (onKey!=null)
            onKey(this, e.KeyCode);

       if (OnPreviewKeyDown != null)
            OnPreviewKeyDown(this, e);
    }
}
