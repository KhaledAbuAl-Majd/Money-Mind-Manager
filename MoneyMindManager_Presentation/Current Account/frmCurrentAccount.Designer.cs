namespace MoneyMindManager_Presentation
{
    partial class frmCurrentAccount
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrentAccount));
            this.lblHeader = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.kgtxtDefaultCurrency = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtBalance = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kgtxtDiscription = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.kgtxtCreatedByUserName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbtnSave = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kgtxtCreatedDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtAccountName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1210, 60);
            this.lblHeader.TabIndex = 41;
            this.lblHeader.Text = "بيانات الحساب";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.label7);
            this.guna2Panel2.Controls.Add(this.kgtxtDefaultCurrency);
            this.guna2Panel2.Controls.Add(this.kgtxtBalance);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Controls.Add(this.kgtxtDiscription);
            this.guna2Panel2.Controls.Add(this.label6);
            this.guna2Panel2.Controls.Add(this.kgtxtCreatedByUserName);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Controls.Add(this.label5);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Controls.Add(this.gbtnSave);
            this.guna2Panel2.Controls.Add(this.guna2Panel1);
            this.guna2Panel2.Controls.Add(this.kgtxtCreatedDate);
            this.guna2Panel2.Controls.Add(this.kgtxtAccountName);
            this.guna2Panel2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel2.Location = new System.Drawing.Point(281, 114);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.guna2Panel2.ShadowDecoration.Depth = 20;
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.Size = new System.Drawing.Size(654, 358);
            this.guna2Panel2.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(166, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 17);
            this.label7.TabIndex = 133;
            this.label7.Text = "العملة الإفتراضية للحساب";
            // 
            // kgtxtDefaultCurrency
            // 
            this.kgtxtDefaultCurrency.AllowWhiteSpace = true;
            this.kgtxtDefaultCurrency.ApplyTrimAtTextBoxValue = false;
            this.kgtxtDefaultCurrency.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtDefaultCurrency.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtDefaultCurrency.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtDefaultCurrency.BorderRadius = 10;
            this.kgtxtDefaultCurrency.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtDefaultCurrency.DefaultText = "";
            this.kgtxtDefaultCurrency.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtDefaultCurrency.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtDefaultCurrency.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtDefaultCurrency.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtDefaultCurrency.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtDefaultCurrency.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtDefaultCurrency.ForeColor = System.Drawing.Color.Black;
            this.kgtxtDefaultCurrency.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtDefaultCurrency.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtDefaultCurrency.IsRequired = false;
            this.kgtxtDefaultCurrency.Location = new System.Drawing.Point(29, 226);
            this.kgtxtDefaultCurrency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtDefaultCurrency.MaxLength = 150;
            this.kgtxtDefaultCurrency.Name = "kgtxtDefaultCurrency";
            this.kgtxtDefaultCurrency.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtDefaultCurrency.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtDefaultCurrency.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtDefaultCurrency.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtDefaultCurrency.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtDefaultCurrency.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtDefaultCurrency.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtDefaultCurrency.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtDefaultCurrency.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtDefaultCurrency.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtDefaultCurrency.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtDefaultCurrency.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtDefaultCurrency.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtDefaultCurrency.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtDefaultCurrency.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtDefaultCurrency.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtDefaultCurrency.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtDefaultCurrency.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtDefaultCurrency.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtDefaultCurrency.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtDefaultCurrency.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtDefaultCurrency.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtDefaultCurrency.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtDefaultCurrency.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtDefaultCurrency.PlaceholderText = "العملة الإفتراضية للحساب";
            this.kgtxtDefaultCurrency.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtDefaultCurrency.SelectedText = "";
            this.kgtxtDefaultCurrency.ShadowDecoration.BorderRadius = 2;
            this.kgtxtDefaultCurrency.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtDefaultCurrency.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtDefaultCurrency.Size = new System.Drawing.Size(283, 41);
            this.kgtxtDefaultCurrency.TabIndex = 6;
            this.kgtxtDefaultCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtDefaultCurrency.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtDefaultCurrency.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtDefaultCurrency.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtDefaultCurrency.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtDefaultCurrency.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtDefaultCurrency.TextProperties.MinLength = ((short)(0));
            this.kgtxtDefaultCurrency.TextProperties.MinLengthOption = false;
            this.kgtxtDefaultCurrency.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtDefaultCurrency.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtDefaultCurrency.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtDefaultCurrency.TrimEnd = true;
            this.kgtxtDefaultCurrency.TrimStart = true;
            // 
            // kgtxtBalance
            // 
            this.kgtxtBalance.AllowWhiteSpace = false;
            this.kgtxtBalance.ApplyTrimAtTextBoxValue = false;
            this.kgtxtBalance.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtBalance.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtBalance.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtBalance.BorderRadius = 10;
            this.kgtxtBalance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtBalance.DefaultText = "";
            this.kgtxtBalance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtBalance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtBalance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtBalance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtBalance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtBalance.ForeColor = System.Drawing.Color.Black;
            this.kgtxtBalance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtBalance.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtBalance.IsRequired = false;
            this.kgtxtBalance.Location = new System.Drawing.Point(341, 226);
            this.kgtxtBalance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtBalance.MaxLength = 20;
            this.kgtxtBalance.Name = "kgtxtBalance";
            this.kgtxtBalance.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtBalance.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtBalance.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtBalance.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtBalance.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtBalance.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtBalance.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtBalance.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtBalance.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtBalance.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtBalance.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtBalance.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtBalance.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtBalance.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtBalance.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtBalance.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtBalance.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtBalance.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtBalance.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtBalance.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtBalance.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtBalance.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.N4;
            this.kgtxtBalance.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber;
            this.kgtxtBalance.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtBalance.PlaceholderText = "الرصيد";
            this.kgtxtBalance.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtBalance.SelectedText = "";
            this.kgtxtBalance.ShadowDecoration.BorderRadius = 2;
            this.kgtxtBalance.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtBalance.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtBalance.Size = new System.Drawing.Size(283, 41);
            this.kgtxtBalance.TabIndex = 2;
            this.kgtxtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtBalance.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtBalance.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtBalance.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtBalance.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtBalance.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtBalance.TextProperties.MinLength = ((short)(0));
            this.kgtxtBalance.TextProperties.MinLengthOption = false;
            this.kgtxtBalance.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtBalance.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtBalance.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Phone;
            this.kgtxtBalance.TrimEnd = true;
            this.kgtxtBalance.TrimStart = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(581, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 127;
            this.label1.Text = "الرصيد";
            // 
            // kgtxtDiscription
            // 
            this.kgtxtDiscription.AllowWhiteSpace = true;
            this.kgtxtDiscription.ApplyTrimAtTextBoxValue = false;
            this.kgtxtDiscription.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtDiscription.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtDiscription.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtDiscription.BorderRadius = 10;
            this.kgtxtDiscription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtDiscription.DefaultText = "";
            this.kgtxtDiscription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtDiscription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtDiscription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtDiscription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtDiscription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtDiscription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtDiscription.ForeColor = System.Drawing.Color.Black;
            this.kgtxtDiscription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtDiscription.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtDiscription.IsRequired = false;
            this.kgtxtDiscription.Location = new System.Drawing.Point(341, 89);
            this.kgtxtDiscription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtDiscription.MaxLength = 200;
            this.kgtxtDiscription.Multiline = true;
            this.kgtxtDiscription.Name = "kgtxtDiscription";
            this.kgtxtDiscription.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtDiscription.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtDiscription.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtDiscription.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtDiscription.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtDiscription.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtDiscription.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtDiscription.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtDiscription.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtDiscription.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtDiscription.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtDiscription.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtDiscription.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtDiscription.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtDiscription.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtDiscription.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtDiscription.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtDiscription.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtDiscription.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtDiscription.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtDiscription.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtDiscription.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtDiscription.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtDiscription.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtDiscription.PlaceholderText = "الوصف (اختياري)";
            this.kgtxtDiscription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.kgtxtDiscription.SelectedText = "";
            this.kgtxtDiscription.ShadowDecoration.BorderRadius = 2;
            this.kgtxtDiscription.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtDiscription.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtDiscription.Size = new System.Drawing.Size(283, 107);
            this.kgtxtDiscription.TabIndex = 1;
            this.kgtxtDiscription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtDiscription.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtDiscription.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtDiscription.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtDiscription.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtDiscription.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtDiscription.TextProperties.MinLength = ((short)(0));
            this.kgtxtDiscription.TextProperties.MinLengthOption = false;
            this.kgtxtDiscription.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtDiscription.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtDiscription.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Phone;
            this.kgtxtDiscription.TrimEnd = false;
            this.kgtxtDiscription.TrimStart = false;
            this.kgtxtDiscription.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtDiscription.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(139, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 17);
            this.label6.TabIndex = 131;
            this.label6.Text = "اسم المستخدم لمنشئ الحساب";
            // 
            // kgtxtCreatedByUserName
            // 
            this.kgtxtCreatedByUserName.AllowWhiteSpace = true;
            this.kgtxtCreatedByUserName.ApplyTrimAtTextBoxValue = false;
            this.kgtxtCreatedByUserName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtCreatedByUserName.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtCreatedByUserName.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtCreatedByUserName.BorderRadius = 10;
            this.kgtxtCreatedByUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtCreatedByUserName.DefaultText = "";
            this.kgtxtCreatedByUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtCreatedByUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtCreatedByUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtCreatedByUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtCreatedByUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtCreatedByUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtCreatedByUserName.ForeColor = System.Drawing.Color.Black;
            this.kgtxtCreatedByUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtCreatedByUserName.IconLeft = ((System.Drawing.Image)(resources.GetObject("kgtxtCreatedByUserName.IconLeft")));
            this.kgtxtCreatedByUserName.IconRight = ((System.Drawing.Image)(resources.GetObject("kgtxtCreatedByUserName.IconRight")));
            this.kgtxtCreatedByUserName.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtCreatedByUserName.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtCreatedByUserName.IsRequired = false;
            this.kgtxtCreatedByUserName.Location = new System.Drawing.Point(29, 155);
            this.kgtxtCreatedByUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtCreatedByUserName.MaxLength = 150;
            this.kgtxtCreatedByUserName.Name = "kgtxtCreatedByUserName";
            this.kgtxtCreatedByUserName.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtCreatedByUserName.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtCreatedByUserName.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtCreatedByUserName.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtCreatedByUserName.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtCreatedByUserName.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtCreatedByUserName.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtCreatedByUserName.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtCreatedByUserName.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtCreatedByUserName.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtCreatedByUserName.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtCreatedByUserName.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtCreatedByUserName.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtCreatedByUserName.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtCreatedByUserName.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtCreatedByUserName.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtCreatedByUserName.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtCreatedByUserName.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtCreatedByUserName.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtCreatedByUserName.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtCreatedByUserName.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtCreatedByUserName.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtCreatedByUserName.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtCreatedByUserName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtCreatedByUserName.PlaceholderText = "اسم المستخدم لمنشئ الحساب";
            this.kgtxtCreatedByUserName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtCreatedByUserName.SelectedText = "";
            this.kgtxtCreatedByUserName.ShadowDecoration.BorderRadius = 2;
            this.kgtxtCreatedByUserName.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtCreatedByUserName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtCreatedByUserName.Size = new System.Drawing.Size(283, 41);
            this.kgtxtCreatedByUserName.TabIndex = 5;
            this.kgtxtCreatedByUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtCreatedByUserName.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtCreatedByUserName.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtCreatedByUserName.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtCreatedByUserName.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtCreatedByUserName.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtCreatedByUserName.TextProperties.MinLength = ((short)(0));
            this.kgtxtCreatedByUserName.TextProperties.MinLengthOption = false;
            this.kgtxtCreatedByUserName.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtCreatedByUserName.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtCreatedByUserName.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.toolTip1.SetToolTip(this.kgtxtCreatedByUserName, "اضغط على الأيقونة اليمنى لرؤية بيانات المستخدم المنشئ");
            this.kgtxtCreatedByUserName.TrimEnd = true;
            this.kgtxtCreatedByUserName.TrimStart = true;
            this.kgtxtCreatedByUserName.IconRightClick += new System.EventHandler(this.kgtxtCreatedByUserName_IconRightClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(576, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 128;
            this.label4.Text = "الوصف";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(240, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 129;
            this.label5.Text = "تاريخ الإنشاء";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(549, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 126;
            this.label3.Text = "اسم الحساب";
            // 
            // gbtnSave
            // 
            this.gbtnSave.Animated = true;
            this.gbtnSave.AutoRoundedCorners = true;
            this.gbtnSave.BackColor = System.Drawing.Color.Transparent;
            this.gbtnSave.BorderColor = System.Drawing.Color.DimGray;
            this.gbtnSave.BorderThickness = 1;
            this.gbtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.gbtnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnSave.FillColor = System.Drawing.Color.White;
            this.gbtnSave.FocusedColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbtnSave.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbtnSave.ForeColor = System.Drawing.Color.Black;
            this.gbtnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnSave.HoverState.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnSave.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("gbtnSave.Image")));
            this.gbtnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnSave.ImageSize = new System.Drawing.Size(25, 25);
            this.gbtnSave.IndicateFocus = true;
            this.gbtnSave.Location = new System.Drawing.Point(185, 292);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.PressedColor = System.Drawing.Color.White;
            this.gbtnSave.Size = new System.Drawing.Size(283, 41);
            this.gbtnSave.TabIndex = 3;
            this.gbtnSave.Text = "حفظ";
            this.gbtnSave.Click += new System.EventHandler(this.gbtnSave_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Gray;
            this.guna2Panel1.BorderRadius = 8;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.lblAccountID);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.CustomizableEdges.BottomRight = false;
            this.guna2Panel1.CustomizableEdges.TopRight = false;
            this.guna2Panel1.Location = new System.Drawing.Point(75, 24);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(237, 41);
            this.guna2Panel1.TabIndex = 98;
            // 
            // lblAccountID
            // 
            this.lblAccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountID.Location = new System.Drawing.Point(9, 10);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAccountID.Size = new System.Drawing.Size(120, 23);
            this.lblAccountID.TabIndex = 96;
            this.lblAccountID.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 8);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 97;
            this.label2.Text = "معرف الحساب :";
            // 
            // kgtxtCreatedDate
            // 
            this.kgtxtCreatedDate.AllowWhiteSpace = false;
            this.kgtxtCreatedDate.ApplyTrimAtTextBoxValue = false;
            this.kgtxtCreatedDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtCreatedDate.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtCreatedDate.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtCreatedDate.BorderRadius = 10;
            this.kgtxtCreatedDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtCreatedDate.DefaultText = "";
            this.kgtxtCreatedDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtCreatedDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtCreatedDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtCreatedDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtCreatedDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtCreatedDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtCreatedDate.ForeColor = System.Drawing.Color.Black;
            this.kgtxtCreatedDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtCreatedDate.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtCreatedDate.IsRequired = false;
            this.kgtxtCreatedDate.Location = new System.Drawing.Point(29, 89);
            this.kgtxtCreatedDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtCreatedDate.MaxLength = 255;
            this.kgtxtCreatedDate.Name = "kgtxtCreatedDate";
            this.kgtxtCreatedDate.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtCreatedDate.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtCreatedDate.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtCreatedDate.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtCreatedDate.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtCreatedDate.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtCreatedDate.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtCreatedDate.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtCreatedDate.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtCreatedDate.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtCreatedDate.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtCreatedDate.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtCreatedDate.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtCreatedDate.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtCreatedDate.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtCreatedDate.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtCreatedDate.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtCreatedDate.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtCreatedDate.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtCreatedDate.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtCreatedDate.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtCreatedDate.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtCreatedDate.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtCreatedDate.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtCreatedDate.PlaceholderText = "تاريخ الإنشاء";
            this.kgtxtCreatedDate.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtCreatedDate.SelectedText = "";
            this.kgtxtCreatedDate.ShadowDecoration.BorderRadius = 2;
            this.kgtxtCreatedDate.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtCreatedDate.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtCreatedDate.Size = new System.Drawing.Size(283, 41);
            this.kgtxtCreatedDate.TabIndex = 4;
            this.kgtxtCreatedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtCreatedDate.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtCreatedDate.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtCreatedDate.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtCreatedDate.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.TwelveHours;
            this.kgtxtCreatedDate.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtCreatedDate.TextProperties.MinLength = ((short)(0));
            this.kgtxtCreatedDate.TextProperties.MinLengthOption = false;
            this.kgtxtCreatedDate.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtCreatedDate.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtCreatedDate.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Date;
            this.kgtxtCreatedDate.TrimEnd = false;
            this.kgtxtCreatedDate.TrimStart = false;
            // 
            // kgtxtAccountName
            // 
            this.kgtxtAccountName.AllowWhiteSpace = true;
            this.kgtxtAccountName.ApplyTrimAtTextBoxValue = false;
            this.kgtxtAccountName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtAccountName.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtAccountName.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtAccountName.BorderRadius = 10;
            this.kgtxtAccountName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtAccountName.DefaultText = "";
            this.kgtxtAccountName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtAccountName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtAccountName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtAccountName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtAccountName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtAccountName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtAccountName.ForeColor = System.Drawing.Color.Black;
            this.kgtxtAccountName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtAccountName.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtAccountName.IsRequired = true;
            this.kgtxtAccountName.Location = new System.Drawing.Point(342, 24);
            this.kgtxtAccountName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtAccountName.MaxLength = 150;
            this.kgtxtAccountName.Name = "kgtxtAccountName";
            this.kgtxtAccountName.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtAccountName.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtAccountName.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtAccountName.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtAccountName.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtAccountName.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtAccountName.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtAccountName.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtAccountName.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtAccountName.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtAccountName.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtAccountName.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtAccountName.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtAccountName.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtAccountName.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtAccountName.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtAccountName.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtAccountName.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtAccountName.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtAccountName.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtAccountName.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtAccountName.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtAccountName.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtAccountName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtAccountName.PlaceholderText = "اسم الحساب";
            this.kgtxtAccountName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtAccountName.SelectedText = "";
            this.kgtxtAccountName.ShadowDecoration.BorderRadius = 2;
            this.kgtxtAccountName.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtAccountName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtAccountName.Size = new System.Drawing.Size(283, 41);
            this.kgtxtAccountName.TabIndex = 0;
            this.kgtxtAccountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtAccountName.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtAccountName.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtAccountName.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtAccountName.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtAccountName.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtAccountName.TextProperties.MinLength = ((short)(0));
            this.kgtxtAccountName.TextProperties.MinLengthOption = false;
            this.kgtxtAccountName.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtAccountName.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtAccountName.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtAccountName.TrimEnd = true;
            this.kgtxtAccountName.TrimStart = true;
            this.kgtxtAccountName.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtAccountName.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // frmCurrentAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1210, 809);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmCurrentAccount";
            this.Text = "frmCurrentAccount";
            this.Shown += new System.EventHandler(this.frmCurrentAccount_Shown);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button gbtnSave;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.Label label2;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtDiscription;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtBalance;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtCreatedDate;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtAccountName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtDefaultCurrency;
        private System.Windows.Forms.Label label6;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtCreatedByUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}