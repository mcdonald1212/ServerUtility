namespace ServerUserCleanup
{
    partial class ServerUserCleanup
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutServerCleanupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutServerCleanupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_FileSystemOptions = new System.Windows.Forms.ListBox();
            this.clb_FileInfo = new System.Windows.Forms.CheckedListBox();
            this.btn_remove = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.statstrip_main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tb_serverlimit = new System.Windows.Forms.TextBox();
            this.lbl_limitsearch = new System.Windows.Forms.Label();
            this.btn_limitsearch = new System.Windows.Forms.Button();
            this.rb_loc1 = new System.Windows.Forms.RadioButton();
            this.rb_loc2 = new System.Windows.Forms.RadioButton();
            this.gb_location = new System.Windows.Forms.GroupBox();
            this.lbl_user = new System.Windows.Forms.Label();
            this.tb_user = new System.Windows.Forms.TextBox();
            this.btn_user = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.lbl_student = new System.Windows.Forms.Label();
            this.gb_selection = new System.Windows.Forms.GroupBox();
            this.rb_selectall = new System.Windows.Forms.RadioButton();
            this.rb_selectnone = new System.Windows.Forms.RadioButton();
            this.cb_disabledAccounts = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.statstrip_main.SuspendLayout();
            this.gb_location.SuspendLayout();
            this.gb_selection.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutServerCleanupToolStripMenuItem1});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutServerCleanupToolStripMenuItem1
            // 
            this.aboutServerCleanupToolStripMenuItem1.Name = "aboutServerCleanupToolStripMenuItem1";
            this.aboutServerCleanupToolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            this.aboutServerCleanupToolStripMenuItem1.Text = "About Server Cleanup";
            this.aboutServerCleanupToolStripMenuItem1.Click += new System.EventHandler(this.aboutServerCleanupToolStripMenuItem1_Click);
            // 
            // aboutServerCleanupToolStripMenuItem
            // 
            this.aboutServerCleanupToolStripMenuItem.Name = "aboutServerCleanupToolStripMenuItem";
            this.aboutServerCleanupToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.aboutServerCleanupToolStripMenuItem.Text = "About Server Cleanup";
            // 
            // lb_FileSystemOptions
            // 
            this.lb_FileSystemOptions.FormattingEnabled = true;
            this.lb_FileSystemOptions.Location = new System.Drawing.Point(13, 175);
            this.lb_FileSystemOptions.Name = "lb_FileSystemOptions";
            this.lb_FileSystemOptions.Size = new System.Drawing.Size(219, 290);
            this.lb_FileSystemOptions.TabIndex = 1;
            this.lb_FileSystemOptions.SelectedIndexChanged += new System.EventHandler(this.FileSystemOptions_SelectedIndexChanged);
            // 
            // clb_FileInfo
            // 
            this.clb_FileInfo.FormattingEnabled = true;
            this.clb_FileInfo.Location = new System.Drawing.Point(272, 176);
            this.clb_FileInfo.Name = "clb_FileInfo";
            this.clb_FileInfo.Size = new System.Drawing.Size(221, 289);
            this.clb_FileInfo.TabIndex = 3;
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(272, 470);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(75, 23);
            this.btn_remove.TabIndex = 4;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(11, 469);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // statstrip_main
            // 
            this.statstrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statstrip_main.Location = new System.Drawing.Point(0, 504);
            this.statstrip_main.Name = "statstrip_main";
            this.statstrip_main.Size = new System.Drawing.Size(639, 22);
            this.statstrip_main.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tb_serverlimit
            // 
            this.tb_serverlimit.Location = new System.Drawing.Point(13, 149);
            this.tb_serverlimit.Name = "tb_serverlimit";
            this.tb_serverlimit.Size = new System.Drawing.Size(150, 20);
            this.tb_serverlimit.TabIndex = 6;
            this.tb_serverlimit.TextChanged += new System.EventHandler(this.tb_serverlimit_TextChanged);
            // 
            // lbl_limitsearch
            // 
            this.lbl_limitsearch.AutoSize = true;
            this.lbl_limitsearch.Location = new System.Drawing.Point(13, 130);
            this.lbl_limitsearch.Name = "lbl_limitsearch";
            this.lbl_limitsearch.Size = new System.Drawing.Size(100, 13);
            this.lbl_limitsearch.TabIndex = 7;
            this.lbl_limitsearch.Text = "Limit Server Results";
            // 
            // btn_limitsearch
            // 
            this.btn_limitsearch.Location = new System.Drawing.Point(170, 149);
            this.btn_limitsearch.Name = "btn_limitsearch";
            this.btn_limitsearch.Size = new System.Drawing.Size(62, 20);
            this.btn_limitsearch.TabIndex = 8;
            this.btn_limitsearch.Text = "Search";
            this.btn_limitsearch.UseVisualStyleBackColor = true;
            this.btn_limitsearch.Click += new System.EventHandler(this.btn_limitsearch_Click);
            // 
            // rb_loc1
            // 
            this.rb_loc1.AutoSize = true;
            this.rb_loc1.Location = new System.Drawing.Point(6, 19);
            this.rb_loc1.Name = "rb_loc1";
            this.rb_loc1.Size = new System.Drawing.Size(72, 17);
            this.rb_loc1.TabIndex = 9;
            this.rb_loc1.Tag = "loc1";
            this.rb_loc1.Text = "Location1";
            this.rb_loc1.UseVisualStyleBackColor = true;
            // 
            // rb_loc2
            // 
            this.rb_loc2.AutoSize = true;
            this.rb_loc2.Location = new System.Drawing.Point(6, 43);
            this.rb_loc2.Name = "rb_loc2";
            this.rb_loc2.Size = new System.Drawing.Size(72, 17);
            this.rb_loc2.TabIndex = 10;
            this.rb_loc2.Tag = "loc2";
            this.rb_loc2.Text = "Location2";
            this.rb_loc2.UseVisualStyleBackColor = true;
            // 
            // gb_location
            // 
            this.gb_location.Controls.Add(this.rb_loc1);
            this.gb_location.Controls.Add(this.rb_loc2);
            this.gb_location.Location = new System.Drawing.Point(16, 31);
            this.gb_location.Name = "gb_location";
            this.gb_location.Size = new System.Drawing.Size(151, 85);
            this.gb_location.TabIndex = 11;
            this.gb_location.TabStop = false;
            this.gb_location.Text = "Server Location";
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(269, 130);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(91, 13);
            this.lbl_user.TabIndex = 12;
            this.lbl_user.Text = "Limit User Results";
            // 
            // tb_user
            // 
            this.tb_user.Location = new System.Drawing.Point(272, 149);
            this.tb_user.Name = "tb_user";
            this.tb_user.Size = new System.Drawing.Size(150, 20);
            this.tb_user.TabIndex = 13;
            this.tb_user.TextChanged += new System.EventHandler(this.tb_user_TextChanged);
            // 
            // btn_user
            // 
            this.btn_user.Location = new System.Drawing.Point(431, 149);
            this.btn_user.Name = "btn_user";
            this.btn_user.Size = new System.Drawing.Size(62, 20);
            this.btn_user.TabIndex = 14;
            this.btn_user.Text = "Search";
            this.btn_user.UseVisualStyleBackColor = true;
            this.btn_user.Click += new System.EventHandler(this.btn_user_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(227, 49);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(154, 64);
            this.checkedListBox1.TabIndex = 0;
            // 
            // lbl_student
            // 
            this.lbl_student.AutoSize = true;
            this.lbl_student.Location = new System.Drawing.Point(224, 33);
            this.lbl_student.Name = "lbl_student";
            this.lbl_student.Size = new System.Drawing.Size(69, 13);
            this.lbl_student.TabIndex = 15;
            this.lbl_student.Text = "Student Year";
            // 
            // gb_selection
            // 
            this.gb_selection.Controls.Add(this.rb_selectall);
            this.gb_selection.Controls.Add(this.rb_selectnone);
            this.gb_selection.Location = new System.Drawing.Point(501, 146);
            this.gb_selection.Name = "gb_selection";
            this.gb_selection.Size = new System.Drawing.Size(97, 69);
            this.gb_selection.TabIndex = 16;
            this.gb_selection.TabStop = false;
            this.gb_selection.Text = "Profile Selection";
            // 
            // rb_selectall
            // 
            this.rb_selectall.AutoSize = true;
            this.rb_selectall.Location = new System.Drawing.Point(6, 19);
            this.rb_selectall.Name = "rb_selectall";
            this.rb_selectall.Size = new System.Drawing.Size(69, 17);
            this.rb_selectall.TabIndex = 9;
            this.rb_selectall.Tag = "loc1";
            this.rb_selectall.Text = "Select All";
            this.rb_selectall.UseVisualStyleBackColor = true;
            // 
            // rb_selectnone
            // 
            this.rb_selectnone.AutoSize = true;
            this.rb_selectnone.Location = new System.Drawing.Point(6, 42);
            this.rb_selectnone.Name = "rb_selectnone";
            this.rb_selectnone.Size = new System.Drawing.Size(84, 17);
            this.rb_selectnone.TabIndex = 10;
            this.rb_selectnone.Tag = "loc2";
            this.rb_selectnone.Text = "Select None";
            this.rb_selectnone.UseVisualStyleBackColor = true;
            // 
            // cb_disabledAccounts
            // 
            this.cb_disabledAccounts.AutoSize = true;
            this.cb_disabledAccounts.Location = new System.Drawing.Point(501, 227);
            this.cb_disabledAccounts.Name = "cb_disabledAccounts";
            this.cb_disabledAccounts.Size = new System.Drawing.Size(115, 17);
            this.cb_disabledAccounts.TabIndex = 18;
            this.cb_disabledAccounts.Text = "Disabled Accounts";
            this.cb_disabledAccounts.UseVisualStyleBackColor = true;
            this.cb_disabledAccounts.CheckedChanged += new System.EventHandler(this.cb_disabledAccounts_CheckedChanged);
            // 
            // ServerUserCleanup
            // 
            this.AcceptButton = this.btn_limitsearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(639, 526);
            this.Controls.Add(this.cb_disabledAccounts);
            this.Controls.Add(this.gb_selection);
            this.Controls.Add(this.lbl_student);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btn_user);
            this.Controls.Add(this.tb_user);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.gb_location);
            this.Controls.Add(this.btn_limitsearch);
            this.Controls.Add(this.lbl_limitsearch);
            this.Controls.Add(this.tb_serverlimit);
            this.Controls.Add(this.statstrip_main);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.clb_FileInfo);
            this.Controls.Add(this.lb_FileSystemOptions);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ServerUserCleanup";
            this.Text = "Server User Profile Cleanup";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statstrip_main.ResumeLayout(false);
            this.statstrip_main.PerformLayout();
            this.gb_location.ResumeLayout(false);
            this.gb_location.PerformLayout();
            this.gb_selection.ResumeLayout(false);
            this.gb_selection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutServerCleanupToolStripMenuItem;
        private System.Windows.Forms.ListBox lb_FileSystemOptions;
        private System.Windows.Forms.CheckedListBox clb_FileInfo;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.StatusStrip statstrip_main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutServerCleanupToolStripMenuItem1;
        private System.Windows.Forms.TextBox tb_serverlimit;
        private System.Windows.Forms.Label lbl_limitsearch;
        private System.Windows.Forms.Button btn_limitsearch;
        private System.Windows.Forms.RadioButton rb_loc1;
        private System.Windows.Forms.RadioButton rb_loc2;
        private System.Windows.Forms.GroupBox gb_location;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.TextBox tb_user;
        private System.Windows.Forms.Button btn_user;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label lbl_student;
        private System.Windows.Forms.GroupBox gb_selection;
        private System.Windows.Forms.RadioButton rb_selectall;
        private System.Windows.Forms.RadioButton rb_selectnone;
        private System.Windows.Forms.CheckBox cb_disabledAccounts;
    }
}

