namespace KaggleCSVCleaner
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
            this.txtFileInput = new System.Windows.Forms.TextBox();
            this.txtFileOutput = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFileInput
            // 
            this.txtFileInput.Location = new System.Drawing.Point(38, 22);
            this.txtFileInput.Name = "txtFileInput";
            this.txtFileInput.Size = new System.Drawing.Size(653, 20);
            this.txtFileInput.TabIndex = 0;
            this.txtFileInput.Text = "d:\\kaggle2\\train.csv\\train.csv";
            // 
            // txtFileOutput
            // 
            this.txtFileOutput.Location = new System.Drawing.Point(38, 48);
            this.txtFileOutput.Name = "txtFileOutput";
            this.txtFileOutput.Size = new System.Drawing.Size(653, 20);
            this.txtFileOutput.TabIndex = 1;
            this.txtFileOutput.Text = "d:\\kaggle2\\train.csv\\train1.csv";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(38, 128);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(35, 83);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 3;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(129, 96);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(562, 153);
            this.txtLog.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 261);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtFileOutput);
            this.Controls.Add(this.txtFileInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileInput;
        private System.Windows.Forms.TextBox txtFileOutput;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtLog;
    }
}

