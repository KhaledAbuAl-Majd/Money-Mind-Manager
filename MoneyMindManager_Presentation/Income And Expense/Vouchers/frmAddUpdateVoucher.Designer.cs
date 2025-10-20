namespace MoneyMindManager_Presentation.Income_And_Expense.Vouchers
{
    partial class frmAddUpdateVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateVoucher));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.lblCurrentPageRecordsCount = new System.Windows.Forms.Label();
            this.lblDescriptionOfCurrentPageNumOfRcords = new System.Windows.Forms.Label();
            this.gibtnPreviousPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.gibtnNextPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lblCurrentPageOfNumberOfPages = new System.Windows.Forms.Label();
            this.lblTotalRecordsNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gdgvTransactions = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.gtsmAddTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmTransactionInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmExport = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblNoTransactionsFoundMessage = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.kgtxtNotes = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtVoucherDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtVoucherName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtPageNumber = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gchkIsLocked = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kgtxtCreatedDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.kgtxtVoucherValue = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtCreatedByUserName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbtnSave = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnAddTransaction = new Guna.UI2.WinForms.Guna2Button();
            this.label8 = new System.Windows.Forms.Label();
            this.kgtxtVoucherID = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gibtnDeleteVoucher = new Guna.UI2.WinForms.Guna2ImageButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gdgvTransactions)).BeginInit();
            this.guna2ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblUserMessage.Location = new System.Drawing.Point(35, 55);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserMessage.Size = new System.Drawing.Size(1148, 30);
            this.lblUserMessage.TabIndex = 39;
            this.lblUserMessage.Text = "\"تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.\"";
            this.lblUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPageRecordsCount
            // 
            this.lblCurrentPageRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageRecordsCount.Location = new System.Drawing.Point(879, 778);
            this.lblCurrentPageRecordsCount.Name = "lblCurrentPageRecordsCount";
            this.lblCurrentPageRecordsCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageRecordsCount.Size = new System.Drawing.Size(114, 24);
            this.lblCurrentPageRecordsCount.TabIndex = 38;
            this.lblCurrentPageRecordsCount.Text = "N/A";
            this.lblCurrentPageRecordsCount.Click += new System.EventHandler(this.lblCurrentPageRecordsCount_Click);
            // 
            // lblDescriptionOfCurrentPageNumOfRcords
            // 
            this.lblDescriptionOfCurrentPageNumOfRcords.AutoSize = true;
            this.lblDescriptionOfCurrentPageNumOfRcords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionOfCurrentPageNumOfRcords.Location = new System.Drawing.Point(996, 778);
            this.lblDescriptionOfCurrentPageNumOfRcords.Name = "lblDescriptionOfCurrentPageNumOfRcords";
            this.lblDescriptionOfCurrentPageNumOfRcords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDescriptionOfCurrentPageNumOfRcords.Size = new System.Drawing.Size(205, 24);
            this.lblDescriptionOfCurrentPageNumOfRcords.TabIndex = 37;
            this.lblDescriptionOfCurrentPageNumOfRcords.Text = "# عدد صفوف الصفحة الحالية : ";
            this.lblDescriptionOfCurrentPageNumOfRcords.Click += new System.EventHandler(this.lblDescriptionOfCurrentPageNumOfRcords_Click);
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
            this.gibtnPreviousPage.Location = new System.Drawing.Point(447, 757);
            this.gibtnPreviousPage.Name = "gibtnPreviousPage";
            this.gibtnPreviousPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnPreviousPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnPreviousPage.TabIndex = 35;
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
            this.gibtnNextPage.Location = new System.Drawing.Point(725, 757);
            this.gibtnNextPage.Name = "gibtnNextPage";
            this.gibtnNextPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnNextPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnNextPage.TabIndex = 34;
            this.toolTip1.SetToolTip(this.gibtnNextPage, "الصفحة التالية");
            this.gibtnNextPage.UseTransparentBackground = true;
            this.gibtnNextPage.Click += new System.EventHandler(this.gibtnNextPage_Click);
            // 
            // lblCurrentPageOfNumberOfPages
            // 
            this.lblCurrentPageOfNumberOfPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageOfNumberOfPages.Location = new System.Drawing.Point(482, 761);
            this.lblCurrentPageOfNumberOfPages.Name = "lblCurrentPageOfNumberOfPages";
            this.lblCurrentPageOfNumberOfPages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageOfNumberOfPages.Size = new System.Drawing.Size(249, 30);
            this.lblCurrentPageOfNumberOfPages.TabIndex = 33;
            this.lblCurrentPageOfNumberOfPages.Text = "0 من  0  صفحات";
            this.lblCurrentPageOfNumberOfPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCurrentPageOfNumberOfPages.Click += new System.EventHandler(this.lblCurrentPageOfNumberOfPages_Click);
            // 
            // lblTotalRecordsNumber
            // 
            this.lblTotalRecordsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecordsNumber.Location = new System.Drawing.Point(924, 749);
            this.lblTotalRecordsNumber.Name = "lblTotalRecordsNumber";
            this.lblTotalRecordsNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalRecordsNumber.Size = new System.Drawing.Size(114, 24);
            this.lblTotalRecordsNumber.TabIndex = 32;
            this.lblTotalRecordsNumber.Text = "N/A";
            this.lblTotalRecordsNumber.Click += new System.EventHandler(this.lblTotalRecordsNumber_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1046, 749);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 31;
            this.label1.Text = "# عدد الصفوف الكلية : ";
            // 
            // gdgvTransactions
            // 
            this.gdgvTransactions.AllowUserToAddRows = false;
            this.gdgvTransactions.AllowUserToDeleteRows = false;
            this.gdgvTransactions.AllowUserToResizeColumns = false;
            this.gdgvTransactions.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.gdgvTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gdgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.gdgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gdgvTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gdgvTransactions.ColumnHeadersHeight = 35;
            this.gdgvTransactions.ContextMenuStrip = this.guna2ContextMenuStrip1;
            this.gdgvTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.NullValue = "N/A";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdgvTransactions.DefaultCellStyle = dataGridViewCellStyle7;
            this.gdgvTransactions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gdgvTransactions.GridColor = System.Drawing.Color.White;
            this.gdgvTransactions.Location = new System.Drawing.Point(19, 258);
            this.gdgvTransactions.MultiSelect = false;
            this.gdgvTransactions.Name = "gdgvTransactions";
            this.gdgvTransactions.ReadOnly = true;
            this.gdgvTransactions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gdgvTransactions.RowHeadersVisible = false;
            this.gdgvTransactions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gdgvTransactions.RowTemplate.Height = 40;
            this.gdgvTransactions.Size = new System.Drawing.Size(1179, 488);
            this.gdgvTransactions.TabIndex = 30;
            this.gdgvTransactions.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvTransactions.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gdgvTransactions.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gdgvTransactions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gdgvTransactions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gdgvTransactions.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gdgvTransactions.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.gdgvTransactions.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gdgvTransactions.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.gdgvTransactions.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvTransactions.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gdgvTransactions.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gdgvTransactions.ThemeStyle.HeaderStyle.Height = 35;
            this.gdgvTransactions.ThemeStyle.ReadOnly = true;
            this.gdgvTransactions.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvTransactions.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gdgvTransactions.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvTransactions.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvTransactions.ThemeStyle.RowsStyle.Height = 40;
            this.gdgvTransactions.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gdgvTransactions.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvTransactions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gdgvTransactions_CellFormatting);
            this.gdgvTransactions.DoubleClick += new System.EventHandler(this.gdgvTransactions_DoubleClick);
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
            // lblNoTransactionsFoundMessage
            // 
            this.lblNoTransactionsFoundMessage.Font = new System.Drawing.Font("Segoe Script", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTransactionsFoundMessage.ForeColor = System.Drawing.Color.Red;
            this.lblNoTransactionsFoundMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblNoTransactionsFoundMessage.Location = new System.Drawing.Point(30, 387);
            this.lblNoTransactionsFoundMessage.Name = "lblNoTransactionsFoundMessage";
            this.lblNoTransactionsFoundMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNoTransactionsFoundMessage.Size = new System.Drawing.Size(1155, 42);
            this.lblNoTransactionsFoundMessage.TabIndex = 42;
            this.lblNoTransactionsFoundMessage.Text = "لا يوجد معاملات لهذا المستند !";
            this.lblNoTransactionsFoundMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoTransactionsFoundMessage.Click += new System.EventHandler(this.lblNoTransactionsFoundMessage_Click);
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
            this.kgtxtNotes.Location = new System.Drawing.Point(850, 145);
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
            this.kgtxtNotes.TextChanged += new System.EventHandler(this.kgtxtNotes_TextChanged);
            // 
            // kgtxtVoucherDate
            // 
            this.kgtxtVoucherDate.AllowWhiteSpace = false;
            this.kgtxtVoucherDate.Animated = true;
            this.kgtxtVoucherDate.ApplyTrimAtTextBoxValue = false;
            this.kgtxtVoucherDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtVoucherDate.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtVoucherDate.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtVoucherDate.BorderRadius = 10;
            this.kgtxtVoucherDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtVoucherDate.DefaultText = "";
            this.kgtxtVoucherDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtVoucherDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtVoucherDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtVoucherDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtVoucherDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtVoucherDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtVoucherDate.ForeColor = System.Drawing.Color.Black;
            this.kgtxtVoucherDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtVoucherDate.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtVoucherDate.IsRequired = true;
            this.kgtxtVoucherDate.Location = new System.Drawing.Point(608, 92);
            this.kgtxtVoucherDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtVoucherDate.MaxLength = 30;
            this.kgtxtVoucherDate.Name = "kgtxtVoucherDate";
            this.kgtxtVoucherDate.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtVoucherDate.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtVoucherDate.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherDate.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherDate.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtVoucherDate.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherDate.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtVoucherDate.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtVoucherDate.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtVoucherDate.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherDate.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherDate.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtVoucherDate.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherDate.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtVoucherDate.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtVoucherDate.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtVoucherDate.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherDate.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherDate.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtVoucherDate.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherDate.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtVoucherDate.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtVoucherDate.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtVoucherDate.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtVoucherDate.PlaceholderText = "تاريخ المستند (مطلوب)";
            this.kgtxtVoucherDate.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtVoucherDate.SelectedText = "";
            this.kgtxtVoucherDate.ShadowDecoration.BorderRadius = 2;
            this.kgtxtVoucherDate.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtVoucherDate.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtVoucherDate.Size = new System.Drawing.Size(220, 41);
            this.kgtxtVoucherDate.TabIndex = 2;
            this.kgtxtVoucherDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtVoucherDate.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtVoucherDate.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtVoucherDate.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtVoucherDate.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtVoucherDate.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtVoucherDate.TextProperties.MinLength = ((short)(0));
            this.kgtxtVoucherDate.TextProperties.MinLengthOption = false;
            this.kgtxtVoucherDate.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtVoucherDate.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtVoucherDate.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Date;
            this.kgtxtVoucherDate.TrimEnd = true;
            this.kgtxtVoucherDate.TrimStart = true;
            this.kgtxtVoucherDate.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxtPageNumber_OnValidationError);
            this.kgtxtVoucherDate.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtPageNumber_OnValidationSuccess);
            this.kgtxtVoucherDate.TextChanged += new System.EventHandler(this.kgtxtVoucherDate_TextChanged);
            // 
            // kgtxtVoucherName
            // 
            this.kgtxtVoucherName.AllowWhiteSpace = true;
            this.kgtxtVoucherName.ApplyTrimAtTextBoxValue = false;
            this.kgtxtVoucherName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtVoucherName.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtVoucherName.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtVoucherName.BorderRadius = 10;
            this.kgtxtVoucherName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtVoucherName.DefaultText = "";
            this.kgtxtVoucherName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtVoucherName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtVoucherName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtVoucherName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtVoucherName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtVoucherName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtVoucherName.ForeColor = System.Drawing.Color.Black;
            this.kgtxtVoucherName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtVoucherName.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtVoucherName.IsRequired = true;
            this.kgtxtVoucherName.Location = new System.Drawing.Point(850, 92);
            this.kgtxtVoucherName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtVoucherName.MaxLength = 150;
            this.kgtxtVoucherName.Name = "kgtxtVoucherName";
            this.kgtxtVoucherName.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtVoucherName.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtVoucherName.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherName.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherName.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtVoucherName.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherName.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtVoucherName.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtVoucherName.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtVoucherName.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherName.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherName.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtVoucherName.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherName.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtVoucherName.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtVoucherName.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtVoucherName.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherName.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherName.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtVoucherName.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherName.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtVoucherName.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtVoucherName.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtVoucherName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtVoucherName.PlaceholderText = "اسم المستند (مطلوب)";
            this.kgtxtVoucherName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtVoucherName.SelectedText = "";
            this.kgtxtVoucherName.ShadowDecoration.BorderRadius = 2;
            this.kgtxtVoucherName.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtVoucherName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtVoucherName.Size = new System.Drawing.Size(337, 41);
            this.kgtxtVoucherName.TabIndex = 0;
            this.kgtxtVoucherName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtVoucherName.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtVoucherName.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtVoucherName.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtVoucherName.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtVoucherName.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtVoucherName.TextProperties.MinLength = ((short)(0));
            this.kgtxtVoucherName.TextProperties.MinLengthOption = false;
            this.kgtxtVoucherName.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtVoucherName.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtVoucherName.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtVoucherName.TrimEnd = true;
            this.kgtxtVoucherName.TrimStart = true;
            this.kgtxtVoucherName.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxtPageNumber_OnValidationError);
            this.kgtxtVoucherName.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtPageNumber_OnValidationSuccess);
            this.kgtxtVoucherName.TextChanged += new System.EventHandler(this.kgtxtVoucherName_TextChanged);
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
            this.kgtxtPageNumber.Location = new System.Drawing.Point(199, 757);
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
            this.kgtxtPageNumber.TabIndex = 36;
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
            this.kgtxtPageNumber.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxtPageNumber_OnValidationError);
            this.kgtxtPageNumber.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtPageNumber_OnValidationSuccess);
            this.kgtxtPageNumber.TextChanged += new System.EventHandler(this.kgtxtPageNumber_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1115, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 105;
            this.label3.Text = "اسم المستند";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(754, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 106;
            this.label4.Text = "تاريخ المستند";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1133, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 107;
            this.label5.Text = "ملاحظات";
            this.label5.Click += new System.EventHandler(this.label5_Click);
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
            this.gchkIsLocked.Location = new System.Drawing.Point(139, 98);
            this.gchkIsLocked.Name = "gchkIsLocked";
            this.gchkIsLocked.Size = new System.Drawing.Size(64, 25);
            this.gchkIsLocked.TabIndex = 8;
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
            this.label2.Location = new System.Drawing.Point(521, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 110;
            this.label2.Text = "تاريخ الإنشاء";
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            this.kgtxtCreatedDate.Location = new System.Drawing.Point(367, 92);
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
            this.kgtxtCreatedDate.TabIndex = 5;
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
            this.kgtxtCreatedDate.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxtPageNumber_OnValidationError);
            this.kgtxtCreatedDate.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtPageNumber_OnValidationSuccess);
            this.kgtxtCreatedDate.TextChanged += new System.EventHandler(this.kgtxtCreatedDate_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(754, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 112;
            this.label6.Text = "قيمة المستند";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // kgtxtVoucherValue
            // 
            this.kgtxtVoucherValue.AllowWhiteSpace = true;
            this.kgtxtVoucherValue.ApplyTrimAtTextBoxValue = false;
            this.kgtxtVoucherValue.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtVoucherValue.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtVoucherValue.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtVoucherValue.BorderRadius = 10;
            this.kgtxtVoucherValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtVoucherValue.DefaultText = "0.0000";
            this.kgtxtVoucherValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtVoucherValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtVoucherValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtVoucherValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtVoucherValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtVoucherValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtVoucherValue.ForeColor = System.Drawing.Color.Black;
            this.kgtxtVoucherValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtVoucherValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtVoucherValue.IsRequired = false;
            this.kgtxtVoucherValue.Location = new System.Drawing.Point(608, 145);
            this.kgtxtVoucherValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtVoucherValue.MaxLength = 150;
            this.kgtxtVoucherValue.Name = "kgtxtVoucherValue";
            this.kgtxtVoucherValue.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtVoucherValue.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtVoucherValue.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherValue.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherValue.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtVoucherValue.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherValue.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtVoucherValue.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtVoucherValue.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtVoucherValue.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherValue.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherValue.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtVoucherValue.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherValue.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtVoucherValue.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtVoucherValue.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtVoucherValue.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherValue.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherValue.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtVoucherValue.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherValue.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtVoucherValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.N4;
            this.kgtxtVoucherValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber;
            this.kgtxtVoucherValue.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtVoucherValue.PlaceholderText = "اسم المستند (مطلوب)";
            this.kgtxtVoucherValue.ReadOnly = true;
            this.kgtxtVoucherValue.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtVoucherValue.SelectedText = "";
            this.kgtxtVoucherValue.ShadowDecoration.BorderRadius = 2;
            this.kgtxtVoucherValue.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtVoucherValue.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtVoucherValue.Size = new System.Drawing.Size(220, 41);
            this.kgtxtVoucherValue.TabIndex = 3;
            this.kgtxtVoucherValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtVoucherValue.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtVoucherValue.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtVoucherValue.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtVoucherValue.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtVoucherValue.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtVoucherValue.TextProperties.MinLength = ((short)(0));
            this.kgtxtVoucherValue.TextProperties.MinLengthOption = false;
            this.kgtxtVoucherValue.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtVoucherValue.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtVoucherValue.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtVoucherValue.TrimEnd = true;
            this.kgtxtVoucherValue.TrimStart = true;
            this.kgtxtVoucherValue.TextChanged += new System.EventHandler(this.kgtxtVoucherValue_TextChanged);
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
            this.kgtxtCreatedByUserName.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtCreatedByUserName.IsRequired = false;
            this.kgtxtCreatedByUserName.Location = new System.Drawing.Point(608, 198);
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
            this.kgtxtCreatedByUserName.Size = new System.Drawing.Size(220, 41);
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
            this.kgtxtCreatedByUserName.TrimEnd = true;
            this.kgtxtCreatedByUserName.TrimStart = true;
            this.kgtxtCreatedByUserName.TextChanged += new System.EventHandler(this.kgtxtCreatedByUserName_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(699, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 17);
            this.label7.TabIndex = 114;
            this.label7.Text = "اسم المستخدم للمنشئ ";
            this.label7.Click += new System.EventHandler(this.label7_Click);
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
            this.gbtnSave.Location = new System.Drawing.Point(367, 145);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.PressedColor = System.Drawing.Color.White;
            this.gbtnSave.Size = new System.Drawing.Size(220, 41);
            this.gbtnSave.TabIndex = 6;
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
            this.gbtnClose.Location = new System.Drawing.Point(367, 199);
            this.gbtnClose.Name = "gbtnClose";
            this.gbtnClose.PressedColor = System.Drawing.Color.White;
            this.gbtnClose.Size = new System.Drawing.Size(220, 41);
            this.gbtnClose.TabIndex = 7;
            this.gbtnClose.Text = "غلق";
            this.gbtnClose.Click += new System.EventHandler(this.gbtnClose_Click);
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
            this.gbtnAddTransaction.Location = new System.Drawing.Point(20, 199);
            this.gbtnAddTransaction.Name = "gbtnAddTransaction";
            this.gbtnAddTransaction.PressedColor = System.Drawing.Color.White;
            this.gbtnAddTransaction.Size = new System.Drawing.Size(210, 41);
            this.gbtnAddTransaction.TabIndex = 9;
            this.gbtnAddTransaction.Text = "إضافة معاملة";
            this.gbtnAddTransaction.Click += new System.EventHandler(this.gbtnAddTransaction_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(265, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 116;
            this.label8.Text = "معرف المستند";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // kgtxtVoucherID
            // 
            this.kgtxtVoucherID.AllowWhiteSpace = true;
            this.kgtxtVoucherID.ApplyTrimAtTextBoxValue = true;
            this.kgtxtVoucherID.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtVoucherID.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtVoucherID.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtVoucherID.BorderRadius = 10;
            this.kgtxtVoucherID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtVoucherID.DefaultText = "1234567891";
            this.kgtxtVoucherID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtVoucherID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtVoucherID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtVoucherID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtVoucherID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtVoucherID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtVoucherID.ForeColor = System.Drawing.Color.Black;
            this.kgtxtVoucherID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtVoucherID.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtVoucherID.IsRequired = false;
            this.kgtxtVoucherID.Location = new System.Drawing.Point(209, 92);
            this.kgtxtVoucherID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtVoucherID.MaxLength = 150;
            this.kgtxtVoucherID.Name = "kgtxtVoucherID";
            this.kgtxtVoucherID.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtVoucherID.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtVoucherID.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherID.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherID.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtVoucherID.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherID.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtVoucherID.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtVoucherID.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtVoucherID.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherID.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherID.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtVoucherID.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherID.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtVoucherID.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtVoucherID.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtVoucherID.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtVoucherID.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtVoucherID.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtVoucherID.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtVoucherID.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtVoucherID.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtVoucherID.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtVoucherID.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtVoucherID.PlaceholderText = "معرف المستند";
            this.kgtxtVoucherID.ReadOnly = true;
            this.kgtxtVoucherID.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtVoucherID.SelectedText = "";
            this.kgtxtVoucherID.ShadowDecoration.BorderRadius = 2;
            this.kgtxtVoucherID.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtVoucherID.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtVoucherID.Size = new System.Drawing.Size(138, 41);
            this.kgtxtVoucherID.TabIndex = 115;
            this.kgtxtVoucherID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtVoucherID.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtVoucherID.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtVoucherID.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtVoucherID.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtVoucherID.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtVoucherID.TextProperties.MinLength = ((short)(0));
            this.kgtxtVoucherID.TextProperties.MinLengthOption = false;
            this.kgtxtVoucherID.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtVoucherID.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtVoucherID.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtVoucherID.TrimEnd = true;
            this.kgtxtVoucherID.TrimStart = true;
            this.kgtxtVoucherID.TextChanged += new System.EventHandler(this.kgtxtVoucherID_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1103, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 117;
            this.label9.Text = "معاملات المستند";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // gibtnDeleteVoucher
            // 
            this.gibtnDeleteVoucher.BackColor = System.Drawing.Color.Transparent;
            this.gibtnDeleteVoucher.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnDeleteVoucher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gibtnDeleteVoucher.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.gibtnDeleteVoucher.Image = ((System.Drawing.Image)(resources.GetObject("gibtnDeleteVoucher.Image")));
            this.gibtnDeleteVoucher.ImageOffset = new System.Drawing.Point(0, 0);
            this.gibtnDeleteVoucher.ImageRotate = 0F;
            this.gibtnDeleteVoucher.ImageSize = new System.Drawing.Size(28, 28);
            this.gibtnDeleteVoucher.Location = new System.Drawing.Point(79, 89);
            this.gibtnDeleteVoucher.Name = "gibtnDeleteVoucher";
            this.gibtnDeleteVoucher.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnDeleteVoucher.Size = new System.Drawing.Size(40, 42);
            this.gibtnDeleteVoucher.TabIndex = 118;
            this.toolTip1.SetToolTip(this.gibtnDeleteVoucher, "حذف المستند , يجب حذف جميع المعاملات أولا");
            this.gibtnDeleteVoucher.UseTransparentBackground = true;
            this.gibtnDeleteVoucher.Click += new System.EventHandler(this.gibtnDeleteVoucher_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // frmAddUpdateVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.gbtnClose;
            this.ClientSize = new System.Drawing.Size(1210, 809);
            this.Controls.Add(this.gibtnDeleteVoucher);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gchkIsLocked);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.kgtxtVoucherID);
            this.Controls.Add(this.gbtnAddTransaction);
            this.Controls.Add(this.gbtnClose);
            this.Controls.Add(this.gbtnSave);
            this.Controls.Add(this.kgtxtCreatedByUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.kgtxtVoucherValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kgtxtCreatedDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kgtxtNotes);
            this.Controls.Add(this.kgtxtVoucherDate);
            this.Controls.Add(this.kgtxtVoucherName);
            this.Controls.Add(this.lblNoTransactionsFoundMessage);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.lblCurrentPageRecordsCount);
            this.Controls.Add(this.lblDescriptionOfCurrentPageNumOfRcords);
            this.Controls.Add(this.kgtxtPageNumber);
            this.Controls.Add(this.gibtnPreviousPage);
            this.Controls.Add(this.gibtnNextPage);
            this.Controls.Add(this.lblCurrentPageOfNumberOfPages);
            this.Controls.Add(this.lblTotalRecordsNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gdgvTransactions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateVoucher";
            this.Text = "frmAddVoucher";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.frmAddUpdateVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdgvTransactions)).EndInit();
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUserMessage;
        private System.Windows.Forms.Label lblCurrentPageRecordsCount;
        private System.Windows.Forms.Label lblDescriptionOfCurrentPageNumOfRcords;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPageNumber;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnPreviousPage;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnNextPage;
        private System.Windows.Forms.Label lblCurrentPageOfNumberOfPages;
        private System.Windows.Forms.Label lblTotalRecordsNumber;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView gdgvTransactions;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblNoTransactionsFoundMessage;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtVoucherName;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtVoucherDate;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2CheckBox gchkIsLocked;
        private System.Windows.Forms.Label label2;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtCreatedDate;
        private System.Windows.Forms.Label label6;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtVoucherValue;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtCreatedByUserName;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button gbtnSave;
        private Guna.UI2.WinForms.Guna2Button gbtnClose;
        private Guna.UI2.WinForms.Guna2Button gbtnAddTransaction;
        private System.Windows.Forms.Label label8;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtVoucherID;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gtsmAddTransactions;
        private System.Windows.Forms.ToolStripMenuItem gtsmEdit;
        private System.Windows.Forms.ToolStripMenuItem gtsmDelete;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnDeleteVoucher;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem gtsmTransactionInfo;
        private System.Windows.Forms.ToolStripMenuItem gtsmExport;
        private System.Windows.Forms.ToolStripMenuItem gtsmExportExcel;
    }
}