using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.DirectoryServices;
using System.ComponentModel;

namespace NetworkBrowser
{
    public class NetViewer : INotifyPropertyChanged 
    {
        private string _localDomainName;
        public String LocalDomainName 
        {
            get
            { 
                 return _localDomainName; 
            }

            set
            {
                _localDomainName = value;
               // Notify();
            }
        }

        private string _localComputerName;
        public String LocalComputerName { get; set; }

        private List<string> _listOfComputerNames;
        public List<string> ListOfComputerNames { get; set; }

        private int _countOfComputers;
        public int CountOfComputers { get; set; }

        public NetViewer()
        {//ctor
            GetLocalComputerInfo();
            PopComputerNames(LocalDomainName);
        }
        

        public bool GetLocalComputerInfo()
        { 
            ManagementObjectSearcher query;
            ManagementObjectCollection queryCollection;

            String query_command = "SELECT * FROM Win32_ComputerSystem";
            ManagementScope msc = new ManagementScope("\\root\\cimv2");

            SelectQuery select_query = new SelectQuery(query_command);

            query = new ManagementObjectSearcher(msc, select_query);
            queryCollection = query.Get();
            
            foreach (ManagementObject management_object in queryCollection)
	        {                
                LocalDomainName =(string)management_object["Domain"] ;
                LocalComputerName = (string)management_object["Name"];
	        }

              return true;
        }//end method

          public void PopComputerNames(string domain)
          {
              DirectoryEntry domainEntry = new DirectoryEntry("WinNT://" + domain);
              domainEntry.Children.SchemaFilter.Add("computer");
              ListOfComputerNames = new List<String>();

              foreach (var item in domainEntry.Children)
              {
                  DirectoryEntry de = (DirectoryEntry)item;

                  ListOfComputerNames.Add(de.Name);                 
              }

              this.CountOfComputers = ListOfComputerNames.Count;
              
          }

        public event PropertyChangedEventHandler PropertyChanged;



    }//end class
}
