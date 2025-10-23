namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    partial class frmCategoriesList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoriesList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.gtsmAddVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmShowCategoryMonthlyFlow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gibtnRefreshData = new Guna.UI2.WinForms.Guna2ImageButton();
            this.kgtxtPageNumber = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.gibtnPreviousPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.gibtnNextPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SearchAfterTimerFinish = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbtnAddCategory = new Guna.UI2.WinForms.Guna2Button();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.kgtxtFilterValue = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.lblNoRecordsFoundMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gcbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCurrentPageRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentPageOfNumberOfPages = new System.Windows.Forms.Label();
            this.lblTotalRecordsNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gdgvCategories = new Guna.UI2.WinForms.Guna2DataGridView();
            this.gcbIsActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gchkIncludeMainCategory = new Guna.UI2.WinForms.Guna2CheckBox();
            this.gchkIncludeSubCategories = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdgvCategories)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.BackColor = System.Drawing.Color.Snow;
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gtsmAddVoucher,
            this.gtsmEdit,
            this.gtsmShowCategoryMonthlyFlow});
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
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(261, 134);
            // 
            // gtsmAddVoucher
            // 
            this.gtsmAddVoucher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmAddVoucher.Image = ((System.Drawing.Image)(resources.GetObject("gtsmAddVoucher.Image")));
            this.gtsmAddVoucher.Name = "gtsmAddVoucher";
            this.gtsmAddVoucher.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.gtsmAddVoucher.ShowShortcutKeys = false;
            this.gtsmAddVoucher.Size = new System.Drawing.Size(260, 36);
            this.gtsmAddVoucher.Text = "إضافة فئة";
            this.gtsmAddVoucher.Click += new System.EventHandler(this.gtsmAddVoucher_Click);
            // 
            // gtsmEdit
            // 
            this.gtsmEdit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmEdit.Image = ((System.Drawing.Image)(resources.GetObject("gtsmEdit.Image")));
            this.gtsmEdit.Name = "gtsmEdit";
            this.gtsmEdit.Size = new System.Drawing.Size(260, 36);
            this.gtsmEdit.Text = "تعديل";
            this.gtsmEdit.Click += new System.EventHandler(this.gtsmEdit_Click);
            // 
            // gtsmShowCategoryMonthlyFlow
            // 
            this.gtsmShowCategoryMonthlyFlow.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmShowCategoryMonthlyFlow.Image = ((System.Drawing.Image)(resources.GetObject("gtsmShowCategoryMonthlyFlow.Image")));
            this.gtsmShowCategoryMonthlyFlow.Name = "gtsmShowCategoryMonthlyFlow";
            this.gtsmShowCategoryMonthlyFlow.Size = new System.Drawing.Size(260, 36);
            this.gtsmShowCategoryMonthlyFlow.Text = "صافي التدفق الشهري للفئة";
            this.gtsmShowCategoryMonthlyFlow.Click += new System.EventHandler(this.gtsmShowCategoryMonthlyFlow_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
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
            this.gibtnRefreshData.Location = new System.Drawing.Point(344, 5);
            this.gibtnRefreshData.Name = "gibtnRefreshData";
            this.gibtnRefreshData.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnRefreshData.Size = new System.Drawing.Size(40, 42);
            this.gibtnRefreshData.TabIndex = 123;
            this.toolTip1.SetToolTip(this.gibtnRefreshData, "تحديث البيانات");
            this.gibtnRefreshData.UseTransparentBackground = true;
            this.gibtnRefreshData.Click += new System.EventHandler(this.gibtnRefreshData_Click);
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
            this.kgtxtPageNumber.Location = new System.Drawing.Point(250, 633);
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
            this.kgtxtPageNumber.TabIndex = 107;
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
            this.gibtnPreviousPage.Location = new System.Drawing.Point(446, 631);
            this.gibtnPreviousPage.Name = "gibtnPreviousPage";
            this.gibtnPreviousPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnPreviousPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnPreviousPage.TabIndex = 106;
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
            this.gibtnNextPage.Location = new System.Drawing.Point(724, 631);
            this.gibtnNextPage.Name = "gibtnNextPage";
            this.gibtnNextPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnNextPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnNextPage.TabIndex = 105;
            this.toolTip1.SetToolTip(this.gibtnNextPage, "الصفحة التالية");
            this.gibtnNextPage.UseTransparentBackground = true;
            this.gibtnNextPage.Click += new System.EventHandler(this.gibtnNextPage_Click);
            // 
            // SearchAfterTimerFinish
            // 
            this.SearchAfterTimerFinish.Interval = 400;
            this.SearchAfterTimerFinish.Tick += new System.EventHandler(this.SearchAfterTimerFinish_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbtnAddCategory
            // 
            this.gbtnAddCategory.Animated = true;
            this.gbtnAddCategory.AutoRoundedCorners = true;
            this.gbtnAddCategory.BackColor = System.Drawing.Color.Transparent;
            this.gbtnAddCategory.BorderColor = System.Drawing.Color.DimGray;
            this.gbtnAddCategory.BorderThickness = 1;
            this.gbtnAddCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnAddCategory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAddCategory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAddCategory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnAddCategory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnAddCategory.FillColor = System.Drawing.Color.White;
            this.gbtnAddCategory.FocusedColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbtnAddCategory.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbtnAddCategory.ForeColor = System.Drawing.Color.Black;
            this.gbtnAddCategory.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnAddCategory.HoverState.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnAddCategory.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnAddCategory.Image = ((System.Drawing.Image)(resources.GetObject("gbtnAddCategory.Image")));
            this.gbtnAddCategory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnAddCategory.ImageSize = new System.Drawing.Size(25, 25);
            this.gbtnAddCategory.IndicateFocus = true;
            this.gbtnAddCategory.Location = new System.Drawing.Point(15, 11);
            this.gbtnAddCategory.Name = "gbtnAddCategory";
            this.gbtnAddCategory.PressedColor = System.Drawing.Color.White;
            this.gbtnAddCategory.Size = new System.Drawing.Size(154, 41);
            this.gbtnAddCategory.TabIndex = 115;
            this.gbtnAddCategory.Text = "إضافة فئة";
            this.gbtnAddCategory.Click += new System.EventHandler(this.gbtnAddCategory_Click);
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblUserMessage.Location = new System.Drawing.Point(28, 257);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserMessage.Size = new System.Drawing.Size(1159, 42);
            this.lblUserMessage.TabIndex = 114;
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
            this.kgtxtFilterValue.Location = new System.Drawing.Point(775, 11);
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
            this.kgtxtFilterValue.TabIndex = 113;
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
            this.lblNoRecordsFoundMessage.Location = new System.Drawing.Point(28, 215);
            this.lblNoRecordsFoundMessage.Name = "lblNoRecordsFoundMessage";
            this.lblNoRecordsFoundMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNoRecordsFoundMessage.Size = new System.Drawing.Size(1159, 42);
            this.lblNoRecordsFoundMessage.TabIndex = 112;
            this.lblNoRecordsFoundMessage.Text = "لا يوجد نتائج مطابقة لبحثك !";
            this.lblNoRecordsFoundMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1108, 16);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 111;
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
            this.gcbFilterBy.DropDownWidth = 145;
            this.gcbFilterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterBy.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gcbFilterBy.ForeColor = System.Drawing.Color.Black;
            this.gcbFilterBy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbFilterBy.ItemHeight = 30;
            this.gcbFilterBy.Items.AddRange(new object[] {
            "بدون",
            "معرف الفئة",
            "اسم الفئة",
            "الفئة التابعة لها",
            "الفئة الرئيسية"});
            this.gcbFilterBy.Location = new System.Drawing.Point(941, 11);
            this.gcbFilterBy.Name = "gcbFilterBy";
            this.gcbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcbFilterBy.Size = new System.Drawing.Size(154, 36);
            this.gcbFilterBy.TabIndex = 110;
            this.gcbFilterBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gcbFilterBy.SelectedIndexChanged += new System.EventHandler(this.gcbFilterBy_SelectedIndexChanged);
            // 
            // lblCurrentPageRecordsCount
            // 
            this.lblCurrentPageRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageRecordsCount.Location = new System.Drawing.Point(891, 657);
            this.lblCurrentPageRecordsCount.Name = "lblCurrentPageRecordsCount";
            this.lblCurrentPageRecordsCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageRecordsCount.Size = new System.Drawing.Size(114, 24);
            this.lblCurrentPageRecordsCount.TabIndex = 109;
            this.lblCurrentPageRecordsCount.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1001, 657);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(205, 24);
            this.label3.TabIndex = 108;
            this.label3.Text = "# عدد صفوف الصفحة الحالية : ";
            // 
            // lblCurrentPageOfNumberOfPages
            // 
            this.lblCurrentPageOfNumberOfPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageOfNumberOfPages.Location = new System.Drawing.Point(481, 635);
            this.lblCurrentPageOfNumberOfPages.Name = "lblCurrentPageOfNumberOfPages";
            this.lblCurrentPageOfNumberOfPages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageOfNumberOfPages.Size = new System.Drawing.Size(249, 30);
            this.lblCurrentPageOfNumberOfPages.TabIndex = 104;
            this.lblCurrentPageOfNumberOfPages.Text = "0 من  0  صفحات";
            this.lblCurrentPageOfNumberOfPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalRecordsNumber
            // 
            this.lblTotalRecordsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecordsNumber.Location = new System.Drawing.Point(941, 628);
            this.lblTotalRecordsNumber.Name = "lblTotalRecordsNumber";
            this.lblTotalRecordsNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalRecordsNumber.Size = new System.Drawing.Size(114, 24);
            this.lblTotalRecordsNumber.TabIndex = 103;
            this.lblTotalRecordsNumber.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1051, 628);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 102;
            this.label1.Text = "# عدد الصفوف الكلية : ";
            // 
            // gdgvCategories
            // 
            this.gdgvCategories.AllowUserToAddRows = false;
            this.gdgvCategories.AllowUserToDeleteRows = false;
            this.gdgvCategories.AllowUserToResizeColumns = false;
            this.gdgvCategories.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.gdgvCategories.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gdgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.gdgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gdgvCategories.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gdgvCategories.ColumnHeadersHeight = 35;
            this.gdgvCategories.ContextMenuStrip = this.guna2ContextMenuStrip1;
            this.gdgvCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = "N/A";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdgvCategories.DefaultCellStyle = dataGridViewCellStyle3;
            this.gdgvCategories.GridColor = System.Drawing.Color.White;
            this.gdgvCategories.Location = new System.Drawing.Point(12, 60);
            this.gdgvCategories.MultiSelect = false;
            this.gdgvCategories.Name = "gdgvCategories";
            this.gdgvCategories.ReadOnly = true;
            this.gdgvCategories.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvCategories.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gdgvCategories.RowHeadersVisible = false;
            this.gdgvCategories.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gdgvCategories.RowTemplate.Height = 40;
            this.gdgvCategories.Size = new System.Drawing.Size(1188, 563);
            this.gdgvCategories.TabIndex = 101;
            this.gdgvCategories.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvCategories.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gdgvCategories.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gdgvCategories.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gdgvCategories.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gdgvCategories.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gdgvCategories.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.gdgvCategories.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gdgvCategories.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.gdgvCategories.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvCategories.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gdgvCategories.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gdgvCategories.ThemeStyle.HeaderStyle.Height = 35;
            this.gdgvCategories.ThemeStyle.ReadOnly = true;
            this.gdgvCategories.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvCategories.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gdgvCategories.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvCategories.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvCategories.ThemeStyle.RowsStyle.Height = 40;
            this.gdgvCategories.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gdgvCategories.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvCategories.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gdgvCategories_CellFormatting);
            this.gdgvCategories.DoubleClick += new System.EventHandler(this.gdgvCategories_DoubleClick);
            // 
            // gcbIsActive
            // 
            this.gcbIsActive.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gcbIsActive.AutoRoundedCorners = true;
            this.gcbIsActive.BackColor = System.Drawing.Color.Transparent;
            this.gcbIsActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcbIsActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gcbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gcbIsActive.DropDownWidth = 90;
            this.gcbIsActive.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbIsActive.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbIsActive.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gcbIsActive.ForeColor = System.Drawing.Color.Black;
            this.gcbIsActive.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbIsActive.IntegralHeight = false;
            this.gcbIsActive.ItemHeight = 30;
            this.gcbIsActive.Items.AddRange(new object[] {
            "الكل",
            "فعال",
            "موقوف"});
            this.gcbIsActive.Location = new System.Drawing.Point(627, 11);
            this.gcbIsActive.Name = "gcbIsActive";
            this.gcbIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcbIsActive.Size = new System.Drawing.Size(138, 36);
            this.gcbIsActive.StartIndex = 0;
            this.gcbIsActive.TabIndex = 124;
            this.gcbIsActive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gcbIsActive.SelectedIndexChanged += new System.EventHandler(this.gcbFilterByIsActive_SelectedIndexChanged);
            // 
            // gchkIncludeMainCategory
            // 
            this.gchkIncludeMainCategory.Animated = true;
            this.gchkIncludeMainCategory.AutoSize = true;
            this.gchkIncludeMainCategory.Checked = true;
            this.gchkIncludeMainCategory.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gchkIncludeMainCategory.CheckedState.BorderRadius = 0;
            this.gchkIncludeMainCategory.CheckedState.BorderThickness = 0;
            this.gchkIncludeMainCategory.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gchkIncludeMainCategory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gchkIncludeMainCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gchkIncludeMainCategory.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gchkIncludeMainCategory.Location = new System.Drawing.Point(117, 10);
            this.gchkIncludeMainCategory.Name = "gchkIncludeMainCategory";
            this.gchkIncludeMainCategory.Size = new System.Drawing.Size(107, 25);
            this.gchkIncludeMainCategory.TabIndex = 125;
            this.gchkIncludeMainCategory.Text = "فئات رئيسية";
            this.gchkIncludeMainCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gchkIncludeMainCategory.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gchkIncludeMainCategory.UncheckedState.BorderRadius = 0;
            this.gchkIncludeMainCategory.UncheckedState.BorderThickness = 0;
            this.gchkIncludeMainCategory.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gchkIncludeMainCategory.CheckedChanged += new System.EventHandler(this.gchkIncludeCategory_CheckedChanged);
            // 
            // gchkIncludeSubCategories
            // 
            this.gchkIncludeSubCategories.Animated = true;
            this.gchkIncludeSubCategories.AutoSize = true;
            this.gchkIncludeSubCategories.Checked = true;
            this.gchkIncludeSubCategories.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gchkIncludeSubCategories.CheckedState.BorderRadius = 0;
            this.gchkIncludeSubCategories.CheckedState.BorderThickness = 0;
            this.gchkIncludeSubCategories.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gchkIncludeSubCategories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gchkIncludeSubCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gchkIncludeSubCategories.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gchkIncludeSubCategories.Location = new System.Drawing.Point(10, 10);
            this.gchkIncludeSubCategories.Name = "gchkIncludeSubCategories";
            this.gchkIncludeSubCategories.Size = new System.Drawing.Size(101, 25);
            this.gchkIncludeSubCategories.TabIndex = 126;
            this.gchkIncludeSubCategories.Text = "فئات فرعية";
            this.gchkIncludeSubCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gchkIncludeSubCategories.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gchkIncludeSubCategories.UncheckedState.BorderRadius = 0;
            this.gchkIncludeSubCategories.UncheckedState.BorderThickness = 0;
            this.gchkIncludeSubCategories.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gchkIncludeSubCategories.CheckedChanged += new System.EventHandler(this.gchkIncludeCategory_CheckedChanged);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.gchkIncludeMainCategory);
            this.guna2Panel2.Controls.Add(this.gchkIncludeSubCategories);
            this.guna2Panel2.Location = new System.Drawing.Point(390, 7);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(229, 42);
            this.guna2Panel2.TabIndex = 129;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(509, -3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 130;
            this.label5.Text = "خيارات عرض الفئات";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(717, -2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 131;
            this.label4.Text = "الفعالية";
            // 
            // frmCategoriesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1210, 687);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.gcbIsActive);
            this.Controls.Add(this.gibtnRefreshData);
            this.Controls.Add(this.gbtnAddCategory);
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
            this.Controls.Add(this.gdgvCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCategoriesList";
            this.Text = "frmCategoriesList";
            this.Load += new System.EventHandler(this.frmCategoriesList_Load);
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdgvCategories)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gtsmAddVoucher;
        private System.Windows.Forms.ToolStripMenuItem gtsmEdit;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnRefreshData;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPageNumber;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnPreviousPage;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnNextPage;
        private System.Windows.Forms.Timer SearchAfterTimerFinish;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2Button gbtnAddCategory;
        private System.Windows.Forms.Label lblUserMessage;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtFilterValue;
        private System.Windows.Forms.Label lblNoRecordsFoundMessage;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox gcbFilterBy;
        private System.Windows.Forms.Label lblCurrentPageRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentPageOfNumberOfPages;
        private System.Windows.Forms.Label lblTotalRecordsNumber;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView gdgvCategories;
        private Guna.UI2.WinForms.Guna2ComboBox gcbIsActive;
        private Guna.UI2.WinForms.Guna2CheckBox gchkIncludeMainCategory;
        private Guna.UI2.WinForms.Guna2CheckBox gchkIncludeSubCategories;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem gtsmShowCategoryMonthlyFlow;
    }
}