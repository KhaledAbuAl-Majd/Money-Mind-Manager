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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.lblCurrentPageRecordsCount = new System.Windows.Forms.Label();
            this.lblDescriptionOfCurrentPageNumOfRcords = new System.Windows.Forms.Label();
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblNoTransactionsFoundMessage = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.kgtxtNotes = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtDebtDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtPageNumber = new KhaledControlLibrary1.KhaledGuna2TextBox();
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
            this.gbtnAddDebtPaymentTransaction = new Guna.UI2.WinForms.Guna2Button();
            this.label8 = new System.Windows.Forms.Label();
            this.kgtxtDebtID = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gibtnDeleteDebt = new Guna.UI2.WinForms.Guna2ImageButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.kgtxtPersonName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gcbDebtType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.kgtxtPaymentDueDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.kgtxtDebtValue = new KhaledControlLibrary1.KhaledGuna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gdgvDebtPaymentTransctions)).BeginInit();
            this.guna2ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.lblUserMessage.Click += new System.EventHandler(this.lblUserMessage_Click);
            // 
            // lblCurrentPageRecordsCount
            // 
            this.lblCurrentPageRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageRecordsCount.Location = new System.Drawing.Point(879, 779);
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
            this.lblDescriptionOfCurrentPageNumOfRcords.Location = new System.Drawing.Point(996, 779);
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
            this.gibtnPreviousPage.Location = new System.Drawing.Point(447, 756);
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
            this.gibtnNextPage.Location = new System.Drawing.Point(725, 756);
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
            this.lblCurrentPageOfNumberOfPages.Location = new System.Drawing.Point(482, 760);
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
            this.lblTotalRecordsNumber.Location = new System.Drawing.Point(924, 750);
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
            this.label1.Location = new System.Drawing.Point(1046, 750);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 31;
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
            this.gdgvDebtPaymentTransctions.Location = new System.Drawing.Point(19, 263);
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
            this.gdgvDebtPaymentTransctions.TabIndex = 30;
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
            this.gdgvDebtPaymentTransctions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gdgvTransactions_CellFormatting);
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
            this.lblHeader.Click += new System.EventHandler(this.lblHeader_Click);
            // 
            // lblNoTransactionsFoundMessage
            // 
            this.lblNoTransactionsFoundMessage.Font = new System.Drawing.Font("Segoe Script", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoTransactionsFoundMessage.ForeColor = System.Drawing.Color.Red;
            this.lblNoTransactionsFoundMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblNoTransactionsFoundMessage.Location = new System.Drawing.Point(30, 392);
            this.lblNoTransactionsFoundMessage.Name = "lblNoTransactionsFoundMessage";
            this.lblNoTransactionsFoundMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNoTransactionsFoundMessage.Size = new System.Drawing.Size(1155, 42);
            this.lblNoTransactionsFoundMessage.TabIndex = 42;
            this.lblNoTransactionsFoundMessage.Text = "لا يوجد معاملات سداد لسند الدين هذا !";
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
            this.kgtxtNotes.TextChanged += new System.EventHandler(this.kgtxtNotes_TextChanged);
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
            this.kgtxtDebtDate.TextChanged += new System.EventHandler(this.kgtxtDebtDate_TextChanged);
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
            this.kgtxtPageNumber.Location = new System.Drawing.Point(199, 756);
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
            this.kgtxtPageNumber.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtPageNumber.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtPageNumber.TextChanged += new System.EventHandler(this.kgtxtPageNumber_TextChanged);
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
            this.label4.Click += new System.EventHandler(this.label4_Click);
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
            this.gchkIsLocked.Location = new System.Drawing.Point(280, 210);
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
            this.kgtxtCreatedDate.TextChanged += new System.EventHandler(this.kgtxtCreatedDate_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(460, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 17);
            this.label6.TabIndex = 112;
            this.label6.Text = "القيمة المتبقية للسداد";
            this.label6.Click += new System.EventHandler(this.label6_Click);
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
            this.kgtxtRemainingAmount.Location = new System.Drawing.Point(362, 150);
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
            this.kgtxtRemainingAmount.TextChanged += new System.EventHandler(this.kgtxtRemainingAmount_TextChanged);
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
            this.kgtxtCreatedByUserName.Location = new System.Drawing.Point(362, 204);
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
            this.label7.Location = new System.Drawing.Point(453, 192);
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
            this.gbtnSave.Location = new System.Drawing.Point(19, 97);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.PressedColor = System.Drawing.Color.White;
            this.gbtnSave.Size = new System.Drawing.Size(173, 41);
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
            this.gbtnClose.Location = new System.Drawing.Point(19, 150);
            this.gbtnClose.Name = "gbtnClose";
            this.gbtnClose.PressedColor = System.Drawing.Color.White;
            this.gbtnClose.Size = new System.Drawing.Size(173, 41);
            this.gbtnClose.TabIndex = 12;
            this.gbtnClose.Text = "غلق";
            this.gbtnClose.Click += new System.EventHandler(this.gbtnClose_Click);
            // 
            // gbtnAddDebtPaymentTransaction
            // 
            this.gbtnAddDebtPaymentTransaction.Animated = true;
            this.gbtnAddDebtPaymentTransaction.AutoRoundedCorners = true;
            this.gbtnAddDebtPaymentTransaction.BackColor = System.Drawing.Color.Transparent;
            this.gbtnAddDebtPaymentTransaction.BorderColor = System.Drawing.Color.DimGray;
            this.gbtnAddDebtPaymentTransaction.BorderThickness = 1;
            this.gbtnAddDebtPaymentTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnAddDebtPaymentTransaction.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.gbtnAddDebtPaymentTransaction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAddDebtPaymentTransaction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAddDebtPaymentTransaction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnAddDebtPaymentTransaction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnAddDebtPaymentTransaction.FillColor = System.Drawing.Color.White;
            this.gbtnAddDebtPaymentTransaction.FocusedColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbtnAddDebtPaymentTransaction.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbtnAddDebtPaymentTransaction.ForeColor = System.Drawing.Color.Black;
            this.gbtnAddDebtPaymentTransaction.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnAddDebtPaymentTransaction.HoverState.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnAddDebtPaymentTransaction.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnAddDebtPaymentTransaction.Image = ((System.Drawing.Image)(resources.GetObject("gbtnAddDebtPaymentTransaction.Image")));
            this.gbtnAddDebtPaymentTransaction.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnAddDebtPaymentTransaction.ImageSize = new System.Drawing.Size(25, 25);
            this.gbtnAddDebtPaymentTransaction.IndicateFocus = true;
            this.gbtnAddDebtPaymentTransaction.Location = new System.Drawing.Point(20, 204);
            this.gbtnAddDebtPaymentTransaction.Name = "gbtnAddDebtPaymentTransaction";
            this.gbtnAddDebtPaymentTransaction.PressedColor = System.Drawing.Color.White;
            this.gbtnAddDebtPaymentTransaction.Size = new System.Drawing.Size(173, 41);
            this.gbtnAddDebtPaymentTransaction.TabIndex = 13;
            this.gbtnAddDebtPaymentTransaction.Text = "إضافة معاملة";
            this.gbtnAddDebtPaymentTransaction.Click += new System.EventHandler(this.gbtnAddTransaction_Click);
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
            this.label8.Click += new System.EventHandler(this.label8_Click);
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
            this.kgtxtDebtID.TextChanged += new System.EventHandler(this.kgtxtDebtID_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1056, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 17);
            this.label9.TabIndex = 117;
            this.label9.Text = "معاملات سداد سند الدين";
            this.label9.Click += new System.EventHandler(this.label9_Click);
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
            this.gibtnDeleteDebt.Location = new System.Drawing.Point(224, 199);
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
            this.kgtxtPersonName.TextChanged += new System.EventHandler(this.kgtxtPersonName_TextChanged);
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
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            this.label11.Click += new System.EventHandler(this.label11_Click);
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
            this.gcbDebtType.SelectedIndexChanged += new System.EventHandler(this.gcbDebtType_SelectedIndexChanged);
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
            this.label10.Click += new System.EventHandler(this.label10_Click);
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
            this.kgtxtPaymentDueDate.TextChanged += new System.EventHandler(this.kgtxtPaymentDueDate_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(521, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 17);
            this.label12.TabIndex = 138;
            this.label12.Text = "قيمة الدين";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // kgtxtDebtValue
            // 
            this.kgtxtDebtValue.AllowWhiteSpace = false;
            this.kgtxtDebtValue.ApplyTrimAtTextBoxValue = false;
            this.kgtxtDebtValue.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtDebtValue.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtDebtValue.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtDebtValue.BorderRadius = 10;
            this.kgtxtDebtValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtDebtValue.DefaultText = "";
            this.kgtxtDebtValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtDebtValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtDebtValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtDebtValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtDebtValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtDebtValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtDebtValue.ForeColor = System.Drawing.Color.Black;
            this.kgtxtDebtValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtDebtValue.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtDebtValue.IsRequired = true;
            this.kgtxtDebtValue.Location = new System.Drawing.Point(362, 97);
            this.kgtxtDebtValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtDebtValue.MaxLength = 150;
            this.kgtxtDebtValue.Name = "kgtxtDebtValue";
            this.kgtxtDebtValue.NumberProperties.DecimalNumberProperties.AllowNegative = false;
            this.kgtxtDebtValue.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtDebtValue.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtDebtValue.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtDebtValue.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtDebtValue.NumberProperties.DecimalNumberProperties.MinValueIncluded = false;
            this.kgtxtDebtValue.NumberProperties.DecimalNumberProperties.MinValueOption = true;
            this.kgtxtDebtValue.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtDebtValue.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtDebtValue.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtDebtValue.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtDebtValue.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtDebtValue.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtDebtValue.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtDebtValue.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtDebtValue.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtDebtValue.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtDebtValue.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtDebtValue.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtDebtValue.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtDebtValue.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtDebtValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.N4;
            this.kgtxtDebtValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber;
            this.kgtxtDebtValue.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtDebtValue.PlaceholderText = "قيمة الدين (مطلوب)";
            this.kgtxtDebtValue.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtDebtValue.SelectedText = "";
            this.kgtxtDebtValue.ShadowDecoration.BorderRadius = 2;
            this.kgtxtDebtValue.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtDebtValue.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtDebtValue.Size = new System.Drawing.Size(220, 41);
            this.kgtxtDebtValue.TabIndex = 5;
            this.kgtxtDebtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtDebtValue.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtDebtValue.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtDebtValue.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtDebtValue.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtDebtValue.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtDebtValue.TextProperties.MinLength = ((short)(0));
            this.kgtxtDebtValue.TextProperties.MinLengthOption = false;
            this.kgtxtDebtValue.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtDebtValue.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtDebtValue.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtDebtValue.TrimEnd = true;
            this.kgtxtDebtValue.TrimStart = true;
            this.kgtxtDebtValue.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtDebtValue.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtDebtValue.TextChanged += new System.EventHandler(this.kgtxtDebtValue_TextChanged);
            // 
            // frmAddUpdateDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.gbtnClose;
            this.ClientSize = new System.Drawing.Size(1210, 809);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.kgtxtDebtValue);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.kgtxtPaymentDueDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gcbDebtType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kgtxtPersonName);
            this.Controls.Add(this.gibtnDeleteDebt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gchkIsLocked);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.kgtxtDebtID);
            this.Controls.Add(this.gbtnAddDebtPaymentTransaction);
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
            this.Controls.Add(this.gdgvDebtPaymentTransctions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateDebt";
            this.Text = "frmAddUpdateDebt";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.frmAddUpdateVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdgvDebtPaymentTransctions)).EndInit();
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
        private Guna.UI2.WinForms.Guna2DataGridView gdgvDebtPaymentTransctions;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblNoTransactionsFoundMessage;
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
        private Guna.UI2.WinForms.Guna2Button gbtnAddDebtPaymentTransaction;
        private System.Windows.Forms.Label label8;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtDebtID;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gtsmAddTransactions;
        private System.Windows.Forms.ToolStripMenuItem gtsmEdit;
        private System.Windows.Forms.ToolStripMenuItem gtsmDelete;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnDeleteDebt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPersonName;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2ComboBox gcbDebtType;
        private System.Windows.Forms.Label label10;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPaymentDueDate;
        private System.Windows.Forms.Label label12;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtDebtValue;
        private System.Windows.Forms.ToolStripMenuItem gtsmExport;
        private System.Windows.Forms.ToolStripMenuItem gtsmExportExcel;
        private System.Windows.Forms.ToolStripMenuItem gtsmTransactionInfo;
    }
}