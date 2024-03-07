namespace Knv.BHS
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonRoute = new System.Windows.Forms.Button();
            this.buttonMute = new System.Windows.Forms.Button();
            this.buttonOnOff = new System.Windows.Forms.Button();
            this.textBoxIrCode = new System.Windows.Forms.TextBox();
            this.buttonCurrentDateTime = new System.Windows.Forms.Button();
            this.buttonColckUpdate = new System.Windows.Forms.Button();
            this.timerSampling = new System.Windows.Forms.Timer(this.components);
            this.buttonIrSendCode = new System.Windows.Forms.Button();
            this.knvTracingControl1 = new Knv.BHS.Controls.KnvTracingControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(750, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 505);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(750, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonCurrentDateTime);
            this.splitContainer1.Panel1.Controls.Add(this.buttonColckUpdate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.knvTracingControl1);
            this.splitContainer1.Size = new System.Drawing.Size(750, 481);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 2;
            // 
            // buttonRoute
            // 
            this.buttonRoute.Location = new System.Drawing.Point(124, 51);
            this.buttonRoute.Name = "buttonRoute";
            this.buttonRoute.Size = new System.Drawing.Size(75, 35);
            this.buttonRoute.TabIndex = 5;
            this.buttonRoute.Text = "ROUTE";
            this.buttonRoute.UseVisualStyleBackColor = true;
            this.buttonRoute.Click += new System.EventHandler(this.buttonRoute_Click);
            // 
            // buttonMute
            // 
            this.buttonMute.Location = new System.Drawing.Point(205, 51);
            this.buttonMute.Name = "buttonMute";
            this.buttonMute.Size = new System.Drawing.Size(75, 35);
            this.buttonMute.TabIndex = 4;
            this.buttonMute.Text = "MUTE";
            this.buttonMute.UseVisualStyleBackColor = true;
            this.buttonMute.Click += new System.EventHandler(this.buttonMute_Click);
            // 
            // buttonOnOff
            // 
            this.buttonOnOff.Location = new System.Drawing.Point(43, 51);
            this.buttonOnOff.Name = "buttonOnOff";
            this.buttonOnOff.Size = new System.Drawing.Size(75, 35);
            this.buttonOnOff.TabIndex = 3;
            this.buttonOnOff.Text = "ON/OFF";
            this.buttonOnOff.UseVisualStyleBackColor = true;
            this.buttonOnOff.Click += new System.EventHandler(this.buttonOnOff_Click);
            // 
            // textBoxIrCode
            // 
            this.textBoxIrCode.Location = new System.Drawing.Point(86, 22);
            this.textBoxIrCode.Name = "textBoxIrCode";
            this.textBoxIrCode.Size = new System.Drawing.Size(61, 20);
            this.textBoxIrCode.TabIndex = 2;
            this.textBoxIrCode.Text = "3";
            this.textBoxIrCode.TextChanged += new System.EventHandler(this.textBoxIrCode_TextChanged);
            // 
            // buttonCurrentDateTime
            // 
            this.buttonCurrentDateTime.Location = new System.Drawing.Point(29, 45);
            this.buttonCurrentDateTime.Name = "buttonCurrentDateTime";
            this.buttonCurrentDateTime.Size = new System.Drawing.Size(120, 23);
            this.buttonCurrentDateTime.TabIndex = 1;
            this.buttonCurrentDateTime.Text = "Current Date Time";
            this.buttonCurrentDateTime.UseVisualStyleBackColor = true;
            this.buttonCurrentDateTime.Click += new System.EventHandler(this.buttonCurrentDateTime_Click);
            // 
            // buttonColckUpdate
            // 
            this.buttonColckUpdate.Location = new System.Drawing.Point(29, 16);
            this.buttonColckUpdate.Name = "buttonColckUpdate";
            this.buttonColckUpdate.Size = new System.Drawing.Size(120, 23);
            this.buttonColckUpdate.TabIndex = 0;
            this.buttonColckUpdate.Text = "Clock Update";
            this.buttonColckUpdate.UseVisualStyleBackColor = true;
            this.buttonColckUpdate.Click += new System.EventHandler(this.buttonColckUpdate_Click);
            // 
            // timerSampling
            // 
            this.timerSampling.Interval = 1000;
            this.timerSampling.Tick += new System.EventHandler(this.timerSampling_Tick);
            // 
            // buttonIrSendCode
            // 
            this.buttonIrSendCode.Location = new System.Drawing.Point(153, 22);
            this.buttonIrSendCode.Name = "buttonIrSendCode";
            this.buttonIrSendCode.Size = new System.Drawing.Size(127, 23);
            this.buttonIrSendCode.TabIndex = 2;
            this.buttonIrSendCode.Text = "Ir Send Code";
            this.buttonIrSendCode.UseVisualStyleBackColor = true;
            this.buttonIrSendCode.Click += new System.EventHandler(this.buttonIrSendCode_Click);
            // 
            // knvTracingControl1
            // 
            this.knvTracingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knvTracingControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knvTracingControl1.Location = new System.Drawing.Point(0, 0);
            this.knvTracingControl1.Name = "knvTracingControl1";
            this.knvTracingControl1.Size = new System.Drawing.Size(750, 242);
            this.knvTracingControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonIrSendCode);
            this.groupBox1.Controls.Add(this.buttonRoute);
            this.groupBox1.Controls.Add(this.buttonMute);
            this.groupBox1.Controls.Add(this.buttonOnOff);
            this.groupBox1.Controls.Add(this.textBoxIrCode);
            this.groupBox1.Location = new System.Drawing.Point(420, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 116);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BHS-IR.FW";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 527);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timerSampling;
        private System.Windows.Forms.Button buttonColckUpdate;
        private Controls.KnvTracingControl knvTracingControl1;
        private System.Windows.Forms.Button buttonCurrentDateTime;
        private System.Windows.Forms.Button buttonIrSendCode;
        private System.Windows.Forms.TextBox textBoxIrCode;
        private System.Windows.Forms.Button buttonOnOff;
        private System.Windows.Forms.Button buttonMute;
        private System.Windows.Forms.Button buttonRoute;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

