using System.ComponentModel;

namespace MoneyMindManager_Presentation.Users
{
    partial class frmAddUpdateUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateUser));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblUserID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gtswIsActive = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.gbtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.gpnlUserPart = new Guna.UI2.WinForms.Guna2Panel();
            this.gibtnDeleteUser = new Guna.UI2.WinForms.Guna2ImageButton();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.chklbUserPermissions = new System.Windows.Forms.CheckedListBox();
            this.kgtxtConfirmPassword = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.kgtxtpassword = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbluserMessage = new System.Windows.Forms.Label();
            this.kgtxtUserName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtNotes = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.gbtnSave = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlPersonCardWithFilter1 = new MoneyMindManager_Presentation.People.Controls.ctrlPersonCardWithFilter();
            this.lblHeader = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.gpnlUserPart.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblUserID
            // 
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(112, 10);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserID.Size = new System.Drawing.Size(151, 23);
            this.lblUserID.TabIndex = 96;
            this.lblUserID.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(267, 10);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(115, 24);
            this.label2.TabIndex = 97;
            this.label2.Text = "معرف المستخدم :";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Gray;
            this.guna2Panel1.BorderRadius = 8;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.gtswIsActive);
            this.guna2Panel1.Controls.Add(this.lblUserID);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.CustomizableEdges.BottomRight = false;
            this.guna2Panel1.CustomizableEdges.TopRight = false;
            this.guna2Panel1.Location = new System.Drawing.Point(39, 41);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(382, 41);
            this.guna2Panel1.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 10);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 98;
            this.label1.Text = "الفعالية";
            // 
            // gtswIsActive
            // 
            this.gtswIsActive.Animated = true;
            this.gtswIsActive.AutoRoundedCorners = true;
            this.gtswIsActive.Checked = true;
            this.gtswIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gtswIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gtswIsActive.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.gtswIsActive.CheckedState.InnerColor = System.Drawing.Color.White;
            this.gtswIsActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gtswIsActive.Location = new System.Drawing.Point(19, 13);
            this.gtswIsActive.Name = "gtswIsActive";
            this.gtswIsActive.Size = new System.Drawing.Size(35, 20);
            this.gtswIsActive.TabIndex = 99;
            this.gtswIsActive.UncheckedState.BorderColor = System.Drawing.Color.Silver;
            this.gtswIsActive.UncheckedState.BorderThickness = 1;
            this.gtswIsActive.UncheckedState.FillColor = System.Drawing.Color.White;
            this.gtswIsActive.UncheckedState.InnerBorderColor = System.Drawing.Color.WhiteSmoke;
            this.gtswIsActive.UncheckedState.InnerColor = System.Drawing.Color.Gray;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.gbtnClose);
            this.guna2Panel2.Controls.Add(this.gpnlUserPart);
            this.guna2Panel2.Controls.Add(this.gbtnSave);
            this.guna2Panel2.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.guna2Panel2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel2.Location = new System.Drawing.Point(84, 89);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.guna2Panel2.ShadowDecoration.Depth = 20;
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.Size = new System.Drawing.Size(1046, 679);
            this.guna2Panel2.TabIndex = 11;
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
            this.gbtnClose.Location = new System.Drawing.Point(48, 615);
            this.gbtnClose.Name = "gbtnClose";
            this.gbtnClose.PressedColor = System.Drawing.Color.White;
            this.gbtnClose.Size = new System.Drawing.Size(180, 41);
            this.gbtnClose.TabIndex = 6;
            this.gbtnClose.Text = "غلق";
            this.gbtnClose.Click += new System.EventHandler(this.gbtnClose_Click);
            // 
            // gpnlUserPart
            // 
            this.gpnlUserPart.Controls.Add(this.gibtnDeleteUser);
            this.gpnlUserPart.Controls.Add(this.label4);
            this.gpnlUserPart.Controls.Add(this.guna2Panel3);
            this.gpnlUserPart.Controls.Add(this.kgtxtConfirmPassword);
            this.gpnlUserPart.Controls.Add(this.label5);
            this.gpnlUserPart.Controls.Add(this.kgtxtpassword);
            this.gpnlUserPart.Controls.Add(this.label3);
            this.gpnlUserPart.Controls.Add(this.lbluserMessage);
            this.gpnlUserPart.Controls.Add(this.guna2Panel1);
            this.gpnlUserPart.Controls.Add(this.kgtxtUserName);
            this.gpnlUserPart.Controls.Add(this.kgtxtNotes);
            this.gpnlUserPart.Location = new System.Drawing.Point(9, 16);
            this.gpnlUserPart.Name = "gpnlUserPart";
            this.gpnlUserPart.Size = new System.Drawing.Size(456, 593);
            this.gpnlUserPart.TabIndex = 14;
            // 
            // gibtnDeleteUser
            // 
            this.gibtnDeleteUser.BackColor = System.Drawing.Color.Transparent;
            this.gibtnDeleteUser.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnDeleteUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gibtnDeleteUser.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.gibtnDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("gibtnDeleteUser.Image")));
            this.gibtnDeleteUser.ImageOffset = new System.Drawing.Point(0, 0);
            this.gibtnDeleteUser.ImageRotate = 0F;
            this.gibtnDeleteUser.ImageSize = new System.Drawing.Size(28, 28);
            this.gibtnDeleteUser.Location = new System.Drawing.Point(3, 41);
            this.gibtnDeleteUser.Name = "gibtnDeleteUser";
            this.gibtnDeleteUser.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnDeleteUser.Size = new System.Drawing.Size(33, 42);
            this.gibtnDeleteUser.TabIndex = 139;
            this.toolTip1.SetToolTip(this.gibtnDeleteUser, "حذف المستخدم نهائيا");
            this.gibtnDeleteUser.UseTransparentBackground = true;
            this.gibtnDeleteUser.Click += new System.EventHandler(this.gibtnDeleteUser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 138;
            this.label4.Text = "صلاحيات المستخدم";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel3.BorderRadius = 10;
            this.guna2Panel3.BorderThickness = 1;
            this.guna2Panel3.Controls.Add(this.chklbUserPermissions);
            this.guna2Panel3.Location = new System.Drawing.Point(39, 377);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(377, 213);
            this.guna2Panel3.TabIndex = 137;
            // 
            // chklbUserPermissions
            // 
            this.chklbUserPermissions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chklbUserPermissions.CheckOnClick = true;
            this.chklbUserPermissions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chklbUserPermissions.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklbUserPermissions.FormattingEnabled = true;
            this.chklbUserPermissions.HorizontalScrollbar = true;
            this.chklbUserPermissions.Location = new System.Drawing.Point(3, 6);
            this.chklbUserPermissions.Name = "chklbUserPermissions";
            this.chklbUserPermissions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chklbUserPermissions.Size = new System.Drawing.Size(371, 198);
            this.chklbUserPermissions.TabIndex = 4;
            this.chklbUserPermissions.Leave += new System.EventHandler(this.chklbUserPermissions_Leave);
            // 
            // kgtxtConfirmPassword
            // 
            this.kgtxtConfirmPassword.AllowWhiteSpace = true;
            this.kgtxtConfirmPassword.ApplyTrimAtTextBoxValue = false;
            this.kgtxtConfirmPassword.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtConfirmPassword.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtConfirmPassword.BorderRadius = 10;
            this.kgtxtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtConfirmPassword.DefaultText = "";
            this.kgtxtConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtConfirmPassword.ForeColor = System.Drawing.Color.Black;
            this.kgtxtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtConfirmPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("kgtxtConfirmPassword.IconLeft")));
            this.kgtxtConfirmPassword.IconRight = global::MoneyMindManager_Presentation.Properties.Resources.crossed_eye_icon_256370;
            this.kgtxtConfirmPassword.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtConfirmPassword.IconRightOffset = new System.Drawing.Point(10, 0);
            this.kgtxtConfirmPassword.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtConfirmPassword.IsRequired = true;
            this.kgtxtConfirmPassword.Location = new System.Drawing.Point(39, 319);
            this.kgtxtConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtConfirmPassword.MaxLength = 200;
            this.kgtxtConfirmPassword.Name = "kgtxtConfirmPassword";
            this.kgtxtConfirmPassword.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtConfirmPassword.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtConfirmPassword.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtConfirmPassword.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtConfirmPassword.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtConfirmPassword.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtConfirmPassword.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtConfirmPassword.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtConfirmPassword.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtConfirmPassword.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtConfirmPassword.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtConfirmPassword.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtConfirmPassword.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtConfirmPassword.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtConfirmPassword.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtConfirmPassword.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtConfirmPassword.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtConfirmPassword.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtConfirmPassword.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtConfirmPassword.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtConfirmPassword.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtConfirmPassword.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtConfirmPassword.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtConfirmPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtConfirmPassword.PlaceholderText = "تأكيد كلمة السر (مطلوب)";
            this.kgtxtConfirmPassword.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtConfirmPassword.SelectedText = "";
            this.kgtxtConfirmPassword.ShadowDecoration.BorderRadius = 2;
            this.kgtxtConfirmPassword.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtConfirmPassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtConfirmPassword.Size = new System.Drawing.Size(382, 41);
            this.kgtxtConfirmPassword.TabIndex = 3;
            this.kgtxtConfirmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtConfirmPassword.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtConfirmPassword.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtConfirmPassword.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtConfirmPassword.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtConfirmPassword.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtConfirmPassword.TextProperties.MinLength = ((short)(4));
            this.kgtxtConfirmPassword.TextProperties.MinLengthOption = false;
            this.kgtxtConfirmPassword.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtConfirmPassword.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtConfirmPassword.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtConfirmPassword.TrimEnd = false;
            this.kgtxtConfirmPassword.TrimStart = false;
            this.kgtxtConfirmPassword.UseSystemPasswordChar = true;
            this.kgtxtConfirmPassword.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtConfirmPassword.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtConfirmPassword.After_kgtxt_Validating += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.AfterMyValidatingEventArgs>(this.kgtxtConfirmPassword_After_kgtxt_Validating);
            this.kgtxtConfirmPassword.IconRightClick += new System.EventHandler(this.kgtxtpassword_IconRightClick);
            this.kgtxtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kgtxt_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(334, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 122;
            this.label5.Text = "اسم المستخدم";
            // 
            // kgtxtpassword
            // 
            this.kgtxtpassword.AllowWhiteSpace = true;
            this.kgtxtpassword.ApplyTrimAtTextBoxValue = false;
            this.kgtxtpassword.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtpassword.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtpassword.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtpassword.BorderRadius = 10;
            this.kgtxtpassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtpassword.DefaultText = "";
            this.kgtxtpassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtpassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtpassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtpassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtpassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtpassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtpassword.ForeColor = System.Drawing.Color.Black;
            this.kgtxtpassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtpassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("kgtxtpassword.IconLeft")));
            this.kgtxtpassword.IconRight = global::MoneyMindManager_Presentation.Properties.Resources.crossed_eye_icon_256370;
            this.kgtxtpassword.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtpassword.IconRightOffset = new System.Drawing.Point(10, 0);
            this.kgtxtpassword.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtpassword.IsRequired = true;
            this.kgtxtpassword.Location = new System.Drawing.Point(39, 266);
            this.kgtxtpassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtpassword.MaxLength = 200;
            this.kgtxtpassword.Name = "kgtxtpassword";
            this.kgtxtpassword.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtpassword.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtpassword.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtpassword.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtpassword.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtpassword.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtpassword.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtpassword.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtpassword.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtpassword.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtpassword.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtpassword.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtpassword.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtpassword.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtpassword.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtpassword.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtpassword.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtpassword.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtpassword.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtpassword.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtpassword.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtpassword.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtpassword.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtpassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtpassword.PlaceholderText = "كلمة السر (مطلوب)";
            this.kgtxtpassword.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtpassword.SelectedText = "";
            this.kgtxtpassword.ShadowDecoration.BorderRadius = 2;
            this.kgtxtpassword.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtpassword.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtpassword.Size = new System.Drawing.Size(382, 41);
            this.kgtxtpassword.TabIndex = 2;
            this.kgtxtpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtpassword.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtpassword.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtpassword.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtpassword.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtpassword.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtpassword.TextProperties.MinLength = ((short)(4));
            this.kgtxtpassword.TextProperties.MinLengthOption = true;
            this.kgtxtpassword.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtpassword.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtpassword.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtpassword.TrimEnd = false;
            this.kgtxtpassword.TrimStart = false;
            this.kgtxtpassword.UseSystemPasswordChar = true;
            this.kgtxtpassword.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtpassword.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtpassword.IconRightClick += new System.EventHandler(this.kgtxtpassword_IconRightClick);
            this.kgtxtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kgtxt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(364, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 123;
            this.label3.Text = "ملاحظات";
            // 
            // lbluserMessage
            // 
            this.lbluserMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserMessage.ForeColor = System.Drawing.Color.Red;
            this.lbluserMessage.Location = new System.Drawing.Point(3, 5);
            this.lbluserMessage.Name = "lbluserMessage";
            this.lbluserMessage.Size = new System.Drawing.Size(450, 34);
            this.lbluserMessage.TabIndex = 13;
            this.lbluserMessage.Text = "إضافة مستخدم";
            this.lbluserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kgtxtUserName
            // 
            this.kgtxtUserName.AllowWhiteSpace = false;
            this.kgtxtUserName.ApplyTrimAtTextBoxValue = false;
            this.kgtxtUserName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtUserName.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtUserName.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtUserName.BorderRadius = 10;
            this.kgtxtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtUserName.DefaultText = "";
            this.kgtxtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtUserName.ForeColor = System.Drawing.Color.Black;
            this.kgtxtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtUserName.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtUserName.IsRequired = true;
            this.kgtxtUserName.Location = new System.Drawing.Point(39, 94);
            this.kgtxtUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtUserName.MaxLength = 30;
            this.kgtxtUserName.Name = "kgtxtUserName";
            this.kgtxtUserName.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtUserName.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtUserName.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtUserName.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtUserName.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtUserName.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtUserName.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtUserName.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtUserName.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtUserName.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtUserName.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtUserName.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtUserName.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtUserName.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtUserName.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtUserName.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtUserName.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtUserName.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtUserName.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtUserName.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtUserName.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtUserName.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtUserName.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtUserName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtUserName.PlaceholderText = "اسم المستخدم (مطلوب - فريد)";
            this.kgtxtUserName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtUserName.SelectedText = "";
            this.kgtxtUserName.ShadowDecoration.BorderRadius = 2;
            this.kgtxtUserName.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtUserName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtUserName.Size = new System.Drawing.Size(382, 41);
            this.kgtxtUserName.TabIndex = 0;
            this.kgtxtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtUserName.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtUserName.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtUserName.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtUserName.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtUserName.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtUserName.TextProperties.MinLength = ((short)(0));
            this.kgtxtUserName.TextProperties.MinLengthOption = false;
            this.kgtxtUserName.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtUserName.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtUserName.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtUserName.TrimEnd = true;
            this.kgtxtUserName.TrimStart = true;
            this.kgtxtUserName.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtUserName.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtUserName.After_kgtxt_Validating += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.AfterMyValidatingEventArgs>(this.kgtxtUserName_After_kgtxt_Validating_1);
            this.kgtxtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kgtxt_KeyPress);
            // 
            // kgtxtNotes
            // 
            this.kgtxtNotes.AllowWhiteSpace = true;
            this.kgtxtNotes.ApplyTrimAtTextBoxValue = false;
            this.kgtxtNotes.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtNotes.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtNotes.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtNotes.BorderRadius = 10;
            this.kgtxtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtNotes.DefaultText = "";
            this.kgtxtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtNotes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtNotes.ForeColor = System.Drawing.Color.Black;
            this.kgtxtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtNotes.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtNotes.IsRequired = false;
            this.kgtxtNotes.Location = new System.Drawing.Point(39, 146);
            this.kgtxtNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtNotes.MaxLength = 200;
            this.kgtxtNotes.Multiline = true;
            this.kgtxtNotes.Name = "kgtxtNotes";
            this.kgtxtNotes.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtNotes.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtNotes.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtNotes.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtNotes.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtNotes.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtNotes.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtNotes.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtNotes.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtNotes.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtNotes.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtNotes.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtNotes.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtNotes.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtNotes.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtNotes.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtNotes.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtNotes.PlaceholderText = "ملاحظات (اختياري)";
            this.kgtxtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.kgtxtNotes.SelectedText = "";
            this.kgtxtNotes.ShadowDecoration.BorderRadius = 2;
            this.kgtxtNotes.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtNotes.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtNotes.Size = new System.Drawing.Size(382, 107);
            this.kgtxtNotes.TabIndex = 1;
            this.kgtxtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtNotes.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtNotes.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtNotes.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtNotes.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtNotes.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtNotes.TextProperties.MinLength = ((short)(0));
            this.kgtxtNotes.TextProperties.MinLengthOption = false;
            this.kgtxtNotes.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtNotes.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtNotes.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Phone;
            this.kgtxtNotes.TrimEnd = false;
            this.kgtxtNotes.TrimStart = false;
            this.kgtxtNotes.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtNotes.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtNotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kgtxt_KeyPress);
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
            this.gbtnSave.Location = new System.Drawing.Point(237, 615);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.PressedColor = System.Drawing.Color.White;
            this.gbtnSave.Size = new System.Drawing.Size(193, 41);
            this.gbtnSave.TabIndex = 5;
            this.gbtnSave.Text = "حفظ";
            this.gbtnSave.Click += new System.EventHandler(this.gbtnSave_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCardWithFilter1.EnablityOfSearchPart = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(468, 16);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(575, 640);
            this.ctrlPersonCardWithFilter1.TabIndex = 13;
            this.ctrlPersonCardWithFilter1.OnSuccess += new System.Action(this.ctrlPersonCardWithFilter1_OnSuccess);
            this.ctrlPersonCardWithFilter1.OnFailed += new System.Action(this.ctrlPersonCardWithFilter1_OnFailed);
            this.ctrlPersonCardWithFilter1.OnEditingPerson += new System.Action(this.ctrlPersonCardWithFilter1_OnEditingPerson);
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1210, 60);
            this.lblHeader.TabIndex = 37;
            this.lblHeader.Text = "إضافة مستخدم";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.gbtnClose;
            this.ClientSize = new System.Drawing.Size(1210, 809);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateUser";
            this.Text = "frmAddUpdateUser";
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.gpnlUserPart.ResumeLayout(false);
            this.gpnlUserPart.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label2;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtNotes;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtUserName;
        private People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private Guna.UI2.WinForms.Guna2ToggleSwitch gtswIsActive;
        private System.Windows.Forms.Label label1;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtpassword;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtConfirmPassword;
        private Guna.UI2.WinForms.Guna2Panel gpnlUserPart;
        private System.Windows.Forms.Label lbluserMessage;
        private System.Windows.Forms.Label lblHeader;
        private Guna.UI2.WinForms.Guna2Button gbtnClose;
        private Guna.UI2.WinForms.Guna2Button gbtnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.CheckedListBox chklbUserPermissions;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnDeleteUser;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}