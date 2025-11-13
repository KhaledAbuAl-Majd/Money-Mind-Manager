namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    partial class frmSelectPerson
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectPerson));
            this.lblNoRecordsFoundMessage = new System.Windows.Forms.Label();
            this.gdgvPeople = new Guna.UI2.WinForms.Guna2DataGridView();
            this.kgtxtFilterValue = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.lblTotalRecordsNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlInfoIcon1 = new KhaledControlLibrary1.ctrlInfoIcon();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.kgtxtPageNumber = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.gibtnPreviousPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.gibtnNextPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.grbTextSearchMode_SubString = new Guna.UI2.WinForms.Guna2RadioButton();
            this.grbTextSearchMode_WordsPrefix = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblCurrentPageRecordsCount = new System.Windows.Forms.Label();
            this.lblDescriptionOfCurrentPageNumOfRcords = new System.Windows.Forms.Label();
            this.lblCurrentPageOfNumberOfPages = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SearchAfterTimerFinish = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gdgvPeople)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon1.PictureBoxControl)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNoRecordsFoundMessage
            // 
            this.lblNoRecordsFoundMessage.BackColor = System.Drawing.Color.White;
            this.lblNoRecordsFoundMessage.Font = new System.Drawing.Font("Segoe Script", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecordsFoundMessage.ForeColor = System.Drawing.Color.Red;
            this.lblNoRecordsFoundMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblNoRecordsFoundMessage.Location = new System.Drawing.Point(17, 235);
            this.lblNoRecordsFoundMessage.Name = "lblNoRecordsFoundMessage";
            this.lblNoRecordsFoundMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNoRecordsFoundMessage.Size = new System.Drawing.Size(808, 42);
            this.lblNoRecordsFoundMessage.TabIndex = 32;
            this.lblNoRecordsFoundMessage.Text = "لا يوجد نتائج مطابقة لبحثك !";
            this.lblNoRecordsFoundMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gdgvPeople
            // 
            this.gdgvPeople.AllowUserToAddRows = false;
            this.gdgvPeople.AllowUserToDeleteRows = false;
            this.gdgvPeople.AllowUserToResizeColumns = false;
            this.gdgvPeople.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.gdgvPeople.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gdgvPeople.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.gdgvPeople.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gdgvPeople.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvPeople.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gdgvPeople.ColumnHeadersHeight = 35;
            this.gdgvPeople.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = "N/A";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdgvPeople.DefaultCellStyle = dataGridViewCellStyle3;
            this.gdgvPeople.GridColor = System.Drawing.Color.White;
            this.gdgvPeople.Location = new System.Drawing.Point(10, 66);
            this.gdgvPeople.MultiSelect = false;
            this.gdgvPeople.Name = "gdgvPeople";
            this.gdgvPeople.ReadOnly = true;
            this.gdgvPeople.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvPeople.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gdgvPeople.RowHeadersVisible = false;
            this.gdgvPeople.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gdgvPeople.RowTemplate.Height = 40;
            this.gdgvPeople.Size = new System.Drawing.Size(825, 480);
            this.gdgvPeople.TabIndex = 31;
            this.gdgvPeople.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvPeople.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gdgvPeople.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gdgvPeople.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gdgvPeople.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gdgvPeople.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gdgvPeople.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.gdgvPeople.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gdgvPeople.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.gdgvPeople.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvPeople.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gdgvPeople.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gdgvPeople.ThemeStyle.HeaderStyle.Height = 35;
            this.gdgvPeople.ThemeStyle.ReadOnly = true;
            this.gdgvPeople.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvPeople.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gdgvPeople.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvPeople.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvPeople.ThemeStyle.RowsStyle.Height = 40;
            this.gdgvPeople.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gdgvPeople.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvPeople.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gdgvCategories_CellFormatting);
            this.gdgvPeople.DoubleClick += new System.EventHandler(this.gdgvCategories_DoubleClick);
            // 
            // kgtxtFilterValue
            // 
            this.kgtxtFilterValue.AllowWhiteSpace = true;
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
            this.kgtxtFilterValue.Location = new System.Drawing.Point(59, 24);
            this.kgtxtFilterValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtFilterValue.MaxLength = 200;
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
            this.kgtxtFilterValue.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtFilterValue.PlaceholderText = "اسم الشخص";
            this.kgtxtFilterValue.SelectedText = "";
            this.kgtxtFilterValue.Size = new System.Drawing.Size(776, 38);
            this.kgtxtFilterValue.TabIndex = 33;
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
            this.toolTip1.SetToolTip(this.kgtxtFilterValue, "اسم الشخص الذي تود اختياره");
            this.kgtxtFilterValue.TrimEnd = true;
            this.kgtxtFilterValue.TrimStart = true;
            this.kgtxtFilterValue.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtFilterValue.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtFilterValue.TextChanged += new System.EventHandler(this.kgtxtFilterValue_TextChanged);
            // 
            // lblTotalRecordsNumber
            // 
            this.lblTotalRecordsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecordsNumber.Location = new System.Drawing.Point(546, 546);
            this.lblTotalRecordsNumber.Name = "lblTotalRecordsNumber";
            this.lblTotalRecordsNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalRecordsNumber.Size = new System.Drawing.Size(148, 24);
            this.lblTotalRecordsNumber.TabIndex = 35;
            this.lblTotalRecordsNumber.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(684, 546);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 34;
            this.label1.Text = "# عدد الصفوف الكلية : ";
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.BackColor = System.Drawing.Color.White;
            this.lblUserMessage.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblUserMessage.Location = new System.Drawing.Point(17, 273);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserMessage.Size = new System.Drawing.Size(813, 42);
            this.lblUserMessage.TabIndex = 36;
            this.lblUserMessage.Text = "\"تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.\"";
            this.lblUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlInfoIcon1
            // 
            this.ctrlInfoIcon1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlInfoIcon1.IconImage = ((System.Drawing.Image)(resources.GetObject("ctrlInfoIcon1.IconImage")));
            this.ctrlInfoIcon1.Location = new System.Drawing.Point(17, 31);
            this.ctrlInfoIcon1.Name = "ctrlInfoIcon1";
            // 
            // 
            // 
            this.ctrlInfoIcon1.PictureBoxControl.Image = ((System.Drawing.Image)(resources.GetObject("ctrlInfoIcon1.PictureBoxControl.Image")));
            this.ctrlInfoIcon1.PictureBoxControl.ImageRotate = 0F;
            this.ctrlInfoIcon1.PictureBoxControl.Location = new System.Drawing.Point(0, 0);
            this.ctrlInfoIcon1.PictureBoxControl.Name = "gpbInfoIcon";
            this.ctrlInfoIcon1.PictureBoxControl.TabIndex = 0;
            this.ctrlInfoIcon1.PictureBoxControl.TabStop = false;
            this.ctrlInfoIcon1.Size = new System.Drawing.Size(33, 24);
            this.ctrlInfoIcon1.TabIndex = 37;
            // 
            // 
            // 
            this.ctrlInfoIcon1.ToolTipControl.IsBalloon = true;
            this.ctrlInfoIcon1.ToolTipText = " Enter لاختيار الشخص قم بالنقر على العنصر المختار مرتين بالماوس او قم بالضغط على " +
    "زر";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
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
            this.kgtxtPageNumber.Location = new System.Drawing.Point(68, 550);
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
            this.kgtxtPageNumber.TabIndex = 123;
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
            this.gibtnPreviousPage.Location = new System.Drawing.Point(223, 549);
            this.gibtnPreviousPage.Name = "gibtnPreviousPage";
            this.gibtnPreviousPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnPreviousPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnPreviousPage.TabIndex = 122;
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
            this.gibtnNextPage.Location = new System.Drawing.Point(494, 549);
            this.gibtnNextPage.Name = "gibtnNextPage";
            this.gibtnNextPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnNextPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnNextPage.TabIndex = 121;
            this.toolTip1.SetToolTip(this.gibtnNextPage, "الصفحة التالية");
            this.gibtnNextPage.UseTransparentBackground = true;
            this.gibtnNextPage.Click += new System.EventHandler(this.gibtnNextPage_Click);
            // 
            // grbTextSearchMode_SubString
            // 
            this.grbTextSearchMode_SubString.Animated = true;
            this.grbTextSearchMode_SubString.AutoSize = true;
            this.grbTextSearchMode_SubString.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grbTextSearchMode_SubString.CheckedState.BorderThickness = 0;
            this.grbTextSearchMode_SubString.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grbTextSearchMode_SubString.CheckedState.InnerColor = System.Drawing.Color.White;
            this.grbTextSearchMode_SubString.CheckedState.InnerOffset = -4;
            this.grbTextSearchMode_SubString.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grbTextSearchMode_SubString.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTextSearchMode_SubString.Location = new System.Drawing.Point(100, 2);
            this.grbTextSearchMode_SubString.Name = "grbTextSearchMode_SubString";
            this.grbTextSearchMode_SubString.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbTextSearchMode_SubString.Size = new System.Drawing.Size(256, 21);
            this.grbTextSearchMode_SubString.TabIndex = 138;
            this.grbTextSearchMode_SubString.Text = "مطابقة جزء من النص (شامل،قد يكون أبطأ)";
            this.toolTip1.SetToolTip(this.grbTextSearchMode_SubString, "بحث شامل وعميق، مصمم لإيجاد تطابق حرفي دقيق للنص المُدخل في أي موضع، حتى لو كان ف" +
        "ي منتصف الكلمات. مثال: البحث بـ «داد فات» يجد جملة «تم سـداد فاتـورة الكهرباء».");
            this.grbTextSearchMode_SubString.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grbTextSearchMode_SubString.UncheckedState.BorderThickness = 2;
            this.grbTextSearchMode_SubString.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.grbTextSearchMode_SubString.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // grbTextSearchMode_WordsPrefix
            // 
            this.grbTextSearchMode_WordsPrefix.Animated = true;
            this.grbTextSearchMode_WordsPrefix.AutoSize = true;
            this.grbTextSearchMode_WordsPrefix.Checked = true;
            this.grbTextSearchMode_WordsPrefix.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grbTextSearchMode_WordsPrefix.CheckedState.BorderThickness = 0;
            this.grbTextSearchMode_WordsPrefix.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grbTextSearchMode_WordsPrefix.CheckedState.InnerColor = System.Drawing.Color.White;
            this.grbTextSearchMode_WordsPrefix.CheckedState.InnerOffset = -4;
            this.grbTextSearchMode_WordsPrefix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grbTextSearchMode_WordsPrefix.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTextSearchMode_WordsPrefix.Location = new System.Drawing.Point(365, 2);
            this.grbTextSearchMode_WordsPrefix.Name = "grbTextSearchMode_WordsPrefix";
            this.grbTextSearchMode_WordsPrefix.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grbTextSearchMode_WordsPrefix.Size = new System.Drawing.Size(271, 21);
            this.grbTextSearchMode_WordsPrefix.TabIndex = 137;
            this.grbTextSearchMode_WordsPrefix.TabStop = true;
            this.grbTextSearchMode_WordsPrefix.Text = "مطابقة بداية الكلمات (سريع، لا يشترط الترتيب)";
            this.toolTip1.SetToolTip(this.grbTextSearchMode_WordsPrefix, "بحث فائق السرعة، مصمم لإيجاد المصطلحات الرئيسية بناءً على بدايات كلماتها، بصرف ال" +
        "نظر عن ترتيبها في النص. مثال: البحث بـ «سد فات» يجد جملة «تم سداد فاتورة الكهربا" +
        "ء».");
            this.grbTextSearchMode_WordsPrefix.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grbTextSearchMode_WordsPrefix.UncheckedState.BorderThickness = 2;
            this.grbTextSearchMode_WordsPrefix.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.grbTextSearchMode_WordsPrefix.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // lblCurrentPageRecordsCount
            // 
            this.lblCurrentPageRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageRecordsCount.Location = new System.Drawing.Point(524, 569);
            this.lblCurrentPageRecordsCount.Name = "lblCurrentPageRecordsCount";
            this.lblCurrentPageRecordsCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageRecordsCount.Size = new System.Drawing.Size(114, 24);
            this.lblCurrentPageRecordsCount.TabIndex = 125;
            this.lblCurrentPageRecordsCount.Text = "N/A";
            // 
            // lblDescriptionOfCurrentPageNumOfRcords
            // 
            this.lblDescriptionOfCurrentPageNumOfRcords.AutoSize = true;
            this.lblDescriptionOfCurrentPageNumOfRcords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionOfCurrentPageNumOfRcords.Location = new System.Drawing.Point(634, 569);
            this.lblDescriptionOfCurrentPageNumOfRcords.Name = "lblDescriptionOfCurrentPageNumOfRcords";
            this.lblDescriptionOfCurrentPageNumOfRcords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDescriptionOfCurrentPageNumOfRcords.Size = new System.Drawing.Size(205, 24);
            this.lblDescriptionOfCurrentPageNumOfRcords.TabIndex = 124;
            this.lblDescriptionOfCurrentPageNumOfRcords.Text = "# عدد صفوف الصفحة الحالية : ";
            // 
            // lblCurrentPageOfNumberOfPages
            // 
            this.lblCurrentPageOfNumberOfPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageOfNumberOfPages.Location = new System.Drawing.Point(258, 553);
            this.lblCurrentPageOfNumberOfPages.Name = "lblCurrentPageOfNumberOfPages";
            this.lblCurrentPageOfNumberOfPages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageOfNumberOfPages.Size = new System.Drawing.Size(237, 30);
            this.lblCurrentPageOfNumberOfPages.TabIndex = 120;
            this.lblCurrentPageOfNumberOfPages.Text = "0 من  0  صفحات";
            this.lblCurrentPageOfNumberOfPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(642, 3);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(129, 17);
            this.label5.TabIndex = 139;
            this.label5.Text = "خيارات بحث النصوص :";
            // 
            // SearchAfterTimerFinish
            // 
            this.SearchAfterTimerFinish.Interval = 400;
            this.SearchAfterTimerFinish.Tick += new System.EventHandler(this.SearchAfterTimerFinish_Tick);
            // 
            // frmSelectPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(842, 598);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grbTextSearchMode_SubString);
            this.Controls.Add(this.grbTextSearchMode_WordsPrefix);
            this.Controls.Add(this.lblCurrentPageRecordsCount);
            this.Controls.Add(this.lblDescriptionOfCurrentPageNumOfRcords);
            this.Controls.Add(this.kgtxtPageNumber);
            this.Controls.Add(this.gibtnPreviousPage);
            this.Controls.Add(this.gibtnNextPage);
            this.Controls.Add(this.lblCurrentPageOfNumberOfPages);
            this.Controls.Add(this.ctrlInfoIcon1);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.lblTotalRecordsNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kgtxtFilterValue);
            this.Controls.Add(this.lblNoRecordsFoundMessage);
            this.Controls.Add(this.gdgvPeople);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(858, 637);
            this.Name = "frmSelectPerson";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Category";
            this.Load += new System.EventHandler(this.frmSelectPerson_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSelectPerson_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gdgvPeople)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon1.PictureBoxControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNoRecordsFoundMessage;
        private Guna.UI2.WinForms.Guna2DataGridView gdgvPeople;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtFilterValue;
        private System.Windows.Forms.Label lblTotalRecordsNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserMessage;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private KhaledControlLibrary1.ctrlInfoIcon ctrlInfoIcon1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblCurrentPageRecordsCount;
        private System.Windows.Forms.Label lblDescriptionOfCurrentPageNumOfRcords;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPageNumber;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnPreviousPage;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnNextPage;
        private System.Windows.Forms.Label lblCurrentPageOfNumberOfPages;
        private Guna.UI2.WinForms.Guna2RadioButton grbTextSearchMode_SubString;
        private Guna.UI2.WinForms.Guna2RadioButton grbTextSearchMode_WordsPrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer SearchAfterTimerFinish;
    }
}