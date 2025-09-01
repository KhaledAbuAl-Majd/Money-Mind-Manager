namespace MoneyMindManager_Presentation
{
    partial class Form1
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
            this.khaledGuna2TextBox1 = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.SuspendLayout();
            // 
            // khaledGuna2TextBox1
            // 
            this.khaledGuna2TextBox1.AllowWhiteSpace = false;
            this.khaledGuna2TextBox1.ApplyTrimAtTextBoxValue = false;
            this.khaledGuna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.khaledGuna2TextBox1.DefaultText = "";
            this.khaledGuna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.khaledGuna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.khaledGuna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.khaledGuna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.khaledGuna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.khaledGuna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.khaledGuna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.khaledGuna2TextBox1.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.khaledGuna2TextBox1.IsRequired = false;
            this.khaledGuna2TextBox1.Location = new System.Drawing.Point(559, 99);
            this.khaledGuna2TextBox1.Name = "khaledGuna2TextBox1";
            this.khaledGuna2TextBox1.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.khaledGuna2TextBox1.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.khaledGuna2TextBox1.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.khaledGuna2TextBox1.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.khaledGuna2TextBox1.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.khaledGuna2TextBox1.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.khaledGuna2TextBox1.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.khaledGuna2TextBox1.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.khaledGuna2TextBox1.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.khaledGuna2TextBox1.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.khaledGuna2TextBox1.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.khaledGuna2TextBox1.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.khaledGuna2TextBox1.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.khaledGuna2TextBox1.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.khaledGuna2TextBox1.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.khaledGuna2TextBox1.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.khaledGuna2TextBox1.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.khaledGuna2TextBox1.PlaceholderText = "";
            this.khaledGuna2TextBox1.SelectedText = "";
            this.khaledGuna2TextBox1.Size = new System.Drawing.Size(200, 36);
            this.khaledGuna2TextBox1.TabIndex = 0;
            this.khaledGuna2TextBox1.TextProperties.MinLength = ((short)(0));
            this.khaledGuna2TextBox1.TextProperties.MinLengthOption = false;
            this.khaledGuna2TextBox1.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.khaledGuna2TextBox1.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.khaledGuna2TextBox1.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.khaledGuna2TextBox1.TrimEnd = false;
            this.khaledGuna2TextBox1.TrimStart = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.khaledGuna2TextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private KhaledControlLibrary1.KhaledGuna2TextBox khaledGuna2TextBox1;
    }
}

