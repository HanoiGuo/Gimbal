namespace Monocle
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
            this.button2 = new System.Windows.Forms.Button();
            this.labelNotice = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.View = new System.Windows.Forms.Button();
            this.StopTest = new System.Windows.Forms.Button();
            this.StartTest = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ShowMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Cyan;
            this.button2.Location = new System.Drawing.Point(-5, -5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(1273, 44);
            this.button2.TabIndex = 2;
            this.button2.Text = "Gimbal Test System";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // labelNotice
            // 
            this.labelNotice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelNotice.Location = new System.Drawing.Point(0, 118);
            this.labelNotice.Name = "labelNotice";
            this.labelNotice.Size = new System.Drawing.Size(1268, 29);
            this.labelNotice.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.View);
            this.panel1.Controls.Add(this.StopTest);
            this.panel1.Controls.Add(this.StartTest);
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1268, 80);
            this.panel1.TabIndex = 14;
            // 
            // View
            // 
            this.View.BackColor = System.Drawing.Color.Yellow;
            this.View.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.View.ForeColor = System.Drawing.Color.Black;
            this.View.Location = new System.Drawing.Point(1026, 3);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(99, 67);
            this.View.TabIndex = 22;
            this.View.Text = "View";
            this.View.UseVisualStyleBackColor = false;
            this.View.Click += new System.EventHandler(this.View_Click);
            // 
            // StopTest
            // 
            this.StopTest.BackColor = System.Drawing.Color.Red;
            this.StopTest.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopTest.ForeColor = System.Drawing.Color.Black;
            this.StopTest.Location = new System.Drawing.Point(896, 3);
            this.StopTest.Name = "StopTest";
            this.StopTest.Size = new System.Drawing.Size(99, 67);
            this.StopTest.TabIndex = 14;
            this.StopTest.Text = "Stop";
            this.StopTest.UseVisualStyleBackColor = false;
            this.StopTest.Click += new System.EventHandler(this.StopTest_Click);
            // 
            // StartTest
            // 
            this.StartTest.BackColor = System.Drawing.Color.Lime;
            this.StartTest.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartTest.ForeColor = System.Drawing.Color.Black;
            this.StartTest.Location = new System.Drawing.Point(768, 3);
            this.StartTest.Name = "StartTest";
            this.StartTest.Size = new System.Drawing.Size(99, 67);
            this.StartTest.TabIndex = 13;
            this.StartTest.Text = "Start";
            this.StartTest.UseVisualStyleBackColor = false;
            this.StartTest.Click += new System.EventHandler(this.StartTest_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.ShowMessage);
            this.panel2.Location = new System.Drawing.Point(0, 584);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1568, 140);
            this.panel2.TabIndex = 31;
            // 
            // ShowMessage
            // 
            this.ShowMessage.BackColor = System.Drawing.Color.DarkOrchid;
            this.ShowMessage.Font = new System.Drawing.Font("宋体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowMessage.ForeColor = System.Drawing.Color.Navy;
            this.ShowMessage.Location = new System.Drawing.Point(0, 2);
            this.ShowMessage.Name = "ShowMessage";
            this.ShowMessage.Size = new System.Drawing.Size(1268, 76);
            this.ShowMessage.TabIndex = 26;
            this.ShowMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1262, 663);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelNotice);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Gimbal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelNotice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StartTest;
        private System.Windows.Forms.Button StopTest;
        private System.Windows.Forms.Button View;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ShowMessage;
    }
}

