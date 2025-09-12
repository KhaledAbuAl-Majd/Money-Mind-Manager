using System.ComponentModel;

namespace MoneyMindManager_Presentation
{
    partial class FrmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.SearchAfterTimerFinish = new System.Windows.Forms.Timer(this.components);
            this.kgtxtFilterValue = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.lblNoRecordsFoundMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gcbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCurrentPageRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.kgtxtPageNumber = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.gibtnNextPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.gibtnPreviousPage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.gbtnAddUser = new Guna.UI2.WinForms.Guna2Button();
            this.lblCurrentPageOfNumberOfPages = new System.Windows.Forms.Label();
            this.lblTotalRecordsNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gtsmDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.gtsmUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.gdgvUser = new Guna.UI2.WinForms.Guna2DataGridView();
            this.gcbIsActive = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.guna2ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(12, 24);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1186, 62);
            this.lblHeader.TabIndex = 34;
            this.lblHeader.Text = "المستخدمين";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblUserMessage.Location = new System.Drawing.Point(61, 397);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserMessage.Size = new System.Drawing.Size(1085, 42);
            this.lblUserMessage.TabIndex = 32;
            this.lblUserMessage.Text = "\"تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.\"";
            this.lblUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchAfterTimerFinish
            // 
            this.SearchAfterTimerFinish.Interval = 400;
            this.SearchAfterTimerFinish.Tick += new System.EventHandler(this.SearchAfterTimerFinish_Tick);
            // 
            // kgtxtFilterValue
            // 
            this.kgtxtFilterValue.AllowWhiteSpace = false;
            this.kgtxtFilterValue.ApplyTrimAtTextBoxValue = false;
            this.kgtxtFilterValue.AutoRoundedCorners = true;
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
            this.kgtxtFilterValue.Location = new System.Drawing.Point(712, 151);
            this.kgtxtFilterValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtFilterValue.Name = "kgtxtFilterValue";
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtFilterValue.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtFilterValue.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtFilterValue.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtFilterValue.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtFilterValue.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtFilterValue.PlaceholderText = "";
            this.kgtxtFilterValue.SelectedText = "";
            this.kgtxtFilterValue.Size = new System.Drawing.Size(157, 36);
            this.kgtxtFilterValue.TabIndex = 31;
            this.kgtxtFilterValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.lblNoRecordsFoundMessage.Location = new System.Drawing.Point(61, 355);
            this.lblNoRecordsFoundMessage.Name = "lblNoRecordsFoundMessage";
            this.lblNoRecordsFoundMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNoRecordsFoundMessage.Size = new System.Drawing.Size(1092, 42);
            this.lblNoRecordsFoundMessage.TabIndex = 30;
            this.lblNoRecordsFoundMessage.Text = "لا يوجد نتائج مطباقة لبحثك !";
            this.lblNoRecordsFoundMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1060, 156);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 29;
            this.label2.Text = "تصفية حسب :";
            // 
            // gcbFilterBy
            // 
            this.gcbFilterBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gcbFilterBy.AutoRoundedCorners = true;
            this.gcbFilterBy.BackColor = System.Drawing.Color.Transparent;
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
            "معرف المستخدم",
            "اسم المستخدم",
            "اسم الشخص",
            "الفعالية"});
            this.gcbFilterBy.Location = new System.Drawing.Point(894, 151);
            this.gcbFilterBy.Name = "gcbFilterBy";
            this.gcbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcbFilterBy.Size = new System.Drawing.Size(157, 36);
            this.gcbFilterBy.TabIndex = 28;
            this.gcbFilterBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gcbFilterBy.SelectedIndexChanged += new System.EventHandler(this.gcbFilterBy_SelectedIndexChanged);
            // 
            // lblCurrentPageRecordsCount
            // 
            this.lblCurrentPageRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageRecordsCount.Location = new System.Drawing.Point(827, 688);
            this.lblCurrentPageRecordsCount.Name = "lblCurrentPageRecordsCount";
            this.lblCurrentPageRecordsCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageRecordsCount.Size = new System.Drawing.Size(114, 24);
            this.lblCurrentPageRecordsCount.TabIndex = 27;
            this.lblCurrentPageRecordsCount.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(952, 688);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(205, 24);
            this.label3.TabIndex = 26;
            this.label3.Text = "# عدد صفوف الصفحة الحالية : ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.kgtxtPageNumber.Location = new System.Drawing.Point(196, 655);
            this.kgtxtPageNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtPageNumber.MaxLength = 150;
            this.kgtxtPageNumber.Name = "kgtxtPageNumber";
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPageNumber.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtPageNumber.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtPageNumber.NumberProperties.IntegerNumberProperties.AllowNegative = false;
            this.kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtPageNumber.NumberProperties.IntegerNumberProperties.MinValue = 1;
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
            this.kgtxtPageNumber.TabIndex = 25;
            this.kgtxtPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtPageNumber.TextProperties.MinLength = ((short)(0));
            this.kgtxtPageNumber.TextProperties.MinLengthOption = false;
            this.kgtxtPageNumber.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtPageNumber.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtPageNumber.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.toolTip1.SetToolTip(this.kgtxtPageNumber, "رقم الصفحة الحالية, أدخل رقم الصفحة التي تريد التنقل إليها");
            this.kgtxtPageNumber.TrimEnd = true;
            this.kgtxtPageNumber.TrimStart = false;
            this.kgtxtPageNumber.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtPageNumber.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            this.kgtxtPageNumber.TextChanged += new System.EventHandler(this.kgtxtPageNumber_TextChanged);
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
            this.gibtnNextPage.Location = new System.Drawing.Point(722, 655);
            this.gibtnNextPage.Name = "gibtnNextPage";
            this.gibtnNextPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnNextPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnNextPage.TabIndex = 23;
            this.toolTip1.SetToolTip(this.gibtnNextPage, "الصفحة التالية");
            this.gibtnNextPage.UseTransparentBackground = true;
            this.gibtnNextPage.Click += new System.EventHandler(this.gibtnNextPage_Click);
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
            this.gibtnPreviousPage.Location = new System.Drawing.Point(444, 655);
            this.gibtnPreviousPage.Name = "gibtnPreviousPage";
            this.gibtnPreviousPage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnPreviousPage.Size = new System.Drawing.Size(40, 42);
            this.gibtnPreviousPage.TabIndex = 24;
            this.toolTip1.SetToolTip(this.gibtnPreviousPage, "الصفحة السابقة");
            this.gibtnPreviousPage.UseTransparentBackground = true;
            this.gibtnPreviousPage.Click += new System.EventHandler(this.gibtnPreviousPage_Click);
            // 
            // gbtnAddUser
            // 
            this.gbtnAddUser.Animated = true;
            this.gbtnAddUser.AutoRoundedCorners = true;
            this.gbtnAddUser.BackColor = System.Drawing.Color.Transparent;
            this.gbtnAddUser.BorderColor = System.Drawing.Color.DimGray;
            this.gbtnAddUser.BorderThickness = 1;
            this.gbtnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnAddUser.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.gbtnAddUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAddUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAddUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnAddUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnAddUser.FillColor = System.Drawing.Color.White;
            this.gbtnAddUser.FocusedColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbtnAddUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnAddUser.ForeColor = System.Drawing.Color.Black;
            this.gbtnAddUser.HoverState.FillColor = System.Drawing.Color.SlateBlue;
            this.gbtnAddUser.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("gbtnAddUser.Image")));
            this.gbtnAddUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnAddUser.ImageSize = new System.Drawing.Size(30, 30);
            this.gbtnAddUser.IndicateFocus = true;
            this.gbtnAddUser.Location = new System.Drawing.Point(50, 146);
            this.gbtnAddUser.Name = "gbtnAddUser";
            this.gbtnAddUser.PressedColor = System.Drawing.Color.White;
            this.gbtnAddUser.Size = new System.Drawing.Size(196, 41);
            this.gbtnAddUser.TabIndex = 33;
            this.gbtnAddUser.Text = "إضافة مستخدم";
            this.gbtnAddUser.Click += new System.EventHandler(this.gbtnAddPerson_Click);
            // 
            // lblCurrentPageOfNumberOfPages
            // 
            this.lblCurrentPageOfNumberOfPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPageOfNumberOfPages.Location = new System.Drawing.Point(479, 659);
            this.lblCurrentPageOfNumberOfPages.Name = "lblCurrentPageOfNumberOfPages";
            this.lblCurrentPageOfNumberOfPages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCurrentPageOfNumberOfPages.Size = new System.Drawing.Size(249, 30);
            this.lblCurrentPageOfNumberOfPages.TabIndex = 22;
            this.lblCurrentPageOfNumberOfPages.Text = "0 من  0  صفحات";
            this.lblCurrentPageOfNumberOfPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalRecordsNumber
            // 
            this.lblTotalRecordsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecordsNumber.Location = new System.Drawing.Point(871, 659);
            this.lblTotalRecordsNumber.Name = "lblTotalRecordsNumber";
            this.lblTotalRecordsNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalRecordsNumber.Size = new System.Drawing.Size(114, 24);
            this.lblTotalRecordsNumber.TabIndex = 21;
            this.lblTotalRecordsNumber.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1002, 659);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "# عدد الصفوف الكلية : ";
            // 
            // gtsmDeleteUser
            // 
            this.gtsmDeleteUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("gtsmDeleteUser.Image")));
            this.gtsmDeleteUser.Name = "gtsmDeleteUser";
            this.gtsmDeleteUser.Size = new System.Drawing.Size(214, 36);
            this.gtsmDeleteUser.Text = "حذف";
            // 
            // gtsmEditUser
            // 
            this.gtsmEditUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmEditUser.Image = ((System.Drawing.Image)(resources.GetObject("gtsmEditUser.Image")));
            this.gtsmEditUser.Name = "gtsmEditUser";
            this.gtsmEditUser.Size = new System.Drawing.Size(214, 36);
            this.gtsmEditUser.Text = "تعديل";
            this.gtsmEditUser.Click += new System.EventHandler(this.gtsmEditUser_Click);
            // 
            // gtsmAddUser
            // 
            this.gtsmAddUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmAddUser.Image = ((System.Drawing.Image)(resources.GetObject("gtsmAddUser.Image")));
            this.gtsmAddUser.Name = "gtsmAddUser";
            this.gtsmAddUser.Size = new System.Drawing.Size(214, 36);
            this.gtsmAddUser.Text = "إضافة مستخدم";
            this.gtsmAddUser.Click += new System.EventHandler(this.gtsmAddUser_Click);
            // 
            // gtsmUserInfo
            // 
            this.gtsmUserInfo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtsmUserInfo.Image = ((System.Drawing.Image)(resources.GetObject("gtsmUserInfo.Image")));
            this.gtsmUserInfo.Name = "gtsmUserInfo";
            this.gtsmUserInfo.Size = new System.Drawing.Size(214, 36);
            this.gtsmUserInfo.Text = "معلومات المستخدم";
            this.gtsmUserInfo.Click += new System.EventHandler(this.gtsmUserInfo_Click);
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.BackColor = System.Drawing.Color.Snow;
            this.guna2ContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gtsmUserInfo,
            this.gtsmAddUser,
            this.gtsmEditUser,
            this.gtsmDeleteUser});
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
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(215, 148);
            // 
            // gdgvUser
            // 
            this.gdgvUser.AllowUserToAddRows = false;
            this.gdgvUser.AllowUserToDeleteRows = false;
            this.gdgvUser.AllowUserToResizeColumns = false;
            this.gdgvUser.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.gdgvUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gdgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.gdgvUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gdgvUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gdgvUser.ColumnHeadersHeight = 35;
            this.gdgvUser.ContextMenuStrip = this.guna2ContextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = "N/A";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdgvUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.gdgvUser.GridColor = System.Drawing.Color.White;
            this.gdgvUser.Location = new System.Drawing.Point(50, 201);
            this.gdgvUser.MultiSelect = false;
            this.gdgvUser.Name = "gdgvUser";
            this.gdgvUser.ReadOnly = true;
            this.gdgvUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdgvUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gdgvUser.RowHeadersVisible = false;
            this.gdgvUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gdgvUser.RowTemplate.Height = 40;
            this.gdgvUser.Size = new System.Drawing.Size(1110, 440);
            this.gdgvUser.TabIndex = 19;
            this.gdgvUser.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvUser.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gdgvUser.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gdgvUser.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gdgvUser.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gdgvUser.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gdgvUser.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.gdgvUser.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gdgvUser.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.gdgvUser.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvUser.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gdgvUser.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gdgvUser.ThemeStyle.HeaderStyle.Height = 35;
            this.gdgvUser.ThemeStyle.ReadOnly = true;
            this.gdgvUser.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gdgvUser.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gdgvUser.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdgvUser.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvUser.ThemeStyle.RowsStyle.Height = 40;
            this.gdgvUser.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gdgvUser.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gdgvUser.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.guna2DataGridView1_CellFormatting);
            // 
            // gcbIsActive
            // 
            this.gcbIsActive.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gcbIsActive.AutoRoundedCorners = true;
            this.gcbIsActive.BackColor = System.Drawing.Color.Transparent;
            this.gcbIsActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcbIsActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gcbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gcbIsActive.DropDownWidth = 150;
            this.gcbIsActive.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbIsActive.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbIsActive.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gcbIsActive.ForeColor = System.Drawing.Color.Black;
            this.gcbIsActive.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbIsActive.ItemHeight = 30;
            this.gcbIsActive.Items.AddRange(new object[] {
            "الكل",
            "فعال",
            "موقوف"});
            this.gcbIsActive.Location = new System.Drawing.Point(712, 151);
            this.gcbIsActive.Name = "gcbIsActive";
            this.gcbIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcbIsActive.Size = new System.Drawing.Size(157, 36);
            this.gcbIsActive.TabIndex = 35;
            this.gcbIsActive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gcbIsActive.SelectedIndexChanged += new System.EventHandler(this.gcbIsActive_SelectedIndexChanged);
            // 
            // FrmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1210, 737);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.lblNoRecordsFoundMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gcbFilterBy);
            this.Controls.Add(this.lblCurrentPageRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbtnAddUser);
            this.Controls.Add(this.kgtxtPageNumber);
            this.Controls.Add(this.gibtnNextPage);
            this.Controls.Add(this.lblCurrentPageOfNumberOfPages);
            this.Controls.Add(this.lblTotalRecordsNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gibtnPreviousPage);
            this.Controls.Add(this.gdgvUser);
            this.Controls.Add(this.gcbIsActive);
            this.Controls.Add(this.kgtxtFilterValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmUsers";
            this.Text = "FrmUsers";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdgvUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblUserMessage;
        private System.Windows.Forms.Timer SearchAfterTimerFinish;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtFilterValue;
        private System.Windows.Forms.Label lblNoRecordsFoundMessage;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox gcbFilterBy;
        private System.Windows.Forms.Label lblCurrentPageRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2Button gbtnAddUser;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPageNumber;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnNextPage;
        private System.Windows.Forms.Label lblCurrentPageOfNumberOfPages;
        private System.Windows.Forms.Label lblTotalRecordsNumber;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnPreviousPage;
        private Guna.UI2.WinForms.Guna2DataGridView gdgvUser;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gtsmUserInfo;
        private System.Windows.Forms.ToolStripMenuItem gtsmAddUser;
        private System.Windows.Forms.ToolStripMenuItem gtsmEditUser;
        private System.Windows.Forms.ToolStripMenuItem gtsmDeleteUser;
        private Guna.UI2.WinForms.Guna2ComboBox gcbIsActive;
    }
}