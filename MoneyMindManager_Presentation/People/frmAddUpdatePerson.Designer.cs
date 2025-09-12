using System.ComponentModel;

namespace MoneyMindManager_Presentation.People
{
    partial class frmAddUpdatePerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdatePerson));
            this.kgtxtNotes = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtPhone = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtEmail = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtAddress = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.kgtxtPersonName = new KhaledControlLibrary1.KhaledGuna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblHeader = new System.Windows.Forms.Label();
            this.gbtnSave = new Guna.UI2.WinForms.Guna2Button();
            this.gbtnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.kgtxtNotes.Location = new System.Drawing.Point(342, 160);
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
            this.kgtxtNotes.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxtPersonName_OnValidationError);
            this.kgtxtNotes.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtPersonName_OnValidationSuccess);
            this.kgtxtNotes.TextChanged += new System.EventHandler(this.kgtxtNotes_TextChanged);
            // 
            // kgtxtPhone
            // 
            this.kgtxtPhone.AllowWhiteSpace = false;
            this.kgtxtPhone.ApplyTrimAtTextBoxValue = false;
            this.kgtxtPhone.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtPhone.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtPhone.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtPhone.BorderRadius = 10;
            this.kgtxtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtPhone.DefaultText = "";
            this.kgtxtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtPhone.ForeColor = System.Drawing.Color.Black;
            this.kgtxtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPhone.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtPhone.IsRequired = false;
            this.kgtxtPhone.Location = new System.Drawing.Point(342, 89);
            this.kgtxtPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtPhone.MaxLength = 20;
            this.kgtxtPhone.Name = "kgtxtPhone";
            this.kgtxtPhone.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtPhone.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPhone.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtPhone.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPhone.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtPhone.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtPhone.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtPhone.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtPhone.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtPhone.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtPhone.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtPhone.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtPhone.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtPhone.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtPhone.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtPhone.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtPhone.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtPhone.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtPhone.PlaceholderText = "رقم الهاتف (اختياري)";
            this.kgtxtPhone.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtPhone.SelectedText = "";
            this.kgtxtPhone.ShadowDecoration.BorderRadius = 2;
            this.kgtxtPhone.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtPhone.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtPhone.Size = new System.Drawing.Size(283, 41);
            this.kgtxtPhone.TabIndex = 1;
            this.kgtxtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtPhone.TextProperties.MinLength = ((short)(0));
            this.kgtxtPhone.TextProperties.MinLengthOption = false;
            this.kgtxtPhone.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtPhone.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtPhone.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Phone;
            this.kgtxtPhone.TrimEnd = false;
            this.kgtxtPhone.TrimStart = false;
            this.kgtxtPhone.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxtPersonName_OnValidationError);
            this.kgtxtPhone.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtPersonName_OnValidationSuccess);
            this.kgtxtPhone.TextChanged += new System.EventHandler(this.kgtxtPhone_TextChanged);
            // 
            // kgtxtEmail
            // 
            this.kgtxtEmail.AllowWhiteSpace = false;
            this.kgtxtEmail.ApplyTrimAtTextBoxValue = false;
            this.kgtxtEmail.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtEmail.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtEmail.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtEmail.BorderRadius = 10;
            this.kgtxtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtEmail.DefaultText = "";
            this.kgtxtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtEmail.ForeColor = System.Drawing.Color.Black;
            this.kgtxtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtEmail.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Text;
            this.kgtxtEmail.IsRequired = false;
            this.kgtxtEmail.Location = new System.Drawing.Point(29, 89);
            this.kgtxtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtEmail.MaxLength = 255;
            this.kgtxtEmail.Name = "kgtxtEmail";
            this.kgtxtEmail.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtEmail.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtEmail.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtEmail.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtEmail.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtEmail.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtEmail.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtEmail.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtEmail.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtEmail.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtEmail.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtEmail.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtEmail.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtEmail.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtEmail.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtEmail.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtEmail.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtEmail.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtEmail.PlaceholderText = "البريد الإلكتروني (اختياري)";
            this.kgtxtEmail.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtEmail.SelectedText = "";
            this.kgtxtEmail.ShadowDecoration.BorderRadius = 2;
            this.kgtxtEmail.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtEmail.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtEmail.Size = new System.Drawing.Size(283, 41);
            this.kgtxtEmail.TabIndex = 2;
            this.kgtxtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtEmail.TextProperties.MinLength = ((short)(0));
            this.kgtxtEmail.TextProperties.MinLengthOption = false;
            this.kgtxtEmail.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtEmail.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtEmail.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.Email;
            this.kgtxtEmail.TrimEnd = false;
            this.kgtxtEmail.TrimStart = false;
            this.kgtxtEmail.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxtPersonName_OnValidationError);
            this.kgtxtEmail.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtPersonName_OnValidationSuccess);
            // 
            // kgtxtAddress
            // 
            this.kgtxtAddress.AllowWhiteSpace = true;
            this.kgtxtAddress.ApplyTrimAtTextBoxValue = false;
            this.kgtxtAddress.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtAddress.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtAddress.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtAddress.BorderRadius = 10;
            this.kgtxtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtAddress.DefaultText = "";
            this.kgtxtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtAddress.ForeColor = System.Drawing.Color.Black;
            this.kgtxtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtAddress.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtAddress.IsRequired = false;
            this.kgtxtAddress.Location = new System.Drawing.Point(29, 160);
            this.kgtxtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtAddress.MaxLength = 300;
            this.kgtxtAddress.Multiline = true;
            this.kgtxtAddress.Name = "kgtxtAddress";
            this.kgtxtAddress.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtAddress.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtAddress.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtAddress.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtAddress.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtAddress.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtAddress.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtAddress.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtAddress.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtAddress.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtAddress.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtAddress.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtAddress.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtAddress.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtAddress.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtAddress.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtAddress.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtAddress.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtAddress.PlaceholderText = "العنوان (اختياري)";
            this.kgtxtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.kgtxtAddress.SelectedText = "";
            this.kgtxtAddress.ShadowDecoration.BorderRadius = 2;
            this.kgtxtAddress.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtAddress.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtAddress.Size = new System.Drawing.Size(283, 107);
            this.kgtxtAddress.TabIndex = 4;
            this.kgtxtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtAddress.TextProperties.MinLength = ((short)(0));
            this.kgtxtAddress.TextProperties.MinLengthOption = false;
            this.kgtxtAddress.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtAddress.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtAddress.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtAddress.TrimEnd = false;
            this.kgtxtAddress.TrimStart = false;
            this.kgtxtAddress.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxtPersonName_OnValidationError);
            this.kgtxtAddress.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtPersonName_OnValidationSuccess);
            // 
            // kgtxtPersonName
            // 
            this.kgtxtPersonName.AllowWhiteSpace = true;
            this.kgtxtPersonName.ApplyTrimAtTextBoxValue = false;
            this.kgtxtPersonName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.kgtxtPersonName.BackColor = System.Drawing.Color.Transparent;
            this.kgtxtPersonName.BorderColor = System.Drawing.Color.DimGray;
            this.kgtxtPersonName.BorderRadius = 10;
            this.kgtxtPersonName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.kgtxtPersonName.DefaultText = "";
            this.kgtxtPersonName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.kgtxtPersonName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.kgtxtPersonName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPersonName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.kgtxtPersonName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPersonName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgtxtPersonName.ForeColor = System.Drawing.Color.Black;
            this.kgtxtPersonName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.kgtxtPersonName.InputType = KhaledControlLibrary1.KhaledGuna2TextBox.enInputType.Normal;
            this.kgtxtPersonName.IsRequired = true;
            this.kgtxtPersonName.Location = new System.Drawing.Point(342, 24);
            this.kgtxtPersonName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kgtxtPersonName.MaxLength = 150;
            this.kgtxtPersonName.Name = "kgtxtPersonName";
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.AllowNegative = true;
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.MaxValueOption = false;
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kgtxtPersonName.NumberProperties.DecimalNumberProperties.MinValueOption = false;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.AllowNegative = true;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.MaxValue = 0F;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.MaxValueOption = false;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.MinValue = 0F;
            this.kgtxtPersonName.NumberProperties.FloatNumberProperties.MinValueOption = false;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.AllowNegative = true;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.MaxValue = 0;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.MaxValueOption = false;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.MinValue = 0;
            this.kgtxtPersonName.NumberProperties.IntegerNumberProperties.MinValueOption = false;
            this.kgtxtPersonName.NumberProperties.NumberFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberFormat.None;
            this.kgtxtPersonName.NumberProperties.NumberInputTypes = KhaledControlLibrary1.KhaledGuna2TextBox.clsNumberProperties.enNumberInputTypes.IntegerNumber;
            this.kgtxtPersonName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.kgtxtPersonName.PlaceholderText = "الاسم (مطلوب)";
            this.kgtxtPersonName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.kgtxtPersonName.SelectedText = "";
            this.kgtxtPersonName.ShadowDecoration.BorderRadius = 2;
            this.kgtxtPersonName.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.kgtxtPersonName.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.kgtxtPersonName.Size = new System.Drawing.Size(283, 41);
            this.kgtxtPersonName.TabIndex = 0;
            this.kgtxtPersonName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kgtxtPersonName.TextProperties.MinLength = ((short)(0));
            this.kgtxtPersonName.TextProperties.MinLengthOption = false;
            this.kgtxtPersonName.TextProperties.PhoneProperties.AllowPlusSign = true;
            this.kgtxtPersonName.TextProperties.PhoneProperties.MaxPhoneLength = ((byte)(15));
            this.kgtxtPersonName.TextProperties.TextFormat = KhaledControlLibrary1.KhaledGuna2TextBox.clsText.enTextFormat.None;
            this.kgtxtPersonName.TrimEnd = true;
            this.kgtxtPersonName.TrimStart = false;
            this.kgtxtPersonName.OnValidationError += new System.EventHandler<KhaledControlLibrary1.KhaledGuna2TextBox.ValidatingErrorEventArgs>(this.kgtxtPersonName_OnValidationError);
            this.kgtxtPersonName.OnValidationSuccess += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.kgtxtPersonName_OnValidationSuccess);
            this.kgtxtPersonName.TextChanged += new System.EventHandler(this.kgtxtPersonName_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(12, 30);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1186, 62);
            this.lblHeader.TabIndex = 10;
            this.lblHeader.Text = "إضافة شخص";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.gbtnSave.ImageSize = new System.Drawing.Size(25, 25);
            this.gbtnSave.IndicateFocus = true;
            this.gbtnSave.Location = new System.Drawing.Point(497, 279);
            this.gbtnSave.Name = "gbtnSave";
            this.gbtnSave.PressedColor = System.Drawing.Color.White;
            this.gbtnSave.Size = new System.Drawing.Size(128, 45);
            this.gbtnSave.TabIndex = 5;
            this.gbtnSave.Text = "حفظ";
            this.gbtnSave.Click += new System.EventHandler(this.gbtnSave_Click);
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
            this.gbtnClose.Location = new System.Drawing.Point(361, 279);
            this.gbtnClose.Name = "gbtnClose";
            this.gbtnClose.PressedColor = System.Drawing.Color.White;
            this.gbtnClose.Size = new System.Drawing.Size(128, 45);
            this.gbtnClose.TabIndex = 6;
            this.gbtnClose.Text = "غلق";
            this.gbtnClose.Click += new System.EventHandler(this.gbtnClose_Click);
            // 
            // lblPersonID
            // 
            this.lblPersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID.Location = new System.Drawing.Point(9, 10);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPersonID.Size = new System.Drawing.Size(100, 23);
            this.lblPersonID.TabIndex = 96;
            this.lblPersonID.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 8);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 97;
            this.label2.Text = "معرف الشخص :";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Gray;
            this.guna2Panel1.BorderRadius = 8;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.lblPersonID);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.CustomizableEdges.BottomRight = false;
            this.guna2Panel1.CustomizableEdges.TopRight = false;
            this.guna2Panel1.Location = new System.Drawing.Point(75, 24);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(237, 41);
            this.guna2Panel1.TabIndex = 98;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.guna2Panel1);
            this.guna2Panel2.Controls.Add(this.gbtnClose);
            this.guna2Panel2.Controls.Add(this.gbtnSave);
            this.guna2Panel2.Controls.Add(this.kgtxtNotes);
            this.guna2Panel2.Controls.Add(this.kgtxtPhone);
            this.guna2Panel2.Controls.Add(this.kgtxtEmail);
            this.guna2Panel2.Controls.Add(this.kgtxtAddress);
            this.guna2Panel2.Controls.Add(this.kgtxtPersonName);
            this.guna2Panel2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel2.Location = new System.Drawing.Point(281, 106);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.guna2Panel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.guna2Panel2.Size = new System.Drawing.Size(654, 358);
            this.guna2Panel2.TabIndex = 0;
            // 
            // frmAddUpdatePerson
            // 
            this.AcceptButton = this.gbtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.gbtnClose;
            this.ClientSize = new System.Drawing.Size(1210, 737);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdatePerson";
            this.Text = "إضافة شخص";
            this.Load += new System.EventHandler(this.frmAddUpdatePerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtNotes;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPhone;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtEmail;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtAddress;
        private KhaledControlLibrary1.KhaledGuna2TextBox kgtxtPersonName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblHeader;
        private Guna.UI2.WinForms.Guna2Button gbtnClose;
        private Guna.UI2.WinForms.Guna2Button gbtnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPersonID;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
    }
}