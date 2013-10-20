namespace newznabCleanup
{
    partial class Settings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_host = new System.Windows.Forms.TextBox();
            this.tb_user = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_database = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_autorarpar = new System.Windows.Forms.CheckBox();
            this.cb_nationalgeographic = new System.Windows.Forms.CheckBox();
            this.cb_scenenzb = new System.Windows.Forms.CheckBox();
            this.cb_zero_results = new System.Windows.Forms.CheckBox();
            this.cb_autocorrect = new System.Windows.Forms.CheckBox();
            this.tb_autocorrectscore = new System.Windows.Forms.TextBox();
            this.tb_autodeletescore = new System.Windows.Forms.TextBox();
            this.cb_autodelete = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tb_database);
            this.groupBox1.Controls.Add(this.tb_password);
            this.groupBox1.Controls.Add(this.tb_user);
            this.groupBox1.Controls.Add(this.tb_host);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Database name";
            // 
            // tb_host
            // 
            this.tb_host.Location = new System.Drawing.Point(105, 13);
            this.tb_host.Name = "tb_host";
            this.tb_host.Size = new System.Drawing.Size(141, 20);
            this.tb_host.TabIndex = 4;
            this.tb_host.TextChanged += new System.EventHandler(this.tb_host_TextChanged);
            // 
            // tb_user
            // 
            this.tb_user.Location = new System.Drawing.Point(105, 38);
            this.tb_user.Name = "tb_user";
            this.tb_user.Size = new System.Drawing.Size(141, 20);
            this.tb_user.TabIndex = 5;
            this.tb_user.TextChanged += new System.EventHandler(this.tb_user_TextChanged);
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(105, 64);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(141, 20);
            this.tb_password.TabIndex = 6;
            this.tb_password.TextChanged += new System.EventHandler(this.tb_password_TextChanged);
            // 
            // tb_database
            // 
            this.tb_database.Location = new System.Drawing.Point(105, 90);
            this.tb_database.Name = "tb_database";
            this.tb_database.Size = new System.Drawing.Size(141, 20);
            this.tb_database.TabIndex = 7;
            this.tb_database.TextChanged += new System.EventHandler(this.tb_database_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.VisibleChanged += new System.EventHandler(this.button1_VisibleChanged);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_autodeletescore);
            this.groupBox2.Controls.Add(this.cb_autodelete);
            this.groupBox2.Controls.Add(this.tb_autocorrectscore);
            this.groupBox2.Controls.Add(this.cb_autocorrect);
            this.groupBox2.Controls.Add(this.cb_zero_results);
            this.groupBox2.Controls.Add(this.cb_scenenzb);
            this.groupBox2.Controls.Add(this.cb_nationalgeographic);
            this.groupBox2.Controls.Add(this.cb_autorarpar);
            this.groupBox2.Location = new System.Drawing.Point(12, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 162);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auto Cleanup settings";
            // 
            // cb_autorarpar
            // 
            this.cb_autorarpar.AutoSize = true;
            this.cb_autorarpar.Location = new System.Drawing.Point(9, 19);
            this.cb_autorarpar.Name = "cb_autorarpar";
            this.cb_autorarpar.Size = new System.Drawing.Size(179, 17);
            this.cb_autorarpar.TabIndex = 0;
            this.cb_autorarpar.Text = "Remove all AutoRarPar releases";
            this.cb_autorarpar.UseVisualStyleBackColor = true;
            this.cb_autorarpar.CheckedChanged += new System.EventHandler(this.cb_autorarpar_CheckedChanged);
            // 
            // cb_nationalgeographic
            // 
            this.cb_nationalgeographic.AutoSize = true;
            this.cb_nationalgeographic.Location = new System.Drawing.Point(9, 42);
            this.cb_nationalgeographic.Name = "cb_nationalgeographic";
            this.cb_nationalgeographic.Size = new System.Drawing.Size(224, 17);
            this.cb_nationalgeographic.TabIndex = 1;
            this.cb_nationalgeographic.Text = "Clean National Geographic release names";
            this.cb_nationalgeographic.UseVisualStyleBackColor = true;
            this.cb_nationalgeographic.CheckedChanged += new System.EventHandler(this.cb_nationalgeographic_CheckedChanged);
            // 
            // cb_scenenzb
            // 
            this.cb_scenenzb.AutoSize = true;
            this.cb_scenenzb.Location = new System.Drawing.Point(9, 65);
            this.cb_scenenzb.Name = "cb_scenenzb";
            this.cb_scenenzb.Size = new System.Drawing.Size(180, 17);
            this.cb_scenenzb.TabIndex = 2;
            this.cb_scenenzb.Text = "Clean SceneNZB release names";
            this.cb_scenenzb.UseVisualStyleBackColor = true;
            this.cb_scenenzb.CheckedChanged += new System.EventHandler(this.cb_scenenzb_CheckedChanged);
            // 
            // cb_zero_results
            // 
            this.cb_zero_results.AutoSize = true;
            this.cb_zero_results.Location = new System.Drawing.Point(9, 88);
            this.cb_zero_results.Name = "cb_zero_results";
            this.cb_zero_results.Size = new System.Drawing.Size(253, 17);
            this.cb_zero_results.TabIndex = 3;
            this.cb_zero_results.Text = "Remove any release with 0 results from TVRage";
            this.cb_zero_results.UseVisualStyleBackColor = true;
            this.cb_zero_results.CheckedChanged += new System.EventHandler(this.cb_zero_results_CheckedChanged);
            // 
            // cb_autocorrect
            // 
            this.cb_autocorrect.AutoSize = true;
            this.cb_autocorrect.Location = new System.Drawing.Point(9, 111);
            this.cb_autocorrect.Name = "cb_autocorrect";
            this.cb_autocorrect.Size = new System.Drawing.Size(165, 17);
            this.cb_autocorrect.TabIndex = 4;
            this.cb_autocorrect.Text = "Auto Correct if score exceeds";
            this.cb_autocorrect.UseVisualStyleBackColor = true;
            this.cb_autocorrect.CheckedChanged += new System.EventHandler(this.cb_autocorrect_CheckedChanged);
            // 
            // tb_autocorrectscore
            // 
            this.tb_autocorrectscore.Location = new System.Drawing.Point(194, 109);
            this.tb_autocorrectscore.Name = "tb_autocorrectscore";
            this.tb_autocorrectscore.Size = new System.Drawing.Size(52, 20);
            this.tb_autocorrectscore.TabIndex = 5;
            this.tb_autocorrectscore.TextChanged += new System.EventHandler(this.tb_autocorrectscore_TextChanged);
            // 
            // tb_autodeletescore
            // 
            this.tb_autodeletescore.Location = new System.Drawing.Point(194, 132);
            this.tb_autodeletescore.Name = "tb_autodeletescore";
            this.tb_autodeletescore.Size = new System.Drawing.Size(52, 20);
            this.tb_autodeletescore.TabIndex = 7;
            this.tb_autodeletescore.TextChanged += new System.EventHandler(this.tb_autodeletescore_TextChanged);
            // 
            // cb_autodelete
            // 
            this.cb_autodelete.AutoSize = true;
            this.cb_autodelete.Location = new System.Drawing.Point(9, 134);
            this.cb_autodelete.Name = "cb_autodelete";
            this.cb_autodelete.Size = new System.Drawing.Size(183, 17);
            this.cb_autodelete.TabIndex = 6;
            this.cb_autodelete.Text = "Auto Remove if score is less than";
            this.cb_autodelete.UseVisualStyleBackColor = true;
            this.cb_autodelete.CheckedChanged += new System.EventHandler(this.cb_autodelete_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 311);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_database;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_user;
        private System.Windows.Forms.TextBox tb_host;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_scenenzb;
        private System.Windows.Forms.CheckBox cb_nationalgeographic;
        private System.Windows.Forms.CheckBox cb_autorarpar;
        private System.Windows.Forms.TextBox tb_autodeletescore;
        private System.Windows.Forms.CheckBox cb_autodelete;
        private System.Windows.Forms.TextBox tb_autocorrectscore;
        private System.Windows.Forms.CheckBox cb_autocorrect;
        private System.Windows.Forms.CheckBox cb_zero_results;
    }
}