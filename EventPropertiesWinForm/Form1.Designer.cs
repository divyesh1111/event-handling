namespace EventPropertiesWinForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnRaiseEvent1 = new System.Windows.Forms.Button();
            this.btnRaiseEvent2 = new System.Windows.Forms.Button();
            this.btnRaiseEvent3 = new System.Windows.Forms.Button();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(80, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 25);
            this.lblTitle.Text = "Event Properties Demo";
            
            // btnRaiseEvent1
            this.btnRaiseEvent1.Location = new System.Drawing.Point(30, 70);
            this.btnRaiseEvent1.Name = "btnRaiseEvent1";
            this.btnRaiseEvent1.Size = new System.Drawing.Size(120, 40);
            this.btnRaiseEvent1.Text = "Raise Event 1";
            this.btnRaiseEvent1.UseVisualStyleBackColor = true;
            this.btnRaiseEvent1.Click += new System.EventHandler(this.btnRaiseEvent1_Click);
            
            // btnRaiseEvent2
            this.btnRaiseEvent2.Location = new System.Drawing.Point(160, 70);
            this.btnRaiseEvent2.Name = "btnRaiseEvent2";
            this.btnRaiseEvent2.Size = new System.Drawing.Size(120, 40);
            this.btnRaiseEvent2.Text = "Raise Event 2";
            this.btnRaiseEvent2.UseVisualStyleBackColor = true;
            this.btnRaiseEvent2.Click += new System.EventHandler(this.btnRaiseEvent2_Click);
            
            // btnRaiseEvent3
            this.btnRaiseEvent3.Location = new System.Drawing.Point(290, 70);
            this.btnRaiseEvent3.Name = "btnRaiseEvent3";
            this.btnRaiseEvent3.Size = new System.Drawing.Size(120, 40);
            this.btnRaiseEvent3.Text = "Raise Event 3";
            this.btnRaiseEvent3.UseVisualStyleBackColor = true;
            this.btnRaiseEvent3.Click += new System.EventHandler(this.btnRaiseEvent3_Click);
            
            // lstOutput
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.ItemHeight = 15;
            this.lstOutput.Location = new System.Drawing.Point(30, 130);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.Size = new System.Drawing.Size(380, 150);
            
            // btnClear
            this.btnClear.Location = new System.Drawing.Point(160, 300);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 30);
            this.btnClear.Text = "Clear Output";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            
            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 350);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lstOutput);
            this.Controls.Add(this.btnRaiseEvent3);
            this.Controls.Add(this.btnRaiseEvent2);
            this.Controls.Add(this.btnRaiseEvent1);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Event Properties Demo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnRaiseEvent1;
        private System.Windows.Forms.Button btnRaiseEvent2;
        private System.Windows.Forms.Button btnRaiseEvent3;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClear;
    }
}