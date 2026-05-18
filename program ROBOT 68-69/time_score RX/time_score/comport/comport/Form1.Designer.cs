namespace comport
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
            this.components = new System.ComponentModel.Container();
            this.comport = new System.Windows.Forms.ComboBox();
            this.baudpate = new System.Windows.Forms.ComboBox();
            this.stopbits = new System.Windows.Forms.ComboBox();
            this.databits = new System.Windows.Forms.ComboBox();
            this.paritybits = new System.Windows.Forms.ComboBox();
            this.open = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.senddata = new System.Windows.Forms.Button();
            this.dataout = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comport
            // 
            this.comport.FormattingEnabled = true;
            this.comport.Location = new System.Drawing.Point(74, 37);
            this.comport.Name = "comport";
            this.comport.Size = new System.Drawing.Size(121, 24);
            this.comport.TabIndex = 0;
            // 
            // baudpate
            // 
            this.baudpate.FormattingEnabled = true;
            this.baudpate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600"});
            this.baudpate.Location = new System.Drawing.Point(74, 67);
            this.baudpate.Name = "baudpate";
            this.baudpate.Size = new System.Drawing.Size(121, 24);
            this.baudpate.TabIndex = 1;
            this.baudpate.Text = "9600";
            // 
            // stopbits
            // 
            this.stopbits.FormattingEnabled = true;
            this.stopbits.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.stopbits.Location = new System.Drawing.Point(74, 127);
            this.stopbits.Name = "stopbits";
            this.stopbits.Size = new System.Drawing.Size(121, 24);
            this.stopbits.TabIndex = 3;
            this.stopbits.Text = "One";
            // 
            // databits
            // 
            this.databits.FormattingEnabled = true;
            this.databits.Location = new System.Drawing.Point(74, 97);
            this.databits.Name = "databits";
            this.databits.Size = new System.Drawing.Size(121, 24);
            this.databits.TabIndex = 2;
            this.databits.Text = "8";
            // 
            // paritybits
            // 
            this.paritybits.FormattingEnabled = true;
            this.paritybits.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.paritybits.Location = new System.Drawing.Point(74, 157);
            this.paritybits.Name = "paritybits";
            this.paritybits.Size = new System.Drawing.Size(121, 24);
            this.paritybits.TabIndex = 4;
            this.paritybits.Text = "None";
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(74, 187);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(121, 23);
            this.open.TabIndex = 5;
            this.open.Text = "open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(201, 187);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(121, 23);
            this.close.TabIndex = 6;
            this.close.Text = "close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(74, 216);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(248, 23);
            this.progressBar2.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.senddata);
            this.groupBox1.Controls.Add(this.comport);
            this.groupBox1.Controls.Add(this.baudpate);
            this.groupBox1.Controls.Add(this.databits);
            this.groupBox1.Controls.Add(this.stopbits);
            this.groupBox1.Controls.Add(this.paritybits);
            this.groupBox1.Controls.Add(this.dataout);
            this.groupBox1.Controls.Add(this.progressBar2);
            this.groupBox1.Controls.Add(this.close);
            this.groupBox1.Controls.Add(this.open);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 265);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // senddata
            // 
            this.senddata.Location = new System.Drawing.Point(328, 186);
            this.senddata.Name = "senddata";
            this.senddata.Size = new System.Drawing.Size(87, 53);
            this.senddata.TabIndex = 10;
            this.senddata.Text = "senddata";
            this.senddata.UseVisualStyleBackColor = true;
            this.senddata.Click += new System.EventHandler(this.senddata_Click);
            // 
            // dataout
            // 
            this.dataout.Location = new System.Drawing.Point(210, 37);
            this.dataout.Multiline = true;
            this.dataout.Name = "dataout";
            this.dataout.Size = new System.Drawing.Size(205, 144);
            this.dataout.TabIndex = 9;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(651, 416);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comport;
        private System.Windows.Forms.ComboBox baudpate;
        private System.Windows.Forms.ComboBox stopbits;
        private System.Windows.Forms.ComboBox databits;
        private System.Windows.Forms.ComboBox paritybits;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dataout;
        private System.Windows.Forms.Button senddata;
    }
}

