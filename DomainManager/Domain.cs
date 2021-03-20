using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MACED
{
    public partial class Domain : Form
    {
        public string appPath = Directory.GetCurrentDirectory();
        string dbpath;
        public Domain()
        {
            InitializeComponent();
            dbpath = appPath + "\\domain.sqlite";
        }

   
        private void butAdd_Click(object sender, EventArgs e)
        {
            var ConnectionString = string.Format("Data Source = {0};Version = 3;", dbpath);
            var con = new SQLiteConnection(ConnectionString);
            con.Open();
            if (textList.Lines.Length > 0)
                {
                    for (int i = 0; i < textList.Lines.Length; i++)
                    {
                        string link = textList.Lines[i].ToString();
                       
                    string domain = "127.0.0.1      " + link +"      #"+link;
                        if (checkItem(link))
                        {
                            textLog.AppendText(link + " already added successfully");
                            textLog.AppendText(Environment.NewLine);
                            textLog.ScrollToCaret();
                            return;
                        }
                        if (ModifyHostsFile(domain))
                        {
                            var cmd = new SQLiteCommand(con);
                            cmd.CommandText = "INSERT INTO domains (name, domain) VALUES(@name,@domain)";
                            cmd.Parameters.AddWithValue("@name", link);
                            cmd.Parameters.AddWithValue("@domain", domain);
                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                        textLog.AppendText(link + " added successfully");
                    }
                        else
                        {
                            textLog.AppendText(textList.Lines[i].ToString() + " add failed");

                        }
                        textLog.AppendText(Environment.NewLine);
                        textLog.ScrollToCaret();
                    }
                    textLog.AppendText("Done");
                checkHost();


            }
               
              
        }

        public bool checkItem(string item)
        {
            var ConnectionString = string.Format("Data Source = {0};Version = 3;", dbpath);
          
            using (var sqlite2 = new SQLiteConnection(ConnectionString))
            {
                sqlite2.Open();
                using (SQLiteCommand command = new SQLiteCommand(sqlite2))
                {
                    command.CommandText =
                        "select  count(*) from  domains where name=:value";
                    command.Parameters.Add("value", DbType.String).Value = item;
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if(count > 0)
                    {
                        return true;
                    }
                }
            }
         
            return false;
        }
        public void checkHost()
        {
            var oldLines = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts"));
            foreach (var item in oldLines)
            {
                if(item.StartsWith("127"))
                    Debug.WriteLine(item);
            }
        }
        public static bool ModifyHostsFile(string entry)
        {
            try
            {
                using (StreamWriter w = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts")))
                {
                    w.WriteLine(entry);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void Domain_Load(object sender, EventArgs e)
        {

        }

        private void butList_Click(object sender, EventArgs e)
        {
            Form1.fromAdd = true;
            Form1 pnd = new Form1();
            pnd.Show();
            this.Hide();
        }
    }
}
