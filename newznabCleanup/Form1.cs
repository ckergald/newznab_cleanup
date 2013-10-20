using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Xml;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace newznabCleanup
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private bool running;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label14.Visible = false;
            autoCleanupToolStripMenuItem.Enabled = false;
            stopAutoCleanupToolStripMenuItem.Enabled = false;
            bool testing = OpenConnection();
            CloseConnection();
            if (testing)
            {
                update_unmatched_list();
            }
            else
            {
                MessageBox.Show("Unable to connect to database\r\nVerify settings in the File > Settings menu.");
            }
        }
        private bool OpenConnection()
        {
            dbinfo();
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        return false;

                    case 1045:
                        return false;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        public List<string>[] Selectrage()
        {
            string query = "SELECT * FROM tvrage where rageID='-2'";

            //Create a list to store the result
            List<string>[] list = new List<string>[13];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();
            list[6] = new List<string>();
            list[7] = new List<string>();
            list[8] = new List<string>();
            list[9] = new List<string>();
            list[10] = new List<string>();
            list[11] = new List<string>();
            list[12] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["ID"] + "");
                    list[1].Add(dataReader["rageID"] + "");
                    list[2].Add(dataReader["tvdbID"] + "");
                    list[3].Add(dataReader["releasetitle"] + "");
                    list[4].Add(dataReader["description"] + "");
                    list[5].Add(dataReader["genre"] + "");
                    list[6].Add(dataReader["country"] + "");
                    list[7].Add(dataReader["imgdata"] + "");
                    list[8].Add(dataReader["createddate"] + "");
                    list[9].Add(dataReader["prevdate"] + "");
                    list[10].Add(dataReader["previnfo"] + "");
                    list[11].Add(dataReader["nextdate"] + "");
                    list[12].Add(dataReader["nextinfo"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();
                Application.DoEvents();
                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            List<string>[] dblist = Selectrage();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            tb_ID.Text = "";
            tb_rageid.Text = "";
            tb_tvdbid.Text = "";
            for (int i = 0; i < dblist[3].Count(); i++)
            {
                listBox1.Items.Add(dblist[3][i].ToString());
                listBox2.Items.Add(dblist[0][i].ToString());
                listBox3.Items.Add(dblist[1][i].ToString());
                listBox4.Items.Add(dblist[2][i].ToString());
            }
            listBox1.Refresh();
        }
        private void update_unmatched_list()
        {
            List<string>[] dblist = Selectrage();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            tb_ID.Text = "";
            tb_rageid.Text = "";
            tb_tvdbid.Text = "";
            for (int i = 0; i < dblist[3].Count(); i++)
            {
                listBox1.Items.Add(dblist[3][i].ToString());
                listBox2.Items.Add(dblist[0][i].ToString());
                listBox3.Items.Add(dblist[1][i].ToString());
                listBox4.Items.Add(dblist[2][i].ToString());
            }
            listBox1.Refresh();
            if (listBox1.Items.Count > 0) { autoCleanupToolStripMenuItem.Enabled = true; }
        }
        private void dbinfo()
        {
            server = Properties.Settings.Default.db_host;
            database = Properties.Settings.Default.dbname;
            uid = Properties.Settings.Default.db_user;
            password = Properties.Settings.Default.db_pass;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        private void tb_db_host_TextChanged(object sender, EventArgs e)
        {
            dbinfo();
        }

        private void tb_db_user_TextChanged(object sender, EventArgs e)
        {
            dbinfo();
        }

        private void tb_db_pass_TextChanged(object sender, EventArgs e)
        {
            dbinfo();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_ID.Text = listBox2.Items[listBox1.SelectedIndex].ToString();
            tb_rageid.Text = listBox3.Items[listBox1.SelectedIndex].ToString();
            tb_tvdbid.Text = listBox4.Items[listBox1.SelectedIndex].ToString();
            tb_release_title.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
            tvrage_lookup(listBox1.Items[listBox1.SelectedIndex].ToString());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            lb_log.Items.Add("Corrected " + listBox5.Items[listBox5.SelectedIndex]);
            tb_rageid.Text = listBox6.Items[listBox5.SelectedIndex].ToString();
            tb_tvdbid.Refresh();
            Application.DoEvents();
            updaterage();
            List<string>[] dblist = Selectrage();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            tb_ID.Text = "";
            tb_rageid.Text = "";
            tb_tvdbid.Text = "";
            label14.Text = "";
            label14.Visible = false;
            for (int i = 0; i < dblist[3].Count(); i++)
            {
                listBox1.Items.Add(dblist[3][i].ToString());
                listBox2.Items.Add(dblist[0][i].ToString());
                listBox3.Items.Add(dblist[1][i].ToString());
                listBox4.Items.Add(dblist[2][i].ToString());
            }
            listBox1.Refresh();
        }
        private void tvrage_lookup(string title)
        {
            listBox5.Items.Clear();
            listBox5.Refresh();
            listBox6.Items.Clear();
            listBox6.Refresh();
            Application.DoEvents();
            string rageresults = "";
            WebClient wc = new WebClient();
            bool retry = true;
            int counter = 0;
            while (retry)
            {
                try
                {
                    wc.Encoding = System.Text.Encoding.UTF8;
                    rageresults = wc.DownloadString("http://services.tvrage.com/feeds/full_search.php?show=" + Uri.EscapeUriString(title));
                    retry = false;
                }
                catch
                {
                    if (counter < 5)
                    {
                        counter = counter + 1;
                    }
                }
            }
            XmlDocument rage = new XmlDocument();
            try
            {
                rage.LoadXml(rageresults);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A problem occured parsing TVRAGE RESULTS \r\nPossibly to many attempts\r\n" + ex.Message.ToString());
                tvrage_lookup(title);
            }
            XmlNodeList ragenl = rage.SelectNodes("/Results/show");
            if (ragenl.Count > 0)
            {
                decimal max_score = 0;
                for (int x = 0; x < ragenl.Count; x++)
                {
                    listBox5.Items.Add(ragenl[x]["name"].InnerText.ToString());
                    listBox6.Items.Add(ragenl[x]["showid"].InnerText.ToString());
                    listBox5.Refresh();
                    string comp = ragenl[x]["name"].InnerText.ToString();
                    int difference = score_differences( title.ToUpper(), comp.ToUpper());
                    decimal score = 0;
                    if (difference != 0)
                    {
                        decimal tempd = (decimal)100 / (decimal)title.Length;
                        decimal tempd2 = (decimal)title.Length * (decimal)tempd;
                        decimal tempd3 = (decimal)difference * (decimal)tempd;
                        decimal tempd4 = (decimal)tempd3 / (decimal)tempd2;
                        tempd4 = tempd4 * 100;
                        score = (decimal)100 - tempd4;
                        score = decimal.Round(score, 2, MidpointRounding.AwayFromZero);
                        if (score > max_score) 
                        { 
                            max_score = score;
                            label14.Text = "TV RAGE search results   -   Best Match - " + ragenl[x]["name"].InnerText.ToString();
                            label14.Refresh();
                            label14.Visible = true;
                            label15.Text = x.ToString();
                            label15.Refresh();
                            Application.DoEvents();
                        }
                    }
                }
                if ((Properties.Settings.Default.AutoCorrect) && (max_score > Properties.Settings.Default.AutoCorrectScore))
                {
                    listBox5.SelectedIndex = int.Parse(label15.Text);
                }
            }
            else
            {
                listBox5.Items.Add("NO match found");
                listBox5.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Delete_from_table(tb_ID.Text);
            lb_log.Items.Add("Manualy DELETED - " + tb_ID.Text);
            update_app();
            label14.Text = "";
            label14.Visible = false;
        }
        public void Delete_from_table(string ID)
        {
            string query = "DELETE FROM tvrage WHERE ID='"+ID+"'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public void update_app()
        {
            List<string>[] dblist = Selectrage();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            tb_ID.Text = "";
            tb_rageid.Text = "";
            tb_tvdbid.Text = "";
            tb_release_title.Text = "";
            label15.Text = "Index";
            for (int i = 0; i < dblist[3].Count(); i++)
            {
                listBox1.Items.Add(dblist[3][i].ToString());
                listBox2.Items.Add(dblist[0][i].ToString());
                listBox3.Items.Add(dblist[1][i].ToString());
                listBox4.Items.Add(dblist[2][i].ToString());
            }
            listBox1.Refresh();
        }
        public void updaterage()
        {
            string query = "UPDATE tvrage SET rageID='" + tb_rageid.Text + "', tvdbID='" + tb_tvdbid.Text + "' WHERE ID='" + tb_ID.Text + "'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tb_release_title_TextChanged(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox6.Refresh();
            listBox5.Refresh();
            tvrage_lookup(tb_release_title.Text);
        }

        static private int score_differences(string source, string target)
        {
            int n = source.Length;
            int m = target.Length;
            
            int[,] d = new int[n + 1, m + 1];
            int cost;
            if (n == 0) { return m; }
            if (m == 0) { return n; }
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 0; j <= m; d[0, j] = j++) ;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    cost = (target.Substring(j - 1, 1) == source.Substring(i - 1, 1) ? 0 : 1);
                    d[i, j] = System.Math.Min(System.Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                              d[i - 1, j - 1] + cost);
                }
            }
            return d[n, m];
        }
        private void start_auto_cleanup()
        {
            autoCleanupToolStripMenuItem.Enabled = false;
            stopAutoCleanupToolStripMenuItem.Enabled = true;
            int del = 0;
            int corrected = 0;
            int skipped = 0;
            running = true;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (running == false) 
                {
                    autoCleanupToolStripMenuItem.Enabled = true;
                    stopAutoCleanupToolStripMenuItem.Enabled = false;
                    break; 
                }
                this.Text = "Neznab Updater  - " + i.ToString() + " / " + listBox1.Items.Count.ToString();
                tb_ID.Text = listBox2.Items[i].ToString();
                tb_rageid.Text = listBox3.Items[i].ToString();
                tb_tvdbid.Text = listBox4.Items[i].ToString();
                tb_release_title.Text = listBox1.Items[i].ToString();
                tb_rageid.Text = "";
                Application.DoEvents();
                Thread.Sleep(200);
                string rel = listBox1.Items[i].ToString();
                if ((Properties.Settings.Default.NationalGeographic) && (rel.ToUpper().Contains("NATIONAL GEOGRAPHIC")))
                {
                    string[] temp = Regex.Split(rel.ToUpper(), "NATIONAL GEOGRAPHIC");
                    rel = temp[1].Trim();
                    Application.DoEvents();
                    Thread.Sleep(500);
                }
                if ((Properties.Settings.Default.NationalGeographic) && (rel.ToUpper().Contains("NATIONAL GEOGRAPHIC ")))
                {
                    string[] temp = Regex.Split(rel.ToUpper(), "NATIONAL GEOGRAPHIC ");
                    rel = temp[1].Trim();
                    Application.DoEvents();
                    Thread.Sleep(500);
                }
                if ((Properties.Settings.Default.NationalGeographic) && (rel.ToUpper().Contains("NATIONAL GEOGRAPHIC WILD")))
                {
                    string[] temp = Regex.Split(rel.ToUpper(), "NATIONAL GEOGRAPHIC WILD");
                    rel = temp[1].Trim();
                    Application.DoEvents();
                    Thread.Sleep(500);
                }
                if ((Properties.Settings.Default.NationalGeographic) && (rel.ToUpper().Contains("NATIONAL GEOGRAPHIC WILD ")))
                {
                    string[] temp = Regex.Split(rel.ToUpper(), "NATIONAL GEOGRAPHIC WILD ");
                    rel = temp[1].Trim();
                    Application.DoEvents();
                    Thread.Sleep(500);
                }
                if ((Properties.Settings.Default.SceneNZB) && (rel.ToUpper().Contains("SCENENZB ")))
                {
                    string[] temp = Regex.Split(rel.ToUpper(), "SCENENZB ");
                    rel = temp[1].Trim();
                    Application.DoEvents();
                    Thread.Sleep(500);
                }

                if ((Properties.Settings.Default.AutoRarPar) && (rel.ToUpper().Contains("AUTORARPAR")))
                {
                    Delete_from_table(listBox2.Items[i].ToString());
                    del = del + 1;
                    lb_log.Items.Add("DELETED - " + rel);
                    lb_log.Refresh();
                    Thread.Sleep(1000);
                    continue;
                }
                tvrage_lookup(rel);
                listBox5.Refresh();
                listBox6.Refresh();
                Application.DoEvents();
                if (listBox5.Items.Count == 0) { continue; }
                if ((Properties.Settings.Default.ZeroMatches) && (listBox5.Items[0].ToString() == "NO match found"))
                {
                    Delete_from_table(listBox2.Items[i].ToString());
                    del = del + 1;
                    lb_log.Items.Add("DELETED - " + rel);
                    lb_log.Refresh();
                    Thread.Sleep(1000);
                    continue;
                }
                if (Properties.Settings.Default.AutoCorrect)
                {
                    for (int x = 0; x < listBox5.Items.Count; x++)
                    {
                        string comp = listBox5.Items[x].ToString();
                        int difference = score_differences(rel.ToUpper(), comp.ToUpper());
                        decimal score = 0;
                        if (difference != 0)
                        {
                            decimal tempd = (decimal)100 / (decimal)rel.Length;
                            decimal tempd2 = (decimal)rel.Length * (decimal)tempd;
                            decimal tempd3 = (decimal)difference * (decimal)tempd;
                            decimal tempd4 = (decimal)tempd3 / (decimal)tempd2;
                            tempd4 = tempd4 * 100;
                            score = (decimal)100 - tempd4;
                            score = decimal.Round(score, 2, MidpointRounding.AwayFromZero);
                            decimal req = (decimal)Properties.Settings.Default.AutoCorrectScore;
                            if (score >= req)
                            {
                                tb_rageid.Text = listBox6.Items[x].ToString();
                                tb_tvdbid.Refresh();
                                Application.DoEvents();
                                Thread.Sleep(1000);
                                corrected = corrected + 1;
                                lb_log.Items.Add("CORRECTED - " + rel);
                                lb_log.SelectedIndex = lb_log.Items.Count - 1;
                                lb_log.Refresh();
                                updaterage();
                                continue;
                            }
                        }
                    }
                }
                if (Properties.Settings.Default.AutoRemove)
                {
                    bool deleteit = true;
                    decimal val = (decimal)0;
                    for (int x = 0; x < listBox5.Items.Count; x++)
                    {
                        string comp = listBox5.Items[x].ToString();
                        int difference = score_differences(rel.ToUpper(), comp.ToUpper());
                        decimal score = 0;
                        if (difference != 0)
                        {
                            decimal tempd = (decimal)100 / (decimal)rel.Length;
                            decimal tempd2 = (decimal)rel.Length * (decimal)tempd;
                            decimal tempd3 = (decimal)difference * (decimal)tempd;
                            decimal tempd4 = (decimal)tempd3 / (decimal)tempd2;
                            tempd4 = tempd4 * 100;
                            score = (decimal)100 - tempd4;
                            score = decimal.Round(score, 2, MidpointRounding.AwayFromZero);
                            decimal req = (decimal)Properties.Settings.Default.AutoRemoveScore;
                            if (score > val)
                            {
                                val = score;
                                Application.DoEvents();
                                Thread.Sleep(50);
                            }

                            if (score >= req)
                            {
                                deleteit = false;
                                continue;
                            }
                        }
                    }
                    if (deleteit)
                    {
                        lb_log.Items.Add("DELETED - " + rel);
                        lb_log.SelectedIndex = lb_log.Items.Count - 1;
                        lb_log.Refresh();
                        string comps = "";
                        for (int x = 0; x < listBox5.Items.Count; x++)
                        {
                            string comp = listBox5.Items[x].ToString();
                            int difference = score_differences(rel.ToUpper(), comp.ToUpper());
                            decimal score = 0;
                            if (difference != 0)
                            {
                                decimal tempd = (decimal)100 / (decimal)rel.Length;
                                decimal tempd2 = (decimal)rel.Length * (decimal)tempd;
                                decimal tempd3 = (decimal)difference * (decimal)tempd;
                                decimal tempd4 = (decimal)tempd3 / (decimal)tempd2;
                                tempd4 = tempd4 * 100;
                                score = (decimal)100 - tempd4;
                                score = decimal.Round(score, 2, MidpointRounding.AwayFromZero);
                                decimal req = (decimal)Properties.Settings.Default.AutoCorrectScore;
                                comps = comps + listBox5.Items[x].ToString().ToUpper() + "-" + score.ToString() + " - req " + req.ToString() + "\r\n";
                            }
                            else { comps = comps + listBox5.Items[x].ToString().ToUpper() + "-" + score.ToString() + "\r\n"; }

                        }
                        Delete_from_table(listBox2.Items[i].ToString());
                        del = del + 1;
                        Thread.Sleep(1000);
                        continue;
                    }
                }
                skipped = skipped + 1;
                lb_log.Items.Add("skipped - " + rel);
                lb_log.SelectedIndex = lb_log.Items.Count - 1;
                lb_log.Refresh();
            }
            autoCleanupToolStripMenuItem.Enabled = true;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings frm2 = new Settings();
            frm2.Show();
        }


        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseConnection();
            Application.Exit();
            return;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update_unmatched_list();
        }

        private void autoCleanupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start_auto_cleanup();
        }

        private void stopAutoCleanupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            running = false;
            this.Text = "Newznab Updater";
        }
    }
}
