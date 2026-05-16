namespace MoneyMindManager.UI.Forms.Debts.DebtPayment
{
    partial class ctrDebtPaymentsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrDebtPaymentsList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNoTransactionsFoundMessage = new System.Windows.Forms.Label();
            this.kgtxtPageNumber = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.gibtnPreviousPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.gibtnNextPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lblCurrentPageOfNumberOfPages = new System.Windows.Forms.Label();
            this.lblTotalRecordsNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gdgvDebtPaymentTransctions = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.gtsmAddTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmTransactionInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchAfterTimerFinish = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.lblCurrentPageRecordsCount = new System.Windows.Forms.Label();
            this.lblDescriptionOfCurrentPageNumOfRcords = new System.Windows.Forms.Label();
            this.gbtnAddTransaction = new Guna.UI2.WinForms.Guna2Button();
            this.gibtnRefreshData = new Guna.UI2.WinForms.Guna2ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.gdgvDebtPaymentTransctions)).BeginInit();
            this.guna2ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNoTransactionsFoundMessage
            // 
            this.lblNoTransactionsFoundMessage.Font = new System.Drawing.Font("Segoe Script", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTransactionsFoundMessage.ForeColor = System.Drawing.Color.Red;
            this.lblNoTransactionsFoundMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblNoTransactionsFoundMessage.Location = new System.Drawing.Point(9, 135);
            this.lblNoTransactionsFoundMessage.Name = "lblNoTransactionsFoundMessage";
            this.lblNoTransactionsFoundMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNoTransactionsFoundMessage.Size = new System.Drawing.Size(1155, 42);
            this.lblNoTransactionsFoundMessage.TabIndex = 50;
            this.lblNoTransactionsFoundMessage.Text = "لا يوجد معاملات سداد لمستند الدين هذا !";
            this.lblNoTransactionsFoundMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.kgtxtPageNumber.Location = new System.Drawing.Point(250, 499);
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
            this.kgtxtPageNumber.TabIndex = 49;
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
            this.gibtnPreviousPage.Location = new System.Drawing.Point(426, 499);
            this.gibtnPreviousPage.Name = "gibtnPreviousPage";
            this.gibtnPreviousPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnPreviousPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnPreviousPage.TabIndex = 48;
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
            this.gibtnNextPage.Location = new System.Drawing.Point(704, 499);
            this.gibtnNextPage.Name = "gibtnNextPage";
            this.gibtnNextPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnNextPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnNextPage.TabIndex = 47;
            this.toolTip1.SetToolTip(this.gibtnNextPage, "الصفحة التالية");
            this.gibtnNextPage.UseTransparentBackground = true;
            this.gibtnNextPage.Click += new System.EventHandler(this.gibtnNextPage_Click);
            // 
            // lblCurrentPageOfNumberOfPages
            // 
            this.lblCurrentPageOfNumberOfPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageOfNumberOfPages.Location = new System.Drawing.Point(461, 503);
            this.lblCurrentPageOfNumberOfPages.Name = "lblCurrentPageOfNumberOfPages";
            this.lblCurrentPageOfNumberOfPages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageOfNumberOfPages.Size = new System.Drawing.Size(249, 30);
            this.lblCurrentPageOfNumberOfPages.TabIndex = 46;
            this.lblCurrentPageOfNumberOfPages.Text = "0 من  0  صفحات";
            this.lblCurrentPageOfNumberOfPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalRecordsNumber
            // 
            this.lblTotalRecordsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecordsNumber.Location = new System.Drawing.Point(903, 493);
            this.lblTotalRecordsNumber.Name = "lblTotalRecordsNumber";
            this.lblTotalRecordsNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalRecordsNumber.Size = new System.Drawing.Size(114, 24);
            this.lblTotalRecordsNumber.TabIndex = 45;
            this.lblTotalRecordsNumber.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1025, 493);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 44;
            this.label1.Text = "# عدد الصفوف الكلية : ";
            // 
            // gdgvDebtPaymentTransctions
            // 
            this.gdgvDebtPaymentTransctions.AllowUserToAddRows = false;
            this.gdgvDebtPaymentTransctions.AllowUserToDeleteRows = false;
            this.gdgvDebtPaymentTransctions.AllowUserToResizeColumns = false;
            this.gdgvDebtPaymentTransctions.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.gdgvDebtPaymentTransctions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gdgvDebtPaymentTransctions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.gdgvDebtPaymentTransctions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gdgvDebtPaymentTransctions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvDebtPaymentTransctions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gdgvDebtPaymentTransctions.ColumnHeadersHeight = 35;
            this.gdgvDebtPaymentTransctions.ContextMenuStrip = this.guna2ContextMenuStrip1;
            this.gdgvDebtPaymentTransctions.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = "N/A";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdgvDebtPaymentTransctions.DefaultCellStyle = dataGridViewCellStyle3;
            this.gdgvDebtPaymentTransctions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gdgvDebtPaymentTransctions.GridColor = System.Drawing.Color.White;
            this.gdgvDebtPaymentTransctions.Location = new System.Drawing.Point(-2, 6);
            this.gdgvDebtPaymentTransctions.MultiSelect = false;
            this.gdgvDebtPaymentTransctions.Name = "gdgvDebtPaymentTransctions";
            this.gdgvDebtPaymentTransctions.ReadOnly = true;
            this.gdgvDebtPaymentTransctions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvDebtPaymentTransctions.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gdgvDebtPaymentTransctions.RowHeadersVisible = false;
            this.gdgvDebtPaymentTransctions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gdgvDebtPaymentTransctions.RowTemplate.Height = 40;
            this.gdgvDebtPaymentTransctions.Size = new System.Drawing.Size(1179, 484);
            this.gdgvDebtPaymentTransctions.TabIndex = 43;
            this.gdgvDebtPaymentTransctions.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvDebtPaymentTransctions.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gdgvDebtPaymentTransctions.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gdgvDebtPaymentTransctions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gdgvDebtPaymentTransctions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gdgvDebtPaymentTransctions.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gdgvDebtPaymentTransctions.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.gdgvDebtPaymentTransctions.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gdgvDebtPaymentTransctions.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.gdgvDebtPaymentTransctions.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvDebtPaymentTransctions.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gdgvDebtPaymentTransctions.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gdgvDebtPaymentTransctions.ThemeStyle.HeaderStyle.Height = 35;
            this.gdgvDebtPaymentTransctions.ThemeStyle.ReadOnly = true;
            this.gdgvDebtPaymentTransctions.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvDebtPaymentTransctions.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gdgvDebtPaymentTransctions.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvDebtPaymentTransctions.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvDebtPaymentTransctions.ThemeStyle.RowsStyle.Height = 40;
            this.gdgvDebtPaymentTransctions.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gdgvDebtPaymentTransctions.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvDebtPaymentTransctions.DoubleClick += new System.EventHandler(this.gdgvTransactions_DoubleClick);
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.BackColor = System.Drawing.Color.Snow;
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gtsmAddTransactions,
            this.gtsmEdit,
            this.gtsmTransactionInfo,
            this.gtsmDelete,
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
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(206, 184);
            // 
            // gtsmAddTransactions
            // 
            this.gtsmAddTransactions.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmAddTransactions.Image = ((System.Drawing.Image)(resources.GetObject("gtsmAddTransactions.Image")));
            this.gtsmAddTransactions.Name = "gtsmAddTransactions";
            this.gtsmAddTransactions.Size = new System.Drawing.Size(205, 36);
            this.gtsmAddTransactions.Text = "إضافة معاملة";
            this.gtsmAddTransactions.Click += new System.EventHandler(this.gtsmAddTransactions_Click);
            // 
            // gtsmEdit
            // 
            this.gtsmEdit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmEdit.Image = ((System.Drawing.Image)(resources.GetObject("gtsmEdit.Image")));
            this.gtsmEdit.Name = "gtsmEdit";
            this.gtsmEdit.Size = new System.Drawing.Size(205, 36);
            this.gtsmEdit.Text = "تعديل";
            this.gtsmEdit.Click += new System.EventHandler(this.gtsmEdit_Click);
            // 
            // gtsmTransactionInfo
            // 
            this.gtsmTransactionInfo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmTransactionInfo.Image = ((System.Drawing.Image)(resources.GetObject("gtsmTransactionInfo.Image")));
            this.gtsmTransactionInfo.Name = "gtsmTransactionInfo";
            this.gtsmTransactionInfo.Size = new System.Drawing.Size(205, 36);
            this.gtsmTransactionInfo.Text = "معلومات المعاملة";
            this.gtsmTransactionInfo.Click += new System.EventHandler(this.gtsmTransactionInfo_Click);
            // 
            // gtsmDelete
            // 
            this.gtsmDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmDelete.Image = ((System.Drawing.Image)(resources.GetObject("gtsmDelete.Image")));
            this.gtsmDelete.Name = "gtsmDelete";
            this.gtsmDelete.Size = new System.Drawing.Size(205, 36);
            this.gtsmDelete.Text = "حذف";
            this.gtsmDelete.Click += new System.EventHandler(this.gtsmDelete_Click);
            // 
            // gtsmExport
            // 
            this.gtsmExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gtsmExportExcel});
            this.gtsmExport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmExport.Image = ((System.Drawing.Image)(resources.GetObject("gtsmExport.Image")));
            this.gtsmExport.Name = "gtsmExport";
            this.gtsmExport.Size = new System.Drawing.Size(205, 36);
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
            this.gtsmExportExcel.Click += new System.EventHandler(this.gtsmExportExcel_Click);
            // 
            // SearchAfterTimerFinish
            // 
            this.SearchAfterTimerFinish.Interval = 400;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMessage.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblUserMessage.Location = new System.Drawing.Point(14, 188);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserMessage.Size = new System.Drawing.Size(1148, 30);
            this.lblUserMessage.TabIndex = 51;
            this.lblUserMessage.Text = "\"تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.\"";
            this.lblUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPageRecordsCount
            // 
            this.lblCurrentPageRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageRecordsCount.Location = new System.Drawing.Point(858, 518);
            this.lblCurrentPageRecordsCount.Name = "lblCurrentPageRecordsCount";
            this.lblCurrentPageRecordsCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageRecordsCount.Size = new System.Drawing.Size(114, 24);
            this.lblCurrentPageRecordsCount.TabIndex = 53;
            this.lblCurrentPageRecordsCount.Text = "N/A";
            // 
            // lblDescriptionOfCurrentPageNumOfRcords
            // 
            this.lblDescriptionOfCurrentPageNumOfRcords.AutoSize = true;
            this.lblDescriptionOfCurrentPageNumOfRcords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionOfCurrentPageNumOfRcords.Location = new System.Drawing.Point(975, 518);
            this.lblDescriptionOfCurrentPageNumOfRcords.Name = "lblDescriptionOfCurrentPageNumOfRcords";
            this.lblDescriptionOfCurrentPageNumOfRcords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDescriptionOfCurrentPageNumOfRcords.Size = new System.Drawing.Size(205, 24);
            this.lblDescriptionOfCurrentPageNumOfRcords.TabIndex = 52;
            this.lblDescriptionOfCurrentPageNumOfRcords.Text = "# عدد صفوف الصفحة الحالية : ";
            // 
            // gbtnAddTransaction
            // 
            this.gbtnAddTransaction.Animated = true;
            this.gbtnAddTransaction.AutoRoundedCorners = true;
            this.gbtnAddTransaction.BackColor = System.Drawing.Color.Transparent;
            this.gbtnAddTransaction.BorderColor = System.Drawing.Color.DimGray;
            this.gbtnAddTransaction.BorderThickness = 1;
            this.gbtnAddTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnAddTransaction.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.gbtnAddTransaction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAddTransaction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAddTransaction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnAddTransaction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnAddTransaction.FillColor = System.Drawing.Color.White;
            this.gbtnAddTransaction.FocusedColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbtnAddTransaction.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbtnAddTransaction.ForeColor = System.Drawing.Color.Black;
            this.gbtnAddTransaction.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnAddTransaction.HoverState.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnAddTransaction.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnAddTransaction.Image = ((System.Drawing.Image)(resources.GetObject("gbtnAddTransaction.Image")));
            this.gbtnAddTransaction.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnAddTransaction.ImageSize = new System.Drawing.Size(25, 25);
            this.gbtnAddTransaction.IndicateFocus = true;
            this.gbtnAddTransaction.Location = new System.Drawing.Point(58, 496);
            this.gbtnAddTransaction.Name = "gbtnAddTransaction";
            this.gbtnAddTransaction.PressedColor = System.Drawing.Color.White;
            this.gbtnAddTransaction.Size = new System.Drawing.Size(173, 41);
            this.gbtnAddTransaction.TabIndex = 54;
            this.gbtnAddTransaction.Text = "إضافة معاملة";
            this.gbtnAddTransaction.Click += new System.EventHandler(this.gbtnAddTransaction_Click);
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
            this.gibtnRefreshData.Location = new System.Drawing.Point(12, 495);
            this.gibtnRefreshData.Name = "gibtnRefreshData";
            this.gibtnRefreshData.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnRefreshData.Size = new System.Drawing.Size(40, 42);
            this.gibtnRefreshData.TabIndex = 55;
            this.toolTip1.SetToolTip(this.gibtnRefreshData, "تحديث البيانات");
            this.gibtnRefreshData.UseTransparentBackground = true;
            this.gibtnRefreshData.Click += new System.EventHandler(this.gibtnRefreshData_Click);
            // 
            // ctrDebtPaymentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gibtnRefreshData);
            this.Controls.Add(this.gbtnAddTransaction);
            this.Controls.Add(this.lblCurrentPageRecordsCount);
            this.Controls.Add(this.lblDescriptionOfCurrentPageNumOfRcords);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.lblNoTransactionsFoundMessage);
            this.Controls.Add(this.kgtxtPageNumber);
            this.Controls.Add(this.gibtnPreviousPage);
            this.Controls.Add(this.gibtnNextPage);
            this.Controls.Add(this.lblCurrentPageOfNumberOfPages);
            this.Controls.Add(this.lblTotalRecordsNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gdgvDebtPaymentTransctions);
            this.Name = "ctrDebtPaymentsList";
            this.Size = new System.Drawing.Size(1179, 547);
            this.Load += new System.EventHandler(this.ctrDebtPaymentsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdgvDebtPaymentTransctions)).EndInit();
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNoTransactionsFoundMessage;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPageNumber;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnPreviousPage;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnNextPage;
        private System.Windows.Forms.Label lblCurrentPageOfNumberOfPages;
        private System.Windows.Forms.Label lblTotalRecordsNumber;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView gdgvDebtPaymentTransctions;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gtsmAddTransactions;
        private System.Windows.Forms.ToolStripMenuItem gtsmEdit;
        private System.Windows.Forms.ToolStripMenuItem gtsmTransactionInfo;
        private System.Windows.Forms.ToolStripMenuItem gtsmDelete;
        private System.Windows.Forms.ToolStripMenuItem gtsmExport;
        private System.Windows.Forms.ToolStripMenuItem gtsmExportExcel;
        private System.Windows.Forms.Timer SearchAfterTimerFinish;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblUserMessage;
        private System.Windows.Forms.Label lblCurrentPageRecordsCount;
        private System.Windows.Forms.Label lblDescriptionOfCurrentPageNumOfRcords;
        private Guna.UI2.WinForms.Guna2Button gbtnAddTransaction;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnRefreshData;
    }
}
