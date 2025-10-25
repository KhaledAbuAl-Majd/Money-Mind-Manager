namespace MoneyMindManager_Presentation.Users
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.lblHeader = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbtnSave = new Guna.UI2.WinForms.Guna2Button();
            this.kgtxtOldPassword = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtConfirmNewPassword = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtNewpassword = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.gbtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlUserCard1 = new MoneyMindManager_Presentation.Users.ctrlUserCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2Panel2.SuspendLayout();
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
            this.lblHeader.TabIndex = 39;
            this.lblHeader.Text = "تغيير كلمة السر";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Controls.Add(this.gbtnSave);
            this.guna2Panel2.Controls.Add(this.kgtxtOldPassword);
            this.guna2Panel2.Controls.Add(this.kgtxtConfirmNewPassword);
            this.guna2Panel2.Controls.Add(this.kgtxtNewpassword);
            this.guna2Panel2.Controls.Add(this.gbtnClose);
            this.guna2Panel2.Controls.Add(this.ctrlUserCard1);
            this.guna2Panel2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel2.Location = new System.Drawing.Point(20, 79);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.guna2Panel2.ShadowDecoration.Depth = 20;
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.Size = new System.Drawing.Size(1178, 718);
            this.guna2Panel2.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(268, 605);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 128;
            this.label2.Text = "تأكيد كلمة السر الجديدة";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(658, 605);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 127;
            this.label1.Text = "كلمة السر الجديدة";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1016, 605);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 126;
            this.label3.Text = "كلمة السر القديمة";
            // 
            // gbtnSave
            // 
            this.gbtnSave.Animated = true;
            this.gbtnSave.AutoRoundedCorners = true;
            this.gbtnSave.BackColor = System.Drawing.Color.Transparent;
            this.gbtnSave.BorderColor = System.Drawing.Color.DimGray;
            this.gbtnSave.BorderThickness = 1;
            this.gbtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.gbtnSave.Location = new System.Drawing.Point(594, 671);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.PressedColor = System.Drawing.Color.White;
            this.gbtnSave.Size = new System.Drawing.Size(229, 41);
            this.gbtnSave.TabIndex = 125;
            this.gbtnSave.Text = "حفظ";
            this.gbtnSave.Click += new System.EventHandler(this.gbtnSave_Click);
            // 
            // kgtxtOldPassword
            // 
            this.kgtxtOldPassword.AllowWhiteSpace = true;
            this.kgtxtOldPassword.ApplyTrimAtTextBoxValue = false;
            this.kgtxtOldPassword.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtOldPassword.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtOldPassword.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtOldPassword.BorderRadius = 10;
            this.kgtxtOldPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtOldPassword.DefaultText = "";
            this.kgtxtOldPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtOldPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtOldPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtOldPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtOldPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtOldPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtOldPassword.ForeColor = System.Drawing.Color.Black;
            this.kgtxtOldPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtOldPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("kgtxtOldPassword.IconLeft")));
            this.kgtxtOldPassword.IconRight = global::MoneyMindManager_Presentation.Properties.Resources.crossed_eye_icon_256370;
            this.kgtxtOldPassword.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtOldPassword.IconRightOffset = new System.Drawing.Point(10, 0);
            this.kgtxtOldPassword.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtOldPassword.IsRequired = true;
            this.kgtxtOldPassword.Location = new System.Drawing.Point(780, 616);
            this.kgtxtOldPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtOldPassword.MaxLength = 200;
            this.kgtxtOldPassword.Name = "kgtxtOldPassword";
            this.kgtxtOldPassword.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtOldPassword.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtOldPassword.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtOldPassword.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtOldPassword.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtOldPassword.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtOldPassword.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtOldPassword.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtOldPassword.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtOldPassword.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtOldPassword.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtOldPassword.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtOldPassword.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtOldPassword.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtOldPassword.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtOldPassword.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtOldPassword.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtOldPassword.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtOldPassword.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtOldPassword.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtOldPassword.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtOldPassword.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtOldPassword.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtOldPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtOldPassword.PlaceholderText = "كلمة السر القديمة (مطلوب)";
            this.kgtxtOldPassword.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtOldPassword.SelectedText = "";
            this.kgtxtOldPassword.ShadowDecoration.BorderRadius = 2;
            this.kgtxtOldPassword.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtOldPassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtOldPassword.Size = new System.Drawing.Size(337, 41);
            this.kgtxtOldPassword.TabIndex = 1;
            this.kgtxtOldPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtOldPassword.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtOldPassword.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtOldPassword.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtOldPassword.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtOldPassword.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtOldPassword.TextProperties.MinLength = ((short)(4));
            this.kgtxtOldPassword.TextProperties.MinLengthOption = false;
            this.kgtxtOldPassword.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtOldPassword.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtOldPassword.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtOldPassword.TrimEnd = false;
            this.kgtxtOldPassword.TrimStart = false;
            this.kgtxtOldPassword.UseSystemPasswordChar = true;
            this.kgtxtOldPassword.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtOldPassword.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtOldPassword.IconRightClick += new System.EventHandler(this.kgtxtpassword_IconRightClick);
            // 
            // kgtxtConfirmNewPassword
            // 
            this.kgtxtConfirmNewPassword.AllowWhiteSpace = true;
            this.kgtxtConfirmNewPassword.ApplyTrimAtTextBoxValue = false;
            this.kgtxtConfirmNewPassword.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtConfirmNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtConfirmNewPassword.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtConfirmNewPassword.BorderRadius = 10;
            this.kgtxtConfirmNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtConfirmNewPassword.DefaultText = "";
            this.kgtxtConfirmNewPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtConfirmNewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtConfirmNewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtConfirmNewPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtConfirmNewPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtConfirmNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtConfirmNewPassword.ForeColor = System.Drawing.Color.Black;
            this.kgtxtConfirmNewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtConfirmNewPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("kgtxtConfirmNewPassword.IconLeft")));
            this.kgtxtConfirmNewPassword.IconRight = global::MoneyMindManager_Presentation.Properties.Resources.crossed_eye_icon_256370;
            this.kgtxtConfirmNewPassword.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtConfirmNewPassword.IconRightOffset = new System.Drawing.Point(10, 0);
            this.kgtxtConfirmNewPassword.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtConfirmNewPassword.IsRequired = true;
            this.kgtxtConfirmNewPassword.Location = new System.Drawing.Point(64, 616);
            this.kgtxtConfirmNewPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtConfirmNewPassword.MaxLength = 200;
            this.kgtxtConfirmNewPassword.Name = "kgtxtConfirmNewPassword";
            this.kgtxtConfirmNewPassword.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtConfirmNewPassword.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtConfirmNewPassword.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtConfirmNewPassword.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtConfirmNewPassword.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtConfirmNewPassword.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtConfirmNewPassword.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtConfirmNewPassword.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtConfirmNewPassword.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtConfirmNewPassword.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtConfirmNewPassword.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtConfirmNewPassword.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtConfirmNewPassword.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtConfirmNewPassword.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtConfirmNewPassword.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtConfirmNewPassword.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtConfirmNewPassword.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtConfirmNewPassword.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtConfirmNewPassword.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtConfirmNewPassword.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtConfirmNewPassword.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtConfirmNewPassword.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtConfirmNewPassword.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtConfirmNewPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtConfirmNewPassword.PlaceholderText = "تأكيد كلمة السر الجديدة (مطلوب)";
            this.kgtxtConfirmNewPassword.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtConfirmNewPassword.SelectedText = "";
            this.kgtxtConfirmNewPassword.ShadowDecoration.BorderRadius = 2;
            this.kgtxtConfirmNewPassword.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtConfirmNewPassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtConfirmNewPassword.Size = new System.Drawing.Size(337, 41);
            this.kgtxtConfirmNewPassword.TabIndex = 3;
            this.kgtxtConfirmNewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtConfirmNewPassword.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtConfirmNewPassword.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtConfirmNewPassword.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtConfirmNewPassword.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtConfirmNewPassword.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtConfirmNewPassword.TextProperties.MinLength = ((short)(4));
            this.kgtxtConfirmNewPassword.TextProperties.MinLengthOption = false;
            this.kgtxtConfirmNewPassword.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtConfirmNewPassword.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtConfirmNewPassword.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtConfirmNewPassword.TrimEnd = false;
            this.kgtxtConfirmNewPassword.TrimStart = false;
            this.kgtxtConfirmNewPassword.UseSystemPasswordChar = true;
            this.kgtxtConfirmNewPassword.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtConfirmNewPassword.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtConfirmPassword_OnValidationSuccess);
            this.kgtxtConfirmNewPassword.IconRightClick += new System.EventHandler(this.kgtxtpassword_IconRightClick);
            // 
            // kgtxtNewpassword
            // 
            this.kgtxtNewpassword.AllowWhiteSpace = true;
            this.kgtxtNewpassword.ApplyTrimAtTextBoxValue = false;
            this.kgtxtNewpassword.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtNewpassword.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtNewpassword.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtNewpassword.BorderRadius = 10;
            this.kgtxtNewpassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtNewpassword.DefaultText = "";
            this.kgtxtNewpassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtNewpassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtNewpassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtNewpassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtNewpassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtNewpassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtNewpassword.ForeColor = System.Drawing.Color.Black;
            this.kgtxtNewpassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtNewpassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("kgtxtNewpassword.IconLeft")));
            this.kgtxtNewpassword.IconRight = global::MoneyMindManager_Presentation.Properties.Resources.crossed_eye_icon_256370;
            this.kgtxtNewpassword.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtNewpassword.IconRightOffset = new System.Drawing.Point(10, 0);
            this.kgtxtNewpassword.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtNewpassword.IsRequired = true;
            this.kgtxtNewpassword.Location = new System.Drawing.Point(422, 616);
            this.kgtxtNewpassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtNewpassword.MaxLength = 200;
            this.kgtxtNewpassword.Name = "kgtxtNewpassword";
            this.kgtxtNewpassword.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtNewpassword.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtNewpassword.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtNewpassword.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtNewpassword.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtNewpassword.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtNewpassword.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtNewpassword.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtNewpassword.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtNewpassword.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtNewpassword.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtNewpassword.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtNewpassword.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtNewpassword.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtNewpassword.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtNewpassword.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtNewpassword.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtNewpassword.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtNewpassword.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtNewpassword.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtNewpassword.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtNewpassword.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtNewpassword.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtNewpassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtNewpassword.PlaceholderText = "كلمة السر الجديدة (مطلوب)";
            this.kgtxtNewpassword.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtNewpassword.SelectedText = "";
            this.kgtxtNewpassword.ShadowDecoration.BorderRadius = 2;
            this.kgtxtNewpassword.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtNewpassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtNewpassword.Size = new System.Drawing.Size(337, 41);
            this.kgtxtNewpassword.TabIndex = 2;
            this.kgtxtNewpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtNewpassword.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtNewpassword.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtNewpassword.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtNewpassword.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtNewpassword.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtNewpassword.TextProperties.MinLength = ((short)(4));
            this.kgtxtNewpassword.TextProperties.MinLengthOption = true;
            this.kgtxtNewpassword.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtNewpassword.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtNewpassword.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtNewpassword.TrimEnd = false;
            this.kgtxtNewpassword.TrimStart = false;
            this.kgtxtNewpassword.UseSystemPasswordChar = true;
            this.kgtxtNewpassword.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtNewpassword.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtNewpassword.IconRightClick += new System.EventHandler(this.kgtxtpassword_IconRightClick);
            // 
            // gbtnClose
            // 
            this.gbtnClose.Animated = true;
            this.gbtnClose.AutoRoundedCorners = true;
            this.gbtnClose.BackColor = System.Drawing.Color.Transparent;
            this.gbtnClose.BorderColor = System.Drawing.Color.DimGray;
            this.gbtnClose.BorderThickness = 1;
            this.gbtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.gbtnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnClose.FillColor = System.Drawing.Color.White;
            this.gbtnClose.FocusedColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbtnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbtnClose.ForeColor = System.Drawing.Color.Black;
            this.gbtnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnClose.HoverState.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("gbtnClose.Image")));
            this.gbtnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnClose.ImageSize = new System.Drawing.Size(25, 25);
            this.gbtnClose.IndicateFocus = true;
            this.gbtnClose.Location = new System.Drawing.Point(358, 671);
            this.gbtnClose.Name = "gbtnClose";
            this.gbtnClose.PressedColor = System.Drawing.Color.White;
            this.gbtnClose.Size = new System.Drawing.Size(229, 41);
            this.gbtnClose.TabIndex = 121;
            this.gbtnClose.Text = "غلق";
            this.gbtnClose.Click += new System.EventHandler(this.gbtnClose_Click);
            // 
            // ctrlUserCard1
            // 
            this.ctrlUserCard1.BackColor = System.Drawing.Color.White;
            this.ctrlUserCard1.Location = new System.Drawing.Point(30, 10);
            this.ctrlUserCard1.Name = "ctrlUserCard1";
            this.ctrlUserCard1.Size = new System.Drawing.Size(1125, 603);
            this.ctrlUserCard1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.gbtnClose;
            this.ClientSize = new System.Drawing.Size(1210, 809);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChangePassword";
            this.Text = "frmChangePassword";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button gbtnClose;
        private ctrlUserCard ctrlUserCard1;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtOldPassword;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtConfirmNewPassword;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtNewpassword;
        private Guna.UI2.WinForms.Guna2Button gbtnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}