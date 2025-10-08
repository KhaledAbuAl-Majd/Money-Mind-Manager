namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    partial class frmDebtsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDebtsList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.kgtxtFilterValue = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.lblNoRecordsFoundMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gcbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCurrentPageRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kgtxtPageNumber = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.gibtnPreviousPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.gibtnNextPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lblCurrentPageOfNumberOfPages = new System.Windows.Forms.Label();
            this.lblTotalRecordsNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gdgvVouchers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.gtsmAddVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.kgtxtFromData = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtToDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.klblAllVouchersValue = new KhaledControlLibrary1.KhaledLabel();
            this.gibtnRefreshData = new Guna.UI2.WinForms.Guna2ImageButton();
            this.klblCurrentPageVouchersValue = new KhaledControlLibrary1.KhaledLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SearchAfterTimerFinish = new System.Windows.Forms.Timer(this.components);
            this.gbtnAddVoucher = new Guna.UI2.WinForms.Guna2Button();
            this.gcbFilterByDate = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.gcbFilterByDebtType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gcbFilterbyPaymentStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gtsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gdgvVouchers)).BeginInit();
            this.guna2ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblUserMessage.Location = new System.Drawing.Point(25, 406);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserMessage.Size = new System.Drawing.Size(1159, 42);
            this.lblUserMessage.TabIndex = 31;
            this.lblUserMessage.Text = "\"تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.\"";
            this.lblUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kgtxtFilterValue
            // 
            this.kgtxtFilterValue.AllowWhiteSpace = false;
            this.kgtxtFilterValue.ApplyTrimAtTextBoxValue = false;
            this.kgtxtFilterValue.AutoRoundedCorners = true;
            this.kgtxtFilterValue.BorderColor = System.Drawing.Color.Silver;
            this.kgtxtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtFilterValue.DefaultText = "";
            this.kgtxtFilterValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtFilterValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtFilterValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtFilterValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtFilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtFilterValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtFilterValue.ForeColor = System.Drawing.Color.Black;
            this.kgtxtFilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtFilterValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtFilterValue.IsRequired = false;
            this.kgtxtFilterValue.Location = new System.Drawing.Point(771, 112);
            this.kgtxtFilterValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtFilterValue.Name = "kgtxtFilterValue";
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtFilterValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtFilterValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtFilterValue.PlaceholderText = "";
            this.kgtxtFilterValue.SelectedText = "";
            this.kgtxtFilterValue.Size = new System.Drawing.Size(157, 36);
            this.kgtxtFilterValue.TabIndex = 1;
            this.kgtxtFilterValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtFilterValue.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtFilterValue.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtFilterValue.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtFilterValue.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtFilterValue.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtFilterValue.TextProperties.MinLength = ((short)(0));
            this.kgtxtFilterValue.TextProperties.MinLengthOption = false;
            this.kgtxtFilterValue.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtFilterValue.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtFilterValue.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtFilterValue.TrimEnd = false;
            this.kgtxtFilterValue.TrimStart = false;
            this.kgtxtFilterValue.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtFilterValue.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtFilterValue.TextChanged += new System.EventHandler(this.kgtxtFilterValue_TextChanged);
            this.kgtxtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kgtxtFilterValue_KeyPress);
            // 
            // lblNoRecordsFoundMessage
            // 
            this.lblNoRecordsFoundMessage.Font = new System.Drawing.Font("Segoe Script", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFoundMessage.ForeColor = System.Drawing.Color.Red;
            this.lblNoRecordsFoundMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblNoRecordsFoundMessage.Location = new System.Drawing.Point(25, 364);
            this.lblNoRecordsFoundMessage.Name = "lblNoRecordsFoundMessage";
            this.lblNoRecordsFoundMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNoRecordsFoundMessage.Size = new System.Drawing.Size(1159, 42);
            this.lblNoRecordsFoundMessage.TabIndex = 29;
            this.lblNoRecordsFoundMessage.Text = "لا يوجد نتائج مطابقة لبحثك !";
            this.lblNoRecordsFoundMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1106, 117);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 28;
            this.label2.Text = "تصفية حسب :";
            // 
            // gcbFilterBy
            // 
            this.gcbFilterBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gcbFilterBy.AutoRoundedCorners = true;
            this.gcbFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.gcbFilterBy.BorderColor = System.Drawing.Color.Silver;
            this.gcbFilterBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcbFilterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gcbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gcbFilterBy.DropDownWidth = 150;
            this.gcbFilterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterBy.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gcbFilterBy.ForeColor = System.Drawing.Color.Black;
            this.gcbFilterBy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterBy.ItemHeight = 30;
            this.gcbFilterBy.Items.AddRange(new object[] {
            "بدون",
            "معرف المستند",
            "اسم الشخص"});
            this.gcbFilterBy.Location = new System.Drawing.Point(943, 112);
            this.gcbFilterBy.Name = "gcbFilterBy";
            this.gcbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcbFilterBy.Size = new System.Drawing.Size(157, 36);
            this.gcbFilterBy.TabIndex = 0;
            this.gcbFilterBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gcbFilterBy.SelectedIndexChanged += new System.EventHandler(this.gcbFilterBy_SelectedIndexChanged);
            // 
            // lblCurrentPageRecordsCount
            // 
            this.lblCurrentPageRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageRecordsCount.Location = new System.Drawing.Point(888, 705);
            this.lblCurrentPageRecordsCount.Name = "lblCurrentPageRecordsCount";
            this.lblCurrentPageRecordsCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageRecordsCount.Size = new System.Drawing.Size(114, 24);
            this.lblCurrentPageRecordsCount.TabIndex = 26;
            this.lblCurrentPageRecordsCount.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(998, 705);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(205, 24);
            this.label3.TabIndex = 25;
            this.label3.Text = "# عدد صفوف الصفحة الحالية : ";
            // 
            // kgtxtPageNumber
            // 
            this.kgtxtPageNumber.AllowWhiteSpace = false;
            this.kgtxtPageNumber.ApplyTrimAtTextBoxValue = false;
            this.kgtxtPageNumber.AutoRoundedCorners = true;
            this.kgtxtPageNumber.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtPageNumber.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtPageNumber.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtPageNumber.BorderRadius = 16;
            this.kgtxtPageNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtPageNumber.DefaultText = "";
            this.kgtxtPageNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtPageNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtPageNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPageNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPageNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPageNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtPageNumber.ForeColor = System.Drawing.Color.Black;
            this.kgtxtPageNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPageNumber.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtPageNumber.IsRequired = true;
            this.kgtxtPageNumber.Location = new System.Drawing.Point(768, 683);
            this.kgtxtPageNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtPageNumber.MaxLength = 150;
            this.kgtxtPageNumber.Name = "kgtxtPageNumber";
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtPageNumber.NumberProperties.IntegerNumberProperties.AllowNegative = false;
            this.kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MinValue = 1;
            this.kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MinValueOption = true;
            this.kgtxtPageNumber.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtPageNumber.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtPageNumber.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtPageNumber.PlaceholderText = "رقم الصفحة";
            this.kgtxtPageNumber.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtPageNumber.SelectedText = "";
            this.kgtxtPageNumber.ShadowDecoration.BorderRadius = 2;
            this.kgtxtPageNumber.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtPageNumber.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtPageNumber.Size = new System.Drawing.Size(119, 34);
            this.kgtxtPageNumber.TabIndex = 9;
            this.kgtxtPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtPageNumber.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtPageNumber.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtPageNumber.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtPageNumber.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtPageNumber.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtPageNumber.TextProperties.MinLength = ((short)(0));
            this.kgtxtPageNumber.TextProperties.MinLengthOption = false;
            this.kgtxtPageNumber.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtPageNumber.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtPageNumber.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.toolTip1.SetToolTip(this.kgtxtPageNumber, "رقم الصفحة الحالية, أدخل رقم الصفحة التي تريد الإنتقال إليها");
            this.kgtxtPageNumber.TrimEnd = true;
            this.kgtxtPageNumber.TrimStart = false;
            this.kgtxtPageNumber.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtPageNumber.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtPageNumber.TextChanged += new System.EventHandler(this.kgtxtPageNumber_TextChanged);
            // 
            // gibtnPreviousPage
            // 
            this.gibtnPreviousPage.BackColor = System.Drawing.Color.Transparent;
            this.gibtnPreviousPage.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnPreviousPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gibtnPreviousPage.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnPreviousPage.Image = ((System.Drawing.Image)(resources.GetObject("gibtnPreviousPage.Image")));
            this.gibtnPreviousPage.ImageOffset = new System.Drawing.Point(0, 0);
            this.gibtnPreviousPage.ImageRotate = 0F;
            this.gibtnPreviousPage.ImageSize = new System.Drawing.Size(25, 25);
            this.gibtnPreviousPage.Location = new System.Drawing.Point(443, 679);
            this.gibtnPreviousPage.Name = "gibtnPreviousPage";
            this.gibtnPreviousPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnPreviousPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnPreviousPage.TabIndex = 23;
            this.toolTip1.SetToolTip(this.gibtnPreviousPage, "الصفحة السابقة");
            this.gibtnPreviousPage.UseTransparentBackground = true;
            this.gibtnPreviousPage.Click += new System.EventHandler(this.gibtnPreviousPage_Click);
            // 
            // gibtnNextPage
            // 
            this.gibtnNextPage.BackColor = System.Drawing.Color.Transparent;
            this.gibtnNextPage.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gibtnNextPage.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnNextPage.Image = ((System.Drawing.Image)(resources.GetObject("gibtnNextPage.Image")));
            this.gibtnNextPage.ImageOffset = new System.Drawing.Point(0, 0);
            this.gibtnNextPage.ImageRotate = 0F;
            this.gibtnNextPage.ImageSize = new System.Drawing.Size(25, 25);
            this.gibtnNextPage.Location = new System.Drawing.Point(721, 679);
            this.gibtnNextPage.Name = "gibtnNextPage";
            this.gibtnNextPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnNextPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnNextPage.TabIndex = 22;
            this.toolTip1.SetToolTip(this.gibtnNextPage, "الصفحة التالية");
            this.gibtnNextPage.UseTransparentBackground = true;
            this.gibtnNextPage.Click += new System.EventHandler(this.gibtnNextPage_Click);
            // 
            // lblCurrentPageOfNumberOfPages
            // 
            this.lblCurrentPageOfNumberOfPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageOfNumberOfPages.Location = new System.Drawing.Point(478, 683);
            this.lblCurrentPageOfNumberOfPages.Name = "lblCurrentPageOfNumberOfPages";
            this.lblCurrentPageOfNumberOfPages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageOfNumberOfPages.Size = new System.Drawing.Size(249, 30);
            this.lblCurrentPageOfNumberOfPages.TabIndex = 21;
            this.lblCurrentPageOfNumberOfPages.Text = "0 من  0  صفحات";
            this.lblCurrentPageOfNumberOfPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalRecordsNumber
            // 
            this.lblTotalRecordsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecordsNumber.Location = new System.Drawing.Point(938, 676);
            this.lblTotalRecordsNumber.Name = "lblTotalRecordsNumber";
            this.lblTotalRecordsNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalRecordsNumber.Size = new System.Drawing.Size(114, 24);
            this.lblTotalRecordsNumber.TabIndex = 20;
            this.lblTotalRecordsNumber.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1048, 676);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "# عدد الصفوف الكلية : ";
            // 
            // gdgvVouchers
            // 
            this.gdgvVouchers.AllowUserToAddRows = false;
            this.gdgvVouchers.AllowUserToDeleteRows = false;
            this.gdgvVouchers.AllowUserToResizeColumns = false;
            this.gdgvVouchers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.gdgvVouchers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gdgvVouchers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.gdgvVouchers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gdgvVouchers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvVouchers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gdgvVouchers.ColumnHeadersHeight = 35;
            this.gdgvVouchers.ContextMenuStrip = this.guna2ContextMenuStrip1;
            this.gdgvVouchers.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = "N/A";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdgvVouchers.DefaultCellStyle = dataGridViewCellStyle3;
            this.gdgvVouchers.GridColor = System.Drawing.Color.White;
            this.gdgvVouchers.Location = new System.Drawing.Point(12, 209);
            this.gdgvVouchers.MultiSelect = false;
            this.gdgvVouchers.Name = "gdgvVouchers";
            this.gdgvVouchers.ReadOnly = true;
            this.gdgvVouchers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvVouchers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gdgvVouchers.RowHeadersVisible = false;
            this.gdgvVouchers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gdgvVouchers.RowTemplate.Height = 40;
            this.gdgvVouchers.Size = new System.Drawing.Size(1186, 463);
            this.gdgvVouchers.TabIndex = 18;
            this.gdgvVouchers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvVouchers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gdgvVouchers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gdgvVouchers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gdgvVouchers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gdgvVouchers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gdgvVouchers.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.gdgvVouchers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gdgvVouchers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.gdgvVouchers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvVouchers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gdgvVouchers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gdgvVouchers.ThemeStyle.HeaderStyle.Height = 35;
            this.gdgvVouchers.ThemeStyle.ReadOnly = true;
            this.gdgvVouchers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvVouchers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gdgvVouchers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvVouchers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvVouchers.ThemeStyle.RowsStyle.Height = 40;
            this.gdgvVouchers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gdgvVouchers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvVouchers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gdgvVouchers_CellFormatting);
            this.gdgvVouchers.DoubleClick += new System.EventHandler(this.gdgvVouchers_DoubleClick);
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.BackColor = System.Drawing.Color.Snow;
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gtsmAddVoucher,
            this.gtsmEdit,
            this.gtsmExport});
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(195, 134);
            // 
            // gtsmAddVoucher
            // 
            this.gtsmAddVoucher.AutoSize = false;
            this.gtsmAddVoucher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmAddVoucher.Image = ((System.Drawing.Image)(resources.GetObject("gtsmAddVoucher.Image")));
            this.gtsmAddVoucher.Name = "gtsmAddVoucher";
            this.gtsmAddVoucher.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.gtsmAddVoucher.ShowShortcutKeys = false;
            this.gtsmAddVoucher.Size = new System.Drawing.Size(194, 36);
            this.gtsmAddVoucher.Text = "إضافة مستند";
            this.gtsmAddVoucher.Click += new System.EventHandler(this.gtsmAddVoucher_Click);
            // 
            // gtsmEdit
            // 
            this.gtsmEdit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmEdit.Image = ((System.Drawing.Image)(resources.GetObject("gtsmEdit.Image")));
            this.gtsmEdit.Name = "gtsmEdit";
            this.gtsmEdit.Size = new System.Drawing.Size(194, 36);
            this.gtsmEdit.Text = "تعديل";
            this.gtsmEdit.Click += new System.EventHandler(this.gtsmEdit_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // kgtxtFromData
            // 
            this.kgtxtFromData.AllowWhiteSpace = false;
            this.kgtxtFromData.ApplyTrimAtTextBoxValue = false;
            this.kgtxtFromData.AutoRoundedCorners = true;
            this.kgtxtFromData.BorderColor = System.Drawing.Color.Silver;
            this.kgtxtFromData.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtFromData.DefaultText = "";
            this.kgtxtFromData.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtFromData.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtFromData.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtFromData.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtFromData.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtFromData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtFromData.ForeColor = System.Drawing.Color.Black;
            this.kgtxtFromData.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtFromData.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtFromData.IsRequired = false;
            this.kgtxtFromData.Location = new System.Drawing.Point(825, 165);
            this.kgtxtFromData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtFromData.Name = "kgtxtFromData";
            this.kgtxtFromData.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtFromData.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtFromData.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtFromData.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtFromData.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtFromData.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtFromData.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtFromData.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtFromData.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtFromData.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtFromData.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtFromData.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtFromData.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtFromData.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtFromData.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtFromData.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtFromData.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtFromData.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtFromData.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtFromData.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtFromData.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtFromData.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtFromData.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtFromData.PlaceholderText = "من التاريخ";
            this.kgtxtFromData.SelectedText = "";
            this.kgtxtFromData.Size = new System.Drawing.Size(123, 36);
            this.kgtxtFromData.TabIndex = 6;
            this.kgtxtFromData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtFromData.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtFromData.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtFromData.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtFromData.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtFromData.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtFromData.TextProperties.MinLength = ((short)(0));
            this.kgtxtFromData.TextProperties.MinLengthOption = false;
            this.kgtxtFromData.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtFromData.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtFromData.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Date;
            this.toolTip1.SetToolTip(this.kgtxtFromData, "البحث من التاريخ المكتوب , إن كان فارغا فلن يتم البحث به");
            this.kgtxtFromData.TrimEnd = true;
            this.kgtxtFromData.TrimStart = true;
            this.kgtxtFromData.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtFromData.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtFromData.Leave += new System.EventHandler(this.kgtxtDataFrom_Leave);
            // 
            // kgtxtToDate
            // 
            this.kgtxtToDate.AllowWhiteSpace = false;
            this.kgtxtToDate.ApplyTrimAtTextBoxValue = false;
            this.kgtxtToDate.AutoRoundedCorners = true;
            this.kgtxtToDate.BorderColor = System.Drawing.Color.Silver;
            this.kgtxtToDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtToDate.DefaultText = "";
            this.kgtxtToDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtToDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtToDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtToDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtToDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtToDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtToDate.ForeColor = System.Drawing.Color.Black;
            this.kgtxtToDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtToDate.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtToDate.IsRequired = false;
            this.kgtxtToDate.Location = new System.Drawing.Point(686, 165);
            this.kgtxtToDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtToDate.Name = "kgtxtToDate";
            this.kgtxtToDate.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtToDate.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtToDate.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtToDate.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtToDate.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtToDate.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtToDate.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtToDate.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtToDate.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtToDate.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtToDate.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtToDate.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtToDate.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtToDate.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtToDate.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtToDate.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtToDate.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtToDate.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtToDate.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtToDate.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtToDate.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtToDate.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtToDate.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtToDate.PlaceholderText = "إلى التاريخ";
            this.kgtxtToDate.SelectedText = "";
            this.kgtxtToDate.Size = new System.Drawing.Size(123, 36);
            this.kgtxtToDate.TabIndex = 7;
            this.kgtxtToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtToDate.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtToDate.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtToDate.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtToDate.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtToDate.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtToDate.TextProperties.MinLength = ((short)(0));
            this.kgtxtToDate.TextProperties.MinLengthOption = false;
            this.kgtxtToDate.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtToDate.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtToDate.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Date;
            this.toolTip1.SetToolTip(this.kgtxtToDate, "البحث إلى التاريخ المكتوب , إن كان فارغا فلن يتم البحث به");
            this.kgtxtToDate.TrimEnd = true;
            this.kgtxtToDate.TrimStart = true;
            this.kgtxtToDate.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtToDate.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtToDate.Leave += new System.EventHandler(this.kgtxtDataFrom_Leave);
            // 
            // klblAllVouchersValue
            // 
            this.klblAllVouchersValue.DateProperties.DayFormate = KhaledControlLibrary1.KhaledLabel.clsDateTimeProperties.enDayFormate.dd__01;
            this.klblAllVouchersValue.DateProperties.MonthFormate = KhaledControlLibrary1.KhaledLabel.clsDateTimeProperties.enMonthFormate.MM__01;
            this.klblAllVouchersValue.DateProperties.SeparatorFormate = KhaledControlLibrary1.KhaledLabel.clsDateTimeProperties.enSeparator.Dash;
            this.klblAllVouchersValue.DateProperties.TimeFormate = KhaledControlLibrary1.KhaledLabel.clsDateTimeProperties.enTimeFormate.None;
            this.klblAllVouchersValue.DateProperties.YearFormate = KhaledControlLibrary1.KhaledLabel.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.klblAllVouchersValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAllVouchersValue.InputType = KhaledControlLibrary1.KhaledLabel.enInputType.Number;
            this.klblAllVouchersValue.Location = new System.Drawing.Point(6, 674);
            this.klblAllVouchersValue.Name = "klblAllVouchersValue";
            this.klblAllVouchersValue.NumberFormat = KhaledControlLibrary1.KhaledLabel.enNumberFormat.N4;
            this.klblAllVouchersValue.Size = new System.Drawing.Size(277, 28);
            this.klblAllVouchersValue.TabIndex = 98;
            this.klblAllVouchersValue.Text = "111,111,111,111,111.0000";
            this.klblAllVouchersValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.klblAllVouchersValue, "قيمة المستندات الكلية لنتيجة البحث");
            // 
            // gibtnRefreshData
            // 
            this.gibtnRefreshData.BackColor = System.Drawing.Color.Transparent;
            this.gibtnRefreshData.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnRefreshData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gibtnRefreshData.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.gibtnRefreshData.Image = ((System.Drawing.Image)(resources.GetObject("gibtnRefreshData.Image")));
            this.gibtnRefreshData.ImageOffset = new System.Drawing.Point(0, 0);
            this.gibtnRefreshData.ImageRotate = 0F;
            this.gibtnRefreshData.ImageSize = new System.Drawing.Size(28, 28);
            this.gibtnRefreshData.Location = new System.Drawing.Point(435, 107);
            this.gibtnRefreshData.Name = "gibtnRefreshData";
            this.gibtnRefreshData.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnRefreshData.Size = new System.Drawing.Size(40, 42);
            this.gibtnRefreshData.TabIndex = 4;
            this.toolTip1.SetToolTip(this.gibtnRefreshData, "تحديث البيانات");
            this.gibtnRefreshData.UseTransparentBackground = true;
            this.gibtnRefreshData.Click += new System.EventHandler(this.gibtnRefreshData_Click);
            // 
            // klblCurrentPageVouchersValue
            // 
            this.klblCurrentPageVouchersValue.DateProperties.DayFormate = KhaledControlLibrary1.KhaledLabel.clsDateTimeProperties.enDayFormate.dd__01;
            this.klblCurrentPageVouchersValue.DateProperties.MonthFormate = KhaledControlLibrary1.KhaledLabel.clsDateTimeProperties.enMonthFormate.MM__01;
            this.klblCurrentPageVouchersValue.DateProperties.SeparatorFormate = KhaledControlLibrary1.KhaledLabel.clsDateTimeProperties.enSeparator.Dash;
            this.klblCurrentPageVouchersValue.DateProperties.TimeFormate = KhaledControlLibrary1.KhaledLabel.clsDateTimeProperties.enTimeFormate.None;
            this.klblCurrentPageVouchersValue.DateProperties.YearFormate = KhaledControlLibrary1.KhaledLabel.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.klblCurrentPageVouchersValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblCurrentPageVouchersValue.InputType = KhaledControlLibrary1.KhaledLabel.enInputType.Number;
            this.klblCurrentPageVouchersValue.Location = new System.Drawing.Point(1, 702);
            this.klblCurrentPageVouchersValue.Name = "klblCurrentPageVouchersValue";
            this.klblCurrentPageVouchersValue.NumberFormat = KhaledControlLibrary1.KhaledLabel.enNumberFormat.N4;
            this.klblCurrentPageVouchersValue.Size = new System.Drawing.Size(241, 28);
            this.klblCurrentPageVouchersValue.TabIndex = 99;
            this.klblCurrentPageVouchersValue.Text = "111,111,111,111,111.0000";
            this.klblCurrentPageVouchersValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.klblCurrentPageVouchersValue, "قيمة المستندات الكلية لنتيجة البحث للصفحة الحالية");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(231, 706);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(214, 24);
            this.label5.TabIndex = 39;
            this.label5.Text = "# قيمة مستندات الصفحة الحالية : ";
            this.toolTip1.SetToolTip(this.label5, "قيمة المستندات الكلية لنتيجة البحث للصفحة الحالية");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(286, 677);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(159, 24);
            this.label7.TabIndex = 37;
            this.label7.Text = "# قيمة المستندات الكلية :";
            this.toolTip1.SetToolTip(this.label7, "قيمة المستندات الكلية لنتيجة البحث");
            // 
            // SearchAfterTimerFinish
            // 
            this.SearchAfterTimerFinish.Interval = 400;
            this.SearchAfterTimerFinish.Tick += new System.EventHandler(this.SearchAfterTimerFinish_Tick);
            // 
            // gbtnAddVoucher
            // 
            this.gbtnAddVoucher.Animated = true;
            this.gbtnAddVoucher.AutoRoundedCorners = true;
            this.gbtnAddVoucher.BackColor = System.Drawing.Color.Transparent;
            this.gbtnAddVoucher.BorderColor = System.Drawing.Color.DimGray;
            this.gbtnAddVoucher.BorderThickness = 1;
            this.gbtnAddVoucher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnAddVoucher.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAddVoucher.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAddVoucher.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnAddVoucher.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnAddVoucher.FillColor = System.Drawing.Color.White;
            this.gbtnAddVoucher.FocusedColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbtnAddVoucher.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbtnAddVoucher.ForeColor = System.Drawing.Color.Black;
            this.gbtnAddVoucher.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnAddVoucher.HoverState.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnAddVoucher.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnAddVoucher.Image = ((System.Drawing.Image)(resources.GetObject("gbtnAddVoucher.Image")));
            this.gbtnAddVoucher.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnAddVoucher.ImageSize = new System.Drawing.Size(28, 28);
            this.gbtnAddVoucher.IndicateFocus = true;
            this.gbtnAddVoucher.Location = new System.Drawing.Point(12, 160);
            this.gbtnAddVoucher.Name = "gbtnAddVoucher";
            this.gbtnAddVoucher.PressedColor = System.Drawing.Color.White;
            this.gbtnAddVoucher.Size = new System.Drawing.Size(180, 41);
            this.gbtnAddVoucher.TabIndex = 8;
            this.gbtnAddVoucher.Text = "إضافة مستند";
            this.gbtnAddVoucher.Click += new System.EventHandler(this.gbtnAddVoucher_Click);
            // 
            // gcbFilterByDate
            // 
            this.gcbFilterByDate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gcbFilterByDate.AutoRoundedCorners = true;
            this.gcbFilterByDate.BackColor = System.Drawing.Color.Transparent;
            this.gcbFilterByDate.BorderColor = System.Drawing.Color.Silver;
            this.gcbFilterByDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcbFilterByDate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gcbFilterByDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gcbFilterByDate.DropDownWidth = 110;
            this.gcbFilterByDate.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterByDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterByDate.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gcbFilterByDate.ForeColor = System.Drawing.Color.Black;
            this.gcbFilterByDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterByDate.ItemHeight = 30;
            this.gcbFilterByDate.Items.AddRange(new object[] {
            "تاريخ المستند",
            "تاريخ الإنشاء"});
            this.gcbFilterByDate.Location = new System.Drawing.Point(964, 165);
            this.gcbFilterByDate.Name = "gcbFilterByDate";
            this.gcbFilterByDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcbFilterByDate.Size = new System.Drawing.Size(136, 36);
            this.gcbFilterByDate.StartIndex = 0;
            this.gcbFilterByDate.TabIndex = 5;
            this.gcbFilterByDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gcbFilterByDate.SelectedIndexChanged += new System.EventHandler(this.gcbFilterByDate_SelectedIndexChanged);
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1210, 50);
            this.lblHeader.TabIndex = 101;
            this.lblHeader.Text = "مستندات الديون";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gcbFilterByDebtType
            // 
            this.gcbFilterByDebtType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gcbFilterByDebtType.AutoRoundedCorners = true;
            this.gcbFilterByDebtType.BackColor = System.Drawing.Color.Transparent;
            this.gcbFilterByDebtType.BorderColor = System.Drawing.Color.Silver;
            this.gcbFilterByDebtType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcbFilterByDebtType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gcbFilterByDebtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gcbFilterByDebtType.DropDownWidth = 110;
            this.gcbFilterByDebtType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterByDebtType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterByDebtType.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gcbFilterByDebtType.ForeColor = System.Drawing.Color.Black;
            this.gcbFilterByDebtType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterByDebtType.ItemHeight = 30;
            this.gcbFilterByDebtType.Items.AddRange(new object[] {
            "الكل",
            "إقراض",
            "إقتراض"});
            this.gcbFilterByDebtType.Location = new System.Drawing.Point(484, 112);
            this.gcbFilterByDebtType.Name = "gcbFilterByDebtType";
            this.gcbFilterByDebtType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcbFilterByDebtType.Size = new System.Drawing.Size(136, 36);
            this.gcbFilterByDebtType.StartIndex = 0;
            this.gcbFilterByDebtType.TabIndex = 3;
            this.gcbFilterByDebtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gcbFilterByDebtType.SelectedIndexChanged += new System.EventHandler(this.gcbFilterByDebtType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(558, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 132;
            this.label4.Text = "نوع الدين";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1035, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 133;
            this.label6.Text = "نوع التاريخ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(691, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 135;
            this.label8.Text = "حالة السداد";
            // 
            // gcbFilterbyPaymentStatus
            // 
            this.gcbFilterbyPaymentStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gcbFilterbyPaymentStatus.AutoRoundedCorners = true;
            this.gcbFilterbyPaymentStatus.BackColor = System.Drawing.Color.Transparent;
            this.gcbFilterbyPaymentStatus.BorderColor = System.Drawing.Color.Silver;
            this.gcbFilterbyPaymentStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcbFilterbyPaymentStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gcbFilterbyPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gcbFilterbyPaymentStatus.DropDownWidth = 110;
            this.gcbFilterbyPaymentStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterbyPaymentStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterbyPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gcbFilterbyPaymentStatus.ForeColor = System.Drawing.Color.Black;
            this.gcbFilterbyPaymentStatus.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterbyPaymentStatus.ItemHeight = 30;
            this.gcbFilterbyPaymentStatus.Items.AddRange(new object[] {
            "الكل",
            "مسدد",
            "غير مسدد"});
            this.gcbFilterbyPaymentStatus.Location = new System.Drawing.Point(626, 112);
            this.gcbFilterbyPaymentStatus.Name = "gcbFilterbyPaymentStatus";
            this.gcbFilterbyPaymentStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcbFilterbyPaymentStatus.Size = new System.Drawing.Size(136, 36);
            this.gcbFilterbyPaymentStatus.StartIndex = 0;
            this.gcbFilterbyPaymentStatus.TabIndex = 2;
            this.gcbFilterbyPaymentStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gcbFilterbyPaymentStatus.SelectedIndexChanged += new System.EventHandler(this.gcbFilterbyPaymentStatus_SelectedIndexChanged);
            // 
            // gtsmExport
            // 
            this.gtsmExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gtsmExportExcel});
            this.gtsmExport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmExport.Image = ((System.Drawing.Image)(resources.GetObject("gtsmExport.Image")));
            this.gtsmExport.Name = "gtsmExport";
            this.gtsmExport.Size = new System.Drawing.Size(194, 36);
            this.gtsmExport.Text = "تصدير";
            // 
            // gtsmExportExcel
            // 
            this.gtsmExportExcel.AutoSize = false;
            this.gtsmExportExcel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("gtsmExportExcel.Image")));
            this.gtsmExportExcel.Name = "gtsmExportExcel";
            this.gtsmExportExcel.Size = new System.Drawing.Size(194, 27);
            this.gtsmExportExcel.Text = "       Excel";
            // 
            // frmDebtsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1210, 737);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gcbFilterbyPaymentStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gcbFilterByDebtType);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.gibtnRefreshData);
            this.Controls.Add(this.klblCurrentPageVouchersValue);
            this.Controls.Add(this.klblAllVouchersValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.kgtxtToDate);
            this.Controls.Add(this.kgtxtFromData);
            this.Controls.Add(this.gcbFilterByDate);
            this.Controls.Add(this.gbtnAddVoucher);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.kgtxtFilterValue);
            this.Controls.Add(this.lblNoRecordsFoundMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gcbFilterBy);
            this.Controls.Add(this.lblCurrentPageRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kgtxtPageNumber);
            this.Controls.Add(this.gibtnPreviousPage);
            this.Controls.Add(this.gibtnNextPage);
            this.Controls.Add(this.lblCurrentPageOfNumberOfPages);
            this.Controls.Add(this.lblTotalRecordsNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gdgvVouchers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDebtsList";
            this.Text = "VouhcersList";
            this.Load += new System.EventHandler(this.VouhcersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdgvVouchers)).EndInit();
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUserMessage;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtFilterValue;
        private System.Windows.Forms.Label lblNoRecordsFoundMessage;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox gcbFilterBy;
        private System.Windows.Forms.Label lblCurrentPageRecordsCount;
        private System.Windows.Forms.Label label3;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPageNumber;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnPreviousPage;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnNextPage;
        private System.Windows.Forms.Label lblCurrentPageOfNumberOfPages;
        private System.Windows.Forms.Label lblTotalRecordsNumber;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView gdgvVouchers;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gtsmAddVoucher;
        private System.Windows.Forms.ToolStripMenuItem gtsmEdit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer SearchAfterTimerFinish;
        private Guna.UI2.WinForms.Guna2Button gbtnAddVoucher;
        private Guna.UI2.WinForms.Guna2ComboBox gcbFilterByDate;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtToDate;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtFromData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private KhaledControlLibrary1.KhaledLabel klblCurrentPageVouchersValue;
        private KhaledControlLibrary1.KhaledLabel klblAllVouchersValue;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnRefreshData;
        private System.Windows.Forms.Label lblHeader;
        private Guna.UI2.WinForms.Guna2ComboBox gcbFilterByDebtType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2ComboBox gcbFilterbyPaymentStatus;
        private System.Windows.Forms.ToolStripMenuItem gtsmExport;
        private System.Windows.Forms.ToolStripMenuItem gtsmExportExcel;
    }
}