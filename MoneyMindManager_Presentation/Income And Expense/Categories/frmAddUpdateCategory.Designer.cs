namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    partial class frmAddUpdateCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateCategory));
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.gcbIsIncome_CategroyType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gtswIsActive = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.lblCategoryID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlInfoIcon1 = new KhaledControlLibrary1.ctrlInfoIcon();
            this.ctrlInfoIcon2 = new KhaledControlLibrary1.ctrlInfoIcon();
            this.gbtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnSave = new Guna.UI2.WinForms.Guna2Button();
            this.kgtxtNotes = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtMonthlyBudget = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtParentCategoryName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtCategoryName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.gcbIsIncome_CategroyType);
            this.guna2Panel2.Controls.Add(this.guna2Panel3);
            this.guna2Panel2.Controls.Add(this.ctrlInfoIcon1);
            this.guna2Panel2.Controls.Add(this.ctrlInfoIcon2);
            this.guna2Panel2.Controls.Add(this.gbtnClose);
            this.guna2Panel2.Controls.Add(this.gbtnSave);
            this.guna2Panel2.Controls.Add(this.kgtxtNotes);
            this.guna2Panel2.Controls.Add(this.kgtxtMonthlyBudget);
            this.guna2Panel2.Controls.Add(this.kgtxtParentCategoryName);
            this.guna2Panel2.Controls.Add(this.kgtxtCategoryName);
            this.guna2Panel2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel2.Location = new System.Drawing.Point(260, 170);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.guna2Panel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.guna2Panel2.Size = new System.Drawing.Size(698, 313);
            this.guna2Panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(267, 150);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(78, 24);
            this.label2.TabIndex = 100;
            this.label2.Text = "نوع الفئة : ";
            // 
            // gcbIsIncome_CategroyType
            // 
            this.gcbIsIncome_CategroyType.AutoCompleteCustomSource.AddRange(new string[] {
            "واردات",
            "مصروفات"});
            this.gcbIsIncome_CategroyType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gcbIsIncome_CategroyType.AutoRoundedCorners = true;
            this.gcbIsIncome_CategroyType.BackColor = System.Drawing.Color.Transparent;
            this.gcbIsIncome_CategroyType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcbIsIncome_CategroyType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gcbIsIncome_CategroyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gcbIsIncome_CategroyType.DropDownWidth = 150;
            this.gcbIsIncome_CategroyType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbIsIncome_CategroyType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbIsIncome_CategroyType.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gcbIsIncome_CategroyType.ForeColor = System.Drawing.Color.Black;
            this.gcbIsIncome_CategroyType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbIsIncome_CategroyType.ItemHeight = 30;
            this.gcbIsIncome_CategroyType.Items.AddRange(new object[] {
            "واردات",
            "مصروفات"});
            this.gcbIsIncome_CategroyType.Location = new System.Drawing.Point(58, 145);
            this.gcbIsIncome_CategroyType.Name = "gcbIsIncome_CategroyType";
            this.gcbIsIncome_CategroyType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcbIsIncome_CategroyType.Size = new System.Drawing.Size(203, 36);
            this.gcbIsIncome_CategroyType.TabIndex = 102;
            this.gcbIsIncome_CategroyType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gcbIsIncome_CategroyType.SelectedIndexChanged += new System.EventHandler(this.gcbIsIncome_CategroyType_SelectedIndexChanged);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BorderColor = System.Drawing.Color.Gray;
            this.guna2Panel3.BorderRadius = 8;
            this.guna2Panel3.BorderThickness = 1;
            this.guna2Panel3.Controls.Add(this.label1);
            this.guna2Panel3.Controls.Add(this.gtswIsActive);
            this.guna2Panel3.Controls.Add(this.lblCategoryID);
            this.guna2Panel3.Controls.Add(this.label3);
            this.guna2Panel3.CustomizableEdges.BottomRight = false;
            this.guna2Panel3.CustomizableEdges.TopRight = false;
            this.guna2Panel3.Location = new System.Drawing.Point(12, 24);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(329, 41);
            this.guna2Panel3.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 10);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 98;
            this.label1.Text = "الفعالية";
            // 
            // gtswIsActive
            // 
            this.gtswIsActive.Animated = true;
            this.gtswIsActive.AutoRoundedCorners = true;
            this.gtswIsActive.Checked = true;
            this.gtswIsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gtswIsActive.CheckedState.BorderRadius = 13;
            this.gtswIsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gtswIsActive.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.gtswIsActive.CheckedState.InnerBorderRadius = 9;
            this.gtswIsActive.CheckedState.InnerColor = System.Drawing.Color.White;
            this.gtswIsActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gtswIsActive.Location = new System.Drawing.Point(9, 7);
            this.gtswIsActive.Name = "gtswIsActive";
            this.gtswIsActive.Size = new System.Drawing.Size(51, 29);
            this.gtswIsActive.TabIndex = 99;
            this.toolTip1.SetToolTip(this.gtswIsActive, "الفعالية تتحكم في إمكانية اختيارها ");
            this.gtswIsActive.UncheckedState.BorderColor = System.Drawing.Color.Silver;
            this.gtswIsActive.UncheckedState.BorderRadius = 13;
            this.gtswIsActive.UncheckedState.BorderThickness = 1;
            this.gtswIsActive.UncheckedState.FillColor = System.Drawing.Color.White;
            this.gtswIsActive.UncheckedState.InnerBorderColor = System.Drawing.Color.WhiteSmoke;
            this.gtswIsActive.UncheckedState.InnerBorderRadius = 9;
            this.gtswIsActive.UncheckedState.InnerColor = System.Drawing.Color.Gray;
            // 
            // lblCategoryID
            // 
            this.lblCategoryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryID.Location = new System.Drawing.Point(128, 10);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCategoryID.Size = new System.Drawing.Size(100, 23);
            this.lblCategoryID.TabIndex = 96;
            this.lblCategoryID.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(235, 8);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(85, 24);
            this.label3.TabIndex = 97;
            this.label3.Text = "معرفة الفئة :";
            // 
            // ctrlInfoIcon1
            // 
            this.ctrlInfoIcon1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlInfoIcon1.IconImage = ((System.Drawing.Image)(resources.GetObject("ctrlInfoIcon1.IconImage")));
            this.ctrlInfoIcon1.Location = new System.Drawing.Point(352, 101);
            this.ctrlInfoIcon1.Name = "ctrlInfoIcon1";
            this.ctrlInfoIcon1.Size = new System.Drawing.Size(20, 20);
            this.ctrlInfoIcon1.TabIndex = 100;
            // 
            // 
            // 
            this.ctrlInfoIcon1.ToolTipControl.IsBalloon = true;
            this.ctrlInfoIcon1.ToolTipText = "متاحة فقط للفئات الرئيسية من نوع مصروفات";
            // 
            // ctrlInfoIcon2
            // 
            this.ctrlInfoIcon2.BackColor = System.Drawing.Color.Transparent;
            this.ctrlInfoIcon2.IconImage = ((System.Drawing.Image)(resources.GetObject("ctrlInfoIcon2.IconImage")));
            this.ctrlInfoIcon2.Location = new System.Drawing.Point(28, 101);
            this.ctrlInfoIcon2.Name = "ctrlInfoIcon2";
            this.ctrlInfoIcon2.Size = new System.Drawing.Size(20, 20);
            this.ctrlInfoIcon2.TabIndex = 97;
            // 
            // 
            // 
            this.ctrlInfoIcon2.ToolTipControl.IsBalloon = true;
            this.ctrlInfoIcon2.ToolTipText = "ان كانت فارغة فهي فئة رئيسية , إن لم تكن فهي فئة فرعية وستندرج تحت شروط الفئة الم" +
    "ختارة";
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
            this.gbtnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnClose.ForeColor = System.Drawing.Color.Black;
            this.gbtnClose.HoverState.FillColor = System.Drawing.Color.SlateBlue;
            this.gbtnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("gbtnClose.Image")));
            this.gbtnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnClose.ImageOffset = new System.Drawing.Point(5, 0);
            this.gbtnClose.ImageSize = new System.Drawing.Size(30, 30);
            this.gbtnClose.IndicateFocus = true;
            this.gbtnClose.Location = new System.Drawing.Point(58, 252);
            this.gbtnClose.Name = "gbtnClose";
            this.gbtnClose.PressedColor = System.Drawing.Color.White;
            this.gbtnClose.Size = new System.Drawing.Size(283, 45);
            this.gbtnClose.TabIndex = 6;
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
            this.gbtnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.gbtnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnSave.FillColor = System.Drawing.Color.White;
            this.gbtnSave.FocusedColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbtnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnSave.ForeColor = System.Drawing.Color.Black;
            this.gbtnSave.HoverState.FillColor = System.Drawing.Color.SlateBlue;
            this.gbtnSave.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("gbtnSave.Image")));
            this.gbtnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnSave.ImageOffset = new System.Drawing.Point(5, 0);
            this.gbtnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.gbtnSave.IndicateFocus = true;
            this.gbtnSave.Location = new System.Drawing.Point(58, 198);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.PressedColor = System.Drawing.Color.White;
            this.gbtnSave.Size = new System.Drawing.Size(283, 45);
            this.gbtnSave.TabIndex = 5;
            this.gbtnSave.Text = "حفظ";
            this.gbtnSave.Click += new System.EventHandler(this.gbtnSave_Click);
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
            this.kgtxtNotes.Location = new System.Drawing.Point(382, 150);
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
            this.kgtxtNotes.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtNotes.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtNotes.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtNotes.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtNotes.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtNotes.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtNotes.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtNotes.NumberProperties.IntegerNumberProperties.MinValue = 0;
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
            this.kgtxtNotes.Size = new System.Drawing.Size(283, 107);
            this.kgtxtNotes.TabIndex = 3;
            this.kgtxtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtNotes.TextProperties.MinLength = ((short)(0));
            this.kgtxtNotes.TextProperties.MinLengthOption = false;
            this.kgtxtNotes.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtNotes.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtNotes.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Phone;
            this.kgtxtNotes.TrimEnd = false;
            this.kgtxtNotes.TrimStart = false;
            // 
            // kgtxtMonthlyBudget
            // 
            this.kgtxtMonthlyBudget.AllowWhiteSpace = false;
            this.kgtxtMonthlyBudget.ApplyTrimAtTextBoxValue = false;
            this.kgtxtMonthlyBudget.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtMonthlyBudget.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtMonthlyBudget.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtMonthlyBudget.BorderRadius = 10;
            this.kgtxtMonthlyBudget.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtMonthlyBudget.DefaultText = "";
            this.kgtxtMonthlyBudget.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtMonthlyBudget.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtMonthlyBudget.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtMonthlyBudget.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtMonthlyBudget.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtMonthlyBudget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtMonthlyBudget.ForeColor = System.Drawing.Color.Black;
            this.kgtxtMonthlyBudget.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtMonthlyBudget.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Number;
            this.kgtxtMonthlyBudget.IsRequired = false;
            this.kgtxtMonthlyBudget.Location = new System.Drawing.Point(382, 89);
            this.kgtxtMonthlyBudget.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtMonthlyBudget.MaxLength = 25;
            this.kgtxtMonthlyBudget.Name = "kgtxtMonthlyBudget";
            this.kgtxtMonthlyBudget.NumberProperties.DecimalNumberProperties.AllowNegative = false;
            this.kgtxtMonthlyBudget.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtMonthlyBudget.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtMonthlyBudget.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtMonthlyBudget.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtMonthlyBudget.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtMonthlyBudget.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtMonthlyBudget.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtMonthlyBudget.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtMonthlyBudget.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtMonthlyBudget.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtMonthlyBudget.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtMonthlyBudget.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtMonthlyBudget.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtMonthlyBudget.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtMonthlyBudget.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.N2;
            this.kgtxtMonthlyBudget.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.DecimalNumber;
            this.kgtxtMonthlyBudget.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtMonthlyBudget.PlaceholderText = "الميزانية الشهرية (اختياري)";
            this.kgtxtMonthlyBudget.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtMonthlyBudget.SelectedText = "";
            this.kgtxtMonthlyBudget.ShadowDecoration.BorderRadius = 2;
            this.kgtxtMonthlyBudget.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtMonthlyBudget.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtMonthlyBudget.Size = new System.Drawing.Size(283, 41);
            this.kgtxtMonthlyBudget.TabIndex = 1;
            this.kgtxtMonthlyBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtMonthlyBudget.TextProperties.MinLength = ((short)(0));
            this.kgtxtMonthlyBudget.TextProperties.MinLengthOption = false;
            this.kgtxtMonthlyBudget.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtMonthlyBudget.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtMonthlyBudget.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Phone;
            this.kgtxtMonthlyBudget.TrimEnd = false;
            this.kgtxtMonthlyBudget.TrimStart = false;
            this.kgtxtMonthlyBudget.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtMonthlyBudget.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtMonthlyBudget_OnValidationSuccess);
            // 
            // kgtxtParentCategoryName
            // 
            this.kgtxtParentCategoryName.AllowWhiteSpace = false;
            this.kgtxtParentCategoryName.ApplyTrimAtTextBoxValue = false;
            this.kgtxtParentCategoryName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtParentCategoryName.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtParentCategoryName.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtParentCategoryName.BorderRadius = 10;
            this.kgtxtParentCategoryName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtParentCategoryName.DefaultText = "";
            this.kgtxtParentCategoryName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtParentCategoryName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtParentCategoryName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtParentCategoryName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtParentCategoryName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtParentCategoryName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtParentCategoryName.ForeColor = System.Drawing.Color.Black;
            this.kgtxtParentCategoryName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtParentCategoryName.IconLeft = ((System.Drawing.Image)(resources.GetObject("kgtxtParentCategoryName.IconLeft")));
            this.kgtxtParentCategoryName.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtParentCategoryName.IconRight = ((System.Drawing.Image)(resources.GetObject("kgtxtParentCategoryName.IconRight")));
            this.kgtxtParentCategoryName.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.kgtxtParentCategoryName.IconRightOffset = new System.Drawing.Point(2, 0);
            this.kgtxtParentCategoryName.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtParentCategoryName.IsRequired = false;
            this.kgtxtParentCategoryName.Location = new System.Drawing.Point(58, 89);
            this.kgtxtParentCategoryName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtParentCategoryName.MaxLength = 255;
            this.kgtxtParentCategoryName.Name = "kgtxtParentCategoryName";
            this.kgtxtParentCategoryName.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtParentCategoryName.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtParentCategoryName.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtParentCategoryName.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtParentCategoryName.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtParentCategoryName.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtParentCategoryName.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtParentCategoryName.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtParentCategoryName.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtParentCategoryName.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtParentCategoryName.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtParentCategoryName.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtParentCategoryName.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtParentCategoryName.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtParentCategoryName.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtParentCategoryName.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtParentCategoryName.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtParentCategoryName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtParentCategoryName.PlaceholderText = "الفئة التابعة لها (اختياري)";
            this.kgtxtParentCategoryName.ReadOnly = true;
            this.kgtxtParentCategoryName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtParentCategoryName.SelectedText = "";
            this.kgtxtParentCategoryName.ShadowDecoration.BorderRadius = 2;
            this.kgtxtParentCategoryName.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtParentCategoryName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtParentCategoryName.Size = new System.Drawing.Size(283, 41);
            this.kgtxtParentCategoryName.TabIndex = 2;
            this.kgtxtParentCategoryName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtParentCategoryName.TextProperties.MinLength = ((short)(0));
            this.kgtxtParentCategoryName.TextProperties.MinLengthOption = false;
            this.kgtxtParentCategoryName.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtParentCategoryName.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtParentCategoryName.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Email;
            this.kgtxtParentCategoryName.TrimEnd = false;
            this.kgtxtParentCategoryName.TrimStart = false;
            this.kgtxtParentCategoryName.IconLeftClick += new System.EventHandler(this.kgtxtParentCategory_IconLeftClick);
            this.kgtxtParentCategoryName.IconRightClick += new System.EventHandler(this.kgtxtParentCategoryName_RightIconClear);
            // 
            // kgtxtCategoryName
            // 
            this.kgtxtCategoryName.AllowWhiteSpace = true;
            this.kgtxtCategoryName.ApplyTrimAtTextBoxValue = false;
            this.kgtxtCategoryName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtCategoryName.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtCategoryName.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtCategoryName.BorderRadius = 10;
            this.kgtxtCategoryName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtCategoryName.DefaultText = "";
            this.kgtxtCategoryName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtCategoryName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtCategoryName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtCategoryName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtCategoryName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtCategoryName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtCategoryName.ForeColor = System.Drawing.Color.Black;
            this.kgtxtCategoryName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtCategoryName.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtCategoryName.IsRequired = true;
            this.kgtxtCategoryName.Location = new System.Drawing.Point(382, 24);
            this.kgtxtCategoryName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtCategoryName.MaxLength = 200;
            this.kgtxtCategoryName.Name = "kgtxtCategoryName";
            this.kgtxtCategoryName.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtCategoryName.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtCategoryName.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtCategoryName.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtCategoryName.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtCategoryName.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtCategoryName.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtCategoryName.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtCategoryName.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtCategoryName.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtCategoryName.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtCategoryName.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtCategoryName.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtCategoryName.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtCategoryName.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtCategoryName.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtCategoryName.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtCategoryName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtCategoryName.PlaceholderText = "اسم الفئة (مطلوب)";
            this.kgtxtCategoryName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtCategoryName.SelectedText = "";
            this.kgtxtCategoryName.ShadowDecoration.BorderRadius = 2;
            this.kgtxtCategoryName.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtCategoryName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtCategoryName.Size = new System.Drawing.Size(283, 41);
            this.kgtxtCategoryName.TabIndex = 0;
            this.kgtxtCategoryName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtCategoryName.TextProperties.MinLength = ((short)(0));
            this.kgtxtCategoryName.TextProperties.MinLengthOption = false;
            this.kgtxtCategoryName.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtCategoryName.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtCategoryName.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtCategoryName.TrimEnd = true;
            this.kgtxtCategoryName.TrimStart = true;
            this.kgtxtCategoryName.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxt_OnValidationError);
            this.kgtxtCategoryName.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtCategoryName_OnValidationSuccess);
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(12, 19);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1186, 62);
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "إضافة شخص";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // frmAddUpdateIncomeAndExpeseTransction
            // 
            this.AcceptButton = this.gbtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.gbtnClose;
            this.ClientSize = new System.Drawing.Size(1210, 737);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateIncomeAndExpeseTransction";
            this.Text = "frmAddUpdateIncomeAndExpeseTransction";
            this.Load += new System.EventHandler(this.frmAddUpdateCategory_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button gbtnClose;
        private Guna.UI2.WinForms.Guna2Button gbtnSave;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtNotes;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtMonthlyBudget;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtParentCategoryName;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtCategoryName;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private KhaledControlLibrary1.ctrlInfoIcon ctrlInfoIcon2;
        private KhaledControlLibrary1.ctrlInfoIcon ctrlInfoIcon1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ToggleSwitch gtswIsActive;
        private System.Windows.Forms.Label lblCategoryID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox gcbIsIncome_CategroyType;
    }
}