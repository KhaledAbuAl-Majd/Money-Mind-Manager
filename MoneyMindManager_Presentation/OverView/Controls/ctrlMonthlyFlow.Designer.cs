namespace MoneyMindManager_Presentation.OverView.Controls
{
    partial class ctrlMonthlyFlow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlMonthlyFlow));
            this.CartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.kgtxtToDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtFromData = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.gibtnFindPerson = new Guna.UI2.WinForms.Guna2ImageButton();
            this.grbLinerShape = new Guna.UI2.WinForms.Guna2RadioButton();
            this.grbColumnsShape = new Guna.UI2.WinForms.Guna2RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlInfoIcon1 = new KhaledControlLibrary1.ctrlInfoIcon();
            this.label6 = new System.Windows.Forms.Label();
            this.kgtxtTotalIncome = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kgtxtTotalNetExpense = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kgtxtTotalNetCashFlow = new KhaledControlLibrary1.KhaledGuna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon1.PictureBoxControl)).BeginInit();
            this.SuspendLayout();
            // 
            // CartesianChart1
            // 
            this.CartesianChart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CartesianChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CartesianChart1.Location = new System.Drawing.Point(0, 65);
            this.CartesianChart1.Name = "CartesianChart1";
            this.CartesianChart1.Size = new System.Drawing.Size(1143, 495);
            this.CartesianChart1.TabIndex = 0;
            this.CartesianChart1.Text = "cartesianChart1";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // kgtxtToDate
            // 
            this.kgtxtToDate.AllowWhiteSpace = true;
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
            this.kgtxtToDate.IsRequired = true;
            this.kgtxtToDate.Location = new System.Drawing.Point(760, 19);
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
            this.kgtxtToDate.TabIndex = 38;
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
            this.toolTip1.SetToolTip(this.kgtxtToDate, "البحث إلى التاريخ المكتوب");
            this.kgtxtToDate.TrimEnd = true;
            this.kgtxtToDate.TrimStart = true;
            this.kgtxtToDate.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtToDate.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtToDate_OnValidationSuccess);
            // 
            // kgtxtFromData
            // 
            this.kgtxtFromData.AllowWhiteSpace = true;
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
            this.kgtxtFromData.IsRequired = true;
            this.kgtxtFromData.Location = new System.Drawing.Point(899, 19);
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
            this.kgtxtFromData.TabIndex = 37;
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
            this.toolTip1.SetToolTip(this.kgtxtFromData, "البحث من التاريخ المكتوب");
            this.kgtxtFromData.TrimEnd = true;
            this.kgtxtFromData.TrimStart = true;
            this.kgtxtFromData.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtFromData.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            // 
            // gibtnFindPerson
            // 
            this.gibtnFindPerson.AnimatedGIF = true;
            this.gibtnFindPerson.BackColor = System.Drawing.Color.Transparent;
            this.gibtnFindPerson.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnFindPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gibtnFindPerson.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.gibtnFindPerson.Image = ((System.Drawing.Image)(resources.GetObject("gibtnFindPerson.Image")));
            this.gibtnFindPerson.ImageOffset = new System.Drawing.Point(0, 0);
            this.gibtnFindPerson.ImageRotate = 0F;
            this.gibtnFindPerson.ImageSize = new System.Drawing.Size(28, 28);
            this.gibtnFindPerson.Location = new System.Drawing.Point(83, 19);
            this.gibtnFindPerson.Name = "gibtnFindPerson";
            this.gibtnFindPerson.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnFindPerson.Size = new System.Drawing.Size(32, 27);
            this.gibtnFindPerson.TabIndex = 100;
            this.toolTip1.SetToolTip(this.gibtnFindPerson, "إعادة تحميل");
            this.gibtnFindPerson.UseTransparentBackground = true;
            this.gibtnFindPerson.Click += new System.EventHandler(this.gibtnFindPerson_Click);
            // 
            // grbLinerShape
            // 
            this.grbLinerShape.Animated = true;
            this.grbLinerShape.AutoSize = true;
            this.grbLinerShape.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grbLinerShape.CheckedState.BorderThickness = 0;
            this.grbLinerShape.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grbLinerShape.CheckedState.InnerColor = System.Drawing.Color.White;
            this.grbLinerShape.CheckedState.InnerOffset = -4;
            this.grbLinerShape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grbLinerShape.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbLinerShape.Location = new System.Drawing.Point(1029, 28);
            this.grbLinerShape.Name = "grbLinerShape";
            this.grbLinerShape.Size = new System.Drawing.Size(110, 21);
            this.grbLinerShape.TabIndex = 42;
            this.grbLinerShape.Text = "خطوط ومناطق";
            this.grbLinerShape.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grbLinerShape.UncheckedState.BorderThickness = 2;
            this.grbLinerShape.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.grbLinerShape.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // grbColumnsShape
            // 
            this.grbColumnsShape.Animated = true;
            this.grbColumnsShape.AutoSize = true;
            this.grbColumnsShape.Checked = true;
            this.grbColumnsShape.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grbColumnsShape.CheckedState.BorderThickness = 0;
            this.grbColumnsShape.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grbColumnsShape.CheckedState.InnerColor = System.Drawing.Color.White;
            this.grbColumnsShape.CheckedState.InnerOffset = -4;
            this.grbColumnsShape.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grbColumnsShape.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbColumnsShape.Location = new System.Drawing.Point(1080, 10);
            this.grbColumnsShape.Name = "grbColumnsShape";
            this.grbColumnsShape.Size = new System.Drawing.Size(59, 21);
            this.grbColumnsShape.TabIndex = 41;
            this.grbColumnsShape.TabStop = true;
            this.grbColumnsShape.Text = "أعمدة";
            this.grbColumnsShape.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grbColumnsShape.UncheckedState.BorderThickness = 2;
            this.grbColumnsShape.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.grbColumnsShape.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.grbColumnsShape.CheckedChanged += new System.EventHandler(this.grbColumnsShape_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // ctrlInfoIcon1
            // 
            this.ctrlInfoIcon1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlInfoIcon1.IconImage = ((System.Drawing.Image)(resources.GetObject("ctrlInfoIcon1.IconImage")));
            this.ctrlInfoIcon1.Location = new System.Drawing.Point(121, 19);
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
            this.ctrlInfoIcon1.TabIndex = 101;
            // 
            // 
            // 
            this.ctrlInfoIcon1.ToolTipControl.IsBalloon = true;
            this.ctrlInfoIcon1.ToolTipText = "هذا المخطط يشمل (الواردات , المصروفات , مرتجعات المصروفات) فقط , \"صافي المصروفات " +
    "= المصروفات - مرتجع المصروفات \" . لا يشمل الديون";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(550, -2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 17);
            this.label6.TabIndex = 114;
            this.label6.Text = "إجمالي الواردات";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kgtxtTotalIncome
            // 
            this.kgtxtTotalIncome.AllowWhiteSpace = true;
            this.kgtxtTotalIncome.ApplyTrimAtTextBoxValue = false;
            this.kgtxtTotalIncome.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtTotalIncome.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtTotalIncome.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtTotalIncome.BorderRadius = 10;
            this.kgtxtTotalIncome.BorderThickness = 0;
            this.kgtxtTotalIncome.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtTotalIncome.DefaultText = "111,111,111,111,111.00";
            this.kgtxtTotalIncome.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtTotalIncome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtTotalIncome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtTotalIncome.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtTotalIncome.FillColor = System.Drawing.SystemColors.Control;
            this.kgtxtTotalIncome.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtTotalIncome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtTotalIncome.ForeColor = System.Drawing.Color.Black;
            this.kgtxtTotalIncome.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtTotalIncome.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtTotalIncome.IsRequired = false;
            this.kgtxtTotalIncome.Location = new System.Drawing.Point(550, 17);
            this.kgtxtTotalIncome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtTotalIncome.MaxLength = 150;
            this.kgtxtTotalIncome.Name = "kgtxtTotalIncome";
            this.kgtxtTotalIncome.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtTotalIncome.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtTotalIncome.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalIncome.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtTotalIncome.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtTotalIncome.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalIncome.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtTotalIncome.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtTotalIncome.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtTotalIncome.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalIncome.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtTotalIncome.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtTotalIncome.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalIncome.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtTotalIncome.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtTotalIncome.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtTotalIncome.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalIncome.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtTotalIncome.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtTotalIncome.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalIncome.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtTotalIncome.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.N2;
            this.kgtxtTotalIncome.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber;
            this.kgtxtTotalIncome.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtTotalIncome.PlaceholderText = "اسم المستند (مطلوب)";
            this.kgtxtTotalIncome.ReadOnly = true;
            this.kgtxtTotalIncome.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtTotalIncome.SelectedText = "";
            this.kgtxtTotalIncome.ShadowDecoration.BorderRadius = 10;
            this.kgtxtTotalIncome.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.kgtxtTotalIncome.ShadowDecoration.Depth = 15;
            this.kgtxtTotalIncome.ShadowDecoration.Enabled = true;
            this.kgtxtTotalIncome.Size = new System.Drawing.Size(189, 41);
            this.kgtxtTotalIncome.TabIndex = 113;
            this.kgtxtTotalIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtTotalIncome.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtTotalIncome.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtTotalIncome.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtTotalIncome.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtTotalIncome.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtTotalIncome.TextProperties.MinLength = ((short)(0));
            this.kgtxtTotalIncome.TextProperties.MinLengthOption = false;
            this.kgtxtTotalIncome.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtTotalIncome.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtTotalIncome.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtTotalIncome.TrimEnd = true;
            this.kgtxtTotalIncome.TrimStart = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(353, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 17);
            this.label1.TabIndex = 116;
            this.label1.Text = "إجمالي صافي المصروفات";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kgtxtTotalNetExpense
            // 
            this.kgtxtTotalNetExpense.AllowWhiteSpace = true;
            this.kgtxtTotalNetExpense.ApplyTrimAtTextBoxValue = false;
            this.kgtxtTotalNetExpense.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtTotalNetExpense.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtTotalNetExpense.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtTotalNetExpense.BorderRadius = 10;
            this.kgtxtTotalNetExpense.BorderThickness = 0;
            this.kgtxtTotalNetExpense.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtTotalNetExpense.DefaultText = "111,111,111,111,111.00";
            this.kgtxtTotalNetExpense.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtTotalNetExpense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtTotalNetExpense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtTotalNetExpense.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtTotalNetExpense.FillColor = System.Drawing.SystemColors.Control;
            this.kgtxtTotalNetExpense.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtTotalNetExpense.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtTotalNetExpense.ForeColor = System.Drawing.Color.Black;
            this.kgtxtTotalNetExpense.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtTotalNetExpense.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtTotalNetExpense.IsRequired = false;
            this.kgtxtTotalNetExpense.Location = new System.Drawing.Point(353, 17);
            this.kgtxtTotalNetExpense.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtTotalNetExpense.MaxLength = 150;
            this.kgtxtTotalNetExpense.Name = "kgtxtTotalNetExpense";
            this.kgtxtTotalNetExpense.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtTotalNetExpense.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtTotalNetExpense.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalNetExpense.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtTotalNetExpense.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtTotalNetExpense.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalNetExpense.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtTotalNetExpense.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtTotalNetExpense.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtTotalNetExpense.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalNetExpense.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtTotalNetExpense.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtTotalNetExpense.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalNetExpense.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtTotalNetExpense.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtTotalNetExpense.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtTotalNetExpense.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalNetExpense.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtTotalNetExpense.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtTotalNetExpense.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalNetExpense.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtTotalNetExpense.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.N2;
            this.kgtxtTotalNetExpense.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber;
            this.kgtxtTotalNetExpense.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtTotalNetExpense.PlaceholderText = "اسم المستند (مطلوب)";
            this.kgtxtTotalNetExpense.ReadOnly = true;
            this.kgtxtTotalNetExpense.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtTotalNetExpense.SelectedText = "";
            this.kgtxtTotalNetExpense.ShadowDecoration.BorderRadius = 10;
            this.kgtxtTotalNetExpense.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.kgtxtTotalNetExpense.ShadowDecoration.Depth = 15;
            this.kgtxtTotalNetExpense.ShadowDecoration.Enabled = true;
            this.kgtxtTotalNetExpense.Size = new System.Drawing.Size(189, 41);
            this.kgtxtTotalNetExpense.TabIndex = 115;
            this.kgtxtTotalNetExpense.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtTotalNetExpense.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtTotalNetExpense.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtTotalNetExpense.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtTotalNetExpense.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtTotalNetExpense.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtTotalNetExpense.TextProperties.MinLength = ((short)(0));
            this.kgtxtTotalNetExpense.TextProperties.MinLengthOption = false;
            this.kgtxtTotalNetExpense.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtTotalNetExpense.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtTotalNetExpense.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtTotalNetExpense.TrimEnd = true;
            this.kgtxtTotalNetExpense.TrimStart = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(156, -2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 17);
            this.label2.TabIndex = 118;
            this.label2.Text = "إجمالي صافي التدفق النقدي";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kgtxtTotalNetCashFlow
            // 
            this.kgtxtTotalNetCashFlow.AllowWhiteSpace = true;
            this.kgtxtTotalNetCashFlow.ApplyTrimAtTextBoxValue = false;
            this.kgtxtTotalNetCashFlow.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtTotalNetCashFlow.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtTotalNetCashFlow.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtTotalNetCashFlow.BorderRadius = 10;
            this.kgtxtTotalNetCashFlow.BorderThickness = 0;
            this.kgtxtTotalNetCashFlow.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtTotalNetCashFlow.DefaultText = "111,111,111,111,111.00";
            this.kgtxtTotalNetCashFlow.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtTotalNetCashFlow.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtTotalNetCashFlow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtTotalNetCashFlow.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtTotalNetCashFlow.FillColor = System.Drawing.SystemColors.Control;
            this.kgtxtTotalNetCashFlow.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtTotalNetCashFlow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtTotalNetCashFlow.ForeColor = System.Drawing.Color.Black;
            this.kgtxtTotalNetCashFlow.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtTotalNetCashFlow.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtTotalNetCashFlow.IsRequired = false;
            this.kgtxtTotalNetCashFlow.Location = new System.Drawing.Point(156, 17);
            this.kgtxtTotalNetCashFlow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtTotalNetCashFlow.MaxLength = 150;
            this.kgtxtTotalNetCashFlow.Name = "kgtxtTotalNetCashFlow";
            this.kgtxtTotalNetCashFlow.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtTotalNetCashFlow.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtTotalNetCashFlow.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalNetCashFlow.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtTotalNetCashFlow.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtTotalNetCashFlow.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalNetCashFlow.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtTotalNetCashFlow.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtTotalNetCashFlow.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtTotalNetCashFlow.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalNetCashFlow.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtTotalNetCashFlow.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtTotalNetCashFlow.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalNetCashFlow.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtTotalNetCashFlow.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtTotalNetCashFlow.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtTotalNetCashFlow.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtTotalNetCashFlow.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtTotalNetCashFlow.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtTotalNetCashFlow.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtTotalNetCashFlow.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtTotalNetCashFlow.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.N2;
            this.kgtxtTotalNetCashFlow.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber;
            this.kgtxtTotalNetCashFlow.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtTotalNetCashFlow.PlaceholderText = "اسم المستند (مطلوب)";
            this.kgtxtTotalNetCashFlow.ReadOnly = true;
            this.kgtxtTotalNetCashFlow.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtTotalNetCashFlow.SelectedText = "";
            this.kgtxtTotalNetCashFlow.ShadowDecoration.BorderRadius = 10;
            this.kgtxtTotalNetCashFlow.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.kgtxtTotalNetCashFlow.ShadowDecoration.Depth = 15;
            this.kgtxtTotalNetCashFlow.ShadowDecoration.Enabled = true;
            this.kgtxtTotalNetCashFlow.Size = new System.Drawing.Size(189, 41);
            this.kgtxtTotalNetCashFlow.TabIndex = 117;
            this.kgtxtTotalNetCashFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtTotalNetCashFlow.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtTotalNetCashFlow.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtTotalNetCashFlow.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtTotalNetCashFlow.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtTotalNetCashFlow.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtTotalNetCashFlow.TextProperties.MinLength = ((short)(0));
            this.kgtxtTotalNetCashFlow.TextProperties.MinLengthOption = false;
            this.kgtxtTotalNetCashFlow.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtTotalNetCashFlow.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtTotalNetCashFlow.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtTotalNetCashFlow.TrimEnd = true;
            this.kgtxtTotalNetCashFlow.TrimStart = true;
            // 
            // ctrlMonthlyFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kgtxtTotalNetCashFlow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kgtxtTotalNetExpense);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.kgtxtTotalIncome);
            this.Controls.Add(this.ctrlInfoIcon1);
            this.Controls.Add(this.gibtnFindPerson);
            this.Controls.Add(this.grbLinerShape);
            this.Controls.Add(this.grbColumnsShape);
            this.Controls.Add(this.kgtxtToDate);
            this.Controls.Add(this.kgtxtFromData);
            this.Controls.Add(this.CartesianChart1);
            this.Name = "ctrlMonthlyFlow";
            this.Size = new System.Drawing.Size(1143, 560);
            this.Load += new System.EventHandler(this.ctrlMonthlyFlow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon1.PictureBoxControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart CartesianChart1;
        private System.Windows.Forms.ToolTip toolTip1;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtToDate;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtFromData;
        private Guna.UI2.WinForms.Guna2RadioButton grbLinerShape;
        private Guna.UI2.WinForms.Guna2RadioButton grbColumnsShape;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnFindPerson;
        private KhaledControlLibrary1.ctrlInfoIcon ctrlInfoIcon1;
        private System.Windows.Forms.Label label6;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtTotalIncome;
        private System.Windows.Forms.Label label2;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtTotalNetCashFlow;
        private System.Windows.Forms.Label label1;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtTotalNetExpense;
    }
}
