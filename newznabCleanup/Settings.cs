using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace newznabCleanup
{
    public partial class Settings : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbinfo();
            bool worked = OpenConnection();
            if (worked)
            {
                CloseConnection();
                MessageBox.Show("Connection test sucesfull");
            }
        }

        private void button1_VisibleChanged(object sender, EventArgs e)
        {
            tb_host.Text = Properties.Settings.Default.db_host;
            tb_user.Text = Properties.Settings.Default.db_user;
            tb_password.Text = Properties.Settings.Default.db_pass;
            tb_database.Text = Properties.Settings.Default.dbname;
            tb_autocorrectscore.Text = Properties.Settings.Default.AutoCorrectScore.ToString(); 
            tb_autodeletescore.Text = Properties.Settings.Default.AutoRemoveScore.ToString();
            cb_autorarpar.Checked = Properties.Settings.Default.AutoRarPar;
            cb_nationalgeographic.Checked = Properties.Settings.Default.NationalGeographic;
            cb_scenenzb.Checked = Properties.Settings.Default.SceneNZB;
            cb_zero_results.Checked = Properties.Settings.Default.ZeroMatches;
            cb_autocorrect.Checked = Properties.Settings.Default.AutoCorrect;
            cb_autodelete.Checked = Properties.Settings.Default.AutoRemove;
        }
        private bool OpenConnection()
        {
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
                        MessageBox.Show("Cannot connect to server.  Contact administrator\r\nERROR:\n\r" + ex.Message.ToString());
                        return false;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        return false;
                }
                MessageBox.Show("Unable to connect\r\nException - " + ex.Message.ToString());
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

        private void tb_host_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.db_host = tb_host.Text;
            Properties.Settings.Default.Save();
        }

        private void tb_user_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.db_user = tb_user.Text;
            Properties.Settings.Default.Save();
        }

        private void tb_password_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.db_pass = tb_password.Text;
            Properties.Settings.Default.Save();
        }

        private void tb_database_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.dbname = tb_database.Text;
            Properties.Settings.Default.Save();
        }

        private void cb_autorarpar_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoRarPar = cb_autorarpar.Checked;
            Properties.Settings.Default.Save();
        }

        private void cb_nationalgeographic_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NationalGeographic = cb_nationalgeographic.Checked;
            Properties.Settings.Default.Save();
        }

        private void cb_scenenzb_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SceneNZB = cb_scenenzb.Checked;
            Properties.Settings.Default.Save();
        }

        private void cb_zero_results_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ZeroMatches = cb_zero_results.Checked;
            Properties.Settings.Default.Save();
        }

        private void cb_autocorrect_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoCorrect = cb_autocorrect.Checked;
            Properties.Settings.Default.Save();
        }

        private void cb_autodelete_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoRemove = cb_autodelete.Checked;
            Properties.Settings.Default.Save();
        }

        private void tb_autocorrectscore_TextChanged(object sender, EventArgs e)
        {
            if (tb_autocorrectscore.Text.Trim() != "")
            {
                Properties.Settings.Default.AutoCorrectScore = int.Parse(tb_autocorrectscore.Text);
                Properties.Settings.Default.Save();
            }
        }

        private void tb_autodeletescore_TextChanged(object sender, EventArgs e)
        {
            if (tb_autodeletescore.Text.Trim() != "")
            {
                Properties.Settings.Default.AutoRemoveScore = int.Parse(tb_autodeletescore.Text);
                Properties.Settings.Default.Save();
            }
        }
    }
}
