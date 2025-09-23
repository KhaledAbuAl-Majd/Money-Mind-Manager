namespace MoneyMindManager_Presentation.Income_And_Expense.Categories
{
    partial class frmCategoryInfo
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
            this.ctrlCategoryInfo1 = new MoneyMindManager_Presentation.Income_And_Expense.Categories.ctrlCategoryInfo();
            this.SuspendLayout();
            // 
            // ctrlCategoryInfo1
            // 
            this.ctrlCategoryInfo1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrlCategoryInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlCategoryInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlCategoryInfo1.Location = new System.Drawing.Point(100, 77);
            this.ctrlCategoryInfo1.Name = "ctrlCategoryInfo1";
            this.ctrlCategoryInfo1.Size = new System.Drawing.Size(583, 579);
            this.ctrlCategoryInfo1.TabIndex = 0;
            // 
            // frmCategoryInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 718);
            this.Controls.Add(this.ctrlCategoryInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCategoryInfo";
            this.Text = "frmCategoryInfo";
            this.Load += new System.EventHandler(this.frmCategoryInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlCategoryInfo ctrlCategoryInfo1;
    }
}