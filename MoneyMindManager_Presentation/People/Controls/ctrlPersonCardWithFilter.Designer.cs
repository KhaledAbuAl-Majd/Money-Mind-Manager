using System.ComponentModel;

namespace MoneyMindManager_Presentation.People.Controls
{
    partial class ctrlPersonCardWithFilter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlPersonCardWithFilter));
            this.kgtxtPersonID = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gibtnFindPerson = new Guna.UI2.WinForms.Guna2ImageButton();
            this.gibtnAddPerson = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ctrlPersonCard1 = new MoneyMindManager_Presentation.People.Controls.ctrlPersonCard();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlSearchPart = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlSearchPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // kgtxtPersonID
            // 
            this.kgtxtPersonID.AllowWhiteSpace = false;
            this.kgtxtPersonID.ApplyTrimAtTextBoxValue = false;
            this.kgtxtPersonID.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtPersonID.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtPersonID.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtPersonID.BorderRadius = 10;
            this.kgtxtPersonID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtPersonID.DefaultText = "";
            this.kgtxtPersonID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtPersonID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtPersonID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPersonID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPersonID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPersonID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtPersonID.ForeColor = System.Drawing.Color.Black;
            this.kgtxtPersonID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPersonID.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtPersonID.IsRequired = true;
            this.kgtxtPersonID.Location = new System.Drawing.Point(154, 4);
            this.kgtxtPersonID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtPersonID.MaxLength = 150;
            this.kgtxtPersonID.Name = "kgtxtPersonID";
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.AllowNegative = false;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtPersonID.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtPersonID.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtPersonID.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtPersonID.PlaceholderText = "معرف الشخص";
            this.kgtxtPersonID.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtPersonID.SelectedText = "";
            this.kgtxtPersonID.ShadowDecoration.BorderRadius = 2;
            this.kgtxtPersonID.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtPersonID.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtPersonID.Size = new System.Drawing.Size(315, 42);
            this.kgtxtPersonID.TabIndex = 1;
            this.kgtxtPersonID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtPersonID.TextProperties.MinLength = ((short)(0));
            this.kgtxtPersonID.TextProperties.MinLengthOption = false;
            this.kgtxtPersonID.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtPersonID.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtPersonID.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtPersonID.TrimEnd = false;
            this.kgtxtPersonID.TrimStart = false;
            this.kgtxtPersonID.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxtPersonID_OnValidationError);
            this.kgtxtPersonID.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtPersonID_OnValidationSuccess);
            this.kgtxtPersonID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kgtxtPersonID_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(499, 13);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 98;
            this.label2.Text = "معرف الشخص :";
            // 
            // gibtnFindPerson
            // 
            this.gibtnFindPerson.AnimatedGIF = true;
            this.gibtnFindPerson.BackColor = System.Drawing.Color.Transparent;
            this.gibtnFindPerson.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnFindPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gibtnFindPerson.HoverState.ImageSize = new System.Drawing.Size(55, 55);
            this.gibtnFindPerson.Image = ((System.Drawing.Image)(resources.GetObject("gibtnFindPerson.Image")));
            this.gibtnFindPerson.ImageOffset = new System.Drawing.Point(0, 0);
            this.gibtnFindPerson.ImageRotate = 0F;
            this.gibtnFindPerson.ImageSize = new System.Drawing.Size(40, 40);
            this.gibtnFindPerson.IndicateFocus = true;
            this.gibtnFindPerson.Location = new System.Drawing.Point(83, 4);
            this.gibtnFindPerson.Name = "gibtnFindPerson";
            this.gibtnFindPerson.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnFindPerson.Size = new System.Drawing.Size(64, 42);
            this.gibtnFindPerson.TabIndex = 99;
            this.toolTip1.SetToolTip(this.gibtnFindPerson, "وجد الشخص صاحب معرف الشخص");
            this.gibtnFindPerson.UseTransparentBackground = true;
            this.gibtnFindPerson.Click += new System.EventHandler(this.gibtnFindPerson_Click);
            // 
            // gibtnAddPerson
            // 
            this.gibtnAddPerson.AnimatedGIF = true;
            this.gibtnAddPerson.BackColor = System.Drawing.Color.Transparent;
            this.gibtnAddPerson.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gibtnAddPerson.HoverState.ImageSize = new System.Drawing.Size(55, 55);
            this.gibtnAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("gibtnAddPerson.Image")));
            this.gibtnAddPerson.ImageOffset = new System.Drawing.Point(0, 0);
            this.gibtnAddPerson.ImageRotate = 0F;
            this.gibtnAddPerson.ImageSize = new System.Drawing.Size(40, 40);
            this.gibtnAddPerson.IndicateFocus = true;
            this.gibtnAddPerson.Location = new System.Drawing.Point(8, 4);
            this.gibtnAddPerson.Name = "gibtnAddPerson";
            this.gibtnAddPerson.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnAddPerson.Size = new System.Drawing.Size(64, 42);
            this.gibtnAddPerson.TabIndex = 100;
            this.toolTip1.SetToolTip(this.gibtnAddPerson, "إضافة شخص جديد");
            this.gibtnAddPerson.UseTransparentBackground = true;
            this.gibtnAddPerson.Click += new System.EventHandler(this.gibtnAddPerson_Click);
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(11, 74);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(602, 436);
            this.ctrlPersonCard1.TabIndex = 0;
            this.ctrlPersonCard1.OnEditingPerson += new System.Action(this.ctrlPersonCard1_OnEditingPerson);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlSearchPart
            // 
            this.pnlSearchPart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSearchPart.Controls.Add(this.gibtnAddPerson);
            this.pnlSearchPart.Controls.Add(this.gibtnFindPerson);
            this.pnlSearchPart.Controls.Add(this.label2);
            this.pnlSearchPart.Controls.Add(this.kgtxtPersonID);
            this.pnlSearchPart.Location = new System.Drawing.Point(2, 11);
            this.pnlSearchPart.Name = "pnlSearchPart";
            this.pnlSearchPart.Size = new System.Drawing.Size(620, 57);
            this.pnlSearchPart.TabIndex = 101;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlSearchPart);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(624, 519);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlSearchPart.ResumeLayout(false);
            this.pnlSearchPart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPersonID;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnFindPerson;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnAddPerson;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlSearchPart;
    }
}
