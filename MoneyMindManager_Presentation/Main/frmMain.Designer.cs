namespace MoneyMindManager_Presentation.Main
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.gbtnOverOview = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnPeople = new Guna.UI2.WinForms.Guna2Button();
            this.gpnlRightBar = new Guna.UI2.WinForms.Guna2Panel();
            this.gbtnDebts = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnTransactions = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnExpense = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnExpensesReturn = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnIncome = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.gcbClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.gbtnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnUsers = new Guna.UI2.WinForms.Guna2Button();
            this.gpnlTopBar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl3 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.gpnlFormContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.gbtnAccount = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.gpnlRightBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_HIDE;
            this.guna2AnimateWindow1.Interval = 250;
            this.guna2AnimateWindow1.TargetForm = this;
            // 
            // gbtnOverOview
            // 
            this.gbtnOverOview.Animated = true;
            this.gbtnOverOview.BackColor = System.Drawing.Color.Transparent;
            this.gbtnOverOview.BorderRadius = 5;
            this.gbtnOverOview.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnOverOview.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnOverOview.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnOverOview.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnOverOview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnOverOview.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnOverOview.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnOverOview.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnOverOview.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnOverOview.FillColor = System.Drawing.Color.White;
            this.gbtnOverOview.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gbtnOverOview.ForeColor = System.Drawing.Color.Black;
            this.gbtnOverOview.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnOverOview.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnOverOview.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnOverOview.Image = ((System.Drawing.Image)(resources.GetObject("gbtnOverOview.Image")));
            this.gbtnOverOview.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnOverOview.ImageSize = new System.Drawing.Size(40, 40);
            this.gbtnOverOview.IndicateFocus = true;
            this.gbtnOverOview.Location = new System.Drawing.Point(6, 126);
            this.gbtnOverOview.Name = "gbtnOverOview";
            this.gbtnOverOview.Size = new System.Drawing.Size(254, 48);
            this.gbtnOverOview.TabIndex = 0;
            this.gbtnOverOview.Text = "لمحة عامة";
            this.gbtnOverOview.Click += new System.EventHandler(this.gbtnOverOview_Click);
            // 
            // gbtnPeople
            // 
            this.gbtnPeople.Animated = true;
            this.gbtnPeople.BackColor = System.Drawing.Color.Transparent;
            this.gbtnPeople.BorderRadius = 5;
            this.gbtnPeople.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnPeople.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnPeople.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnPeople.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnPeople.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnPeople.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnPeople.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnPeople.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnPeople.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnPeople.FillColor = System.Drawing.Color.White;
            this.gbtnPeople.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnPeople.ForeColor = System.Drawing.Color.Black;
            this.gbtnPeople.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnPeople.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnPeople.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnPeople.Image = ((System.Drawing.Image)(resources.GetObject("gbtnPeople.Image")));
            this.gbtnPeople.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnPeople.ImageSize = new System.Drawing.Size(40, 40);
            this.gbtnPeople.IndicateFocus = true;
            this.gbtnPeople.Location = new System.Drawing.Point(6, 181);
            this.gbtnPeople.Name = "gbtnPeople";
            this.gbtnPeople.Size = new System.Drawing.Size(254, 48);
            this.gbtnPeople.TabIndex = 1;
            this.gbtnPeople.Text = "الأشخاص";
            this.gbtnPeople.Click += new System.EventHandler(this.gbtnPeople_Click);
            // 
            // gpnlRightBar
            // 
            this.gpnlRightBar.Controls.Add(this.gbtnSettings);
            this.gpnlRightBar.Controls.Add(this.gbtnAccount);
            this.gpnlRightBar.Controls.Add(this.gbtnDebts);
            this.gpnlRightBar.Controls.Add(this.gbtnTransactions);
            this.gpnlRightBar.Controls.Add(this.gbtnExpense);
            this.gpnlRightBar.Controls.Add(this.gbtnExpensesReturn);
            this.gpnlRightBar.Controls.Add(this.gbtnIncome);
            this.gpnlRightBar.Controls.Add(this.guna2ControlBox2);
            this.gpnlRightBar.Controls.Add(this.gcbClose);
            this.gpnlRightBar.Controls.Add(this.gbtnLogout);
            this.gpnlRightBar.Controls.Add(this.gbtnUsers);
            this.gpnlRightBar.Controls.Add(this.gbtnOverOview);
            this.gpnlRightBar.Controls.Add(this.gbtnPeople);
            this.gpnlRightBar.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gpnlRightBar.CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.gpnlRightBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.gpnlRightBar.Location = new System.Drawing.Point(1210, 0);
            this.gpnlRightBar.Name = "gpnlRightBar";
            this.gpnlRightBar.Size = new System.Drawing.Size(263, 809);
            this.gpnlRightBar.TabIndex = 3;
            // 
            // gbtnDebts
            // 
            this.gbtnDebts.Animated = true;
            this.gbtnDebts.BackColor = System.Drawing.Color.Transparent;
            this.gbtnDebts.BorderRadius = 5;
            this.gbtnDebts.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnDebts.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnDebts.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnDebts.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnDebts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnDebts.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnDebts.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnDebts.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnDebts.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnDebts.FillColor = System.Drawing.Color.White;
            this.gbtnDebts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnDebts.ForeColor = System.Drawing.Color.Black;
            this.gbtnDebts.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnDebts.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnDebts.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnDebts.Image = ((System.Drawing.Image)(resources.GetObject("gbtnDebts.Image")));
            this.gbtnDebts.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnDebts.ImageSize = new System.Drawing.Size(40, 40);
            this.gbtnDebts.IndicateFocus = true;
            this.gbtnDebts.Location = new System.Drawing.Point(6, 456);
            this.gbtnDebts.Name = "gbtnDebts";
            this.gbtnDebts.Size = new System.Drawing.Size(254, 48);
            this.gbtnDebts.TabIndex = 6;
            this.gbtnDebts.Text = "الديون";
            this.gbtnDebts.Click += new System.EventHandler(this.gbtnDebts_Click);
            // 
            // gbtnTransactions
            // 
            this.gbtnTransactions.Animated = true;
            this.gbtnTransactions.BackColor = System.Drawing.Color.Transparent;
            this.gbtnTransactions.BorderRadius = 5;
            this.gbtnTransactions.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnTransactions.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnTransactions.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnTransactions.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnTransactions.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnTransactions.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnTransactions.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnTransactions.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnTransactions.FillColor = System.Drawing.Color.White;
            this.gbtnTransactions.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnTransactions.ForeColor = System.Drawing.Color.Black;
            this.gbtnTransactions.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnTransactions.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnTransactions.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnTransactions.Image = ((System.Drawing.Image)(resources.GetObject("gbtnTransactions.Image")));
            this.gbtnTransactions.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnTransactions.ImageSize = new System.Drawing.Size(40, 40);
            this.gbtnTransactions.IndicateFocus = true;
            this.gbtnTransactions.Location = new System.Drawing.Point(6, 511);
            this.gbtnTransactions.Name = "gbtnTransactions";
            this.gbtnTransactions.Size = new System.Drawing.Size(254, 48);
            this.gbtnTransactions.TabIndex = 7;
            this.gbtnTransactions.Text = "المعاملات";
            this.gbtnTransactions.Click += new System.EventHandler(this.gbtnTransactions_Click);
            // 
            // gbtnExpense
            // 
            this.gbtnExpense.Animated = true;
            this.gbtnExpense.BackColor = System.Drawing.Color.Transparent;
            this.gbtnExpense.BorderRadius = 5;
            this.gbtnExpense.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnExpense.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnExpense.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnExpense.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnExpense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnExpense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnExpense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnExpense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnExpense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnExpense.FillColor = System.Drawing.Color.White;
            this.gbtnExpense.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnExpense.ForeColor = System.Drawing.Color.Black;
            this.gbtnExpense.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnExpense.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnExpense.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnExpense.Image = ((System.Drawing.Image)(resources.GetObject("gbtnExpense.Image")));
            this.gbtnExpense.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnExpense.ImageSize = new System.Drawing.Size(40, 40);
            this.gbtnExpense.IndicateFocus = true;
            this.gbtnExpense.Location = new System.Drawing.Point(6, 346);
            this.gbtnExpense.Name = "gbtnExpense";
            this.gbtnExpense.Size = new System.Drawing.Size(254, 48);
            this.gbtnExpense.TabIndex = 4;
            this.gbtnExpense.Text = "المصروفات";
            this.gbtnExpense.Click += new System.EventHandler(this.gbtnExpense_Click);
            // 
            // gbtnExpensesReturn
            // 
            this.gbtnExpensesReturn.Animated = true;
            this.gbtnExpensesReturn.BackColor = System.Drawing.Color.Transparent;
            this.gbtnExpensesReturn.BorderRadius = 5;
            this.gbtnExpensesReturn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnExpensesReturn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnExpensesReturn.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnExpensesReturn.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnExpensesReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnExpensesReturn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnExpensesReturn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnExpensesReturn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnExpensesReturn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnExpensesReturn.FillColor = System.Drawing.Color.White;
            this.gbtnExpensesReturn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnExpensesReturn.ForeColor = System.Drawing.Color.Black;
            this.gbtnExpensesReturn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnExpensesReturn.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnExpensesReturn.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnExpensesReturn.Image = ((System.Drawing.Image)(resources.GetObject("gbtnExpensesReturn.Image")));
            this.gbtnExpensesReturn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnExpensesReturn.ImageSize = new System.Drawing.Size(40, 40);
            this.gbtnExpensesReturn.IndicateFocus = true;
            this.gbtnExpensesReturn.Location = new System.Drawing.Point(6, 401);
            this.gbtnExpensesReturn.Name = "gbtnExpensesReturn";
            this.gbtnExpensesReturn.Size = new System.Drawing.Size(254, 48);
            this.gbtnExpensesReturn.TabIndex = 5;
            this.gbtnExpensesReturn.Text = "مرتجعات المصروفات";
            this.gbtnExpensesReturn.Click += new System.EventHandler(this.gbtnExpensesReturn_Click);
            // 
            // gbtnIncome
            // 
            this.gbtnIncome.Animated = true;
            this.gbtnIncome.BackColor = System.Drawing.Color.Transparent;
            this.gbtnIncome.BorderRadius = 5;
            this.gbtnIncome.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnIncome.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnIncome.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnIncome.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnIncome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnIncome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnIncome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnIncome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnIncome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnIncome.FillColor = System.Drawing.Color.White;
            this.gbtnIncome.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnIncome.ForeColor = System.Drawing.Color.Black;
            this.gbtnIncome.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnIncome.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnIncome.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnIncome.Image = ((System.Drawing.Image)(resources.GetObject("gbtnIncome.Image")));
            this.gbtnIncome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnIncome.ImageSize = new System.Drawing.Size(40, 40);
            this.gbtnIncome.IndicateFocus = true;
            this.gbtnIncome.Location = new System.Drawing.Point(6, 291);
            this.gbtnIncome.Name = "gbtnIncome";
            this.gbtnIncome.Size = new System.Drawing.Size(254, 48);
            this.gbtnIncome.TabIndex = 3;
            this.gbtnIncome.Text = "الواردات";
            this.gbtnIncome.Click += new System.EventHandler(this.gbtnIncome_Click);
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.Animated = true;
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.BorderRadius = 8;
            this.guna2ControlBox2.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox2.CustomIconSize = 15F;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox2.HoverState.FillColor = System.Drawing.Color.Silver;
            this.guna2ControlBox2.HoverState.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox2.Location = new System.Drawing.Point(188, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(38, 29);
            this.guna2ControlBox2.TabIndex = 12;
            this.guna2ControlBox2.TabStop = false;
            this.guna2ControlBox2.UseTransparentBackground = true;
            // 
            // gcbClose
            // 
            this.gcbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gcbClose.Animated = true;
            this.gcbClose.BackColor = System.Drawing.Color.Transparent;
            this.gcbClose.BorderRadius = 8;
            this.gcbClose.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.gcbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcbClose.CustomIconSize = 12F;
            this.gcbClose.FillColor = System.Drawing.Color.Transparent;
            this.gcbClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcbClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.gcbClose.HoverState.IconColor = System.Drawing.Color.White;
            this.gcbClose.IconColor = System.Drawing.Color.DimGray;
            this.gcbClose.Location = new System.Drawing.Point(225, 0);
            this.gcbClose.Name = "gcbClose";
            this.gcbClose.Size = new System.Drawing.Size(38, 29);
            this.gcbClose.TabIndex = 11;
            this.gcbClose.TabStop = false;
            this.gcbClose.UseTransparentBackground = true;
            this.gcbClose.Click += new System.EventHandler(this.gcbClose_Click);
            // 
            // gbtnLogout
            // 
            this.gbtnLogout.Animated = true;
            this.gbtnLogout.BackColor = System.Drawing.Color.Transparent;
            this.gbtnLogout.BorderRadius = 5;
            this.gbtnLogout.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnLogout.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnLogout.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnLogout.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnLogout.FillColor = System.Drawing.Color.White;
            this.gbtnLogout.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnLogout.ForeColor = System.Drawing.Color.Black;
            this.gbtnLogout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnLogout.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnLogout.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnLogout.Image = ((System.Drawing.Image)(resources.GetObject("gbtnLogout.Image")));
            this.gbtnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnLogout.ImageSize = new System.Drawing.Size(40, 40);
            this.gbtnLogout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbtnLogout.IndicateFocus = true;
            this.gbtnLogout.Location = new System.Drawing.Point(6, 676);
            this.gbtnLogout.Name = "gbtnLogout";
            this.gbtnLogout.Size = new System.Drawing.Size(254, 48);
            this.gbtnLogout.TabIndex = 10;
            this.gbtnLogout.Text = "تسجيل الخروج";
            this.gbtnLogout.Click += new System.EventHandler(this.gbtnLogout_Click);
            // 
            // gbtnUsers
            // 
            this.gbtnUsers.Animated = true;
            this.gbtnUsers.BackColor = System.Drawing.Color.Transparent;
            this.gbtnUsers.BorderRadius = 5;
            this.gbtnUsers.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnUsers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnUsers.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnUsers.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnUsers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnUsers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnUsers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnUsers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnUsers.FillColor = System.Drawing.Color.White;
            this.gbtnUsers.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnUsers.ForeColor = System.Drawing.Color.Black;
            this.gbtnUsers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnUsers.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnUsers.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnUsers.Image = ((System.Drawing.Image)(resources.GetObject("gbtnUsers.Image")));
            this.gbtnUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnUsers.ImageSize = new System.Drawing.Size(40, 40);
            this.gbtnUsers.IndicateFocus = true;
            this.gbtnUsers.Location = new System.Drawing.Point(6, 236);
            this.gbtnUsers.Name = "gbtnUsers";
            this.gbtnUsers.Size = new System.Drawing.Size(254, 48);
            this.gbtnUsers.TabIndex = 2;
            this.gbtnUsers.Text = "المستخدمين";
            this.gbtnUsers.Click += new System.EventHandler(this.gbtnUsers_Click);
            // 
            // gpnlTopBar
            // 
            this.gpnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.gpnlTopBar.Name = "gpnlTopBar";
            this.gpnlTopBar.Size = new System.Drawing.Size(1210, 72);
            this.gpnlTopBar.TabIndex = 4;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.TargetControl = this.gpnlTopBar;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // guna2DragControl3
            // 
            this.guna2DragControl3.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl3.TargetControl = this.gpnlRightBar;
            this.guna2DragControl3.UseTransparentDrag = true;
            // 
            // gpnlFormContainer
            // 
            this.gpnlFormContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpnlFormContainer.Location = new System.Drawing.Point(0, 72);
            this.gpnlFormContainer.Name = "gpnlFormContainer";
            this.gpnlFormContainer.Size = new System.Drawing.Size(1210, 737);
            this.gpnlFormContainer.TabIndex = 5;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // gbtnAccount
            // 
            this.gbtnAccount.Animated = true;
            this.gbtnAccount.BackColor = System.Drawing.Color.Transparent;
            this.gbtnAccount.BorderRadius = 5;
            this.gbtnAccount.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnAccount.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnAccount.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnAccount.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnAccount.FillColor = System.Drawing.Color.White;
            this.gbtnAccount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnAccount.ForeColor = System.Drawing.Color.Black;
            this.gbtnAccount.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnAccount.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnAccount.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnAccount.Image = ((System.Drawing.Image)(resources.GetObject("gbtnAccount.Image")));
            this.gbtnAccount.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnAccount.ImageSize = new System.Drawing.Size(40, 40);
            this.gbtnAccount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbtnAccount.IndicateFocus = true;
            this.gbtnAccount.Location = new System.Drawing.Point(6, 566);
            this.gbtnAccount.Name = "gbtnAccount";
            this.gbtnAccount.Size = new System.Drawing.Size(254, 48);
            this.gbtnAccount.TabIndex = 8;
            this.gbtnAccount.Text = "الحساب";
            this.gbtnAccount.Click += new System.EventHandler(this.gbtnAccount_Click);
            // 
            // gbtnSettings
            // 
            this.gbtnSettings.Animated = true;
            this.gbtnSettings.BackColor = System.Drawing.Color.Transparent;
            this.gbtnSettings.BorderRadius = 5;
            this.gbtnSettings.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnSettings.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnSettings.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnSettings.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnSettings.FillColor = System.Drawing.Color.White;
            this.gbtnSettings.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnSettings.ForeColor = System.Drawing.Color.Black;
            this.gbtnSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnSettings.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnSettings.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("gbtnSettings.Image")));
            this.gbtnSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnSettings.ImageSize = new System.Drawing.Size(40, 40);
            this.gbtnSettings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbtnSettings.IndicateFocus = true;
            this.gbtnSettings.Location = new System.Drawing.Point(6, 621);
            this.gbtnSettings.Name = "gbtnSettings";
            this.gbtnSettings.Size = new System.Drawing.Size(254, 48);
            this.gbtnSettings.TabIndex = 9;
            this.gbtnSettings.Text = "الإعدادات";
            this.gbtnSettings.Click += new System.EventHandler(this.gbtnSettings_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1473, 809);
            this.Controls.Add(this.gpnlFormContainer);
            this.Controls.Add(this.gpnlTopBar);
            this.Controls.Add(this.gpnlRightBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1473, 809);
            this.MinimumSize = new System.Drawing.Size(263, 809);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Money Mind Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gpnlRightBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Button gbtnOverOview;
        private Guna.UI2.WinForms.Guna2Button gbtnPeople;
        private Guna.UI2.WinForms.Guna2Panel gpnlTopBar;
        private Guna.UI2.WinForms.Guna2Panel gpnlRightBar;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl3;
        private Guna.UI2.WinForms.Guna2Panel gpnlFormContainer;
        private Guna.UI2.WinForms.Guna2Button gbtnUsers;
        private Guna.UI2.WinForms.Guna2Button gbtnLogout;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox gcbClose;
        private Guna.UI2.WinForms.Guna2Button gbtnExpense;
        private Guna.UI2.WinForms.Guna2Button gbtnExpensesReturn;
        private Guna.UI2.WinForms.Guna2Button gbtnIncome;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button gbtnDebts;
        private Guna.UI2.WinForms.Guna2Button gbtnTransactions;
        private Guna.UI2.WinForms.Guna2Button gbtnSettings;
        private Guna.UI2.WinForms.Guna2Button gbtnAccount;
    }
}