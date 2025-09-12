namespace MoneyMindManager_Presentation.People
{
    partial class frmPersonInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonInfo));
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.gbtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.ctrlPersonCard1 = new MoneyMindManager_Presentation.People.Controls.ctrlPersonCard();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.gbtnClose);
            this.guna2Panel2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel2.Location = new System.Drawing.Point(265, 113);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.guna2Panel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.guna2Panel2.Size = new System.Drawing.Size(672, 527);
            this.guna2Panel2.TabIndex = 12;
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
            this.gbtnClose.ImageSize = new System.Drawing.Size(25, 25);
            this.gbtnClose.IndicateFocus = true;
            this.gbtnClose.Location = new System.Drawing.Point(502, 469);
            this.gbtnClose.Name = "gbtnClose";
            this.gbtnClose.PressedColor = System.Drawing.Color.White;
            this.gbtnClose.Size = new System.Drawing.Size(128, 45);
            this.gbtnClose.TabIndex = 7;
            this.gbtnClose.Text = "غلق";
            this.gbtnClose.Click += new System.EventHandler(this.gbtnClose_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(12, 21);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1186, 62);
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "معلومات الشخص";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(300, 140);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(602, 432);
            this.ctrlPersonCard1.TabIndex = 0;
            this.ctrlPersonCard1.OnEditingPerson += new System.Action(this.ctrlPersonCard1_OnEditingPerson);
            // 
            // frmPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1210, 737);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPersonInfo";
            this.Text = "frmPersonInfo";
            this.Load += new System.EventHandler(this.frmPersonInfo_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button gbtnClose;
        private System.Windows.Forms.Label lblHeader;
        private Controls.ctrlPersonCard ctrlPersonCard1;
    }
}