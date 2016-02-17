This project is built using Visual Studio 2015 Express in C#.

CHANGE CONTROL
20151117 - added the ability to restrict search by student year (i.e. 2016/2017...). This requires the settings.settings
parameter loc1_student/loc2_student

20151217 - add radio buttons to select all/none from checked list box.

20160117 - added ability to search/restrict to disabled accounts in AD

The ServerUserCleanup.exe connects to Active Directory and searches for computers grouped in the 
"Servers" Organizational Unit (OU). Depending on the radio button chosen ("Location1", "Location2"), it will search
AD in the corresponding settings locations for Servers (loc1_servers, loc2_servers) 
These setting are configured and compiled into the executable. 

Note: To implement for your own AD configuration, you need to open the solution file and navigate to the settings.settings 
screen to change these values and rebuild the project executables.  

Currently the settings are configured to search the following locations: 
   loc1_server - LDAP://OU=SERVERS,OU=loc1,DC=yourdomain,DC=com
   loc2_server - LDAP://OU=SERVERS,OU=loc2,DC=yourdomain,DC=com
   loc1_student - LDAP://OU=STUDENTS,OU=loc1,DC=yourdomain,DC=com
   loc2_student - LDAP://OU=STUDENTS,OU=loc2,DC=yourdomain,DC=com
   loc1_disabled - LDAP://OU=DISABLED,OU=loc1,DC=yourdomain,DC=com
   loc2_disabled - LDAP://OU=DISBALED,OU=loc2,DC=yourdomain,DC=com

