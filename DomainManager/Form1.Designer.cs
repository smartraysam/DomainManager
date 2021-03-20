namespace MACED
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.domainList = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.domainList)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Program now run in background";
            this.notifyIcon.BalloonTipTitle = "MACED";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MACED";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.domainList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 431);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Domain List";
            // 
            // domainList
            // 
            this.domainList.AllowUserToAddRows = false;
            this.domainList.AllowUserToDeleteRows = false;
            this.domainList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.domainList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.domainList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.domainList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.domain});
            this.domainList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.domainList.Location = new System.Drawing.Point(3, 16);
            this.domainList.Name = "domainList";
            this.domainList.ReadOnly = true;
            this.domainList.RowHeadersVisible = false;
            this.domainList.Size = new System.Drawing.Size(400, 412);
            this.domainList.TabIndex = 2;
            this.domainList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.domainList_CellClick);
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // domain
            // 
            this.domain.HeaderText = "Domain";
            this.domain.Name = "domain";
            this.domain.ReadOnly = true;
            // 
            // butAdd
            // 
            this.butAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.butAdd.Location = new System.Drawing.Point(0, 0);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(406, 23);
            this.butAdd.TabIndex = 1;
            this.butAdd.Text = "Add Domain(s)";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 460);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MACED";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.domainList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView domainList;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn domain;
    }
}

