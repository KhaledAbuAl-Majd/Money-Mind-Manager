namespace MoneyMindManager_Presentation.OverView.Controls
{
    partial class ctrlTopCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlTopCategories));
            this.PieChart1 = new LiveCharts.WinForms.PieChart();
            this.kgtxtFromData = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtToDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.gibtnRefresh = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ctrlInfoIcon1 = new KhaledControlLibrary1.ctrlInfoIcon();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon1.PictureBoxControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // PieChart1
            // 
            this.PieChart1.Dock = System.Windows.Forms.DockStyle.Left;
            this.PieChart1.Location = new System.Drawing.Point(0, 0);
            this.PieChart1.Name = "PieChart1";
            this.PieChart1.Size = new System.Drawing.Size(545, 415);
            this.PieChart1.TabIndex = 0;
            this.PieChart1.Text = "pieChart1";
            // 
            // kgtxtFromData
            // 
            this.kgtxtFromData.AllowWhiteSpace = false;
            this.kgtxtFromData.ApplyTrimAtTextBoxValue = false;
            this.kgtxtFromData.BorderColor = System.Drawing.Color.Silver;
            this.kgtxtFromData.BorderRadius = 8;
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
            this.kgtxtFromData.Location = new System.Drawing.Point(429, 3);
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
            this.kgtxtFromData.TabIndex = 102;
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
            // 
            // kgtxtToDate
            // 
            this.kgtxtToDate.AllowWhiteSpace = false;
            this.kgtxtToDate.ApplyTrimAtTextBoxValue = false;
            this.kgtxtToDate.BorderColor = System.Drawing.Color.Silver;
            this.kgtxtToDate.BorderRadius = 8;
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
            this.kgtxtToDate.Location = new System.Drawing.Point(429, 42);
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
            this.kgtxtToDate.TabIndex = 103;
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
            // 
            // gibtnRefresh
            // 
            this.gibtnRefresh.AnimatedGIF = true;
            this.gibtnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.gibtnRefresh.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gibtnRefresh.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.gibtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("gibtnRefresh.Image")));
            this.gibtnRefresh.ImageOffset = new System.Drawing.Point(0, 0);
            this.gibtnRefresh.ImageRotate = 0F;
            this.gibtnRefresh.ImageSize = new System.Drawing.Size(28, 28);
            this.gibtnRefresh.Location = new System.Drawing.Point(3, 1);
            this.gibtnRefresh.Name = "gibtnRefresh";
            this.gibtnRefresh.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnRefresh.Size = new System.Drawing.Size(32, 27);
            this.gibtnRefresh.TabIndex = 104;
            this.toolTip1.SetToolTip(this.gibtnRefresh, "إعادة التحميل");
            this.gibtnRefresh.UseTransparentBackground = true;
            this.gibtnRefresh.Click += new System.EventHandler(this.gibtnFindPerson_Click);
            // 
            // ctrlInfoIcon1
            // 
            this.ctrlInfoIcon1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlInfoIcon1.IconImage = ((System.Drawing.Image)(resources.GetObject("ctrlInfoIcon1.IconImage")));
            this.ctrlInfoIcon1.Location = new System.Drawing.Point(43, 3);
            this.ctrlInfoIcon1.Name = "ctrlInfoIcon1";
            // 
            // 
            // 
            this.ctrlInfoIcon1.PictureBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlInfoIcon1.PictureBoxControl.Image = ((System.Drawing.Image)(resources.GetObject("ctrlInfoIcon1.PictureBoxControl.Image")));
            this.ctrlInfoIcon1.PictureBoxControl.ImageRotate = 0F;
            this.ctrlInfoIcon1.PictureBoxControl.Location = new System.Drawing.Point(0, 0);
            this.ctrlInfoIcon1.PictureBoxControl.Name = "gpbInfoIcon";
            this.ctrlInfoIcon1.PictureBoxControl.Size = new System.Drawing.Size(28, 27);
            this.ctrlInfoIcon1.PictureBoxControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ctrlInfoIcon1.PictureBoxControl.TabIndex = 0;
            this.ctrlInfoIcon1.PictureBoxControl.TabStop = false;
            this.ctrlInfoIcon1.PictureBoxControl.UseTransparentBackground = true;
            this.ctrlInfoIcon1.Size = new System.Drawing.Size(28, 27);
            this.ctrlInfoIcon1.TabIndex = 105;
            this.toolTip1.SetToolTip(this.ctrlInfoIcon1, "يُظهر هذا المخطط توزيع أكبر 5 فئات (مصروفات/إيرادات) كنسبة مئوية من الإجمالي للفت" +
        "رة المحددة.");
            // 
            // 
            // 
            this.ctrlInfoIcon1.ToolTipControl.IsBalloon = true;
            this.ctrlInfoIcon1.ToolTipText = "يُظهر هذا المخطط توزيع أكبر 7 فئات رئيسية، حيث تمثل قيمة كل فئة مجموع الإنفاق/الإ" +
    "يراد للفئة الرئيسية وجميع فئاتها الفرعية، كنسبة من الإجمالي للفترة المحددة.";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // ctrlTopCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.kgtxtToDate);
            this.Controls.Add(this.kgtxtFromData);
            this.Controls.Add(this.ctrlInfoIcon1);
            this.Controls.Add(this.gibtnRefresh);
            this.Controls.Add(this.PieChart1);
            this.Name = "ctrlTopCategories";
            this.Size = new System.Drawing.Size(555, 415);
            this.Load += new System.EventHandler(this.ctrlTopCategories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon1.PictureBoxControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.PieChart PieChart1;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtFromData;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtToDate;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnRefresh;
        private KhaledControlLibrary1.ctrlInfoIcon ctrlInfoIcon1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
