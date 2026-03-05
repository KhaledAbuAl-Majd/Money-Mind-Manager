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
            this.gibtnFindPerson = new Guna.UI2.WinForms.Guna2ImageButton();
            this.gibtnAddPerson = new Guna.UI2.WinForms.Guna2ImageButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.kgtxtPersonName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlSearchPart = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlPersonCard1 = new MoneyMindManager_Presentation.People.Controls.ctrlPersonCard();
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
            this.kgtxtPersonID.FillColor = System.Drawing.SystemColors.ControlLight;
            this.kgtxtPersonID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPersonID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtPersonID.ForeColor = System.Drawing.Color.Black;
            this.kgtxtPersonID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPersonID.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtPersonID.IsRequired = true;
            this.kgtxtPersonID.Location = new System.Drawing.Point(422, 19);
            this.kgtxtPersonID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtPersonID.MaxLength = 150;
            this.kgtxtPersonID.Name = "kgtxtPersonID";
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtPersonID.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtPersonID.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.AllowNegative = false;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtPersonID.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtPersonID.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtPersonID.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtPersonID.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtPersonID.PlaceholderText = "معرف الشخص";
            this.kgtxtPersonID.ReadOnly = true;
            this.kgtxtPersonID.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtPersonID.SelectedText = "";
            this.kgtxtPersonID.ShadowDecoration.BorderRadius = 2;
            this.kgtxtPersonID.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtPersonID.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtPersonID.Size = new System.Drawing.Size(125, 42);
            this.kgtxtPersonID.TabIndex = 1;
            this.kgtxtPersonID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtPersonID.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtPersonID.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtPersonID.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtPersonID.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtPersonID.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtPersonID.TextProperties.MinLength = ((short)(0));
            this.kgtxtPersonID.TextProperties.MinLengthOption = false;
            this.kgtxtPersonID.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtPersonID.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtPersonID.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.toolTip1.SetToolTip(this.kgtxtPersonID, "F9 للبحث عن شخص قم بالضغط على زر البحث أو قم بضغط على زر");
            this.kgtxtPersonID.TrimEnd = false;
            this.kgtxtPersonID.TrimStart = false;
            this.kgtxtPersonID.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxtPersonID_OnValidationError);
            this.kgtxtPersonID.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtPersonID_OnValidationSuccess);
            this.kgtxtPersonID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kgtxtPersonID_KeyDown);
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
            this.gibtnFindPerson.Location = new System.Drawing.Point(78, 19);
            this.gibtnFindPerson.Name = "gibtnFindPerson";
            this.gibtnFindPerson.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnFindPerson.Size = new System.Drawing.Size(64, 42);
            this.gibtnFindPerson.TabIndex = 99;
            this.toolTip1.SetToolTip(this.gibtnFindPerson, "البحث عن شخص");
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
            this.gibtnAddPerson.Location = new System.Drawing.Point(8, 19);
            this.gibtnAddPerson.Name = "gibtnAddPerson";
            this.gibtnAddPerson.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnAddPerson.Size = new System.Drawing.Size(64, 42);
            this.gibtnAddPerson.TabIndex = 100;
            this.toolTip1.SetToolTip(this.gibtnAddPerson, "إضافة شخص جديد");
            this.gibtnAddPerson.UseTransparentBackground = true;
            this.gibtnAddPerson.Click += new System.EventHandler(this.gibtnAddPerson_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // kgtxtPersonName
            // 
            this.kgtxtPersonName.AllowWhiteSpace = true;
            this.kgtxtPersonName.ApplyTrimAtTextBoxValue = false;
            this.kgtxtPersonName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtPersonName.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtPersonName.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtPersonName.BorderRadius = 10;
            this.kgtxtPersonName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtPersonName.DefaultText = "";
            this.kgtxtPersonName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtPersonName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtPersonName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPersonName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPersonName.FillColor = System.Drawing.SystemColors.ControlLight;
            this.kgtxtPersonName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPersonName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtPersonName.ForeColor = System.Drawing.Color.Black;
            this.kgtxtPersonName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPersonName.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtPersonName.IsRequired = true;
            this.kgtxtPersonName.Location = new System.Drawing.Point(144, 19);
            this.kgtxtPersonName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtPersonName.MaxLength = 200;
            this.kgtxtPersonName.Name = "kgtxtPersonName";
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.AllowNegative = false;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtPersonName.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtPersonName.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtPersonName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtPersonName.PlaceholderText = "اسم الشخص";
            this.kgtxtPersonName.ReadOnly = true;
            this.kgtxtPersonName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtPersonName.SelectedText = "";
            this.kgtxtPersonName.ShadowDecoration.BorderRadius = 2;
            this.kgtxtPersonName.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtPersonName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtPersonName.Size = new System.Drawing.Size(270, 42);
            this.kgtxtPersonName.TabIndex = 125;
            this.kgtxtPersonName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtPersonName.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtPersonName.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtPersonName.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtPersonName.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtPersonName.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtPersonName.TextProperties.MinLength = ((short)(0));
            this.kgtxtPersonName.TextProperties.MinLengthOption = false;
            this.kgtxtPersonName.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtPersonName.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtPersonName.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.toolTip1.SetToolTip(this.kgtxtPersonName, "F9 للبحث عن شخص قم بالضغط على زر البحث أو قم بضغط على زر");
            this.kgtxtPersonName.TrimEnd = false;
            this.kgtxtPersonName.TrimStart = false;
            this.kgtxtPersonName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kgtxtPersonID_KeyDown);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlSearchPart
            // 
            this.pnlSearchPart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSearchPart.Controls.Add(this.label1);
            this.pnlSearchPart.Controls.Add(this.kgtxtPersonName);
            this.pnlSearchPart.Controls.Add(this.label3);
            this.pnlSearchPart.Controls.Add(this.gibtnAddPerson);
            this.pnlSearchPart.Controls.Add(this.gibtnFindPerson);
            this.pnlSearchPart.Controls.Add(this.kgtxtPersonID);
            this.pnlSearchPart.Location = new System.Drawing.Point(2, 0);
            this.pnlSearchPart.Name = "pnlSearchPart";
            this.pnlSearchPart.Size = new System.Drawing.Size(570, 68);
            this.pnlSearchPart.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 126;
            this.label1.Text = "اسم الشخص";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(459, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 124;
            this.label3.Text = "معرف الشخص";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.AllowEditingPerson = false;
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(11, 74);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(536, 556);
            this.ctrlPersonCard1.TabIndex = 0;
            this.ctrlPersonCard1.OnEditingPerson += new System.Action(this.ctrlPersonCard1_OnEditingPerson);
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlSearchPart);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(575, 640);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlSearchPart.ResumeLayout(false);
            this.pnlSearchPart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard ctrlPersonCard1;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPersonID;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnFindPerson;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnAddPerson;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlSearchPart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPersonName;
    }
}
