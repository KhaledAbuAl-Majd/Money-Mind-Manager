namespace MoneyMindManager_Presentation.OverView.Controls
{
    partial class ctlDebtsRepaymentSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlDebtsRepaymentSchedule));
            this.CartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grbLinerShape = new Guna.UI2.WinForms.Guna2RadioButton();
            this.grbColumnsShape = new Guna.UI2.WinForms.Guna2RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlInfoIcon1 = new KhaledControlLibrary1.ctrlInfoIcon();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon1.PictureBoxControl)).BeginInit();
            this.SuspendLayout();
            // 
            // CartesianChart1
            // 
            this.CartesianChart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CartesianChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CartesianChart1.Location = new System.Drawing.Point(0, 17);
            this.CartesianChart1.Name = "CartesianChart1";
            this.CartesianChart1.Size = new System.Drawing.Size(757, 400);
            this.CartesianChart1.TabIndex = 0;
            this.CartesianChart1.Text = "cartesianChart1";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
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
            this.grbLinerShape.Location = new System.Drawing.Point(646, 17);
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
            this.grbColumnsShape.Location = new System.Drawing.Point(697, -1);
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
            // 
            // ctrlInfoIcon1
            // 
            this.ctrlInfoIcon1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlInfoIcon1.IconImage = ((System.Drawing.Image)(resources.GetObject("ctrlInfoIcon1.IconImage")));
            this.ctrlInfoIcon1.Location = new System.Drawing.Point(604, 3);
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
            this.ctrlInfoIcon1.ToolTipText = "هذا المخطط يوضح التزاماتك وتوقعاتك المالية (لك/عليك) مقسمة لـ 7 فترات: (متأخر قبل" +
    " اليوم) + (من اليوم وحتى نهاية الشهر) + (5 أشهر كاملة لاحقة).";
            // 
            // ctlDebtsRepaymentSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlInfoIcon1);
            this.Controls.Add(this.grbLinerShape);
            this.Controls.Add(this.grbColumnsShape);
            this.Controls.Add(this.CartesianChart1);
            this.Name = "ctlDebtsRepaymentSchedule";
            this.Size = new System.Drawing.Size(757, 417);
            this.Load += new System.EventHandler(this.ctrlMonthlyFlow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlInfoIcon1.PictureBoxControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart CartesianChart1;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2RadioButton grbLinerShape;
        private Guna.UI2.WinForms.Guna2RadioButton grbColumnsShape;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private KhaledControlLibrary1.ctrlInfoIcon ctrlInfoIcon1;
    }
}
