using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using System.DirectoryServices;

namespace ServerUserCleanup
{
    class ActiveDirectoryListHelper
    {

        //private string serverLDAPloc;
        private string adStartLocation;
        //constructor for class with where to start in AD tree. This value will be retrieved in the main program from settings.
        public ActiveDirectoryListHelper(string adStartLocation)
        {
            this.adStartLocation = adStartLocation;
        }

        ///<summary>
        ///Uses DirectoryServices to connect to Active Direcotry and return a list of servers that will be searched
        ///for a list of user profiles on the server
        ///</summary>
        ///<returns>SortedList</returns>
        ///<remarks>Returns sortledlist of server that will be displayed in a dialog box</remarks>
        public SortedList GetServerList(string servermask)
        {
            SortedList sl = new SortedList();
            try
            {
                DirectoryEntry searchRoot = new DirectoryEntry(this.adStartLocation);
                DirectorySearcher searcher = new DirectorySearcher(searchRoot);
                searcher.Filter = "(&(objectClass=computer" + "))";
                searcher.PropertiesToLoad.Clear();
                searcher.PropertiesToLoad.AddRange(new string[] { 
                "objectGUID",
                "cn",
                "objectCategory"});
                searcher.Sort = new SortOption("cn", SortDirection.Ascending);
                searcher.PageSize = 1000;
                searcher.SizeLimit = 0;
                foreach (SearchResult result in searcher.FindAll())
                {
                    string serverValue = (string)result.Properties["cn"][0];
                    if (servermask.Length > 0)
                    {
                        if (serverValue.ToUpper().IndexOf(servermask.ToUpper()) != -1)
                        {
                            int i = serverValue.IndexOf(servermask.ToUpper());
                            sl.Add(serverValue, serverValue);
                        }
                    }
                    else
                    {
                        sl.Add(serverValue, serverValue);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("ActiveDirectoryListHelper - server list", e);
            }
            return (sl);
        }

        /// <summary>
        ///Uses DirectoryServices to connect to Active Directory and return a list of years and samaccountnames sorted list of students 
        /// </summary>
        /// <returns>sorted list (sortedlist with key=year and value=sortedlist of students)</returns>
        public SortedList GetStudentByYearList()
        {
            SortedList sl = new SortedList();
            try
            {
                DirectoryEntry searchRoot = new DirectoryEntry(this.adStartLocation);
                DirectorySearcher subOUsearcher = new DirectorySearcher(searchRoot);
                subOUsearcher.SearchScope = SearchScope.OneLevel; // don't recurse down
                subOUsearcher.Filter = "(objectClass=organizationalUnit)";

                foreach (SearchResult result in subOUsearcher.FindAll())
                {
                    SortedList slStudent = new SortedList();
                    string studentYearValue = (string)result.Properties["ou"][0];
                    StringBuilder sbReplaceLDAP= new StringBuilder(this.adStartLocation);
                    sbReplaceLDAP.Replace("LDAP://", "LDAP://OU=" + studentYearValue + ",");
                    //LDAP://OU=DENTAL,OU=STUDENTS,OU=FLORIDA,DC=lecomintra,DC=net
                    try
                     {
                        DirectoryEntry searchRootUser = new DirectoryEntry(sbReplaceLDAP.ToString());
                        DirectorySearcher searcher = new DirectorySearcher(searchRootUser);
                        searcher.Filter = "(&(objectClass=user" + "))";
                        searcher.PropertiesToLoad.Clear();
                        searcher.Sort = new SortOption("cn", SortDirection.Ascending);
                        searcher.PageSize = 1000;
                        searcher.SizeLimit = 0;
                        foreach (SearchResult user in searcher.FindAll())
                        {
                            string studentValue = (string)user.Properties["samaccountname"][0];
                            //will keep the students in alpha order
                            slStudent.Add(studentValue, studentValue);
                        }
                        // stick those Sub OU's into a list and then handle them
                        //2016,sorted list of 2016 students
                        //2017,sorted list of 2017 students
                        sl.Add(studentYearValue, slStudent);
                    }
                    catch (Exception e)
                    {
                        //throw new Exception("ActiveDirectoryListHelper - student list", e);
                    } 
                }
            }
            catch (Exception e)
            {
                throw new Exception("ActiveDirectoryListHelper - student year list", e);
            }
            return (sl);
        }

        /// <summary>
        /// Return a hast table of all disabled AD samaccountname
        /// </summary>
        /// <returns></returns>
        public Hashtable GetDisabledAccountsFLA()
        {
            Hashtable ht = new Hashtable();
            Boolean isActive;
            try
            {
                DirectoryEntry directoryRoot = new DirectoryEntry(this.adStartLocation);
                DirectorySearcher searcher = new DirectorySearcher(directoryRoot,
                    "(&(objectClass=User)(objectCategory=Person))");
                SearchResultCollection results = searcher.FindAll();
                foreach (SearchResult result in results)
                {
                    DirectoryEntry de = result.GetDirectoryEntry();
                    isActive = IsActive(de);
                    if (!isActive)
                    {
                        string accountValue = (string)result.Properties["samaccountname"][0];
                        //will keep the accounts in alpha order
                        ht.Add(accountValue.ToUpper(), accountValue.ToUpper());
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("ActiveDirectoryAttributes - disabled accounts", e);
            }
            return (ht);
        }

        /// <summary>
        /// Is the account disabled
        /// </summary>
        /// <param name="de"></param>
        /// <returns></returns>
        private bool IsActive(DirectoryEntry de)
        {
            if (de.NativeGuid == null) return false;
            int flags = (int)de.Properties["userAccountControl"].Value;
            return !Convert.ToBoolean(flags & 0x0002);
        }
    }
}
