namespace MoneyMindManager_Presentation.OverView
{
    partial class frmOverview
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
            this.ctrlTest1 = new MoneyMindManager_Presentation.OverView.Controls.ctrlMonthlyFlow();
            this.SuspendLayout();
            // 
            // ctrlTest1
            // 
            this.ctrlTest1.BackColor = System.Drawing.Color.White;
            this.ctrlTest1.Location = new System.Drawing.Point(5, 12);
            this.ctrlTest1.Name = "ctrlTest1";
            this.ctrlTest1.Size = new System.Drawing.Size(1193, 398);
            this.ctrlTest1.TabIndex = 0;
            // 
            // frmOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1210, 737);
            this.Controls.Add(this.ctrlTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOverview";
            this.Text = "frmOverview";
            this.Load += new System.EventHandler(this.frmOverview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlMonthlyFlow ctrlTest1;
    }
}