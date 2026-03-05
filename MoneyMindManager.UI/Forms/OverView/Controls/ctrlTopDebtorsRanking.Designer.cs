namespace MoneyMindManager_Presentation.OverView.Controls
{
    partial class ctrlTopDebtorsRanking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlTopDebtorsRanking));
            this.CartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ctrlInfoIcon1 = new KhaledControlLibrary1.ctrlInfoIcon();
            this.gcbDebtType = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon1.PictureBoxControl)).BeginInit();
            this.SuspendLayout();
            // 
            // CartesianChart1
            // 
            this.CartesianChart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CartesianChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CartesianChart1.Location = new System.Drawing.Point(0, 17);
            this.CartesianChart1.Name = "CartesianChart1";
            this.CartesianChart1.Size = new System.Drawing.Size(388, 428);
            this.CartesianChart1.TabIndex = 0;
            this.CartesianChart1.Text = "cartesianChart1";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // ctrlInfoIcon1
            // 
            this.ctrlInfoIcon1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlInfoIcon1.IconImage = ((System.Drawing.Image)(resources.GetObject("ctrlInfoIcon1.IconImage")));
            this.ctrlInfoIcon1.Location = new System.Drawing.Point(226, 3);
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
            this.ctrlInfoIcon1.ToolTipText = "تقرير ترتيب أكبر 5 مدينين/دائنين.";
            // 
            // gcbDebtType
            // 
            this.gcbDebtType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gcbDebtType.AutoRoundedCorners = true;
            this.gcbDebtType.BackColor = System.Drawing.Color.Transparent;
            this.gcbDebtType.BorderColor = System.Drawing.Color.Silver;
            this.gcbDebtType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcbDebtType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.gcbDebtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gcbDebtType.DropDownWidth = 110;
            this.gcbDebtType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbDebtType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbDebtType.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.gcbDebtType.ForeColor = System.Drawing.Color.Black;
            this.gcbDebtType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gcbDebtType.ItemHeight = 30;
            this.gcbDebtType.Items.AddRange(new object[] {
            "الدائنون لي",
            "المدينون لي"});
            this.gcbDebtType.Location = new System.Drawing.Point(256, 0);
            this.gcbDebtType.Name = "gcbDebtType";
            this.gcbDebtType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcbDebtType.Size = new System.Drawing.Size(123, 36);
            this.gcbDebtType.StartIndex = 0;
            this.gcbDebtType.TabIndex = 102;
            this.gcbDebtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gcbDebtType.SelectedIndexChanged += new System.EventHandler(this.gcbDebtType_SelectedIndexChanged);
            // 
            // ctrlTopDebtorsRanking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gcbDebtType);
            this.Controls.Add(this.ctrlInfoIcon1);
            this.Controls.Add(this.CartesianChart1);
            this.Name = "ctrlTopDebtorsRanking";
            this.Size = new System.Drawing.Size(388, 445);
            this.Load += new System.EventHandler(this.ctrlMonthlyFlow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon1.PictureBoxControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart CartesianChart1;
        private System.Windows.Forms.ToolTip toolTip1;
        private KhaledControlLibrary1.ctrlInfoIcon ctrlInfoIcon1;
        private Guna.UI2.WinForms.Guna2ComboBox gcbDebtType;
    }
}
