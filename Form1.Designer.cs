namespace PortsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.portsCB = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblResultFilePath = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // portsCB
            // 
            this.portsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portsCB.Location = new System.Drawing.Point(170, 92);
            this.portsCB.Name = "portsCB";
            this.portsCB.Size = new System.Drawing.Size(100, 28);
            this.portsCB.TabIndex = 0;
            this.portsCB.SelectedIndexChanged += new System.EventHandler(this.PortsCBSelectedIndexChangedEventHandler);
            // 
            // btnStart
            // 
            this.btnStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnStart.Location = new System.Drawing.Point(170, 126);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.CheckedChanged += new System.EventHandler(this.BtnStartCheckedChangedEventHandler);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.lblResultFilePath);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.tbFilePath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.portsCB);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Location = new System.Drawing.Point(48, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 238);
            this.panel1.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(276, 91);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 29);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefreshClickEventHandler);
            // 
            // lblResultFilePath
            // 
            this.lblResultFilePath.AutoSize = true;
            this.lblResultFilePath.Location = new System.Drawing.Point(-1, 18);
            this.lblResultFilePath.Name = "lblResultFilePath";
            this.lblResultFilePath.Size = new System.Drawing.Size(100, 20);
            this.lblResultFilePath.TabIndex = 6;
            this.lblResultFilePath.Text = "ResultFilePath";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(311, 15);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(65, 27);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClickEventHandler);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(105, 15);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            this.tbFilePath.Size = new System.Drawing.Size(200, 27);
            this.tbFilePath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(511, 309);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Receiver wind sensor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox portsCB;
        private CheckBox btnStart;
        private Panel panel1;
        private Label label1;
        private Label lblResultFilePath;
        private Button btnBrowse;
        private TextBox tbFilePath;
        private Button btnRefresh;
    }
}