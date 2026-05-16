namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    partial class frmAddUpdateDebt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateDebt));
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.kgtxtNotes = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtDebtDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gchkIsLocked = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kgtxtCreatedDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.kgtxtRemainingAmount = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtCreatedByUserName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbtnSave = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.label8 = new System.Windows.Forms.Label();
            this.kgtxtDebtID = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.gibtnDeleteDebt = new Guna.UI2.WinForms.Guna2ImageButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.kgtxtPersonName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gcbDebtType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.kgtxtPaymentDueDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.gtabcDebtTransactions = new Guna.UI2.WinForms.Guna2TabControl();
            this.gtabDebtEntries = new System.Windows.Forms.TabPage();
            this.gtabDebtPayments = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.kgtxtTotalPaid = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.kgtxtTotalValue = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.ctrDebtEntriesList1 = new MoneyMindManager.UI.Forms.Debts.DebtEntry.ctrDebtEntriesList();
            this.ctrDebtPaymentsList1 = new MoneyMindManager.UI.Forms.Debts.DebtPayment.ctrDebtPaymentsList();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gtabcDebtTransactions.SuspendLayout();
            this.gtabDebtEntries.SuspendLayout();
            this.gtabDebtPayments.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblUserMessage.Location = new System.Drawing.Point(30, 57);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserMessage.Size = new System.Drawing.Size(1148, 30);
            this.lblUserMessage.TabIndex = 39;
            this.lblUserMessage.Text = "\"تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.\"";
            this.lblUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1210, 60);
            this.lblHeader.TabIndex = 41;
            this.lblHeader.Text = "إضافة شخص";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.kgtxtNotes.Location = new System.Drawing.Point(850, 150);
            this.kgtxtNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtNotes.MaxLength = 150;
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
            this.kgtxtNotes.Size = new System.Drawing.Size(337, 95);
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
            // 
            // kgtxtDebtDate
            // 
            this.kgtxtDebtDate.AllowWhiteSpace = false;
            this.kgtxtDebtDate.Animated = true;
            this.kgtxtDebtDate.ApplyTrimAtTextBoxValue = false;
            this.kgtxtDebtDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtDebtDate.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtDebtDate.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtDebtDate.BorderRadius = 10;
            this.kgtxtDebtDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtDebtDate.DefaultText = "";
            this.kgtxtDebtDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtDebtDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtDebtDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtDebtDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtDebtDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtDebtDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtDebtDate.ForeColor = System.Drawing.Color.Black;
            this.kgtxtDebtDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtDebtDate.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtDebtDate.IsRequired = true;
            this.kgtxtDebtDate.Location = new System.Drawing.Point(602, 97);
            this.kgtxtDebtDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtDebtDate.MaxLength = 30;
            this.kgtxtDebtDate.Name = "kgtxtDebtDate";
            this.kgtxtDebtDate.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtDebtDate.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtDebtDate.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtDebtDate.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtDebtDate.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtDebtDate.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtDebtDate.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtDebtDate.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtDebtDate.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtDebtDate.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtDebtDate.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtDebtDate.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtDebtDate.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtDebtDate.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtDebtDate.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtDebtDate.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtDebtDate.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtDebtDate.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtDebtDate.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtDebtDate.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtDebtDate.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtDebtDate.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtDebtDate.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtDebtDate.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtDebtDate.PlaceholderText = "تاريخ السند (مطلوب)";
            this.kgtxtDebtDate.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtDebtDate.SelectedText = "";
            this.kgtxtDebtDate.ShadowDecoration.BorderRadius = 2;
            this.kgtxtDebtDate.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtDebtDate.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtDebtDate.Size = new System.Drawing.Size(220, 41);
            this.kgtxtDebtDate.TabIndex = 2;
            this.kgtxtDebtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtDebtDate.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtDebtDate.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtDebtDate.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtDebtDate.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtDebtDate.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtDebtDate.TextProperties.MinLength = ((short)(0));
            this.kgtxtDebtDate.TextProperties.MinLengthOption = false;
            this.kgtxtDebtDate.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtDebtDate.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtDebtDate.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Date;
            this.kgtxtDebtDate.TrimEnd = true;
            this.kgtxtDebtDate.TrimStart = true;
            this.kgtxtDebtDate.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtDebtDate.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(761, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 106;
            this.label4.Text = "تاريخ السند";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1133, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 107;
            this.label5.Text = "ملاحظات";
            // 
            // gchkIsLocked
            // 
            this.gchkIsLocked.Animated = true;
            this.gchkIsLocked.AutoSize = true;
            this.gchkIsLocked.Checked = true;
            this.gchkIsLocked.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gchkIsLocked.CheckedState.BorderRadius = 0;
            this.gchkIsLocked.CheckedState.BorderThickness = 0;
            this.gchkIsLocked.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gchkIsLocked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gchkIsLocked.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gchkIsLocked.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gchkIsLocked.Location = new System.Drawing.Point(67, 210);
            this.gchkIsLocked.Name = "gchkIsLocked";
            this.gchkIsLocked.Size = new System.Drawing.Size(64, 25);
            this.gchkIsLocked.TabIndex = 9;
            this.gchkIsLocked.Text = "مغلق";
            this.gchkIsLocked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gchkIsLocked.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gchkIsLocked.UncheckedState.BorderRadius = 0;
            this.gchkIsLocked.UncheckedState.BorderThickness = 0;
            this.gchkIsLocked.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gchkIsLocked.CheckedChanged += new System.EventHandler(this.gchkIsLocked_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(756, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 110;
            this.label2.Text = "تاريخ الإنشاء";
            // 
            // kgtxtCreatedDate
            // 
            this.kgtxtCreatedDate.AllowWhiteSpace = true;
            this.kgtxtCreatedDate.Animated = true;
            this.kgtxtCreatedDate.ApplyTrimAtTextBoxValue = true;
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
            this.kgtxtCreatedDate.Location = new System.Drawing.Point(602, 204);
            this.kgtxtCreatedDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtCreatedDate.MaxLength = 150;
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
            this.kgtxtCreatedDate.ReadOnly = true;
            this.kgtxtCreatedDate.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtCreatedDate.SelectedText = "";
            this.kgtxtCreatedDate.ShadowDecoration.BorderRadius = 2;
            this.kgtxtCreatedDate.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtCreatedDate.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtCreatedDate.Size = new System.Drawing.Size(220, 41);
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
            this.kgtxtCreatedDate.TrimEnd = true;
            this.kgtxtCreatedDate.TrimStart = true;
            this.kgtxtCreatedDate.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtCreatedDate.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(460, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 17);
            this.label6.TabIndex = 112;
            this.label6.Text = "القيمة المتبقية للسداد";
            // 
            // kgtxtRemainingAmount
            // 
            this.kgtxtRemainingAmount.AllowWhiteSpace = true;
            this.kgtxtRemainingAmount.ApplyTrimAtTextBoxValue = false;
            this.kgtxtRemainingAmount.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtRemainingAmount.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtRemainingAmount.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtRemainingAmount.BorderRadius = 10;
            this.kgtxtRemainingAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtRemainingAmount.DefaultText = "";
            this.kgtxtRemainingAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtRemainingAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtRemainingAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtRemainingAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtRemainingAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtRemainingAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtRemainingAmount.ForeColor = System.Drawing.Color.Black;
            this.kgtxtRemainingAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtRemainingAmount.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtRemainingAmount.IsRequired = false;
            this.kgtxtRemainingAmount.Location = new System.Drawing.Point(362, 205);
            this.kgtxtRemainingAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtRemainingAmount.MaxLength = 150;
            this.kgtxtRemainingAmount.Name = "kgtxtRemainingAmount";
            this.kgtxtRemainingAmount.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtRemainingAmount.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtRemainingAmount.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtRemainingAmount.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtRemainingAmount.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtRemainingAmount.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtRemainingAmount.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtRemainingAmount.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtRemainingAmount.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtRemainingAmount.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtRemainingAmount.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtRemainingAmount.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtRemainingAmount.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtRemainingAmount.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtRemainingAmount.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtRemainingAmount.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtRemainingAmount.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtRemainingAmount.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtRemainingAmount.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtRemainingAmount.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtRemainingAmount.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtRemainingAmount.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.N4;
            this.kgtxtRemainingAmount.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber;
            this.kgtxtRemainingAmount.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtRemainingAmount.PlaceholderText = "القيمة المتبقية للسداد";
            this.kgtxtRemainingAmount.ReadOnly = true;
            this.kgtxtRemainingAmount.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtRemainingAmount.SelectedText = "";
            this.kgtxtRemainingAmount.ShadowDecoration.BorderRadius = 2;
            this.kgtxtRemainingAmount.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtRemainingAmount.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtRemainingAmount.Size = new System.Drawing.Size(220, 41);
            this.kgtxtRemainingAmount.TabIndex = 6;
            this.kgtxtRemainingAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtRemainingAmount.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtRemainingAmount.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtRemainingAmount.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtRemainingAmount.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtRemainingAmount.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtRemainingAmount.TextProperties.MinLength = ((short)(0));
            this.kgtxtRemainingAmount.TextProperties.MinLengthOption = false;
            this.kgtxtRemainingAmount.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtRemainingAmount.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtRemainingAmount.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtRemainingAmount.TrimEnd = true;
            this.kgtxtRemainingAmount.TrimStart = true;
            // 
            // kgtxtCreatedByUserName
            // 
            this.kgtxtCreatedByUserName.AllowWhiteSpace = true;
            this.kgtxtCreatedByUserName.Animated = true;
            this.kgtxtCreatedByUserName.ApplyTrimAtTextBoxValue = true;
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
            this.kgtxtCreatedByUserName.Location = new System.Drawing.Point(143, 204);
            this.kgtxtCreatedByUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtCreatedByUserName.MaxLength = 200;
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
            this.kgtxtCreatedByUserName.PlaceholderText = "اسم المستخدم للمنشئ ";
            this.kgtxtCreatedByUserName.ReadOnly = true;
            this.kgtxtCreatedByUserName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtCreatedByUserName.SelectedText = "";
            this.kgtxtCreatedByUserName.ShadowDecoration.BorderRadius = 2;
            this.kgtxtCreatedByUserName.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtCreatedByUserName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtCreatedByUserName.Size = new System.Drawing.Size(201, 41);
            this.kgtxtCreatedByUserName.TabIndex = 4;
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
            this.kgtxtCreatedByUserName.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Date;
            this.toolTip1.SetToolTip(this.kgtxtCreatedByUserName, "اضغط على الأيقونة اليمنى لرؤية بيانات المستخدم المنشئ");
            this.kgtxtCreatedByUserName.TrimEnd = true;
            this.kgtxtCreatedByUserName.TrimStart = true;
            this.kgtxtCreatedByUserName.IconRightClick += new System.EventHandler(this.kgtxtCreatedByUserName_IconRightClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(215, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 17);
            this.label7.TabIndex = 114;
            this.label7.Text = "اسم المستخدم للمنشئ ";
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
            this.gbtnSave.Location = new System.Drawing.Point(18, 97);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.PressedColor = System.Drawing.Color.White;
            this.gbtnSave.Size = new System.Drawing.Size(174, 41);
            this.gbtnSave.TabIndex = 11;
            this.gbtnSave.Text = "حفظ";
            this.gbtnSave.Click += new System.EventHandler(this.gbtnSave_Click);
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
            this.gbtnClose.Location = new System.Drawing.Point(18, 150);
            this.gbtnClose.Name = "gbtnClose";
            this.gbtnClose.PressedColor = System.Drawing.Color.White;
            this.gbtnClose.Size = new System.Drawing.Size(174, 41);
            this.gbtnClose.TabIndex = 12;
            this.gbtnClose.Text = "غلق";
            this.gbtnClose.Click += new System.EventHandler(this.gbtnClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(273, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 17);
            this.label8.TabIndex = 116;
            this.label8.Text = "معرف السند";
            // 
            // kgtxtDebtID
            // 
            this.kgtxtDebtID.AllowWhiteSpace = true;
            this.kgtxtDebtID.ApplyTrimAtTextBoxValue = true;
            this.kgtxtDebtID.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtDebtID.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtDebtID.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtDebtID.BorderRadius = 10;
            this.kgtxtDebtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtDebtID.DefaultText = "1234567891";
            this.kgtxtDebtID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtDebtID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtDebtID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtDebtID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtDebtID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtDebtID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtDebtID.ForeColor = System.Drawing.Color.Black;
            this.kgtxtDebtID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtDebtID.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtDebtID.IsRequired = false;
            this.kgtxtDebtID.Location = new System.Drawing.Point(206, 97);
            this.kgtxtDebtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtDebtID.MaxLength = 150;
            this.kgtxtDebtID.Name = "kgtxtDebtID";
            this.kgtxtDebtID.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtDebtID.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtDebtID.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtDebtID.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtDebtID.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtDebtID.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtDebtID.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtDebtID.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtDebtID.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtDebtID.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtDebtID.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtDebtID.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtDebtID.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtDebtID.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtDebtID.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtDebtID.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtDebtID.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtDebtID.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtDebtID.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtDebtID.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtDebtID.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtDebtID.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtDebtID.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtDebtID.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtDebtID.PlaceholderText = "معرف المستند";
            this.kgtxtDebtID.ReadOnly = true;
            this.kgtxtDebtID.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtDebtID.SelectedText = "";
            this.kgtxtDebtID.ShadowDecoration.BorderRadius = 2;
            this.kgtxtDebtID.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtDebtID.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtDebtID.Size = new System.Drawing.Size(138, 41);
            this.kgtxtDebtID.TabIndex = 7;
            this.kgtxtDebtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtDebtID.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtDebtID.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtDebtID.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtDebtID.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtDebtID.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtDebtID.TextProperties.MinLength = ((short)(0));
            this.kgtxtDebtID.TextProperties.MinLengthOption = false;
            this.kgtxtDebtID.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtDebtID.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtDebtID.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtDebtID.TrimEnd = true;
            this.kgtxtDebtID.TrimStart = true;
            // 
            // gibtnDeleteDebt
            // 
            this.gibtnDeleteDebt.BackColor = System.Drawing.Color.Transparent;
            this.gibtnDeleteDebt.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnDeleteDebt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gibtnDeleteDebt.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.gibtnDeleteDebt.Image = ((System.Drawing.Image)(resources.GetObject("gibtnDeleteDebt.Image")));
            this.gibtnDeleteDebt.ImageOffset = new System.Drawing.Point(0, 0);
            this.gibtnDeleteDebt.ImageRotate = 0F;
            this.gibtnDeleteDebt.ImageSize = new System.Drawing.Size(28, 28);
            this.gibtnDeleteDebt.Location = new System.Drawing.Point(18, 199);
            this.gibtnDeleteDebt.Name = "gibtnDeleteDebt";
            this.gibtnDeleteDebt.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnDeleteDebt.Size = new System.Drawing.Size(40, 42);
            this.gibtnDeleteDebt.TabIndex = 10;
            this.toolTip1.SetToolTip(this.gibtnDeleteDebt, "حذف سند الدين , يجب حذف جميع معاملات السداد أولا");
            this.gibtnDeleteDebt.UseTransparentBackground = true;
            this.gibtnDeleteDebt.Click += new System.EventHandler(this.gibtnDeleteDebt_Click);
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
            this.kgtxtPersonName.IconLeft = ((System.Drawing.Image)(resources.GetObject("kgtxtPersonName.IconLeft")));
            this.kgtxtPersonName.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtPersonName.IconRight = ((System.Drawing.Image)(resources.GetObject("kgtxtPersonName.IconRight")));
            this.kgtxtPersonName.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtPersonName.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtPersonName.IsRequired = true;
            this.kgtxtPersonName.Location = new System.Drawing.Point(850, 97);
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
            this.kgtxtPersonName.PlaceholderText = "اسم الشخص (مطلوب)";
            this.kgtxtPersonName.ReadOnly = true;
            this.kgtxtPersonName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtPersonName.SelectedText = "";
            this.kgtxtPersonName.ShadowDecoration.BorderRadius = 2;
            this.kgtxtPersonName.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtPersonName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtPersonName.Size = new System.Drawing.Size(337, 41);
            this.kgtxtPersonName.TabIndex = 0;
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
            this.toolTip1.SetToolTip(this.kgtxtPersonName, "لإختيار الشخص قم بالضغط على الأيقونة اليسرى (في وضع الإضافة) , لبيانات الشخص قم ب" +
        "الضغط على الأيقونة اليمنى");
            this.kgtxtPersonName.TrimEnd = false;
            this.kgtxtPersonName.TrimStart = false;
            this.kgtxtPersonName.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtPersonName.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtPersonName.IconLeftClick += new System.EventHandler(this.kgtxtPersonName_SelectPerson_IconLeftClick);
            this.kgtxtPersonName.IconRightClick += new System.EventHandler(this.kgtxtPersonName_PersonInfo_IconRightClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1113, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 130;
            this.label3.Text = "اسم الشخص";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(288, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 17);
            this.label11.TabIndex = 134;
            this.label11.Text = "نوع الدين";
            // 
            // gcbDebtType
            // 
            this.gcbDebtType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gcbDebtType.AutoRoundedCorners = true;
            this.gcbDebtType.BackColor = System.Drawing.Color.Transparent;
            this.gcbDebtType.BorderColor = System.Drawing.Color.Silver;
            this.gcbDebtType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcbDebtType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gcbDebtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gcbDebtType.DropDownWidth = 110;
            this.gcbDebtType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbDebtType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbDebtType.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gcbDebtType.ForeColor = System.Drawing.Color.Black;
            this.gcbDebtType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbDebtType.ItemHeight = 35;
            this.gcbDebtType.Items.AddRange(new object[] {
            "إقراض",
            "إقتراض"});
            this.gcbDebtType.Location = new System.Drawing.Point(206, 150);
            this.gcbDebtType.Name = "gcbDebtType";
            this.gcbDebtType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcbDebtType.Size = new System.Drawing.Size(138, 41);
            this.gcbDebtType.StartIndex = 0;
            this.gcbDebtType.TabIndex = 8;
            this.gcbDebtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(695, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 17);
            this.label10.TabIndex = 136;
            this.label10.Text = "التاريخ المستحق للسداد";
            // 
            // kgtxtPaymentDueDate
            // 
            this.kgtxtPaymentDueDate.AllowWhiteSpace = false;
            this.kgtxtPaymentDueDate.Animated = true;
            this.kgtxtPaymentDueDate.ApplyTrimAtTextBoxValue = false;
            this.kgtxtPaymentDueDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtPaymentDueDate.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtPaymentDueDate.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtPaymentDueDate.BorderRadius = 10;
            this.kgtxtPaymentDueDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtPaymentDueDate.DefaultText = "";
            this.kgtxtPaymentDueDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtPaymentDueDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtPaymentDueDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPaymentDueDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPaymentDueDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPaymentDueDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtPaymentDueDate.ForeColor = System.Drawing.Color.Black;
            this.kgtxtPaymentDueDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPaymentDueDate.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtPaymentDueDate.IsRequired = false;
            this.kgtxtPaymentDueDate.Location = new System.Drawing.Point(602, 150);
            this.kgtxtPaymentDueDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtPaymentDueDate.MaxLength = 30;
            this.kgtxtPaymentDueDate.Name = "kgtxtPaymentDueDate";
            this.kgtxtPaymentDueDate.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtPaymentDueDate.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPaymentDueDate.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtPaymentDueDate.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtPaymentDueDate.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPaymentDueDate.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtPaymentDueDate.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtPaymentDueDate.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtPaymentDueDate.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtPaymentDueDate.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtPaymentDueDate.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtPaymentDueDate.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtPaymentDueDate.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtPaymentDueDate.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtPaymentDueDate.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtPaymentDueDate.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtPaymentDueDate.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtPaymentDueDate.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtPaymentDueDate.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtPaymentDueDate.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtPaymentDueDate.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtPaymentDueDate.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtPaymentDueDate.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtPaymentDueDate.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtPaymentDueDate.PlaceholderText = "التاريخ المستحق للسداد (اختياري)";
            this.kgtxtPaymentDueDate.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtPaymentDueDate.SelectedText = "";
            this.kgtxtPaymentDueDate.ShadowDecoration.BorderRadius = 2;
            this.kgtxtPaymentDueDate.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtPaymentDueDate.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtPaymentDueDate.Size = new System.Drawing.Size(220, 41);
            this.kgtxtPaymentDueDate.TabIndex = 3;
            this.kgtxtPaymentDueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtPaymentDueDate.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtPaymentDueDate.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtPaymentDueDate.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtPaymentDueDate.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtPaymentDueDate.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtPaymentDueDate.TextProperties.MinLength = ((short)(0));
            this.kgtxtPaymentDueDate.TextProperties.MinLengthOption = false;
            this.kgtxtPaymentDueDate.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtPaymentDueDate.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtPaymentDueDate.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Date;
            this.kgtxtPaymentDueDate.TrimEnd = true;
            this.kgtxtPaymentDueDate.TrimStart = true;
            this.kgtxtPaymentDueDate.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtPaymentDueDate.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            // 
            // gtabcDebtTransactions
            // 
            this.gtabcDebtTransactions.Controls.Add(this.gtabDebtEntries);
            this.gtabcDebtTransactions.Controls.Add(this.gtabDebtPayments);
            this.gtabcDebtTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gtabcDebtTransactions.ItemSize = new System.Drawing.Size(140, 50);
            this.gtabcDebtTransactions.Location = new System.Drawing.Point(3, 252);
            this.gtabcDebtTransactions.Name = "gtabcDebtTransactions";
            this.gtabcDebtTransactions.SelectedIndex = 0;
            this.gtabcDebtTransactions.Size = new System.Drawing.Size(1205, 610);
            this.gtabcDebtTransactions.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.gtabcDebtTransactions.TabButtonHoverState.FillColor = System.Drawing.Color.BlueViolet;
            this.gtabcDebtTransactions.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.gtabcDebtTransactions.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.gtabcDebtTransactions.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.gtabcDebtTransactions.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.gtabcDebtTransactions.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.gtabcDebtTransactions.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.gtabcDebtTransactions.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.gtabcDebtTransactions.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.gtabcDebtTransactions.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.gtabcDebtTransactions.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.gtabcDebtTransactions.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.gtabcDebtTransactions.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.gtabcDebtTransactions.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.gtabcDebtTransactions.TabButtonSize = new System.Drawing.Size(140, 50);
            this.gtabcDebtTransactions.TabIndex = 139;
            this.gtabcDebtTransactions.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.gtabcDebtTransactions.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // gtabDebtEntries
            // 
            this.gtabDebtEntries.AutoScroll = true;
            this.gtabDebtEntries.BackColor = System.Drawing.Color.White;
            this.gtabDebtEntries.Controls.Add(this.ctrDebtEntriesList1);
            this.gtabDebtEntries.Location = new System.Drawing.Point(4, 54);
            this.gtabDebtEntries.Name = "gtabDebtEntries";
            this.gtabDebtEntries.Padding = new System.Windows.Forms.Padding(3);
            this.gtabDebtEntries.Size = new System.Drawing.Size(1197, 552);
            this.gtabDebtEntries.TabIndex = 0;
            this.gtabDebtEntries.Text = "سندات الديون";
            // 
            // gtabDebtPayments
            // 
            this.gtabDebtPayments.AutoScroll = true;
            this.gtabDebtPayments.BackColor = System.Drawing.Color.White;
            this.gtabDebtPayments.Controls.Add(this.ctrDebtPaymentsList1);
            this.gtabDebtPayments.Location = new System.Drawing.Point(4, 54);
            this.gtabDebtPayments.Name = "gtabDebtPayments";
            this.gtabDebtPayments.Padding = new System.Windows.Forms.Padding(3);
            this.gtabDebtPayments.Size = new System.Drawing.Size(1197, 552);
            this.gtabDebtPayments.TabIndex = 1;
            this.gtabDebtPayments.Text = "معاملات السداد";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(462, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 141;
            this.label1.Text = "إجمالي المبلغ المسدد";
            // 
            // kgtxtTotalPaid
            // 
            this.kgtxtTotalPaid.AllowWhiteSpace = true;
            this.kgtxtTotalPaid.ApplyTrimAtTextBoxValue = false;
            this.kgtxtTotalPaid.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtTotalPaid.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtTotalPaid.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtTotalPaid.BorderRadius = 10;
            this.kgtxtTotalPaid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtTotalPaid.DefaultText = "";
            this.kgtxtTotalPaid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtTotalPaid.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtTotalPaid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtTotalPaid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtTotalPaid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtTotalPaid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtTotalPaid.ForeColor = System.Drawing.Color.Black;
            this.kgtxtTotalPaid.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtTotalPaid.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtTotalPaid.IsRequired = false;
            this.kgtxtTotalPaid.Location = new System.Drawing.Point(362, 150);
            this.kgtxtTotalPaid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtTotalPaid.MaxLength = 150;
            this.kgtxtTotalPaid.Name = "kgtxtTotalPaid";
            this.kgtxtTotalPaid.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtTotalPaid.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtTotalPaid.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalPaid.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtTotalPaid.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtTotalPaid.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalPaid.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtTotalPaid.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtTotalPaid.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtTotalPaid.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalPaid.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtTotalPaid.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtTotalPaid.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalPaid.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtTotalPaid.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtTotalPaid.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtTotalPaid.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalPaid.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtTotalPaid.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtTotalPaid.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalPaid.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtTotalPaid.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.N4;
            this.kgtxtTotalPaid.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber;
            this.kgtxtTotalPaid.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtTotalPaid.PlaceholderText = "إجمالي المبلغ المسدد";
            this.kgtxtTotalPaid.ReadOnly = true;
            this.kgtxtTotalPaid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtTotalPaid.SelectedText = "";
            this.kgtxtTotalPaid.ShadowDecoration.BorderRadius = 2;
            this.kgtxtTotalPaid.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtTotalPaid.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtTotalPaid.Size = new System.Drawing.Size(220, 41);
            this.kgtxtTotalPaid.TabIndex = 140;
            this.kgtxtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtTotalPaid.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtTotalPaid.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtTotalPaid.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtTotalPaid.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtTotalPaid.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtTotalPaid.TextProperties.MinLength = ((short)(0));
            this.kgtxtTotalPaid.TextProperties.MinLengthOption = false;
            this.kgtxtTotalPaid.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtTotalPaid.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtTotalPaid.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtTotalPaid.TrimEnd = true;
            this.kgtxtTotalPaid.TrimStart = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(480, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 17);
            this.label9.TabIndex = 143;
            this.label9.Text = "إجمالي قيمة الدين";
            // 
            // kgtxtTotalValue
            // 
            this.kgtxtTotalValue.AllowWhiteSpace = true;
            this.kgtxtTotalValue.ApplyTrimAtTextBoxValue = false;
            this.kgtxtTotalValue.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtTotalValue.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtTotalValue.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtTotalValue.BorderRadius = 10;
            this.kgtxtTotalValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtTotalValue.DefaultText = "";
            this.kgtxtTotalValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtTotalValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtTotalValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtTotalValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtTotalValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtTotalValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtTotalValue.ForeColor = System.Drawing.Color.Black;
            this.kgtxtTotalValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtTotalValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtTotalValue.IsRequired = false;
            this.kgtxtTotalValue.Location = new System.Drawing.Point(362, 97);
            this.kgtxtTotalValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtTotalValue.MaxLength = 150;
            this.kgtxtTotalValue.Name = "kgtxtTotalValue";
            this.kgtxtTotalValue.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtTotalValue.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtTotalValue.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalValue.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtTotalValue.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtTotalValue.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalValue.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtTotalValue.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtTotalValue.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtTotalValue.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalValue.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtTotalValue.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtTotalValue.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalValue.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtTotalValue.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtTotalValue.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtTotalValue.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalValue.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtTotalValue.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtTotalValue.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalValue.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtTotalValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.N4;
            this.kgtxtTotalValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber;
            this.kgtxtTotalValue.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtTotalValue.PlaceholderText = "إجمالي قيمة الدين";
            this.kgtxtTotalValue.ReadOnly = true;
            this.kgtxtTotalValue.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtTotalValue.SelectedText = "";
            this.kgtxtTotalValue.ShadowDecoration.BorderRadius = 2;
            this.kgtxtTotalValue.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtTotalValue.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtTotalValue.Size = new System.Drawing.Size(220, 41);
            this.kgtxtTotalValue.TabIndex = 142;
            this.kgtxtTotalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtTotalValue.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtTotalValue.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtTotalValue.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtTotalValue.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtTotalValue.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtTotalValue.TextProperties.MinLength = ((short)(0));
            this.kgtxtTotalValue.TextProperties.MinLengthOption = false;
            this.kgtxtTotalValue.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtTotalValue.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtTotalValue.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtTotalValue.TrimEnd = true;
            this.kgtxtTotalValue.TrimStart = true;
            // 
            // ctrDebtEntriesList1
            // 
            this.ctrDebtEntriesList1._Debt = null;
            this.ctrDebtEntriesList1.AutoScroll = true;
            this.ctrDebtEntriesList1.BackColor = System.Drawing.Color.White;
            this.ctrDebtEntriesList1.IsLocked = true;
            this.ctrDebtEntriesList1.Location = new System.Drawing.Point(9, 6);
            this.ctrDebtEntriesList1.Name = "ctrDebtEntriesList1";
            this.ctrDebtEntriesList1.Size = new System.Drawing.Size(1179, 570);
            this.ctrDebtEntriesList1.TabIndex = 0;
            this.ctrDebtEntriesList1.OnLoading += new System.Action<decimal>(this.ctrDebtTransactions_OnLoading);
            // 
            // ctrDebtPaymentsList1
            // 
            this.ctrDebtPaymentsList1._Debt = null;
            this.ctrDebtPaymentsList1.AutoScroll = true;
            this.ctrDebtPaymentsList1.BackColor = System.Drawing.Color.White;
            this.ctrDebtPaymentsList1.IsLocked = true;
            this.ctrDebtPaymentsList1.Location = new System.Drawing.Point(9, 6);
            this.ctrDebtPaymentsList1.Name = "ctrDebtPaymentsList1";
            this.ctrDebtPaymentsList1.Size = new System.Drawing.Size(1179, 570);
            this.ctrDebtPaymentsList1.TabIndex = 0;
            this.ctrDebtPaymentsList1.OnLoading += new System.Action<decimal>(this.ctrDebtTransactions_OnLoading);
            // 
            // frmAddUpdateDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.gbtnClose;
            this.ClientSize = new System.Drawing.Size(1210, 870);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.kgtxtTotalValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kgtxtTotalPaid);
            this.Controls.Add(this.gtabcDebtTransactions);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.kgtxtPaymentDueDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gcbDebtType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kgtxtPersonName);
            this.Controls.Add(this.gibtnDeleteDebt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gchkIsLocked);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.kgtxtDebtID);
            this.Controls.Add(this.gbtnClose);
            this.Controls.Add(this.gbtnSave);
            this.Controls.Add(this.kgtxtCreatedByUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.kgtxtRemainingAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kgtxtCreatedDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.kgtxtNotes);
            this.Controls.Add(this.kgtxtDebtDate);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblUserMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateDebt";
            this.Text = "frmAddUpdateDebt";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.frmAddUpdateVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gtabcDebtTransactions.ResumeLayout(false);
            this.gtabDebtEntries.ResumeLayout(false);
            this.gtabDebtPayments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUserMessage;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtDebtDate;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2CheckBox gchkIsLocked;
        private System.Windows.Forms.Label label2;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtCreatedDate;
        private System.Windows.Forms.Label label6;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtRemainingAmount;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtCreatedByUserName;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button gbtnSave;
        private Guna.UI2.WinForms.Guna2Button gbtnClose;
        private System.Windows.Forms.Label label8;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtDebtID;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnDeleteDebt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPersonName;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2ComboBox gcbDebtType;
        private System.Windows.Forms.Label label10;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPaymentDueDate;
        private Guna.UI2.WinForms.Guna2TabControl gtabcDebtTransactions;
        private System.Windows.Forms.TabPage gtabDebtEntries;
        private System.Windows.Forms.TabPage gtabDebtPayments;
        private MoneyMindManager.UI.Forms.Debts.DebtPayment.ctrDebtPaymentsList ctrDebtPaymentsList1;
        private System.Windows.Forms.Label label9;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtTotalValue;
        private System.Windows.Forms.Label label1;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtTotalPaid;
        private MoneyMindManager.UI.Forms.Debts.DebtEntry.ctrDebtEntriesList ctrDebtEntriesList1;
    }
}