namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    partial class frmAddUpdateDebtPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateDebtPayment));
            this.lblHeader = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.gtswNewTransactionAfterAdd = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gibtnDeleteTransaction = new Guna.UI2.WinForms.Guna2ImageButton();
            this.gbtnNewTransaction = new Guna.UI2.WinForms.Guna2Button();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnSave = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTransactionID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlInfoIcon_Status_IsLocked = new KhaledControlLibrary1.ctrlInfoIcon();
            this.kgtxtPurpose = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtAmount = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtPaymentDate = new KhaledControlLibrary1.KhaledGuna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon_Status_IsLocked.PictureBoxControl)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1210, 50);
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "إضافة معاملة";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(596, 540);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(194, 24);
            this.label1.TabIndex = 104;
            this.label1.Text = "معاملة جديدة بعد الإضافة تلقائيا";
            // 
            // gtswNewTransactionAfterAdd
            // 
            this.gtswNewTransactionAfterAdd.Animated = true;
            this.gtswNewTransactionAfterAdd.AutoRoundedCorners = true;
            this.gtswNewTransactionAfterAdd.Checked = true;
            this.gtswNewTransactionAfterAdd.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gtswNewTransactionAfterAdd.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gtswNewTransactionAfterAdd.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.gtswNewTransactionAfterAdd.CheckedState.InnerColor = System.Drawing.Color.White;
            this.gtswNewTransactionAfterAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gtswNewTransactionAfterAdd.Location = new System.Drawing.Point(556, 543);
            this.gtswNewTransactionAfterAdd.Name = "gtswNewTransactionAfterAdd";
            this.gtswNewTransactionAfterAdd.Size = new System.Drawing.Size(35, 20);
            this.gtswNewTransactionAfterAdd.TabIndex = 5;
            this.toolTip1.SetToolTip(this.gtswNewTransactionAfterAdd, "بعد الحفظ : سيتم التهيئة لإضافة معاملة جديدة تلقائيا");
            this.gtswNewTransactionAfterAdd.UncheckedState.BorderColor = System.Drawing.Color.Silver;
            this.gtswNewTransactionAfterAdd.UncheckedState.BorderThickness = 1;
            this.gtswNewTransactionAfterAdd.UncheckedState.FillColor = System.Drawing.Color.White;
            this.gtswNewTransactionAfterAdd.UncheckedState.InnerBorderColor = System.Drawing.Color.WhiteSmoke;
            this.gtswNewTransactionAfterAdd.UncheckedState.InnerColor = System.Drawing.Color.Gray;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // gibtnDeleteTransaction
            // 
            this.gibtnDeleteTransaction.BackColor = System.Drawing.Color.Transparent;
            this.gibtnDeleteTransaction.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnDeleteTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gibtnDeleteTransaction.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.gibtnDeleteTransaction.Image = ((System.Drawing.Image)(resources.GetObject("gibtnDeleteTransaction.Image")));
            this.gibtnDeleteTransaction.ImageOffset = new System.Drawing.Point(0, 0);
            this.gibtnDeleteTransaction.ImageRotate = 0F;
            this.gibtnDeleteTransaction.ImageSize = new System.Drawing.Size(28, 28);
            this.gibtnDeleteTransaction.Location = new System.Drawing.Point(479, 532);
            this.gibtnDeleteTransaction.Name = "gibtnDeleteTransaction";
            this.gibtnDeleteTransaction.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gibtnDeleteTransaction.Size = new System.Drawing.Size(40, 42);
            this.gibtnDeleteTransaction.TabIndex = 6;
            this.toolTip1.SetToolTip(this.gibtnDeleteTransaction, "حذف المعاملة نهائيا");
            this.gibtnDeleteTransaction.UseTransparentBackground = true;
            this.gibtnDeleteTransaction.Click += new System.EventHandler(this.gibtnDeleteTransaction_Click);
            // 
            // gbtnNewTransaction
            // 
            this.gbtnNewTransaction.Animated = true;
            this.gbtnNewTransaction.AutoRoundedCorners = true;
            this.gbtnNewTransaction.BackColor = System.Drawing.Color.Transparent;
            this.gbtnNewTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnNewTransaction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnNewTransaction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnNewTransaction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnNewTransaction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnNewTransaction.FillColor = System.Drawing.Color.Transparent;
            this.gbtnNewTransaction.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.gbtnNewTransaction.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gbtnNewTransaction.ForeColor = System.Drawing.Color.Black;
            this.gbtnNewTransaction.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnNewTransaction.HoverState.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnNewTransaction.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnNewTransaction.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.gbtnNewTransaction.Image = ((System.Drawing.Image)(resources.GetObject("gbtnNewTransaction.Image")));
            this.gbtnNewTransaction.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnNewTransaction.ImageSize = new System.Drawing.Size(25, 25);
            this.gbtnNewTransaction.IndicateFocus = true;
            this.gbtnNewTransaction.Location = new System.Drawing.Point(464, 584);
            this.gbtnNewTransaction.Name = "gbtnNewTransaction";
            this.gbtnNewTransaction.Size = new System.Drawing.Size(283, 41);
            this.gbtnNewTransaction.TabIndex = 7;
            this.gbtnNewTransaction.Text = "معاملة سداد جديدة";
            this.gbtnNewTransaction.Click += new System.EventHandler(this.gbtnNewTransaction_Click);
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblUserMessage.Location = new System.Drawing.Point(38, 65);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserMessage.Size = new System.Drawing.Size(1148, 42);
            this.lblUserMessage.TabIndex = 106;
            this.lblUserMessage.Text = "\"تم العثور على حقول غير صالحة. ضع المؤشر على العلامات الحمراء لعرض سبب الخطأ.\"";
            this.lblUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.label5);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Controls.Add(this.gbtnClose);
            this.guna2Panel2.Controls.Add(this.gbtnSave);
            this.guna2Panel2.Controls.Add(this.guna2Panel3);
            this.guna2Panel2.Controls.Add(this.ctrlInfoIcon_Status_IsLocked);
            this.guna2Panel2.Controls.Add(this.kgtxtPurpose);
            this.guna2Panel2.Controls.Add(this.kgtxtAmount);
            this.guna2Panel2.Controls.Add(this.kgtxtPaymentDate);
            this.guna2Panel2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel2.Location = new System.Drawing.Point(427, 111);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.guna2Panel2.ShadowDecoration.Depth = 20;
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.Size = new System.Drawing.Size(359, 419);
            this.guna2Panel2.TabIndex = 107;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(283, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 111;
            this.label5.Text = "المبلغ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 110;
            this.label2.Text = "البيان";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(256, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 109;
            this.label4.Text = "تاريخ الدفع";
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
            this.gbtnClose.Location = new System.Drawing.Point(37, 358);
            this.gbtnClose.Name = "gbtnClose";
            this.gbtnClose.PressedColor = System.Drawing.Color.White;
            this.gbtnClose.Size = new System.Drawing.Size(283, 41);
            this.gbtnClose.TabIndex = 4;
            this.gbtnClose.Text = "غلق";
            this.gbtnClose.Click += new System.EventHandler(this.gbtnClose_Click);
            // 
            // gbtnSave
            // 
            this.gbtnSave.Animated = true;
            this.gbtnSave.AutoRoundedCorners = true;
            this.gbtnSave.BackColor = System.Drawing.Color.Transparent;
            this.gbtnSave.BorderColor = System.Drawing.Color.DimGray;
            this.gbtnSave.BorderThickness = 1;
            this.gbtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.gbtnSave.Location = new System.Drawing.Point(37, 304);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.PressedColor = System.Drawing.Color.White;
            this.gbtnSave.Size = new System.Drawing.Size(283, 41);
            this.gbtnSave.TabIndex = 3;
            this.gbtnSave.Text = "حفظ";
            this.gbtnSave.Click += new System.EventHandler(this.gbtnSave_Click);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BorderColor = System.Drawing.Color.Gray;
            this.guna2Panel3.BorderRadius = 8;
            this.guna2Panel3.BorderThickness = 1;
            this.guna2Panel3.Controls.Add(this.lblTransactionID);
            this.guna2Panel3.Controls.Add(this.label3);
            this.guna2Panel3.CustomizableEdges.BottomRight = false;
            this.guna2Panel3.CustomizableEdges.TopRight = false;
            this.guna2Panel3.Location = new System.Drawing.Point(80, 22);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(240, 41);
            this.guna2Panel3.TabIndex = 101;
            // 
            // lblTransactionID
            // 
            this.lblTransactionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionID.Location = new System.Drawing.Point(3, 9);
            this.lblTransactionID.Name = "lblTransactionID";
            this.lblTransactionID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTransactionID.Size = new System.Drawing.Size(130, 23);
            this.lblTransactionID.TabIndex = 96;
            this.lblTransactionID.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(128, 8);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 97;
            this.label3.Text = "معرفة المعاملة :";
            // 
            // ctrlInfoIcon_Status_IsLocked
            // 
            this.ctrlInfoIcon_Status_IsLocked.BackColor = System.Drawing.Color.Transparent;
            this.ctrlInfoIcon_Status_IsLocked.IconImage = global::MoneyMindManager_Presentation.Properties.Resources.unlocked__1_;
            this.ctrlInfoIcon_Status_IsLocked.Location = new System.Drawing.Point(39, 27);
            this.ctrlInfoIcon_Status_IsLocked.Name = "ctrlInfoIcon_Status_IsLocked";
            // 
            // 
            // 
            this.ctrlInfoIcon_Status_IsLocked.PictureBoxControl.Image = global::MoneyMindManager_Presentation.Properties.Resources.unlocked__1_;
            this.ctrlInfoIcon_Status_IsLocked.PictureBoxControl.ImageRotate = 0F;
            this.ctrlInfoIcon_Status_IsLocked.PictureBoxControl.Location = new System.Drawing.Point(0, 0);
            this.ctrlInfoIcon_Status_IsLocked.PictureBoxControl.Name = "gpbInfoIcon";
            this.ctrlInfoIcon_Status_IsLocked.PictureBoxControl.TabIndex = 0;
            this.ctrlInfoIcon_Status_IsLocked.PictureBoxControl.TabStop = false;
            this.ctrlInfoIcon_Status_IsLocked.Size = new System.Drawing.Size(38, 31);
            this.ctrlInfoIcon_Status_IsLocked.TabIndex = 106;
            this.ctrlInfoIcon_Status_IsLocked.TabStop = false;
            // 
            // 
            // 
            this.ctrlInfoIcon_Status_IsLocked.ToolTipControl.IsBalloon = true;
            this.ctrlInfoIcon_Status_IsLocked.ToolTipText = null;
            // 
            // kgtxtPurpose
            // 
            this.kgtxtPurpose.AllowWhiteSpace = true;
            this.kgtxtPurpose.ApplyTrimAtTextBoxValue = false;
            this.kgtxtPurpose.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtPurpose.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtPurpose.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtPurpose.BorderRadius = 10;
            this.kgtxtPurpose.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtPurpose.DefaultText = "";
            this.kgtxtPurpose.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtPurpose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtPurpose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPurpose.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPurpose.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPurpose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtPurpose.ForeColor = System.Drawing.Color.Black;
            this.kgtxtPurpose.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPurpose.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtPurpose.IsRequired = false;
            this.kgtxtPurpose.Location = new System.Drawing.Point(37, 130);
            this.kgtxtPurpose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtPurpose.MaxLength = 150;
            this.kgtxtPurpose.Multiline = true;
            this.kgtxtPurpose.Name = "kgtxtPurpose";
            this.kgtxtPurpose.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtPurpose.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPurpose.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtPurpose.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtPurpose.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPurpose.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtPurpose.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtPurpose.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtPurpose.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtPurpose.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtPurpose.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtPurpose.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtPurpose.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtPurpose.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtPurpose.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtPurpose.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtPurpose.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtPurpose.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtPurpose.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtPurpose.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtPurpose.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtPurpose.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtPurpose.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtPurpose.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtPurpose.PlaceholderText = "البيان (اختياري)";
            this.kgtxtPurpose.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.kgtxtPurpose.SelectedText = "";
            this.kgtxtPurpose.ShadowDecoration.BorderRadius = 2;
            this.kgtxtPurpose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtPurpose.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtPurpose.Size = new System.Drawing.Size(283, 107);
            this.kgtxtPurpose.TabIndex = 1;
            this.kgtxtPurpose.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtPurpose.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtPurpose.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtPurpose.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtPurpose.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtPurpose.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtPurpose.TextProperties.MinLength = ((short)(0));
            this.kgtxtPurpose.TextProperties.MinLengthOption = false;
            this.kgtxtPurpose.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtPurpose.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtPurpose.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Phone;
            this.kgtxtPurpose.TrimEnd = false;
            this.kgtxtPurpose.TrimStart = false;
            this.kgtxtPurpose.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtPurpose.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            // 
            // kgtxtAmount
            // 
            this.kgtxtAmount.AllowWhiteSpace = false;
            this.kgtxtAmount.ApplyTrimAtTextBoxValue = false;
            this.kgtxtAmount.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtAmount.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtAmount.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtAmount.BorderRadius = 10;
            this.kgtxtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtAmount.DefaultText = "";
            this.kgtxtAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtAmount.ForeColor = System.Drawing.Color.Black;
            this.kgtxtAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtAmount.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtAmount.IsRequired = true;
            this.kgtxtAmount.Location = new System.Drawing.Point(37, 250);
            this.kgtxtAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtAmount.MaxLength = 25;
            this.kgtxtAmount.Name = "kgtxtAmount";
            this.kgtxtAmount.NumberProperties.DecimalNumberProperties.AllowNegative = false;
            this.kgtxtAmount.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtAmount.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtAmount.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtAmount.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtAmount.NumberProperties.DecimalNumberProperties.MinValueIncluded = false;
            this.kgtxtAmount.NumberProperties.DecimalNumberProperties.MinValueOption = true;
            this.kgtxtAmount.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtAmount.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtAmount.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtAmount.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtAmount.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtAmount.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtAmount.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtAmount.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtAmount.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtAmount.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtAmount.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtAmount.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtAmount.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtAmount.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtAmount.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.N4;
            this.kgtxtAmount.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber;
            this.kgtxtAmount.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtAmount.PlaceholderText = "المبلغ (مطلوب)";
            this.kgtxtAmount.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtAmount.SelectedText = "";
            this.kgtxtAmount.ShadowDecoration.BorderRadius = 2;
            this.kgtxtAmount.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtAmount.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtAmount.Size = new System.Drawing.Size(283, 41);
            this.kgtxtAmount.TabIndex = 2;
            this.kgtxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtAmount.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtAmount.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtAmount.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtAmount.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtAmount.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtAmount.TextProperties.MinLength = ((short)(0));
            this.kgtxtAmount.TextProperties.MinLengthOption = false;
            this.kgtxtAmount.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtAmount.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtAmount.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Phone;
            this.kgtxtAmount.TrimEnd = true;
            this.kgtxtAmount.TrimStart = true;
            this.kgtxtAmount.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtAmount.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            // 
            // kgtxtPaymentDate
            // 
            this.kgtxtPaymentDate.AllowWhiteSpace = false;
            this.kgtxtPaymentDate.ApplyTrimAtTextBoxValue = false;
            this.kgtxtPaymentDate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtPaymentDate.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtPaymentDate.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtPaymentDate.BorderRadius = 10;
            this.kgtxtPaymentDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtPaymentDate.DefaultText = "";
            this.kgtxtPaymentDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtPaymentDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtPaymentDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPaymentDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPaymentDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPaymentDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtPaymentDate.ForeColor = System.Drawing.Color.Black;
            this.kgtxtPaymentDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPaymentDate.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtPaymentDate.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtPaymentDate.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtPaymentDate.IsRequired = true;
            this.kgtxtPaymentDate.Location = new System.Drawing.Point(37, 76);
            this.kgtxtPaymentDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtPaymentDate.MaxLength = 255;
            this.kgtxtPaymentDate.Name = "kgtxtPaymentDate";
            this.kgtxtPaymentDate.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtPaymentDate.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPaymentDate.NumberProperties.DecimalNumberProperties.MaxValueIncluded = true;
            this.kgtxtPaymentDate.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtPaymentDate.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPaymentDate.NumberProperties.DecimalNumberProperties.MinValueIncluded = true;
            this.kgtxtPaymentDate.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtPaymentDate.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtPaymentDate.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtPaymentDate.NumberProperties.FloatNumberProperties.MaxValueIncluded = true;
            this.kgtxtPaymentDate.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtPaymentDate.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtPaymentDate.NumberProperties.FloatNumberProperties.MinValueIncluded = true;
            this.kgtxtPaymentDate.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtPaymentDate.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtPaymentDate.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtPaymentDate.NumberProperties.IntegerNumberProperties.MaxValueIncluded = true;
            this.kgtxtPaymentDate.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtPaymentDate.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtPaymentDate.NumberProperties.IntegerNumberProperties.MinValueIncluded = true;
            this.kgtxtPaymentDate.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtPaymentDate.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtPaymentDate.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtPaymentDate.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtPaymentDate.PlaceholderText = " تاريخ الدفع (مطلوب)";
            this.kgtxtPaymentDate.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtPaymentDate.SelectedText = "";
            this.kgtxtPaymentDate.ShadowDecoration.BorderRadius = 2;
            this.kgtxtPaymentDate.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtPaymentDate.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtPaymentDate.Size = new System.Drawing.Size(283, 41);
            this.kgtxtPaymentDate.TabIndex = 0;
            this.kgtxtPaymentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtPaymentDate.TextProperties.DateTimeProperties.DayFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enDayFormate.dd__01;
            this.kgtxtPaymentDate.TextProperties.DateTimeProperties.MonthFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enMonthFormate.MM__01;
            this.kgtxtPaymentDate.TextProperties.DateTimeProperties.SeparatorFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enSeparator.Dash;
            this.kgtxtPaymentDate.TextProperties.DateTimeProperties.TimeFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enTimeFormate.None;
            this.kgtxtPaymentDate.TextProperties.DateTimeProperties.YearFormate = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.clsDateTimeProperties.enYearFormate.yyyy__2025;
            this.kgtxtPaymentDate.TextProperties.MinLength = ((short)(0));
            this.kgtxtPaymentDate.TextProperties.MinLengthOption = false;
            this.kgtxtPaymentDate.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtPaymentDate.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtPaymentDate.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Date;
            this.kgtxtPaymentDate.TrimEnd = true;
            this.kgtxtPaymentDate.TrimStart = true;
            this.kgtxtPaymentDate.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtPaymentDate.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxt_OnValidationSuccess);
            // 
            // frmAddUpdateDebtPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.gbtnClose;
            this.ClientSize = new System.Drawing.Size(1210, 737);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.gibtnDeleteTransaction);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gtswNewTransactionAfterAdd);
            this.Controls.Add(this.gbtnNewTransaction);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateDebtPayment";
            this.Text = "frmAddUpdateIncomeAndExpeseTransction";
            this.Load += new System.EventHandler(this.frmAddUpdateIncomeAndExpenseTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon_Status_IsLocked.PictureBoxControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2Button gbtnNewTransaction;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ToggleSwitch gtswNewTransactionAfterAdd;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblUserMessage;
        private Guna.UI2.WinForms.Guna2ImageButton gibtnDeleteTransaction;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button gbtnClose;
        private Guna.UI2.WinForms.Guna2Button gbtnSave;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label lblTransactionID;
        private System.Windows.Forms.Label label3;
        private KhaledControlLibrary1.ctrlInfoIcon ctrlInfoIcon_Status_IsLocked;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPurpose;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtAmount;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPaymentDate;
    }
}