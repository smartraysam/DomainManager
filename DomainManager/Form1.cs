using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;

namespace MACED
{
    public partial class Form1 : Form
    {
        public string appPath = Directory.GetCurrentDirectory();
        string dbpath;
        public static bool fromAdd=false;
        static string hostpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");
        public Form1()
        {
             dbpath = appPath + "\\domain.sqlite";
            InitializeComponent();
            if (!fromAdd)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
           
            if (!File.Exists(dbpath))
            {
                var ConnectionString = string.Format("Data Source = {0};Version = 3;", dbpath);
                SQLiteConnection.CreateFile(dbpath);
                using (var sqlite2 = new SQLiteConnection(ConnectionString))
                {
                    sqlite2.Open();
                    string sql = "create table domains (name varchar(255), domain varchar(255))";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                displayDataGridView(false);
            }
        }
     
        private void Form1_Resize(object sender, EventArgs e)
        {

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = "MACED";
                notifyIcon.BalloonTipText = "Program now running in background";
                notifyIcon.ShowBalloonTip(200);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }

        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            Domain pnd = new Domain();
            pnd.Show();
            this.Hide();
        }

        public void displayDataGridView(bool isEdit)
        {

            var ConnectionString = string.Format("Data Source = {0};Version = 3;", dbpath);
            var con = new SQLiteConnection(ConnectionString);
            con.Open();
            string stringQuery = "SELECT * FROM domains";
            SQLiteCommand comm = new SQLiteCommand(stringQuery, con);
            using (SQLiteDataReader read = comm.ExecuteReader())
            {
                while (read.Read())
                {
                    domainList.Rows.Add(new object[] {
                    read.GetValue(read.GetOrdinal("name")),  // Or column name like this
                    read.GetValue(read.GetOrdinal("domain")),
                   
                });
                }
            }
            if (!isEdit)
            {
                DataGridViewButtonColumn Editlink = new DataGridViewButtonColumn();
                Editlink.DataPropertyName = "lnkColumn";
                Editlink.Text = "Edit";
                Editlink.Name = "Edit";
                Editlink.UseColumnTextForButtonValue = true;
                domainList.Columns.Add(Editlink);

                DataGridViewButtonColumn Deletelink = new DataGridViewButtonColumn();
                Deletelink.Text = "Delete";
                Deletelink.Name = "Delete";
                Deletelink.UseColumnTextForButtonValue = true;
                domainList.Columns.Add(Deletelink);
            }

        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
            this.ShowInTaskbar = true;
        }
        public static bool AddHostsFile(string entry)
        {
          
            string domain = "127.0.0.1      " + entry + "      #" + entry;
            try
            {
                using (StreamWriter w = File.AppendText(hostpath))
                {
                    w.WriteLine(domain);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool DeleteHostsFile(string entry)
        {
            try
            {
                var oldLines = File.ReadAllLines(hostpath);
                var newLines = oldLines.Where(line => !line.Contains("#" + entry));
                File.WriteAllLines(hostpath, newLines);
                FileStream obj = new FileStream(hostpath, FileMode.Append);
                obj.Close();
                return true;
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.Message);
                return false;
            }
        }
        public void checkHost()
        {
            var oldLines = File.ReadAllLines(hostpath);
            foreach (var item in oldLines)
            {
                if (item.StartsWith("127"))
                    Debug.WriteLine(item);
            }
        }
        private void domainList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i,k;
            var ConnectionString = string.Format("Data Source = {0};Version = 3;", dbpath);
            if (e.ColumnIndex == 2)
            {
                i = domainList.CurrentCell.RowIndex;
                k = domainList.CurrentCell.ColumnIndex - 2;
                string value= domainList.Rows[i].Cells[k].Value.ToString();
                string oldname = value;
                if (InputBox("Modify List", "Edit domain name", ref value) == DialogResult.OK)
                {
                    string domain = "127.0.0.1      " + value + "      #" + value;
                 
                    using (var sqlite2 = new SQLiteConnection(ConnectionString))
                    {
                        sqlite2.Open();
                        using (SQLiteCommand command = new SQLiteCommand(sqlite2))
                        {
                            command.CommandText =
                                "update domains set name=:name, domain=:domain where name=:value";
                            command.Parameters.Add("name", DbType.String).Value =value;
                            command.Parameters.Add("domain", DbType.String).Value = domain;
                            command.Parameters.Add("value", DbType.String).Value = oldname;
                            command.ExecuteNonQuery();
                        }
                    }
                    DeleteHostsFile(oldname);
                    AddHostsFile(value);
                    checkHost();
                }
                domainList.Rows.Clear();
                displayDataGridView(true);

            }
            if (e.ColumnIndex == 3)
            {
                i = domainList.CurrentCell.RowIndex;
                k = domainList.CurrentCell.ColumnIndex - 3;
                string value = domainList.Rows[i].Cells[k].Value.ToString();
                Debug.WriteLine(value);
                try
                {
                    using (var sqlite2 = new SQLiteConnection(ConnectionString))
                    {
                        sqlite2.Open();
                        using (SQLiteCommand command = new SQLiteCommand(sqlite2))
                        {
                            command.CommandText = "DELETE FROM domains WHERE name=:name";
                            command.Parameters.Add("name", DbType.String).Value = value;
                            command.ExecuteNonQuery();
                        }
                    }
     
                    DeleteHostsFile(value);
                    domainList.Rows.RemoveAt(i);
                    domainList.Refresh();

                }
                catch (Exception)
                {
                    Debug.WriteLine("Error");
                }
              
                checkHost();


            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!RunOnStartup.Startup.IsInStartup())
            {
                bool startcheck = RunOnStartup.Startup.RunOnStartup();
                Debug.WriteLine(startcheck);
            }
        }
    }
}
