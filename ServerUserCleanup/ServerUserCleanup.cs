using System;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace ServerUserCleanup
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ServerUserCleanup : Form
    {
        //public event UserSelectEvent evt;
        private string serverloc;
        private string serverLDAPloc;
        private string studentLDAPloc;
        private string userLDAPloc;
        //yearByStudentSL (key,value)
        //2016,sortedlist of 2016 students
        //2017,sortedlist of 2016 students ...
        private SortedList yearByStudentSL;
        //adDisabledAccountsHT (key,value)
        //samaccountname,samaccountname   --> these are unique in Active Directory
        //agotlieb,gotlieb
        private Hashtable adDisabledAccountsHT;
        /// <summary>
        /// Constructor for class
        /// </summary>
        public ServerUserCleanup()
        {
            InitializeComponent();
            UpdateStatusStrip("");
            //execute the method ProcessServerSelection code for this grouping of radio buttons
            rb_loc1.CheckedChanged += new EventHandler(this.ProcessServerSelection);
            rb_loc2.CheckedChanged += new EventHandler(this.ProcessServerSelection); 
            //force event so values are set
            this.rb_loc1.Checked = true;
            //execute the method ProcessUserSelection code for this grouping of radio buttons
            rb_selectall.CheckedChanged += new EventHandler(this.ProcessUserSelection);
            rb_selectnone.CheckedChanged += new EventHandler(this.ProcessUserSelection);
            //force event so values are set
            this.rb_selectnone.Checked = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize window.
            this.MaximizeBox = false;
            // Set the MinimizeBox to true to allow minimize window.
            this.MinimizeBox = true;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void aboutServerCleanupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            const string message =
                "A list of servers is retrieved from Active Directory and displayed in the dialog box. " +
                "Choose a server and it will display all users profiles in a listbox. Choose one or " +
                "more profiles to remove from the server. Further restrict the profiles by student class year. " +
                "For loc1 servers Active Directory is searched at " +
                "OU=SERVERS,OU=loc1,DC=yourdomain,DC=com . For loc1 servers Active Directory is searched at " +
                "LDAP://OU=SERVERS,OU=loc2,DC=yourdomain,DC=com. These parameters are included in the settings properties " +
                "for the project.";
            const string caption = "About Server Cleanup";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information);
        }

        private void FileSystemOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatusStrip("Searching for User profiles...");
            ReloadCheckedListBox();
        }

        // remove the checked entries
        private void btn_remove_Click(object sender, EventArgs e)
        {
            UpdateStatusStrip("Removing Selected user profile");
            RemoveSelectedEntries();
            UpdateStatusStrip("Reloading User profile...");
            ReloadCheckedListBox();
        }

        private void btn_limitsearch_Click(object sender, EventArgs e)
        {
            string servermask = tb_serverlimit.Text.ToString();
            CreateServerList(servermask);
            //if nothing selected when starting program --default to listbox entry 1
            if (this.lb_FileSystemOptions.SelectedItem == null && this.lb_FileSystemOptions.Items.Count !=0)
            {
                this.lb_FileSystemOptions.SetSelected(0, true);
            }
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            string curItem = lb_FileSystemOptions.SelectedItem.ToString();
            LoadCheckedListBox(curItem, tb_user.Text.ToString());
        }

        private void tb_user_TextChanged(object sender, EventArgs e)
        {
            //set the default enter button
            this.AcceptButton = this.btn_user;
        }

        private void tb_serverlimit_TextChanged(object sender, EventArgs e)
        {
            //set the default enter button
            this.AcceptButton = this.btn_limitsearch;
        }

        private void cb_disabledAccounts_CheckedChanged(object sender, EventArgs e)
        {
            ReloadCheckedListBox();
        }


        /// <summary>
        /// Method to display list of servers based on radion button selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessServerSelection(object sender, EventArgs e)
        {
            if (rb_loc1.Checked)
            {
                //TAG value is pointer into the Setting.Properties which will return LDAP location to search
                //It would be nice to iterate through the radio buttons in the group and pull the settings dynamically
                this.serverloc = rb_loc1.Tag.ToString();
                this.serverLDAPloc = Properties.Settings.Default.loc1_servers;
                this.userLDAPloc = Properties.Settings.Default.loc1_disabled;
                this.studentLDAPloc = Properties.Settings.Default.loc1_student;
            }
            else if (rb_loc2.Checked)
            {
                //this.serverloc = rb_loc1.Tag.ToString();
                this.serverloc = rb_loc2.Tag.ToString();
                this.serverLDAPloc = Properties.Settings.Default.loc2_servers;
                this.userLDAPloc = Properties.Settings.Default.loc2_disabled;
                this.studentLDAPloc = Properties.Settings.Default.loc2_student;
            }
            //get sortedlist of dental students by year (key=year, value=sortedlist of students)
            yearByStudentSL = CreateStudentYearList();
            //get sortedlist of disabled accounts in AD based on radio button selection - loc1 or loc2
            adDisabledAccountsHT = CreateADDisabledAccountHashTable();
            string servermask = tb_serverlimit.Text.ToString();
            //build checklistbox list of dental student classes to search
            DisplayStudentClassCheckedListBox(yearByStudentSL);
            //fire event to execute search when button changes
            this.btn_limitsearch_Click(null, EventArgs.Empty);
        }

        /// <summary>
        ///  Method to check or uncheck all users displayed in the checkedlistbox control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ProcessUserSelection(object sender, EventArgs e)
        {
    
            if (rb_selectall.Checked)
            {
                //check all user checkboxes
                SelectDeselectAll(true, this.clb_FileInfo);
            }
            else if (rb_selectnone.Checked)
            {
                //uncheck all user checkboxes
                SelectDeselectAll(false, this.clb_FileInfo);
            }   
        }
     
        /// <summary>
        /// Method to check or uncheck all checklistbox (users)
        /// </summary>
        /// <param name="Selected"></param>
        /// <param name="checkedListBox"></param>
        private void SelectDeselectAll(bool Selected, System.Windows.Forms.CheckedListBox checkedListBox)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++) // loop to set all items checked or unchecked
            {
                checkedListBox.SetItemChecked(i, Selected);
            }
        }

        ///<summary>
        ///Uses the HelperClass to determine Active Directory server names.
        ///</summary>
        ///<returns>void</returns>
        ///<remarks>Builds dialog box of servers</remarks>
        private void CreateServerList(string servermask)
        {
            this.lb_FileSystemOptions.Items.Clear();
            clb_FileInfo.Items.Clear();
            SortedList sl = new SortedList();
            try
            {
                ActiveDirectoryListHelper hp = new ActiveDirectoryListHelper(this.serverLDAPloc);
                sl = hp.GetServerList(servermask);
            }
            catch (Exception e)
            {
                UpdateStatusStrip("Error retrieving server list");
                string mess = string.Format("{0} Exception caught", e);
                MessageBox.Show(mess, "Error in Profile Delete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            for (int i = 0; i < sl.Count; i++)
            {
                lb_FileSystemOptions.Items.Add(sl.GetKey(i));
            }
            UpdateStatusStrip(sl.Count + " Servers found");
        }

        private SortedList CreateStudentYearList()
        {
            SortedList sl = new SortedList();
            try
            {
                //constructor for student year 
                ActiveDirectoryListHelper hp = new ActiveDirectoryListHelper(this.studentLDAPloc);
                //sorted list (year,array of students)
                sl = hp.GetStudentByYearList();
            }
            catch (Exception e)
            {
                UpdateStatusStrip("Error retrieving AD list");
                string mess = string.Format("{0} Exception caught", e);
                MessageBox.Show(mess, "Error in Profile Delete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return (sl);
        }

        /// <summary>
        /// HashTable of disabled account in AD
        /// </summary>
        /// <returns></returns>
        private Hashtable CreateADDisabledAccountHashTable()
        {
            Hashtable ht = new Hashtable();
            try
            {
                //constructor for student year 
                ActiveDirectoryListHelper hp = new ActiveDirectoryListHelper(this.userLDAPloc);
                //sorted list (year,array of students)
                ht = hp.GetDisabledAccountsFLA();
            }
            catch (Exception e)
            {
                UpdateStatusStrip("Error retrieving AD list");
                string mess = string.Format("{0} Exception caught", e);
                MessageBox.Show(mess, "Error in Profile Delete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return (ht);
        }

        private void UpdateStatusStrip(string message)
        {
            toolStripStatusLabel1.Text = message;
            this.Refresh();
        }

        ///<summary>
        ///Clear the CheckedListbox and reload the entries - after a delete update the CheckedList box.
        ///</summary>
        ///<returns>void</returns>
        private void ReloadCheckedListBox()
        {
            string curItem = lb_FileSystemOptions.SelectedItem.ToString();
            LoadCheckedListBox(curItem, tb_user.Text.ToString());
            //uncheck all users from reloaded checkedlistbox - will file the ProcessUserSelectionMethod
            this.rb_selectnone.Checked = true;
        }

        ///<summary>
        ///Remove selected user files from server.
        ///</summary>
        ///<returns>void</returns>
        private void RemoveSelectedEntries()
        {
            for (int i = 0; i < clb_FileInfo.Items.Count; i++)
            {
                if (clb_FileInfo.GetItemChecked(i))
                {
                    //pass SID from object
                    WmiPropertiesHelper wh = new WmiPropertiesHelper();
                    wh = (WmiPropertiesHelper)clb_FileInfo.Items[i];
                    try
                    {
                        wh.DeleteUser(lb_FileSystemOptions.SelectedItem.ToString(), wh.SID);
                        UpdateStatusStrip("Reloading User profile list...");
                    }
                    catch (Exception e)
                    {
                        UpdateStatusStrip("Error removing profile " + wh.LocalPath + " from server " + lb_FileSystemOptions.SelectedItem.ToString());
                        string mess = string.Format("{0} Exception caught.", e);
                        MessageBox.Show(mess, "Error in Profile Delete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        
        ///<summary>
        ///Find all users profiles on chosen server.
        ///</summary>
        ///<param name="servername">string</param>
        ///<param name="usermask">string</param>
        ///<returns>void</returns>
        private void LoadCheckedListBox(string servername, string usermask)
        {
            int i = 0;
            //is this a student by year search
            Boolean exist = CheckIfStudentByYearExists();
            Boolean existDisabled = CheckIfDisabledAccounts();
            //remove anything already loaded in CheckedListbox
            clb_FileInfo.Items.Clear();
            WmiPropertiesHelper wp = new WmiPropertiesHelper();
            try
            {
                SortedList sl = new SortedList();
                //hashttable for student lists comparison
                Hashtable ht = new Hashtable();
                //returns all users for the server specified - used for 
                sl = wp.GetUserList(servername, usermask);
                //student checklist box
                if (exist)
                {
                    //yearByStudentSL (key,value)
                    //2016,sortedlist of 2016 students
                    //2017,sortedlist of 2016 students ...
                    ht = GetStudentUserListByYear(yearByStudentSL,this.checkedListBox1);
                }
                ICollection values = sl.GetValueList();
                //narrow list to specific students
                foreach (WmiPropertiesHelper wh in values)
                {
                    if (this.tb_user.Text.ToString() != "")
                    {
                        Regex r = new Regex(usermask.ToLower());
                        if (r.IsMatch(wh.ToString().ToLower()))
                        {
                            //student year checkbox 
                            if (exist)
                            {
                                //check the hashtable for match
                                if (ht.Contains(wh.ToString().ToUpper()))
                                {
                                    //if disabled accounts checked then see if the user account is in the adDisabledAccountsHT
                                    if (CheckDisabledAccountHashTable(existDisabled, wh.ToString().ToUpper()))
                                    {
                                        clb_FileInfo.Items.Add(wh);
                                        i++;
                                    }
                                }
                            }
                            else
                            {
                                //if disabled accounts checked then see if the user account is in the adDisabledAccountsHT
                                if (CheckDisabledAccountHashTable(existDisabled, wh.ToString().ToUpper()))
                                {
                                    clb_FileInfo.Items.Add(wh);
                                    i++;
                                }
                            }
                        }
                    }
                    else
                    {
                        //student checklist box
                        if (exist)
                        {
                            if (ht.Contains(wh.ToString().ToUpper()))
                            {
                                //if disabled accounts checked then see if the user account is in the adDisabledAccountsHT
                                if (CheckDisabledAccountHashTable(existDisabled, wh.ToString().ToUpper()))
                                {
                                    clb_FileInfo.Items.Add(wh);
                                    i++;
                                }
                            }
                        }
                        else
                        {
                           //if disabled accounts checked then see if the user account is in the adDisabledAccountsHT
                                if (CheckDisabledAccountHashTable(existDisabled, wh.ToString().ToUpper()))
                                {
                                    clb_FileInfo.Items.Add(wh);
                                    i++;
                                }
                        }
                    }
                }
                if (i > 0)
                {
                    UpdateStatusStrip(i + " User profiles found");
                }
                else
                {
                    UpdateStatusStrip("No user profiles found");
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                string mess = "";
                switch ((uint)ex.ErrorCode)
                {
                    case 0x80070005:
                        mess = string.Format("{0} Unauthorized System Exceptionn caught.", ex);
                        break;
                    case 0x800706BA:
                        mess = string.Format("{0} Unauthorized System Exceptionn caught.", ex);
                        break;
                    default:
                        MessageBox.Show("Error opening worksheet: " + ex.Message);
                        break;
                }
                UpdateStatusStrip("Error connecting to " + servername);
                MessageBox.Show(mess, "Server Connection Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //HRESULT cases not returned - will come back later to catch exception
            catch (Exception ex)
            {
                string mess = "";
                switch ((uint)ex.HResult)
                {
                    default:
                        mess = string.Format("{0} Exception caught.", ex);
                        break;
                }
                UpdateStatusStrip("Error connecting to " + servername);
                MessageBox.Show(mess, "Server Connection Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Returned whether the samaccount is from user
        /// </summary>
        /// <param name="exists"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Boolean CheckDisabledAccountHashTable(Boolean exists, string value)
        {
            //Disabled accounts checkbox not checked
            if (!exists)
            {
                return true;
            }
            //this is the hash table of disabled accounts created in initialization
            if (adDisabledAccountsHT.Contains(value))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Boolean of any year value is checked</returns>
        private Boolean CheckIfStudentByYearExists()
        {
            //need to see if they have checked any Student Year" checkboxlist elements
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>Boolean of any year value is checked</returns>
        private Boolean CheckIfDisabledAccounts()
        {
            //need to see if they have checked any Student Year" checkboxlist elements
            if (cb_disabledAccounts.Checked)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Uses the yearByStudentSL sorted list of years with array of all students within that year. Will display all the Year keys as items in the CheckedListBox
        /// </summary>
        /// <param name="slIn"></param>
        private void DisplayStudentClassCheckedListBox(SortedList slIn)
        {
            //clear the existing values
            this.checkedListBox1.Items.Clear();
            //IList values = slIn.GetValueList();
            ICollection keys = slIn.GetKeyList();
            foreach (string s in keys)
            {
                this.checkedListBox1.Items.Add(s);
            }
        }

        /// <summary>
        /// GetStudentUserListByYear take StudentByYear sorted list created in the main program and the student years checkedlistbox and creates a hashtable
        /// that will be used to look up the user list to display in the combolistbox display. 
        /// This does not use wmi service, but is the logical place add this method. 
        /// </summary>
        /// <param name="slIn"></param>
        /// <param name="checkListBox"></param>
        /// <returns>sortlist</returns>
        public Hashtable GetStudentUserListByYear(SortedList slIn, CheckedListBox checkListBox)
        {
            Hashtable ht = new Hashtable();
            try
            {
                foreach (object itemChecked in checkListBox.CheckedItems)
                {
                    ICollection keys = slIn.GetKeyList();
                    foreach (string s in keys)
                    {
                        if (s == itemChecked.ToString())
                        {
                            //this is the sortedlist of students for a given year
                            IList values = ((SortedList)slIn[s]).GetValueList();
                            //create the hashtable entries available students - this will be used to lookup and match students by year
                            foreach (string name in values)
                            {
                                ht.Add(name.ToUpper(), name.ToUpper());
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //re-throw exception for main calling
                throw new Exception("WMIPropertiesHelper", e);
            }
            return (ht);
        }
    }
    //end of class definition
}
