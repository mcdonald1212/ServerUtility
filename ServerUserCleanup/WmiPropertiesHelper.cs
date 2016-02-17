using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Management;
using System.Windows.Forms;

namespace ServerUserCleanup
{
    /// <summary>
    ///  Win32_UserProfile properties
    /// </summary>
    class WmiPropertiesHelper
    {
        string localpath;
        uint status;
        string sid;

        //this is the actual user returned from wmi call
        public string LocalPath
        {
            get { return localpath; }
            set
            {
                localpath = value;
            }
        }
        public uint Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }
        public string SID
        {
            get { return sid; }
            set
            {
                sid = value;
            }
        }

        public WmiPropertiesHelper()
        {
        }

        ///<summary> 
        ///Uses System.Management wmi services to retrieve a list of user profiles on the server
        ///</summary>
        ///<param name="server">string</param>
        ///<param name="usermask">string</param>
        ///<returns>SortedList</returns>
        ///<remarks>Returns sortledlist of users that will be displayed in a dialog box</remarks>
        public SortedList GetUserList(string server, string usermask)
        {
            SortedList sl = new SortedList();
            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + server + "\\root\\cimv2");
                scope.Connect();
                ObjectQuery query = new ObjectQuery(String.Format("SELECT * FROM Win32_UserProfile"));
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    string sid = (string)m.GetPropertyValue("SID");
                    string lp = (string)m.GetPropertyValue("LocalPath");
                    status = (uint)m.GetPropertyValue("Status");
                    if (lp.Contains("C:\\Users\\"))
                    {
                        WmiPropertiesHelper wp = new WmiPropertiesHelper();
                        wp.LocalPath = lp.Replace("C:\\Users\\","");
                        wp.SID = sid;
                        wp.Status = status;
                        sl.Add(lp, wp);
                    }
                }
            }
            catch (Exception e)
            {
                //re-throw exception for main calling
                throw new Exception("WMIPropertiesHelper", e);
            }
            return (sl);
        }

        ///<summary> 
        ///Uses System.Management wmi services to retrieve the user profile on the server and delete method of ManagementObject
        ///</summary>
        ///<param name="server">string</param>
        ///<param name="sid">string</param>
        ///<returns>SortedList</returns>
        ///<remarks>No data returned</remarks>
        public void DeleteUser(string server, string sid)
        {
            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + server + "\\root\\cimv2");
                scope.Connect();
                ObjectQuery query = new ObjectQuery(String.Format("SELECT * from win32_UserProfile WHERE SID LIKE '%{0}%'", sid));
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    string lp = (string)m.GetPropertyValue("LocalPath");
                    string mess = "Are you sure that you want to remove " + lp + " user profile from server " + server + "?";
                    const string caption = "Confirm Delete";
                    var result = MessageBox.Show(mess, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            m.Delete();
                        }
                        catch (Exception e)
                        {
                            //re-throw exception for main calling
                            throw new Exception("WMIPropertiesHelper", e);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //re-throw exception for main calling
                throw new Exception("WMIPropertiesHelper", e);
            }
        }

        //override method for display purposes and string comparison 
        public override string ToString()
        {
            return this.LocalPath;
        }

    }
}
