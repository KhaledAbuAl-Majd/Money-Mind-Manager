namespace MoneyMindManager_Presentation.Income_And_Expense
{
    partial class frmIncomeAndExpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIncomeAndExpense));
            this.gpnlFormContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.gbtnCategories = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnVouchers = new Guna.UI2.WinForms.Guna2Button();
            this.ciiExepnsesReturn = new KhaledControlLibrary1.ctrlInfoIcon();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ciiExepnsesReturn.PictureBoxControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gpnlFormContainer
            // 
            this.gpnlFormContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gpnlFormContainer.Location = new System.Drawing.Point(0, 74);
            this.gpnlFormContainer.Name = "gpnlFormContainer";
            this.gpnlFormContainer.Size = new System.Drawing.Size(1210, 735);
            this.gpnlFormContainer.TabIndex = 6;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1210, 60);
            this.lblHeader.TabIndex = 19;
            this.lblHeader.Text = "الأشخاص";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.gbtnCategories);
            this.guna2Panel1.Controls.Add(this.gbtnVouchers);
            this.guna2Panel1.Location = new System.Drawing.Point(942, 11);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(258, 59);
            this.guna2Panel1.TabIndex = 20;
            // 
            // gbtnCategories
            // 
            this.gbtnCategories.Animated = true;
            this.gbtnCategories.BackColor = System.Drawing.Color.Transparent;
            this.gbtnCategories.BorderRadius = 5;
            this.gbtnCategories.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnCategories.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnCategories.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnCategories.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnCategories.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnCategories.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnCategories.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnCategories.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnCategories.FillColor = System.Drawing.Color.White;
            this.gbtnCategories.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gbtnCategories.ForeColor = System.Drawing.Color.Black;
            this.gbtnCategories.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnCategories.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnCategories.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnCategories.Image = ((System.Drawing.Image)(resources.GetObject("gbtnCategories.Image")));
            this.gbtnCategories.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnCategories.ImageOffset = new System.Drawing.Point(5, 0);
            this.gbtnCategories.ImageSize = new System.Drawing.Size(25, 25);
            this.gbtnCategories.IndicateFocus = true;
            this.gbtnCategories.Location = new System.Drawing.Point(7, 6);
            this.gbtnCategories.Name = "gbtnCategories";
            this.gbtnCategories.Size = new System.Drawing.Size(122, 48);
            this.gbtnCategories.TabIndex = 2;
            this.gbtnCategories.Text = "الفئات  ";
            this.gbtnCategories.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gbtnCategories.Click += new System.EventHandler(this.gbtnCategories_Click);
            // 
            // gbtnVouchers
            // 
            this.gbtnVouchers.Animated = true;
            this.gbtnVouchers.BackColor = System.Drawing.Color.Transparent;
            this.gbtnVouchers.BorderRadius = 5;
            this.gbtnVouchers.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.gbtnVouchers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnVouchers.CheckedState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnVouchers.CheckedState.ForeColor = System.Drawing.Color.White;
            this.gbtnVouchers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gbtnVouchers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gbtnVouchers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gbtnVouchers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gbtnVouchers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gbtnVouchers.FillColor = System.Drawing.Color.White;
            this.gbtnVouchers.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gbtnVouchers.ForeColor = System.Drawing.Color.Black;
            this.gbtnVouchers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(194)))));
            this.gbtnVouchers.HoverState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtnVouchers.HoverState.ForeColor = System.Drawing.Color.White;
            this.gbtnVouchers.Image = ((System.Drawing.Image)(resources.GetObject("gbtnVouchers.Image")));
            this.gbtnVouchers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.gbtnVouchers.ImageSize = new System.Drawing.Size(25, 25);
            this.gbtnVouchers.IndicateFocus = true;
            this.gbtnVouchers.Location = new System.Drawing.Point(130, 6);
            this.gbtnVouchers.Name = "gbtnVouchers";
            this.gbtnVouchers.Size = new System.Drawing.Size(122, 48);
            this.gbtnVouchers.TabIndex = 1;
            this.gbtnVouchers.Text = "المستندات";
            this.gbtnVouchers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gbtnVouchers.Click += new System.EventHandler(this.gbtnVouchers_Click);
            // 
            // ciiExepnsesReturn
            // 
            this.ciiExepnsesReturn.BackColor = System.Drawing.Color.Transparent;
            this.ciiExepnsesReturn.IconImage = ((System.Drawing.Image)(resources.GetObject("ciiExepnsesReturn.IconImage")));
            this.ciiExepnsesReturn.Location = new System.Drawing.Point(914, 32);
            this.ciiExepnsesReturn.Name = "ciiExepnsesReturn";
            // 
            // 
            // 
            this.ciiExepnsesReturn.PictureBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ciiExepnsesReturn.PictureBoxControl.Image = ((System.Drawing.Image)(resources.GetObject("ciiExepnsesReturn.PictureBoxControl.Image")));
            this.ciiExepnsesReturn.PictureBoxControl.ImageRotate = 0F;
            this.ciiExepnsesReturn.PictureBoxControl.Location = new System.Drawing.Point(0, 0);
            this.ciiExepnsesReturn.PictureBoxControl.Name = "gpbInfoIcon";
            this.ciiExepnsesReturn.PictureBoxControl.Size = new System.Drawing.Size(20, 20);
            this.ciiExepnsesReturn.PictureBoxControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ciiExepnsesReturn.PictureBoxControl.TabIndex = 0;
            this.ciiExepnsesReturn.PictureBoxControl.TabStop = false;
            this.ciiExepnsesReturn.PictureBoxControl.UseTransparentBackground = true;
            this.ciiExepnsesReturn.Size = new System.Drawing.Size(20, 20);
            this.ciiExepnsesReturn.TabIndex = 21;
            // 
            // 
            // 
            this.ciiExepnsesReturn.ToolTipControl.IsBalloon = true;
            this.ciiExepnsesReturn.ToolTipText = "مرتجعات المصروفات تشترك في فئات المصروفات";
            // 
            // frmIncomeAndExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1210, 809);
            this.Controls.Add(this.ciiExepnsesReturn);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.gpnlFormContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmIncomeAndExpense";
            this.Text = "frmIncomeAndExpense";
            this.Load += new System.EventHandler(this.frmIncomeAndExpense_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ciiExepnsesReturn.PictureBoxControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel gpnlFormContainer;
        private System.Windows.Forms.Label lblHeader;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button gbtnVouchers;
        private Guna.UI2.WinForms.Guna2Button gbtnCategories;
        private KhaledControlLibrary1.ctrlInfoIcon ciiExepnsesReturn;
    }
}