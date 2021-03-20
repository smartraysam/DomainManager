namespace MACED
{
    partial class Domain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Domain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textList = new System.Windows.Forms.TextBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textLog = new System.Windows.Forms.TextBox();
            this.butList = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textList);
            this.groupBox1.Location = new System.Drawing.Point(3, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 279);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add one domain per line i.e example.com";
            // 
            // textList
            // 
            this.textList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textList.Location = new System.Drawing.Point(3, 16);
            this.textList.Multiline = true;
            this.textList.Name = "textList";
            this.textList.Size = new System.Drawing.Size(394, 260);
            this.textList.TabIndex = 0;
            // 
            // butAdd
            // 
            this.butAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.butAdd.Location = new System.Drawing.Point(0, 437);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(406, 23);
            this.butAdd.TabIndex = 1;
            this.butAdd.Text = "Add Domain(s)";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textLog);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 123);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // textLog
            // 
            this.textLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLog.Location = new System.Drawing.Point(3, 16);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(400, 104);
            this.textLog.TabIndex = 0;
            // 
            // butList
            // 
            this.butList.Dock = System.Windows.Forms.DockStyle.Top;
            this.butList.Location = new System.Drawing.Point(0, 0);
            this.butList.Name = "butList";
            this.butList.Size = new System.Drawing.Size(406, 23);
            this.butList.TabIndex = 1;
            this.butList.Text = "Domain List";
            this.butList.UseVisualStyleBackColor = true;
            this.butList.Click += new System.EventHandler(this.butList_Click);
            // 
            // Domain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 460);
            this.Controls.Add(this.butList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Domain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MACED";
            this.Load += new System.EventHandler(this.Domain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textList;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.Button butList;
    }
}